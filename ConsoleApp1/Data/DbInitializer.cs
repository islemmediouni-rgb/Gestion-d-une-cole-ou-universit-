using GestionEcole.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEcole.Data
{
    public static class DbInitializer
    {
        public static void Initialiser(EcoleDbContext db)
        {
            // 1. Crée la base / applique les migrations en attente
            db.Database.Migrate();

            // 2. Si la base contient déjà des données, on ne fait rien
            if (db.Personnes.Any()) return;

            // 3. Création des objets
            var admin = new Administrateur { Nom = "Ben Ali", Prenom = "Sonia", Email = "admin@ecole.tn" };
            var prof  = new Enseignant { Nom = "Gharbi", Prenom = "Sami", Email = "s.gharbi@ecole.tn", Specialite = "Mathématiques" };
            var maths = new Matiere { Nom = "Mathématiques", Coefficient = 2 };
            prof.Matieres.Add(maths);

            var classe = new Classe { Nom = "2A-GSIL" };
            var etu = new Etudiant { Nom = "Ayari", Prenom = "Yasmine", Email = "y.ayari@ecole.tn", Matricule = "E001" };

            // 4. Utilisation des méthodes du diagramme de classes
            admin.InscrireEtudiant(etu, classe, "2026-2027");
            admin.PlanifierSeance(classe, new Seance
            {
                Jour = "Lundi", HeureDebut = "08:30", HeureFin = "10:00",
                Matiere = maths, Salle = new Salle { Numero = "A01", Capacite = 30 }
            });
            prof.SaisirNote(etu, maths, 15);

            // 5. Enregistrement : on ajoute chaque objet "point de départ",
            //    EF enregistre aussi tout ce qui est atteignable depuis eux
            db.Personnes.Add(admin);
            db.Personnes.Add(prof);    // → sa Matiere
            db.Personnes.Add(etu);     // → ses Notes et ses Inscriptions
            db.Classes.Add(classe);    // → ses Seances → la Salle
            db.SaveChanges();
        }
    }
}