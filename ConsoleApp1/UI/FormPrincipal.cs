namespace GestionEcole.UI
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        // Ouvre un écran par-dessus l'accueil ; on revient ici quand il est fermé
        private void Ouvrir(Form ecran)
        {
            using (ecran)
            {
                ecran.ShowDialog(this);
            }
        }

        private void btnEtudiants_Click(object? sender, EventArgs e) => Ouvrir(new FormEtudiants());
        private void btnEnseignants_Click(object? sender, EventArgs e) => Ouvrir(new FormEnseignants());
        private void btnClasses_Click(object? sender, EventArgs e) => Ouvrir(new FormClasses());
        private void btnMatieres_Click(object? sender, EventArgs e) => Ouvrir(new FormMatieres());
        private void btnSalles_Click(object? sender, EventArgs e) => Ouvrir(new FormSalles());
        private void btnSeances_Click(object? sender, EventArgs e) => Ouvrir(new FormSeances());
        private void btnNotes_Click(object? sender, EventArgs e) => Ouvrir(new FormNotes());

        private void btnFermer_Click(object? sender, EventArgs e) => Close();
    }
}