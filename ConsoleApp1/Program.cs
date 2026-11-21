using GestionEcole.Data;
using GestionEcole.UI;

namespace GestionEcole
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Préparer la base : migrations + données de départ
            using (var db = new EcoleDbContext())
            {
                DbInitializer.Initialiser(db);
            }

            // Ouvrir l'écran d'accueil
            Application.Run(new FormPrincipal());
        }
    }
}