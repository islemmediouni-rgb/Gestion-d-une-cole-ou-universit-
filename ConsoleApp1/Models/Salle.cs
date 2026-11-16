namespace GestionEcole.Models
{
    public class Salle
    {
        public int Id { get; set; }
        public string Numero { get; set; } = "";
        public int Capacite { get; set; }
        public List<Seance> Seances { get; set; } = new();
    }
}
