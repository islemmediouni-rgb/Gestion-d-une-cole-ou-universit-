namespace GestionEcole.Models
{
    public abstract class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; } = "";
        public string Prenom { get; set; } = "";
        public string Email { get; set; } = "";
        public abstract string GetRole();

        public string GetNomComplet() => $"{Nom} {Prenom}";
    }
}
