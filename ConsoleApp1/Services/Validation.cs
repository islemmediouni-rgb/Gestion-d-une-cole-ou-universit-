using System.Text.RegularExpressions;

namespace GestionEcole.Services
{
    /// <summary>Règles de validation communes à plusieurs services.</summary>
    public static class Validation
    {
        public static void Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("L'email est obligatoire.");
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("L'email n'est pas valide (exemple : nom@ecole.tn).");
        }

        public static void AnneeUniversitaire(string annee)
        {
            if (!Regex.IsMatch(annee ?? "", @"^\d{4}-\d{4}$"))
                throw new ArgumentException("L'année universitaire doit être au format AAAA-AAAA (exemple : 2026-2027).");
            var debut = int.Parse(annee!.Substring(0, 4));
            var fin = int.Parse(annee.Substring(5, 4));
            if (fin != debut + 1)
                throw new ArgumentException("L'année universitaire doit couvrir deux années qui se suivent (exemple : 2026-2027).");
        }
    }
}