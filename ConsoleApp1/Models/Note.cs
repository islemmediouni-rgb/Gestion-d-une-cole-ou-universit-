namespace GestionEcole.Models
{
    public class Note
    {
        public int Id { get; set; }
        public double Valeur { get; set; }

        public int EtudiantId { get; set; }
        public Etudiant? Etudiant { get; set; }
        public int MatiereId { get; set; }
        public Matiere? Matiere { get; set; }
    }
}
