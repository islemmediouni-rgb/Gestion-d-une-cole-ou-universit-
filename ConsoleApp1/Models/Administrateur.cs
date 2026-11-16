namespace GestionEcole.Models
{
    public class Administrateur : Personne
    {
        public override string GetRole() => "Administrateur";

        public Inscription InscrireEtudiant(Etudiant e, Classe c, string annee)
        {
            return c.AjouterEtudiant(e, annee);
        }

        public void PlanifierSeance(Classe c, Seance s)
        {
            c.AjouterSeance(s);
        }
    }
}
