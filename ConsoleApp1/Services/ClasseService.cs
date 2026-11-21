using GestionEcole.Data;
using GestionEcole.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEcole.Services
{
    public class ClasseService
    {
        // ===== READ (avec le nombre d'inscrits et de séances) =====
        public List<Classe> Lister(string? recherche = null)
        {
            using var db = new EcoleDbContext();
            var requete = db.Classes
                .Include(c => c.Inscriptions)
                .Include(c => c.Seances)
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(recherche))
            {
                var r = recherche.Trim().ToUpper();
                requete = requete.Where(c => c.Nom.ToUpper().Contains(r));
            }
            return requete.OrderBy(c => c.Nom).ToList();
        }

        // ===== CREATE =====
        public void Ajouter(Classe classe)
        {
            Valider(classe);
            using var db = new EcoleDbContext();
            if (db.Classes.Any(c => c.Nom == classe.Nom))
                throw new ArgumentException($"La classe « {classe.Nom} » existe déjà.");

            db.Classes.Add(classe);
            db.SaveChanges();
        }

        // ===== UPDATE =====
        public void Modifier(Classe classe)
        {
            Valider(classe);
            using var db = new EcoleDbContext();
            var existante = db.Classes.Find(classe.Id)
                ?? throw new ArgumentException("Classe introuvable.");
            if (db.Classes.Any(c => c.Nom == classe.Nom && c.Id != classe.Id))
                throw new ArgumentException($"Le nom « {classe.Nom} » est déjà utilisé par une autre classe.");

            existante.Nom = classe.Nom;
            db.SaveChanges();
        }

        // ===== DELETE =====
        public void Supprimer(int id)
        {
            using var db = new EcoleDbContext();
            var classe = db.Classes.Find(id)
                ?? throw new ArgumentException("Classe introuvable.");
            if (db.Inscriptions.Any(i => i.ClasseId == id))
                throw new ArgumentException("Impossible de supprimer : des étudiants sont inscrits dans cette classe.");
            if (db.Seances.Any(s => s.ClasseId == id))
                throw new ArgumentException("Impossible de supprimer : des séances sont planifiées pour cette classe.");

            db.Classes.Remove(classe);
            db.SaveChanges();
        }

        private static void Valider(Classe classe)
        {
            classe.Nom = (classe.Nom ?? "").Trim().ToUpper();
            if (classe.Nom.Length == 0)
                throw new ArgumentException("Le nom de la classe est obligatoire.");
        }
    }
}