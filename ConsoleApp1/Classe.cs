namespace ConsoleApp1
{
    public class Classe
    {
        public string Nom { get; set; } = "";

        public List<Inscription> Inscriptions { get; } = new();  // dans
        public List<Seance> Seances { get; } = new();            // a

        public void AjouterEtudiant(Etudiant e)
        {
            var inscription = new Inscription { Etudiant = e, Classe = this };
            Inscriptions.Add(inscription);
            e.Inscriptions.Add(inscription);
        }

        public void AjouterSeance(Seance s)
        {
            s.Classe = this;
            Seances.Add(s);
        }

        public void AfficherEmploiDuTemps()
        {
            Console.WriteLine($"Emploi du temps de {Nom} :");
            foreach (var s in Seances)
            {
                Console.WriteLine($"- {s.Jour} {s.HeureDebut}-{s.HeureFin} | " +
                                  $"{s.Matiere?.Nom} | Salle {s.Salle?.Numero}");
            }
        }
    }
}
