using GestionEcole.Data;
using GestionEcole.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEcole.Services
{
    public class EnseignantService
    {
        // ===== READ (avec les matières enseignées) =====
        public List<Enseignant> Lister(string? recherche = null)
        {
            using var db = new EcoleDbContext();
            var requete = db.Enseignants.Include(e => e.Matieres).AsQueryable();
            if (!string.IsNullOrWhiteSpace(recherche))
            {
                var r = recherche.Trim().ToUpper();
                requete = requete.Where(e => e.Nom.ToUpper().Contains(r)
                                          || e.Prenom.ToUpper().Contains(r)
                                          || e.Specialite.ToUpper().Contains(r));
            }
            return requete.OrderBy(e => e.Nom).ThenBy(e => e.Prenom).ToList();
        }

        // ===== CREATE =====
        public void Ajouter(Enseignant enseignant)
        {
            Valider(enseignant);
            using var db = new EcoleDbContext();
            if (db.Personnes.Any(p => p.Email == enseignant.Email))
                throw new ArgumentException($"L'email « {enseignant.Email} » est déjà utilisé.");

            db.Enseignants.Add(enseignant);
            db.SaveChanges();
        }

        // ===== UPDATE =====
        public void Modifier(Enseignant enseignant)
        {
            Valider(enseignant);
            using var db = new EcoleDbContext();
            var existant = db.Enseignants.Find(enseignant.Id)
                ?? throw new ArgumentException("Enseignant introuvable.");
            if (db.Personnes.Any(p => p.Email == enseignant.Email && p.Id != enseignant.Id))
                throw new ArgumentException($"L'email « {enseignant.Email} » est déjà utilisé.");

            existant.Nom = enseignant.Nom;
            existant.Prenom = enseignant.Prenom;
            existant.Email = enseignant.Email;
            existant.Specialite = enseignant.Specialite;
            db.SaveChanges();
        }

        // ===== DELETE =====
        public void Supprimer(int id)
        {
            using var db = new EcoleDbContext();
            var enseignant = db.Enseignants.Find(id)
                ?? throw new ArgumentException("Enseignant introuvable.");
            if (db.Matieres.Any(m => m.EnseignantId == id))
                throw new ArgumentException("Impossible de supprimer : cet enseignant est responsable d'au moins une matière.");

            db.Enseignants.Remove(enseignant);
            db.SaveChanges();
        }

        private static void Valider(Enseignant e)
        {
            e.Nom = (e.Nom ?? "").Trim().ToUpper();
            e.Prenom = (e.Prenom ?? "").Trim();
            e.Email = (e.Email ?? "").Trim().ToLower();
            e.Specialite = (e.Specialite ?? "").Trim();

            if (e.Nom.Length == 0) throw new ArgumentException("Le nom est obligatoire.");
            if (e.Prenom.Length == 0) throw new ArgumentException("Le prénom est obligatoire.");
            Validation.Email(e.Email);
            if (e.Specialite.Length == 0) throw new ArgumentException("La spécialité est obligatoire.");
        }
    }
}