using GestionEcole.Data;

namespace GestionEcole
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var db = new EcoleDbContext())
            {
                DbInitializer.Initialiser(db);

                // Test temporaire : sera remplacé par les écrans CRUD
                MessageBox.Show($"Personnes en base : {db.Personnes.Count()}", "Test de la base");
            }

            Application.Run(new Form());
        }
    }
}