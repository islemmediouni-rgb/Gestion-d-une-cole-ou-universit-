namespace ConsoleApp1
{
    public class Administrateur : Personne
    {
        public override string GetRole() => "Administrateur";

        public void InscrireEtudiant(Etudiant e, Classe c, string annee)
        {
            var inscription = new Inscription
            {
                AnneeUniversitaire = annee,
                Etudiant = e,
                Classe = c
            };
            e.Inscriptions.Add(inscription);
            c.Inscriptions.Add(inscription);
        }

        public void PlanifierSeance(Classe c, Seance s)
        {
            c.AjouterSeance(s);
        }
    }
}
