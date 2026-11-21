using GestionEcole.Services;

namespace GestionEcole.UI
{
    public partial class FormNotes : Form
    {
        private readonly NoteService service = new NoteService();
        private int? idSelectionne;
        private bool chargementEnCours;

        public FormNotes()
        {
            InitializeComponent();
        }

        private void FormNotes_Load(object? sender, EventArgs e)
        {
            chargementEnCours = true;
            var etudiants = new EtudiantService().Lister()
                .Select(p => new ElementListe { Id = p.Id, Libelle = $"{p.Matricule} - {p.GetNomComplet()}" })
                .ToList();
            Ui.RemplirCombo(cmbEtudiant, etudiants);
            Ui.RemplirCombo(cmbFiltreEtudiant,
                new[] { new ElementListe { Id = null, Libelle = "Tous" } }.Concat(etudiants));
            Ui.RemplirCombo(cmbMatiere, new MatiereService().Lister()
                .Select(m => new ElementListe { Id = m.Id, Libelle = $"{m.Nom} (coef. {m.Coefficient})" }));
            chargementEnCours = false;

            Charger();
        }

        // ===== READ =====
        private void Charger()
        {
            if (chargementEnCours) return;
            var etudiantId = Ui.IdChoisi(cmbFiltreEtudiant);

            grille.DataSource = service.Lister(etudiantId)
                .Select(n => new
                {
                    n.Id,
                    n.EtudiantId,
                    n.MatiereId,
                    Étudiant = n.Etudiant?.GetNomComplet(),
                    Matricule = n.Etudiant?.Matricule,
                    Matière = n.Matiere?.Nom,
                    Coefficient = n.Matiere?.Coefficient,
                    Note = n.Valeur
                })
                .ToList();
            Ui.MasquerColonnesId(grille);

            // Moyenne pondérée de l'étudiant filtré (méthode CalculerMoyenne du diagramme)
            lblMoyenne.Text = etudiantId.HasValue
                ? $"Moyenne pondérée : {service.MoyenneEtudiant(etudiantId.Value):0.00} / 20"
                : "Moyenne : choisissez un étudiant";
            Vider();
        }

        private void cmbFiltreEtudiant_SelectedIndexChanged(object? sender, EventArgs e) => Charger();

        private void grille_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e) => grille.ClearSelection();

        private void grille_SelectionChanged(object? sender, EventArgs e)
        {
            var ligne = Ui.LigneSelectionnee(grille);
            if (ligne == null) return;
            idSelectionne = (int)ligne.Cells["Id"].Value;
            cmbEtudiant.SelectedValue = (int)ligne.Cells["EtudiantId"].Value;
            cmbMatiere.SelectedValue = (int)ligne.Cells["MatiereId"].Value;
            numValeur.Value = Convert.ToDecimal(ligne.Cells["Note"].Value);
        }

        // ===== CREATE (saisie par l'enseignant de la matière) =====
        private void btnAjouter_Click(object? sender, EventArgs e)
        {
            try
            {
                service.Ajouter(Ui.IdChoisi(cmbEtudiant) ?? 0, Ui.IdChoisi(cmbMatiere) ?? 0, (double)numValeur.Value);
                Ui.Info("Note enregistrée.");
                Charger();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException) { Ui.Erreur(ex.Message); }
        }

        // ===== UPDATE =====
        private void btnModifier_Click(object? sender, EventArgs e)
        {
            if (idSelectionne == null) { Ui.Erreur("Sélectionnez d'abord une note dans la liste."); return; }
            try
            {
                service.Modifier(idSelectionne.Value, Ui.IdChoisi(cmbEtudiant) ?? 0, Ui.IdChoisi(cmbMatiere) ?? 0, (double)numValeur.Value);
                Ui.Info("Note modifiée.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        // ===== DELETE =====
        private void btnSupprimer_Click(object? sender, EventArgs e)
        {
            if (idSelectionne == null) { Ui.Erreur("Sélectionnez d'abord une note dans la liste."); return; }
            if (!Ui.Confirmer("Supprimer cette note ?")) return;
            try
            {
                service.Supprimer(idSelectionne.Value);
                Ui.Info("Note supprimée.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        private void btnVider_Click(object? sender, EventArgs e) => Vider();

        private void Vider()
        {
            idSelectionne = null;
            numValeur.Value = 10;
            grille.ClearSelection();
        }
    }
}