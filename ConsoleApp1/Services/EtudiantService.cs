using GestionEcole.Data;
using GestionEcole.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEcole.Services
{
    public class EtudiantService
    {
        // ===== READ (avec inscriptions + classe, filtre par classe) =====
        public List<Etudiant> Lister(string? recherche = null, int? classeId = null)
        {
            using var db = new EcoleDbContext();
            var requete = db.Etudiants
                .Include(e => e.Inscriptions).ThenInclude(i => i.Classe)
                .AsQueryable();

            if (classeId.HasValue)
                requete = requete.Where(e => e.Inscriptions.Any(i => i.ClasseId == classeId.Value));

            if (!string.IsNullOrWhiteSpace(recherche))
            {
                var r = recherche.Trim().ToUpper();
                requete = requete.Where(e => e.Matricule.ToUpper().Contains(r)
                                          || e.Nom.ToUpper().Contains(r)
                                          || e.Prenom.ToUpper().Contains(r));
            }
            return requete.OrderBy(e => e.Nom).ThenBy(e => e.Prenom).ToList();
        }

        // Inscription la plus récente d'un étudiant (pour l'affichage)
        public static Inscription? DerniereInscription(Etudiant e) =>
            e.Inscriptions.OrderByDescending(i => i.AnneeUniversitaire).FirstOrDefault();

        // ===== CREATE : crée l'étudiant ET son inscription dans la classe =====
        public void Ajouter(Etudiant etudiant, int classeId, string annee)
        {
            Valider(etudiant, classeId, annee);
            using var db = new EcoleDbContext();
            if (db.Etudiants.Any(e => e.Matricule == etudiant.Matricule))
                throw new ArgumentException($"Le matricule « {etudiant.Matricule} » existe déjà.");
            if (db.Personnes.Any(p => p.Email == etudiant.Email))
                throw new ArgumentException($"L'email « {etudiant.Email} » est déjà utilisé.");

            var classe = db.Classes.Include(c => c.Inscriptions).FirstOrDefault(c => c.Id == classeId)
                ?? throw new ArgumentException("Classe introuvable.");

            // Méthode du diagramme de classes : crée l'inscription
            classe.AjouterEtudiant(etudiant, annee);
            db.Etudiants.Add(etudiant);
            db.SaveChanges();
        }

        // ===== UPDATE : modifie l'étudiant et sa classe pour l'année choisie =====
        public void Modifier(Etudiant etudiant, int classeId, string annee)
        {
            Valider(etudiant, classeId, annee);
            using var db = new EcoleDbContext();
            var existant = db.Etudiants.Include(e => e.Inscriptions).FirstOrDefault(e => e.Id == etudiant.Id)
                ?? throw new ArgumentException("Étudiant introuvable.");
            if (db.Etudiants.Any(e => e.Matricule == etudiant.Matricule && e.Id != etudiant.Id))
                throw new ArgumentException($"Le matricule « {etudiant.Matricule} » est déjà utilisé.");
            if (db.Personnes.Any(p => p.Email == etudiant.Email && p.Id != etudiant.Id))
                throw new ArgumentException($"L'email « {etudiant.Email} » est déjà utilisé.");
            if (!db.Classes.Any(c => c.Id == classeId))
                throw new ArgumentException("Classe introuvable.");

            existant.Matricule = etudiant.Matricule;
            existant.Nom = etudiant.Nom;
            existant.Prenom = etudiant.Prenom;
            existant.Email = etudiant.Email;

            // Une seule classe par année : on met à jour l'inscription de l'année, ou on la crée
            var inscription = existant.Inscriptions.FirstOrDefault(i => i.AnneeUniversitaire == annee);
            if (inscription != null)
                inscription.ClasseId = classeId;
            else
                existant.Inscriptions.Add(new Inscription { ClasseId = classeId, AnneeUniversitaire = annee });

            db.SaveChanges();
        }

        // ===== DELETE : ses notes et inscriptions sont supprimées avec lui (cascade) =====
        public void Supprimer(int id)
        {
            using var db = new EcoleDbContext();
            var etudiant = db.Etudiants.Find(id)
                ?? throw new ArgumentException("Étudiant introuvable.");

            db.Etudiants.Remove(etudiant);
            db.SaveChanges();
        }

        private static void Valider(Etudiant e, int classeId, string annee)
        {
            e.Matricule = (e.Matricule ?? "").Trim().ToUpper();
            e.Nom = (e.Nom ?? "").Trim().ToUpper();
            e.Prenom = (e.Prenom ?? "").Trim();
            e.Email = (e.Email ?? "").Trim().ToLower();

            if (e.Matricule.Length == 0) throw new ArgumentException("Le matricule est obligatoire.");
            if (e.Nom.Length == 0) throw new ArgumentException("Le nom est obligatoire.");
            if (e.Prenom.Length == 0) throw new ArgumentException("Le prénom est obligatoire.");
            Validation.Email(e.Email);
            if (classeId <= 0) throw new ArgumentException("Veuillez choisir une classe.");
            Validation.AnneeUniversitaire(annee);
        }
    }
}