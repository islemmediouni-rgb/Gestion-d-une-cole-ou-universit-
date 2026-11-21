using GestionEcole.Data;
using GestionEcole.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEcole.Services
{
    public class NoteService
    {
        // ===== READ (filtre par étudiant) =====
        public List<Note> Lister(int? etudiantId = null)
        {
            using var db = new EcoleDbContext();
            var requete = db.Notes
                .Include(n => n.Etudiant)
                .Include(n => n.Matiere)
                .AsQueryable();
            if (etudiantId.HasValue)
                requete = requete.Where(n => n.EtudiantId == etudiantId.Value);

            return requete.ToList()
                .OrderBy(n => n.Etudiant?.Nom)
                .ThenBy(n => n.Matiere?.Nom)
                .ToList();
        }

        // ===== CREATE : la note est saisie par l'enseignant de la matière =====
        public void Ajouter(int etudiantId, int matiereId, double valeur)
        {
            Valider(etudiantId, matiereId, valeur);
            using var db = new EcoleDbContext();
            var etudiant = db.Etudiants.Find(etudiantId)
                ?? throw new ArgumentException("Étudiant introuvable.");
            var matiere = db.Matieres.Include(m => m.Enseignant).FirstOrDefault(m => m.Id == matiereId)
                ?? throw new ArgumentException("Matière introuvable.");
            var enseignant = matiere.Enseignant
                ?? throw new ArgumentException("Cette matière n'a pas d'enseignant responsable.");

            // Chargement explicite des matières de l'enseignant (utilisées par SaisirNote)
            db.Entry(enseignant).Collection(e => e.Matieres).Load();

            // Méthode du diagramme : Enseignant.SaisirNote(e, m, valeur)
            enseignant.SaisirNote(etudiant, matiere, valeur);
            db.SaveChanges();
        }

        // ===== UPDATE =====
        public void Modifier(int noteId, int etudiantId, int matiereId, double valeur)
        {
            Valider(etudiantId, matiereId, valeur);
            using var db = new EcoleDbContext();
            var note = db.Notes.Find(noteId)
                ?? throw new ArgumentException("Note introuvable.");
            if (!db.Etudiants.Any(e => e.Id == etudiantId)) throw new ArgumentException("Étudiant introuvable.");
            if (!db.Matieres.Any(m => m.Id == matiereId)) throw new ArgumentException("Matière introuvable.");

            note.EtudiantId = etudiantId;
            note.MatiereId = matiereId;
            note.Valeur = valeur;
            db.SaveChanges();
        }

        // ===== DELETE =====
        public void Supprimer(int noteId)
        {
            using var db = new EcoleDbContext();
            var note = db.Notes.Find(noteId)
                ?? throw new ArgumentException("Note introuvable.");
            db.Notes.Remove(note);
            db.SaveChanges();
        }

        // ===== Moyenne pondérée d'un étudiant (méthode du diagramme) =====
        public double MoyenneEtudiant(int etudiantId)
        {
            using var db = new EcoleDbContext();
            var etudiant = db.Etudiants
                .Include(e => e.Notes).ThenInclude(n => n.Matiere)
                .FirstOrDefault(e => e.Id == etudiantId)
                ?? throw new ArgumentException("Étudiant introuvable.");
            return etudiant.CalculerMoyenne();
        }

        private static void Valider(int etudiantId, int matiereId, double valeur)
        {
            if (etudiantId <= 0) throw new ArgumentException("Veuillez choisir un étudiant.");
            if (matiereId <= 0) throw new ArgumentException("Veuillez choisir une matière.");
            if (valeur < 0 || valeur > 20) throw new ArgumentException("La note doit être comprise entre 0 et 20.");
        }
    }
}