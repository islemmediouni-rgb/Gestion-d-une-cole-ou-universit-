using GestionEcole.Models;

namespace GestionEcole
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Petit test des classes
            var e = new Etudiant { Nom = "Ayari", Prenom = "Yasmine", Matricule = "E001" };
            MessageBox.Show($"{e.GetNomComplet()} — {e.GetRole()}", "Test des classes");

            Application.Run(new Form());
        }
    }
}