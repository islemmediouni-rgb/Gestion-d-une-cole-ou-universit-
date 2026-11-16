using GestionEcole.Models;
using GestionEcole.Services;

namespace GestionEcole.UI
{
    public class FormSalles : Form
    {
        private readonly SalleService service = new SalleService();

        // Id de la salle sélectionnée dans la grille (null = aucune)
        private int? idSelectionne = null;

        // ===== Contrôles =====
        private readonly DataGridView grille = new DataGridView();
        private readonly TextBox txtNumero = new TextBox();
        private readonly NumericUpDown numCapacite = new NumericUpDown();
        private readonly Button btnAjouter = new Button();
        private readonly Button btnModifier = new Button();
        private readonly Button btnSupprimer = new Button();
        private readonly Button btnVider = new Button();

        public FormSalles()
        {
            Text = "Gestion des salles";
            Size = new Size(900, 450);
            StartPosition = FormStartPosition.CenterScreen;

            // ----- Grille -----
            grille.Dock = DockStyle.Fill;
            grille.ReadOnly = true;
            grille.AllowUserToAddRows = false;
            grille.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grille.MultiSelect = false;
            grille.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ----- Panneau de saisie -----
            var panneau = new Panel { Dock = DockStyle.Left, Width = 250 };

            var lblNumero = new Label { Text = "Numéro de salle *", Location = new Point(20, 20), AutoSize = true };
            txtNumero.Location = new Point(20, 45);
            txtNumero.Width = 200;

            var lblCapacite = new Label { Text = "Capacité *", Location = new Point(20, 85), AutoSize = true };
            numCapacite.Location = new Point(20, 110);
            numCapacite.Width = 200;
            numCapacite.Minimum = 1;
            numCapacite.Maximum = 500;
            numCapacite.Value = 30;

            ConfigurerBouton(btnAjouter,   "Ajouter",   20,  160, Color.SeaGreen);
            ConfigurerBouton(btnModifier,  "Modifier",  125, 160, Color.SteelBlue);
            ConfigurerBouton(btnSupprimer, "Supprimer", 20,  205, Color.Firebrick);
            ConfigurerBouton(btnVider,     "Vider",     125, 205, Color.Gray);

            panneau.Controls.AddRange(new Control[]
            {
                lblNumero, txtNumero, lblCapacite, numCapacite,
                btnAjouter, btnModifier, btnSupprimer, btnVider
            });

            // Ordre important : d'abord le Fill, ensuite le Left
            Controls.Add(grille);
            Controls.Add(panneau);

            // ----- Événements -----
            Load += (sender, e) => { ChargerSalles(); ViderFormulaire(); };
            grille.DataBindingComplete += (sender, e) => grille.ClearSelection();
            grille.SelectionChanged += (sender, e) => RemplirDepuisSelection();
            btnAjouter.Click += (sender, e) => Ajouter();
            btnModifier.Click += (sender, e) => Modifier();
            btnSupprimer.Click += (sender, e) => Supprimer();
            btnVider.Click += (sender, e) => ViderFormulaire();
        }

        // ===== READ =====
        private void ChargerSalles()
        {
            grille.DataSource = service.Lister()
                .Select(s => new { s.Id, s.Numero, s.Capacite })
                .ToList();
        }

        // Clic sur une ligne → remplir le formulaire
        private void RemplirDepuisSelection()
        {
            if (grille.CurrentRow == null || !grille.CurrentRow.Selected) return;

            idSelectionne = (int)grille.CurrentRow.Cells["Id"].Value;
            txtNumero.Text = grille.CurrentRow.Cells["Numero"].Value.ToString();
            numCapacite.Value = (int)grille.CurrentRow.Cells["Capacite"].Value;
        }

        // ===== CREATE =====
        private void Ajouter()
        {
            try
            {
                var salle = new Salle
                {
                    Numero = txtNumero.Text,
                    Capacite = (int)numCapacite.Value
                };
                service.Ajouter(salle);

                Info("Salle ajoutée.");
                ChargerSalles();
                ViderFormulaire();
            }
            catch (ArgumentException ex) { Erreur(ex.Message); }
        }

        // ===== UPDATE =====
        private void Modifier()
        {
            if (idSelectionne == null) { Erreur("Sélectionnez d'abord une salle dans la liste."); return; }

            try
            {
                var salle = new Salle
                {
                    Id = idSelectionne.Value,
                    Numero = txtNumero.Text,
                    Capacite = (int)numCapacite.Value
                };
                service.Modifier(salle);

                Info("Salle modifiée.");
                ChargerSalles();
                ViderFormulaire();
            }
            catch (ArgumentException ex) { Erreur(ex.Message); }
        }

        // ===== DELETE =====
        private void Supprimer()
        {
            if (idSelectionne == null) { Erreur("Sélectionnez d'abord une salle dans la liste."); return; }

            var reponse = MessageBox.Show($"Supprimer la salle « {txtNumero.Text} » ?", "Confirmation",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reponse != DialogResult.Yes) return;

            try
            {
                service.Supprimer(idSelectionne.Value);

                Info("Salle supprimée.");
                ChargerSalles();
                ViderFormulaire();
            }
            catch (ArgumentException ex) { Erreur(ex.Message); }
        }

        // ===== Outils =====
        private void ViderFormulaire()
        {
            idSelectionne = null;
            txtNumero.Clear();
            numCapacite.Value = 30;
            grille.ClearSelection();
            txtNumero.Focus();
        }

        private static void ConfigurerBouton(Button b, string texte, int x, int y, Color couleur)
        {
            b.Text = texte;
            b.Location = new Point(x, y);
            b.Size = new Size(95, 35);
            b.BackColor = couleur;
            b.ForeColor = Color.White;
            b.FlatStyle = FlatStyle.Flat;
        }

        private static void Info(string message) =>
            MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private static void Erreur(string message) =>
            MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}