namespace ConsoleApp1
{
    public class Enseignant : Personne
    {
        public string Specialite { get; set; } = "";

        // enseigne : 1 Enseignant -> 1..* Matiere
        public List<Matiere> Matieres { get; } = new();

        public override string GetRole() => "Enseignant";

        public void SaisirNote(Etudiant e, Matiere m, double valeur)
        {
            var note = new Note { Valeur = valeur, Etudiant = e, Matiere = m };
            e.AjouterNote(note);
            m.Notes.Add(note);
        }
    }
}
