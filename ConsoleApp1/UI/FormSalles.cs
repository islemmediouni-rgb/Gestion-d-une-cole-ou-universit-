using GestionEcole.Models;
using GestionEcole.Services;

namespace GestionEcole.UI
{
    public partial class FormSalles : Form
    {
        private readonly SalleService service = new SalleService();
        private int? idSelectionne;   // null = aucune salle sélectionnée

        public FormSalles()
        {
            InitializeComponent();
        }

        private void FormSalles_Load(object? sender, EventArgs e) => Charger();

        // ===== READ =====
        private void Charger()
        {
            grille.DataSource = service.Lister(txtRecherche.Text)
                .Select(s => new { s.Id, Numéro = s.Numero, Capacité = s.Capacite })
                .ToList();
            Ui.MasquerColonnesId(grille);
            Vider();
        }

        private void txtRecherche_TextChanged(object? sender, EventArgs e) => Charger();

        private void grille_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e) => grille.ClearSelection();

        private void grille_SelectionChanged(object? sender, EventArgs e)
        {
            var ligne = Ui.LigneSelectionnee(grille);
            if (ligne == null) return;
            idSelectionne = (int)ligne.Cells["Id"].Value;
            txtNumero.Text = ligne.Cells["Numéro"].Value?.ToString();
            numCapacite.Value = (int)ligne.Cells["Capacité"].Value;
        }

        private Salle LireFormulaire() => new Salle
        {
            Id = idSelectionne ?? 0,
            Numero = txtNumero.Text,
            Capacite = (int)numCapacite.Value
        };

        // ===== CREATE =====
        private void btnAjouter_Click(object? sender, EventArgs e)
        {
            try
            {
                var salle = LireFormulaire();
                salle.Id = 0;
                service.Ajouter(salle);
                Ui.Info("Salle ajoutée.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        // ===== UPDATE =====
        private void btnModifier_Click(object? sender, EventArgs e)
        {
            if (idSelectionne == null) { Ui.Erreur("Sélectionnez d'abord une salle dans la liste."); return; }
            try
            {
                service.Modifier(LireFormulaire());
                Ui.Info("Salle modifiée.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        // ===== DELETE =====
        private void btnSupprimer_Click(object? sender, EventArgs e)
        {
            if (idSelectionne == null) { Ui.Erreur("Sélectionnez d'abord une salle dans la liste."); return; }
            if (!Ui.Confirmer($"Supprimer la salle « {txtNumero.Text} » ?")) return;
            try
            {
                service.Supprimer(idSelectionne.Value);
                Ui.Info("Salle supprimée.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        private void btnVider_Click(object? sender, EventArgs e) => Vider();

        private void Vider()
        {
            idSelectionne = null;
            txtNumero.Clear();
            numCapacite.Value = 30;
            grille.ClearSelection();
        }
    }
}