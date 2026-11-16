namespace GestionEcole.Models
{
    public class Inscription
    {
        public int Id { get; set; }
        public string AnneeUniversitaire { get; set; } = "";

        public int EtudiantId { get; set; }
        public Etudiant? Etudiant { get; set; }

        public int ClasseId { get; set; }
        public Classe? Classe { get; set; }
    }
}
