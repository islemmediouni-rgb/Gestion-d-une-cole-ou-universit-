using GestionEcole.Data;
using GestionEcole.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEcole.Services
{
    public class MatiereService
    {
        // ===== READ (avec l'enseignant responsable) =====
        public List<Matiere> Lister(string? recherche = null)
        {
            using var db = new EcoleDbContext();
            var requete = db.Matieres.Include(m => m.Enseignant).AsQueryable();
            if (!string.IsNullOrWhiteSpace(recherche))
            {
                var r = recherche.Trim().ToUpper();
                requete = requete.Where(m => m.Nom.ToUpper().Contains(r));
            }
            return requete.OrderBy(m => m.Nom).ToList();
        }

        // ===== CREATE =====
        public void Ajouter(Matiere matiere)
        {
            Valider(matiere);
            using var db = new EcoleDbContext();
            if (db.Matieres.Any(m => m.Nom == matiere.Nom))
                throw new ArgumentException($"La matière « {matiere.Nom} » existe déjà.");
            if (!db.Enseignants.Any(e => e.Id == matiere.EnseignantId))
                throw new ArgumentException("Enseignant introuvable.");

            db.Matieres.Add(matiere);
            db.SaveChanges();
        }

        // ===== UPDATE =====
        public void Modifier(Matiere matiere)
        {
            Valider(matiere);
            using var db = new EcoleDbContext();
            var existante = db.Matieres.Find(matiere.Id)
                ?? throw new ArgumentException("Matière introuvable.");
            if (db.Matieres.Any(m => m.Nom == matiere.Nom && m.Id != matiere.Id))
                throw new ArgumentException($"Le nom « {matiere.Nom} » est déjà utilisé par une autre matière.");
            if (!db.Enseignants.Any(e => e.Id == matiere.EnseignantId))
                throw new ArgumentException("Enseignant introuvable.");

            existante.Nom = matiere.Nom;
            existante.Coefficient = matiere.Coefficient;
            existante.EnseignantId = matiere.EnseignantId;
            db.SaveChanges();
        }

        // ===== DELETE =====
        public void Supprimer(int id)
        {
            using var db = new EcoleDbContext();
            var matiere = db.Matieres.Find(id)
                ?? throw new ArgumentException("Matière introuvable.");
            if (db.Seances.Any(s => s.MatiereId == id))
                throw new ArgumentException("Impossible de supprimer : des séances sont planifiées pour cette matière.");
            if (db.Notes.Any(n => n.MatiereId == id))
                throw new ArgumentException("Impossible de supprimer : des notes ont été saisies dans cette matière.");

            db.Matieres.Remove(matiere);
            db.SaveChanges();
        }

        private static void Valider(Matiere m)
        {
            m.Nom = (m.Nom ?? "").Trim();
            if (m.Nom.Length == 0) throw new ArgumentException("Le nom de la matière est obligatoire.");
            if (m.Coefficient <= 0) throw new ArgumentException("Le coefficient doit être supérieur à 0.");
            if (m.EnseignantId <= 0) throw new ArgumentException("Veuillez choisir l'enseignant responsable.");
        }
    }
}