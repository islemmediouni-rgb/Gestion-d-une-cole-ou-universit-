namespace GestionEcole.Models
{
    public class Seance
    {
        public int Id { get; set; }
        public string Jour { get; set; } = "";        
        public string HeureDebut { get; set; } = "";  
        public string HeureFin { get; set; } = "";    

        public int ClasseId { get; set; }
        public Classe? Classe { get; set; }

        public int MatiereId { get; set; }
        public Matiere? Matiere { get; set; }


        public int SalleId { get; set; }
        public Salle? Salle { get; set; }
    }
}
