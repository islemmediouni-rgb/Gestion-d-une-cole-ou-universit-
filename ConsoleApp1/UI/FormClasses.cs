using GestionEcole.Models;
using GestionEcole.Services;

namespace GestionEcole.UI
{
    public partial class FormClasses : Form
    {
        private readonly ClasseService service = new ClasseService();
        private int? idSelectionne;

        public FormClasses()
        {
            InitializeComponent();
        }

        private void FormClasses_Load(object? sender, EventArgs e) => Charger();

        // ===== READ =====
        private void Charger()
        {
            grille.DataSource = service.Lister(txtRecherche.Text)
                .Select(c => new
                {
                    c.Id,
                    Classe = c.Nom,
                    Inscrits = c.Inscriptions.Count,
                    Séances = c.Seances.Count
                })
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
            txtNom.Text = ligne.Cells["Classe"].Value?.ToString();
        }

        // ===== CREATE =====
        private void btnAjouter_Click(object? sender, EventArgs e)
        {
            try
            {
                service.Ajouter(new Classe { Nom = txtNom.Text });
                Ui.Info("Classe ajoutée.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        // ===== UPDATE =====
        private void btnModifier_Click(object? sender, EventArgs e)
        {
            if (idSelectionne == null) { Ui.Erreur("Sélectionnez d'abord une classe dans la liste."); return; }
            try
            {
                service.Modifier(new Classe { Id = idSelectionne.Value, Nom = txtNom.Text });
                Ui.Info("Classe modifiée.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        // ===== DELETE =====
        private void btnSupprimer_Click(object? sender, EventArgs e)
        {
            if (idSelectionne == null) { Ui.Erreur("Sélectionnez d'abord une classe dans la liste."); return; }
            if (!Ui.Confirmer($"Supprimer la classe « {txtNom.Text} » ?")) return;
            try
            {
                service.Supprimer(idSelectionne.Value);
                Ui.Info("Classe supprimée.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        private void btnVider_Click(object? sender, EventArgs e) => Vider();

        private void Vider()
        {
            idSelectionne = null;
            txtNom.Clear();
            grille.ClearSelection();
        }
    }
}