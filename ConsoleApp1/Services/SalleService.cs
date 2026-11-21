using GestionEcole.Data;
using GestionEcole.Models;

namespace GestionEcole.Services
{
    public class SalleService
    {
        // ===== READ (avec recherche) =====
        public List<Salle> Lister(string? recherche = null)
        {
            using var db = new EcoleDbContext();
            var requete = db.Salles.AsQueryable();
            if (!string.IsNullOrWhiteSpace(recherche))
            {
                var r = recherche.Trim().ToUpper();
                requete = requete.Where(s => s.Numero.ToUpper().Contains(r));
            }
            return requete.OrderBy(s => s.Numero).ToList();
        }

        // ===== CREATE =====
        public void Ajouter(Salle salle)
        {
            Valider(salle);
            using var db = new EcoleDbContext();
            if (db.Salles.Any(s => s.Numero == salle.Numero))
                throw new ArgumentException($"La salle « {salle.Numero} » existe déjà.");

            db.Salles.Add(salle);
            db.SaveChanges();
        }

        // ===== UPDATE =====
        public void Modifier(Salle salle)
        {
            Valider(salle);
            using var db = new EcoleDbContext();
            var existante = db.Salles.Find(salle.Id)
                ?? throw new ArgumentException("Salle introuvable.");
            if (db.Salles.Any(s => s.Numero == salle.Numero && s.Id != salle.Id))
                throw new ArgumentException($"Le numéro « {salle.Numero} » est déjà utilisé par une autre salle.");

            existante.Numero = salle.Numero;
            existante.Capacite = salle.Capacite;
            db.SaveChanges();
        }

        // ===== DELETE =====
        public void Supprimer(int id)
        {
            using var db = new EcoleDbContext();
            var salle = db.Salles.Find(id)
                ?? throw new ArgumentException("Salle introuvable.");
            if (db.Seances.Any(s => s.SalleId == id))
                throw new ArgumentException("Impossible de supprimer : des séances sont planifiées dans cette salle.");

            db.Salles.Remove(salle);
            db.SaveChanges();
        }

        // ===== Validation commune à Ajouter et Modifier =====
        private static void Valider(Salle salle)
        {
            salle.Numero = (salle.Numero ?? "").Trim().ToUpper();
            if (salle.Numero.Length == 0)
                throw new ArgumentException("Le numéro de salle est obligatoire.");
            if (salle.Capacite <= 0)
                throw new ArgumentException("La capacité doit être supérieure à 0.");
        }
    }
}