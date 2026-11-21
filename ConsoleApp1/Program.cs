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

            // Temporaire : on ouvre directement l'écran en cours de test
            Application.Run(new FormNotes());
        }
    }
}