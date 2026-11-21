namespace GestionEcole.UI
{
    /// <summary>Petites aides communes à tous les écrans.</summary>
    internal static class Ui
    {
        public static void Info(string message) =>
            MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void Erreur(string message) =>
            MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static bool Confirmer(string message) =>
            MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        /// <summary>Cache les colonnes techniques (Id, ClasseId, MatiereId…) de la grille.</summary>
        public static void MasquerColonnesId(DataGridView grille)
        {
            foreach (DataGridViewColumn col in grille.Columns)
                if (col.Name == "Id" || col.Name.EndsWith("Id"))
                    col.Visible = false;
        }

        /// <summary>Retourne la ligne sélectionnée par l'utilisateur, ou null.</summary>
        public static DataGridViewRow? LigneSelectionnee(DataGridView grille) =>
            grille.CurrentRow != null && grille.CurrentRow.Selected ? grille.CurrentRow : null;

        /// <summary>Remplit une liste déroulante avec des éléments (Id, Libelle).</summary>
        public static void RemplirCombo(ComboBox combo, IEnumerable<ElementListe> elements)
        {
            combo.DataSource = elements.ToList();
            combo.DisplayMember = nameof(ElementListe.Libelle);
            combo.ValueMember = nameof(ElementListe.Id);
        }

        /// <summary>Id choisi dans une liste déroulante (0 si rien, null pour « Toutes »).</summary>
        public static int? IdChoisi(ComboBox combo) =>
            combo.SelectedItem is ElementListe e ? e.Id : 0;
    }

    /// <summary>Élément affiché dans une liste déroulante. Id = null signifie « Tous ».</summary>
    public class ElementListe
    {
        public int? Id { get; set; }
        public string Libelle { get; set; } = "";
        public override string ToString() => Libelle;
    }
}