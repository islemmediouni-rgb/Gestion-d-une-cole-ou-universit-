using GestionEcole.Models;
using GestionEcole.Services;

namespace GestionEcole.UI
{
    public partial class FormSeances : Form
    {
        private readonly SeanceService service = new SeanceService();
        private int? idSelectionne;
        private bool chargementEnCours;

        public FormSeances()
        {
            InitializeComponent();
        }

        private void FormSeances_Load(object? sender, EventArgs e)
        {
            chargementEnCours = true;
            var classes = new ClasseService().Lister();
            Ui.RemplirCombo(cmbClasse, classes.Select(c => new ElementListe { Id = c.Id, Libelle = c.Nom }));
            Ui.RemplirCombo(cmbFiltreClasse,
                new[] { new ElementListe { Id = null, Libelle = "Toutes" } }
                .Concat(classes.Select(c => new ElementListe { Id = c.Id, Libelle = c.Nom })));
            Ui.RemplirCombo(cmbMatiere, new MatiereService().Lister()
                .Select(m => new ElementListe { Id = m.Id, Libelle = m.Nom }));
            Ui.RemplirCombo(cmbSalle, new SalleService().Lister()
                .Select(s => new ElementListe { Id = s.Id, Libelle = $"{s.Numero} ({s.Capacite} places)" }));
            cmbJour.Items.Clear();
            cmbJour.Items.AddRange(SeanceService.Jours);
            chargementEnCours = false;

            Charger();
        }

        // ===== READ =====
        private void Charger()
        {
            if (chargementEnCours) return;
            grille.DataSource = service.Lister(Ui.IdChoisi(cmbFiltreClasse))
                .Select(s => new
                {
                    s.Id,
                    s.ClasseId,
                    s.MatiereId,
                    s.SalleId,
                    Classe = s.Classe?.Nom,
                    s.Jour,
                    Début = s.HeureDebut,
                    Fin = s.HeureFin,
                    Matière = s.Matiere?.Nom,
                    Salle = s.Salle?.Numero
                })
                .ToList();
            Ui.MasquerColonnesId(grille);
            Vider();
        }

        private void cmbFiltreClasse_SelectedIndexChanged(object? sender, EventArgs e) => Charger();

        private void grille_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e) => grille.ClearSelection();

        private void grille_SelectionChanged(object? sender, EventArgs e)
        {
            var ligne = Ui.LigneSelectionnee(grille);
            if (ligne == null) return;
            idSelectionne = (int)ligne.Cells["Id"].Value;
            cmbClasse.SelectedValue = (int)ligne.Cells["ClasseId"].Value;
            cmbMatiere.SelectedValue = (int)ligne.Cells["MatiereId"].Value;
            cmbSalle.SelectedValue = (int)ligne.Cells["SalleId"].Value;
            cmbJour.SelectedItem = ligne.Cells["Jour"].Value?.ToString();
            dtpDebut.Value = VersDate(ligne.Cells["Début"].Value?.ToString());
            dtpFin.Value = VersDate(ligne.Cells["Fin"].Value?.ToString());
        }

        // "08:30" → DateTime d'aujourd'hui à 08:30 (pour le sélecteur d'heure)
        private static DateTime VersDate(string? heure) =>
            TimeSpan.TryParse(heure, out var t) ? DateTime.Today.Add(t) : DateTime.Today.AddHours(8);

        private Seance LireFormulaire() => new Seance
        {
            Id = idSelectionne ?? 0,
            ClasseId = Ui.IdChoisi(cmbClasse) ?? 0,
            MatiereId = Ui.IdChoisi(cmbMatiere) ?? 0,
            SalleId = Ui.IdChoisi(cmbSalle) ?? 0,
            Jour = cmbJour.SelectedItem?.ToString() ?? "",
            HeureDebut = dtpDebut.Value.ToString("HH:mm"),
            HeureFin = dtpFin.Value.ToString("HH:mm")
        };

        // ===== CREATE =====
        private void btnAjouter_Click(object? sender, EventArgs e)
        {
            try
            {
                var seance = LireFormulaire();
                seance.Id = 0;
                service.Ajouter(seance);
                Ui.Info("Séance planifiée.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        // ===== UPDATE =====
        private void btnModifier_Click(object? sender, EventArgs e)
        {
            if (idSelectionne == null) { Ui.Erreur("Sélectionnez d'abord une séance dans la liste."); return; }
            try
            {
                service.Modifier(LireFormulaire());
                Ui.Info("Séance modifiée.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        // ===== DELETE =====
        private void btnSupprimer_Click(object? sender, EventArgs e)
        {
            if (idSelectionne == null) { Ui.Erreur("Sélectionnez d'abord une séance dans la liste."); return; }
            if (!Ui.Confirmer("Supprimer cette séance ?")) return;
            try
            {
                service.Supprimer(idSelectionne.Value);
                Ui.Info("Séance supprimée.");
                Charger();
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        // ===== Emploi du temps de la classe filtrée =====
        private void btnEmploiDuTemps_Click(object? sender, EventArgs e)
        {
            var classeId = Ui.IdChoisi(cmbFiltreClasse);
            if (classeId == null) { Ui.Erreur("Choisissez une classe dans le filtre « Classe » en haut."); return; }
            try
            {
                MessageBox.Show(service.EmploiDuTemps(classeId.Value), "Emploi du temps",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex) { Ui.Erreur(ex.Message); }
        }

        private void btnVider_Click(object? sender, EventArgs e) => Vider();

        private void Vider()
        {
            idSelectionne = null;
            cmbJour.SelectedIndex = cmbJour.Items.Count > 0 ? 0 : -1;
            dtpDebut.Value = DateTime.Today.AddHours(8).AddMinutes(30);
            dtpFin.Value = DateTime.Today.AddHours(10);
            grille.ClearSelection();
        }
    }
}