using GestionEcole.Models;
using GestionEcole.Services;

namespace GestionEcole.UI
{
    public partial class FormEtudiants : Form
    {
        private readonly EtudiantService service = new EtudiantService();
        private readonly ClasseService classeService = new ClasseService();
        private int? idSelectionne;
        private bool chargementEnCours;   // évite de recharger pendant le remplissage des listes

        public FormEtudiants()
        {
            InitializeComponent();
        }

        private void FormEtudiants_Load(object? sender, EventArgs e)
        {
            chargementEnCours = true;
            var classes = classeService.Lister();
            Ui.RemplirCombo(cmbClasse, classes.Select(c => new ElementListe { Id = c.Id, Libelle = c.Nom }));
            Ui.RemplirCombo(cmbFiltreClasse,
                new[] { new ElementListe { Id = null, Libelle = "Toutes" } }
                .Concat(classes.Select(c => new ElementListe { Id = c.Id, Libelle = c.Nom })));
            chargementEnCours = false;

            Charger();
            if (classes.Count == 0)
                Ui.Erreur("Aucune classe : créez d'abord une classe avant d'ajouter un étudiant.");
        }

        // ===== READ =====
        private void Charger()
        {
            if (chargementEnCours) return;
            grille.DataSource = service.Lister(txtRecherche.Text, Ui.IdChoisi(cmbFiltreClasse))
                .Select(p =>
                {
                    var inscription = EtudiantService.DerniereInscription(p);
                    return new
                    {
                        p.Id,
                        ClasseId = inscription?.ClasseId ?? 0,
                        p.Matricule,
                        p.Nom,
                        Prénom = p.Prenom,
                        p.Email,
                        Classe = inscription?.Classe?.Nom,
                        Année = inscription?.AnneeUniversitaire
                    };
                })
                .ToList();
            Ui.MasquerColonnesId(grille);
            Vider();
        }

        private void txtRecherche_TextChanged(object? sender, EventArgs e) => Charger();
        private void cmbFiltreClasse_SelectedIndexChanged(object? sender, EventArgs e) => Charger();

        private void grille_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e) => grille.ClearSelection();

        private void grille_SelectionChanged(object? sender, EventArgs e)
        {
            var ligne = Ui.LigneSelectionnee(grille);
            if (ligne == null) return;
            idSelectionne = (int)ligne.Cells["Id"].Value;
            txtMatricule.Text = ligne.Cells["Matricule"].Value?.ToString();
            txtNom.Text = ligne.Cells["Nom"].Value?.ToString();
            txtPrenom.Text = ligne.Cells["Prénom"].Value?.ToString();
            txtEmail.Text = ligne.Cells["Email"].Value?.ToString();
            cmbClasse.SelectedValue = (int)ligne.Cells["ClasseId"].Value;
            txtAnnee.Text = ligne.Cells["Année"].Value?.ToString() ?? "2026-2027";
        }

        private Etudiant LireFormulaire() => new Etudiant
        {
            Id = idSelectionne ?? 0,
            Matricule = txtMatricule.Text,
            Nom = txtNom.Text,
            Prenom = txtPrenom.Text,
            Email = txtEmail.Text
        };

        // ===== CREATE (étudiant + inscription dans la classe) =====
        private void btnAjouter_Click(object? sender, EventArgs e)
        {
            try
            {
                var etudiant = LireFormulaire();
                etudiant.Id = 0;
                service.Ajouter(etudiant, Ui.IdChoisi(cmbClasse) ?? 0, txtAnnee.Text.Trim());
                Ui.Info("Étudiant ajouté et inscrit.");
                Charger();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException) { Ui.Erreur(ex.Message); }
        }

        // ===== UPDATE =====
        private void btnModifier_Click(object? sender, EventArgs e)
        {
            if (idSelectionne == null) { Ui.Erreur("Sélectionnez d'abord un étudiant dans la liste."); return; }
            try
            {
                service.Modifier(LireFormulaire(), Ui.IdChoisi(cmbClasse) ?? 0, txtAnnee.Text.Trim());
                Ui.Info("Étudiant modifié.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        // ===== DELETE =====
        private void btnSupprimer_Click(object? sender, EventArgs e)
        {
            if (idSelectionne == null) { Ui.Erreur("Sélectionnez d'abord un étudiant dans la liste."); return; }
            if (!Ui.Confirmer($"Supprimer l'étudiant « {txtNom.Text} {txtPrenom.Text} » ?\n\nSes notes et ses inscriptions seront aussi supprimées.")) return;
            try
            {
                service.Supprimer(idSelectionne.Value);
                Ui.Info("Étudiant supprimé.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        private void btnVider_Click(object? sender, EventArgs e) => Vider();

        private void Vider()
        {
            idSelectionne = null;
            txtMatricule.Clear();
            txtNom.Clear();
            txtPrenom.Clear();
            txtEmail.Clear();
            txtAnnee.Text = "2026-2027";
            grille.ClearSelection();
        }
    }
}