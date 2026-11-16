namespace GestionEcole.Models
{
    public class Etudiant : Personne
    {
        public string Matricule { get; set; } = "";

        public List<Note> Notes { get; set; } = new();

        public List<Inscription> Inscriptions { get; set; } = new();

        public override string GetRole() => "Étudiant";

        public void AjouterNote(Note n)
        {
            n.Etudiant = this;
            Notes.Add(n);
        }

        public double CalculerMoyenne()
        {
            var notes = Notes.Where(n => n.Matiere != null).ToList();
            double totalCoef = notes.Sum(n => n.Matiere!.Coefficient);
            if (totalCoef == 0) return 0;

            double somme = notes.Sum(n => n.Valeur * n.Matiere!.Coefficient);
            return Math.Round(somme / totalCoef, 2);
        }
    }
}
