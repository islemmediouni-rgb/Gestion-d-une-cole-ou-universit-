using GestionEcole.Data;
using GestionEcole.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEcole.Services
{
    public class SeanceService
    {
        public static readonly string[] Jours = { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi" };

        // ===== READ (triées par jour puis par heure) =====
        public List<Seance> Lister(int? classeId = null)
        {
            using var db = new EcoleDbContext();
            var requete = db.Seances
                .Include(s => s.Classe)
                .Include(s => s.Matiere)
                .Include(s => s.Salle)
                .AsQueryable();
            if (classeId.HasValue)
                requete = requete.Where(s => s.ClasseId == classeId.Value);

            return requete.ToList()
                .OrderBy(s => Array.IndexOf(Jours, s.Jour))
                .ThenBy(s => s.HeureDebut)
                .ToList();
        }

        // ===== CREATE =====
        public void Ajouter(Seance seance)
        {
            Valider(seance);
            using var db = new EcoleDbContext();
            VerifierConflits(db, seance);

            var classe = db.Classes.Find(seance.ClasseId)
                ?? throw new ArgumentException("Classe introuvable.");

            // Méthode du diagramme de classes
            classe.AjouterSeance(seance);
            db.SaveChanges();
        }

        // ===== UPDATE =====
        public void Modifier(Seance seance)
        {
            Valider(seance);
            using var db = new EcoleDbContext();
            var existante = db.Seances.Find(seance.Id)
                ?? throw new ArgumentException("Séance introuvable.");
            VerifierConflits(db, seance);

            existante.ClasseId = seance.ClasseId;
            existante.MatiereId = seance.MatiereId;
            existante.SalleId = seance.SalleId;
            existante.Jour = seance.Jour;
            existante.HeureDebut = seance.HeureDebut;
            existante.HeureFin = seance.HeureFin;
            db.SaveChanges();
        }

        // ===== DELETE =====
        public void Supprimer(int id)
        {
            using var db = new EcoleDbContext();
            var seance = db.Seances.Find(id)
                ?? throw new ArgumentException("Séance introuvable.");
            db.Seances.Remove(seance);
            db.SaveChanges();
        }

        // ===== Emploi du temps d'une classe (méthode du diagramme) =====
        public string EmploiDuTemps(int classeId)
        {
            using var db = new EcoleDbContext();
            var classe = db.Classes
                .Include(c => c.Seances).ThenInclude(s => s.Matiere)
                .Include(c => c.Seances).ThenInclude(s => s.Salle)
                .FirstOrDefault(c => c.Id == classeId)
                ?? throw new ArgumentException("Classe introuvable.");
            return classe.Seances.Count == 0
                ? $"Aucune séance planifiée pour {classe.Nom}."
                : classe.AfficherEmploiDuTemps();
        }

        // ===== Règles métier =====
        private static void Valider(Seance s)
        {
            if (s.ClasseId <= 0) throw new ArgumentException("Veuillez choisir une classe.");
            if (s.MatiereId <= 0) throw new ArgumentException("Veuillez choisir une matière.");
            if (s.SalleId <= 0) throw new ArgumentException("Veuillez choisir une salle.");
            if (Array.IndexOf(Jours, s.Jour) < 0) throw new ArgumentException("Veuillez choisir un jour.");
            if (string.CompareOrdinal(s.HeureDebut, s.HeureFin) >= 0)
                throw new ArgumentException("L'heure de fin doit être après l'heure de début.");
        }

        // Une salle ou une classe ne peut pas avoir deux séances qui se chevauchent
        private static void VerifierConflits(EcoleDbContext db, Seance s)
        {
            var memeJour = db.Seances
                .Include(x => x.Classe)
                .Include(x => x.Salle)
                .Where(x => x.Jour == s.Jour && x.Id != s.Id
                         && (x.SalleId == s.SalleId || x.ClasseId == s.ClasseId))
                .ToList();

            foreach (var x in memeJour)
            {
                bool chevauche = string.CompareOrdinal(x.HeureDebut, s.HeureFin) < 0
                              && string.CompareOrdinal(s.HeureDebut, x.HeureFin) < 0;
                if (!chevauche) continue;

                if (x.SalleId == s.SalleId)
                    throw new ArgumentException(
                        $"Conflit : la salle {x.Salle?.Numero} est déjà occupée le {x.Jour} de {x.HeureDebut} à {x.HeureFin} (classe {x.Classe?.Nom}).");
                throw new ArgumentException(
                    $"Conflit : la classe {x.Classe?.Nom} a déjà une séance le {x.Jour} de {x.HeureDebut} à {x.HeureFin}.");
            }

            // La salle doit pouvoir accueillir tous les étudiants inscrits dans la classe
            var salle = db.Salles.Find(s.SalleId) ?? throw new ArgumentException("Salle introuvable.");
            int inscrits = db.Inscriptions.Count(i => i.ClasseId == s.ClasseId);
            if (inscrits > salle.Capacite)
                throw new ArgumentException(
                    $"La salle {salle.Numero} ({salle.Capacite} places) est trop petite pour cette classe ({inscrits} inscrits).");
        }
    }
}