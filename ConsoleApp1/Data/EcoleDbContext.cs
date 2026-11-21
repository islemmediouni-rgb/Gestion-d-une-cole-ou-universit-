using GestionEcole.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEcole.Data
{
    public class EcoleDbContext : DbContext
    {
        // ===== 1. Les tables =====
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Administrateur> Administrateurs { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Salle> Salles { get; set; }

        // ===== 2. Quelle base, et où =====
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=ecole.db");
        }

        // ===== 3. Les règles =====
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Héritage : Etudiant, Enseignant, Administrateur dans UNE table "Personnes",
            // la colonne "Role" indique le type de chaque ligne
            modelBuilder.Entity<Personne>()
                .HasDiscriminator<string>("Role")
                .HasValue<Etudiant>("Etudiant")
                .HasValue<Enseignant>("Enseignant")
                .HasValue<Administrateur>("Administrateur");

            // Matricule unique
            modelBuilder.Entity<Etudiant>()
                .HasIndex(e => e.Matricule)
                .IsUnique();

            // Pas deux fois la même inscription (même étudiant, même classe, même année)
            modelBuilder.Entity<Inscription>()
                .HasIndex(i => new { i.EtudiantId, i.ClasseId, i.AnneeUniversitaire })
                .IsUnique();

            // Interdire de supprimer une salle, une matière ou un enseignant encore utilisés
            modelBuilder.Entity<Seance>()
                .HasOne(s => s.Salle).WithMany(s => s.Seances)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Seance>()
                .HasOne(s => s.Matiere).WithMany(m => m.Seances)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Matiere>()
                .HasOne(m => m.Enseignant).WithMany(e => e.Matieres)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}