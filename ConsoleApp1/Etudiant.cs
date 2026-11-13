namespace ConsoleApp1
{
    public class Etudiant : Personne
    {
        public string Matricule { get; set; } = "";

        // obtient : 1 Etudiant -> 0..* Note
        public List<Note> Notes { get; } = new();

        // effectue : 1 Etudiant -> 1..* Inscription
        public List<Inscription> Inscriptions { get; } = new();

        public override string GetRole() => "Etudiant";

        public void AjouterNote(Note n)
        {
            n.Etudiant = this;
            Notes.Add(n);
        }

        public double CalculerMoyenne()
        {
            double somme = 0, coeffs = 0;
            foreach (var n in Notes)
            {
                double coef = n.Matiere?.Coefficient ?? 1;
                somme += n.Valeur * coef;
                coeffs += coef;
            }
            return coeffs == 0 ? 0 : somme / coeffs;
        }
}
    }

