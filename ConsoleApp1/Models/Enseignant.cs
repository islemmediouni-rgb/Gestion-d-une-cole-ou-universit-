namespace GestionEcole.Models
{
    public class Enseignant : Personne
    {
        public string Specialite { get; set; } = "";

        public List<Matiere> Matieres { get; set; } = new();

        public override string GetRole() => "Enseignant";

        public Note SaisirNote(Etudiant e, Matiere m, double valeur)
        {
            if (!Matieres.Contains(m))
                throw new InvalidOperationException($"{GetNomComplet()} n'enseigne pas « {m.Nom} ».");
            if (valeur < 0 || valeur > 20)
                throw new ArgumentOutOfRangeException(nameof(valeur), "La note doit être entre 0 et 20.");

            var note = new Note { Valeur = valeur, Matiere = m };
            e.AjouterNote(note);
            return note;
        }
    }
}
