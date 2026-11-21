using GestionEcole.Models;
using GestionEcole.Services;

namespace GestionEcole.UI
{
    public partial class FormEnseignants : Form
    {
        private readonly EnseignantService service = new EnseignantService();
        private int? idSelectionne;

        public FormEnseignants()
        {
            InitializeComponent();
        }

        private void FormEnseignants_Load(object? sender, EventArgs e) => Charger();

        // ===== READ =====
        private void Charger()
        {
            grille.DataSource = service.Lister(txtRecherche.Text)
                .Select(p => new
                {
                    p.Id,
                    p.Nom,
                    Prénom = p.Prenom,
                    p.Email,
                    Spécialité = p.Specialite,
                    Matières = string.Join(", ", p.Matieres.Select(m => m.Nom))
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
            txtNom.Text = ligne.Cells["Nom"].Value?.ToString();
            txtPrenom.Text = ligne.Cells["Prénom"].Value?.ToString();
            txtEmail.Text = ligne.Cells["Email"].Value?.ToString();
            txtSpecialite.Text = ligne.Cells["Spécialité"].Value?.ToString();
        }

        private Enseignant LireFormulaire() => new Enseignant
        {
            Id = idSelectionne ?? 0,
            Nom = txtNom.Text,
            Prenom = txtPrenom.Text,
            Email = txtEmail.Text,
            Specialite = txtSpecialite.Text
        };

        // ===== CREATE =====
        private void btnAjouter_Click(object? sender, EventArgs e)
        {
            try
            {
                var enseignant = LireFormulaire();
                enseignant.Id = 0;
                service.Ajouter(enseignant);
                Ui.Info("Enseignant ajouté.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        // ===== UPDATE =====
        private void btnModifier_Click(object? sender, EventArgs e)
        {
            if (idSelectionne == null) { Ui.Erreur("Sélectionnez d'abord un enseignant dans la liste."); return; }
            try
            {
                service.Modifier(LireFormulaire());
                Ui.Info("Enseignant modifié.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        // ===== DELETE =====
        private void btnSupprimer_Click(object? sender, EventArgs e)
        {
            if (idSelectionne == null) { Ui.Erreur("Sélectionnez d'abord un enseignant dans la liste."); return; }
            if (!Ui.Confirmer($"Supprimer l'enseignant « {txtNom.Text} {txtPrenom.Text} » ?")) return;
            try
            {
                service.Supprimer(idSelectionne.Value);
                Ui.Info("Enseignant supprimé.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        private void btnVider_Click(object? sender, EventArgs e) => Vider();

        private void Vider()
        {
            idSelectionne = null;
            txtNom.Clear();
            txtPrenom.Clear();
            txtEmail.Clear();
            txtSpecialite.Clear();
            grille.ClearSelection();
        }
    }
}