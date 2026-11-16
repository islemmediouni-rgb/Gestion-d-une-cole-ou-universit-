namespace GestionEcole.Models
{
    public class Matiere
    {
        public int Id { get; set; }
        public string Nom { get; set; } = "";
        public double Coefficient { get; set; } = 1;

        public int EnseignantId { get; set; }
        public Enseignant? Enseignant { get; set; }
        public List<Note> Notes { get; set; } = new();

        public List<Seance> Seances { get; set; } = new();
    }
}
