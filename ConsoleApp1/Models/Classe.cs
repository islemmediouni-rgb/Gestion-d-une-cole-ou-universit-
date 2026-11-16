using System.Text;

namespace GestionEcole.Models
{
    public class Classe
    {
        public int Id { get; set; }
        public string Nom { get; set; } = "";

        public List<Inscription> Inscriptions { get; set; } = new();

        public List<Seance> Seances { get; set; } = new();

        public Inscription AjouterEtudiant(Etudiant e, string annee)
        {
            if (Inscriptions.Any(i => i.Etudiant == e && i.AnneeUniversitaire == annee))
                throw new InvalidOperationException($"{e.GetNomComplet()} est déjà inscrit(e) en {Nom} pour {annee}.");

            var inscription = new Inscription { Etudiant = e, Classe = this, AnneeUniversitaire = annee };
            Inscriptions.Add(inscription);
            e.Inscriptions.Add(inscription);
            return inscription;
        }

        public void AjouterSeance(Seance s)
        {
            s.Classe = this;
            Seances.Add(s);
        }

        private static readonly string[] OrdreJours =
            { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi" };

        public string AfficherEmploiDuTemps()
        {
            var sb = new StringBuilder($"Emploi du temps — {Nom}\n");
            var tri = Seances
                .OrderBy(s => Array.IndexOf(OrdreJours, s.Jour))
                .ThenBy(s => s.HeureDebut);

            foreach (var s in tri)
                sb.AppendLine($"{s.Jour,-9} {s.HeureDebut}-{s.HeureFin}  {s.Matiere?.Nom,-20} Salle {s.Salle?.Numero}");
            return sb.ToString();
        }
    }
}
