namespace ConsoleApp1
{
    public class Salle
    {
        public string Numero { get; set; } = "";
        public int Capacite { get; set; }

        public List<Seance> Seances { get; } = new();   // en (0..*)
    }
}
