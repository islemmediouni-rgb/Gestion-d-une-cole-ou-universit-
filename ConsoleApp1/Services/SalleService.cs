using GestionEcole.Data;
using GestionEcole.Models;

namespace GestionEcole.Services
{
    public class SalleService
    {
        // ===== READ =====
        public List<Salle> Lister()
        {
            using var db = new EcoleDbContext();
            return db.Salles.OrderBy(s => s.Numero).ToList();
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

            // Règle "Restrict" : on vérifie avant, pour afficher un message clair
            if (db.Seances.Any(s => s.SalleId == id))
                throw new ArgumentException("Impossible de supprimer : des séances sont planifiées dans cette salle.");

            db.Salles.Remove(salle);
            db.SaveChanges();
        }

        // ===== Règles de validation (communes à Ajouter et Modifier) =====
        private static void Valider(Salle salle)
        {
            salle.Numero = salle.Numero.Trim().ToUpper();

            if (string.IsNullOrEmpty(salle.Numero))
                throw new ArgumentException("Le numéro de salle est obligatoire.");
            if (salle.Capacite <= 0)
                throw new ArgumentException("La capacité doit être supérieure à 0.");
        }
    }
}