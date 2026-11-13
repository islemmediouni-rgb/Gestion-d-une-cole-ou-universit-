namespace ConsoleApp1
{
    public class Matiere
    {
        public string Nom { get; set; } = "";
        public double Coefficient { get; set; }

        public Enseignant? Enseignant { get; set; }          // enseigne
        public List<Note> Notes { get; } = new();             // évalue (0..*)
        public List<Seance> Seances { get; } = new();         // sur (0..*)
    }
}
