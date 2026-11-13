namespace ConsoleApp1
{
    public class Seance
    {
        public string Jour { get; set; } = "";
        public string HeureDebut { get; set; } = "";
        public string HeureFin { get; set; } = "";

        public Classe? Classe { get; set; }     // a
        public Matiere? Matiere { get; set; }   // sur
        public Salle? Salle { get; set; }       // en
    }
}
