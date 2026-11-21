namespace GestionEcole.UI
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBienvenue = new System.Windows.Forms.Label();
            this.lblTitre = new System.Windows.Forms.Label();
            this.btnEtudiants = new System.Windows.Forms.Button();
            this.btnEnseignants = new System.Windows.Forms.Button();
            this.btnClasses = new System.Windows.Forms.Button();
            this.btnMatieres = new System.Windows.Forms.Button();
            this.btnSalles = new System.Windows.Forms.Button();
            this.btnSeances = new System.Windows.Forms.Button();
            this.btnNotes = new System.Windows.Forms.Button();
            this.btnFermer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBienvenue
            // 
            this.lblBienvenue.AutoSize = true;
            this.lblBienvenue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblBienvenue.ForeColor = System.Drawing.Color.DimGray;
            this.lblBienvenue.Location = new System.Drawing.Point(40, 25);
            this.lblBienvenue.Name = "lblBienvenue";
            this.lblBienvenue.Text = "Bienvenue !";
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.FromArgb(30, 64, 120);
            this.lblTitre.Location = new System.Drawing.Point(36, 50);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Text = "Gérez facilement votre école";
            // 
            // btnEtudiants
            // 
            this.btnEtudiants.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEtudiants.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEtudiants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEtudiants.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEtudiants.ForeColor = System.Drawing.Color.White;
            this.btnEtudiants.Location = new System.Drawing.Point(40, 110);
            this.btnEtudiants.Name = "btnEtudiants";
            this.btnEtudiants.Size = new System.Drawing.Size(250, 50);
            this.btnEtudiants.TabIndex = 0;
            this.btnEtudiants.Text = "Étudiants";
            this.btnEtudiants.UseVisualStyleBackColor = false;
            this.btnEtudiants.Click += new System.EventHandler(this.btnEtudiants_Click);
            // 
            // btnEnseignants
            // 
            this.btnEnseignants.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEnseignants.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnseignants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnseignants.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEnseignants.ForeColor = System.Drawing.Color.White;
            this.btnEnseignants.Location = new System.Drawing.Point(310, 110);
            this.btnEnseignants.Name = "btnEnseignants";
            this.btnEnseignants.Size = new System.Drawing.Size(250, 50);
            this.btnEnseignants.TabIndex = 1;
            this.btnEnseignants.Text = "Enseignants";
            this.btnEnseignants.UseVisualStyleBackColor = false;
            this.btnEnseignants.Click += new System.EventHandler(this.btnEnseignants_Click);
            // 
            // btnClasses
            // 
            this.btnClasses.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClasses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClasses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClasses.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnClasses.ForeColor = System.Drawing.Color.White;
            this.btnClasses.Location = new System.Drawing.Point(40, 170);
            this.btnClasses.Name = "btnClasses";
            this.btnClasses.Size = new System.Drawing.Size(250, 50);
            this.btnClasses.TabIndex = 2;
            this.btnClasses.Text = "Classes";
            this.btnClasses.UseVisualStyleBackColor = false;
            this.btnClasses.Click += new System.EventHandler(this.btnClasses_Click);
            // 
            // btnMatieres
            // 
            this.btnMatieres.BackColor = System.Drawing.Color.SteelBlue;
            this.btnMatieres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMatieres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMatieres.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMatieres.ForeColor = System.Drawing.Color.White;
            this.btnMatieres.Location = new System.Drawing.Point(310, 170);
            this.btnMatieres.Name = "btnMatieres";
            this.btnMatieres.Size = new System.Drawing.Size(250, 50);
            this.btnMatieres.TabIndex = 3;
            this.btnMatieres.Text = "Matières";
            this.btnMatieres.UseVisualStyleBackColor = false;
            this.btnMatieres.Click += new System.EventHandler(this.btnMatieres_Click);
            // 
            // btnSalles
            // 
            this.btnSalles.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSalles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalles.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSalles.ForeColor = System.Drawing.Color.White;
            this.btnSalles.Location = new System.Drawing.Point(40, 230);
            this.btnSalles.Name = "btnSalles";
            this.btnSalles.Size = new System.Drawing.Size(250, 50);
            this.btnSalles.TabIndex = 4;
            this.btnSalles.Text = "Salles";
            this.btnSalles.UseVisualStyleBackColor = false;
            this.btnSalles.Click += new System.EventHandler(this.btnSalles_Click);
            // 
            // btnSeances
            // 
            this.btnSeances.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSeances.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeances.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeances.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSeances.ForeColor = System.Drawing.Color.White;
            this.btnSeances.Location = new System.Drawing.Point(310, 230);
            this.btnSeances.Name = "btnSeances";
            this.btnSeances.Size = new System.Drawing.Size(250, 50);
            this.btnSeances.TabIndex = 5;
            this.btnSeances.Text = "Séances / Emploi du temps";
            this.btnSeances.UseVisualStyleBackColor = false;
            this.btnSeances.Click += new System.EventHandler(this.btnSeances_Click);
            // 
            // btnNotes
            // 
            this.btnNotes.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNotes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnNotes.ForeColor = System.Drawing.Color.White;
            this.btnNotes.Location = new System.Drawing.Point(40, 290);
            this.btnNotes.Name = "btnNotes";
            this.btnNotes.Size = new System.Drawing.Size(250, 50);
            this.btnNotes.TabIndex = 6;
            this.btnNotes.Text = "Notes et moyennes";
            this.btnNotes.UseVisualStyleBackColor = false;
            this.btnNotes.Click += new System.EventHandler(this.btnNotes_Click);
            // 
            // btnFermer
            // 
            this.btnFermer.BackColor = System.Drawing.Color.Gray;
            this.btnFermer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFermer.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnFermer.ForeColor = System.Drawing.Color.White;
            this.btnFermer.Location = new System.Drawing.Point(310, 290);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(250, 50);
            this.btnFermer.TabIndex = 7;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.UseVisualStyleBackColor = false;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 370);
            this.Controls.Add(this.lblBienvenue);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.btnEtudiants);
            this.Controls.Add(this.btnEnseignants);
            this.Controls.Add(this.btnClasses);
            this.Controls.Add(this.btnMatieres);
            this.Controls.Add(this.btnSalles);
            this.Controls.Add(this.btnSeances);
            this.Controls.Add(this.btnNotes);
            this.Controls.Add(this.btnFermer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion d'une école";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenue;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Button btnEtudiants;
        private System.Windows.Forms.Button btnEnseignants;
        private System.Windows.Forms.Button btnClasses;
        private System.Windows.Forms.Button btnMatieres;
        private System.Windows.Forms.Button btnSalles;
        private System.Windows.Forms.Button btnSeances;
        private System.Windows.Forms.Button btnNotes;
        private System.Windows.Forms.Button btnFermer;
    }
}