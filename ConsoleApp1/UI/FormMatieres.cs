using GestionEcole.Models;
using GestionEcole.Services;

namespace GestionEcole.UI
{
    public partial class FormMatieres : Form
    {
        private readonly MatiereService service = new MatiereService();
        private readonly EnseignantService enseignantService = new EnseignantService();
        private int? idSelectionne;

        public FormMatieres()
        {
            InitializeComponent();
        }

        private void FormMatieres_Load(object? sender, EventArgs e)
        {
            // Liste déroulante des enseignants : on affiche le nom, on retient l'Id
            Ui.RemplirCombo(cmbEnseignant, enseignantService.Lister()
                .Select(p => new ElementListe { Id = p.Id, Libelle = $"{p.GetNomComplet()} ({p.Specialite})" }));
            Charger();
            if (cmbEnseignant.Items.Count == 0)
                Ui.Erreur("Aucun enseignant : créez d'abord un enseignant avant d'ajouter une matière.");
        }

        // ===== READ =====
        private void Charger()
        {
            grille.DataSource = service.Lister(txtRecherche.Text)
                .Select(m => new
                {
                    m.Id,
                    m.EnseignantId,
                    Matière = m.Nom,
                    m.Coefficient,
                    Enseignant = m.Enseignant?.GetNomComplet()
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
            txtNom.Text = ligne.Cells["Matière"].Value?.ToString();
            numCoefficient.Value = Convert.ToDecimal(ligne.Cells["Coefficient"].Value);
            cmbEnseignant.SelectedValue = (int)ligne.Cells["EnseignantId"].Value;
        }

        private Matiere LireFormulaire() => new Matiere
        {
            Id = idSelectionne ?? 0,
            Nom = txtNom.Text,
            Coefficient = (double)numCoefficient.Value,
            EnseignantId = Ui.IdChoisi(cmbEnseignant) ?? 0
        };

        // ===== CREATE =====
        private void btnAjouter_Click(object? sender, EventArgs e)
        {
            try
            {
                var matiere = LireFormulaire();
                matiere.Id = 0;
                service.Ajouter(matiere);
                Ui.Info("Matière ajoutée.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        // ===== UPDATE =====
        private void btnModifier_Click(object? sender, EventArgs e)
        {
            if (idSelectionne == null) { Ui.Erreur("Sélectionnez d'abord une matière dans la liste."); return; }
            try
            {
                service.Modifier(LireFormulaire());
                Ui.Info("Matière modifiée.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        // ===== DELETE =====
        private void btnSupprimer_Click(object? sender, EventArgs e)
        {
            if (idSelectionne == null) { Ui.Erreur("Sélectionnez d'abord une matière dans la liste."); return; }
            if (!Ui.Confirmer($"Supprimer la matière « {txtNom.Text} » ?")) return;
            try
            {
                service.Supprimer(idSelectionne.Value);
                Ui.Info("Matière supprimée.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        private void btnVider_Click(object? sender, EventArgs e) => Vider();

        private void Vider()
        {
            idSelectionne = null;
            txtNom.Clear();
            numCoefficient.Value = 1;
            grille.ClearSelection();
        }
    }
}