namespace GestionEcole.UI
{
    partial class FormEnseignants
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
            this.grille = new System.Windows.Forms.DataGridView();
            this.panelFiltre = new System.Windows.Forms.Panel();
            this.lblRecherche = new System.Windows.Forms.Label();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.panelSaisie = new System.Windows.Forms.Panel();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblSpecialite = new System.Windows.Forms.Label();
            this.txtSpecialite = new System.Windows.Forms.TextBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnVider = new System.Windows.Forms.Button();
            this.panelFiltre.SuspendLayout();
            this.panelSaisie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grille)).BeginInit();
            this.SuspendLayout();
            // 
            // grille
            // 
            this.grille.AllowUserToAddRows = false;
            this.grille.AllowUserToDeleteRows = false;
            this.grille.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grille.BackgroundColor = System.Drawing.Color.White;
            this.grille.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grille.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grille.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grille.Location = new System.Drawing.Point(300, 50);
            this.grille.MultiSelect = false;
            this.grille.ReadOnly = true;
            this.grille.RowHeadersVisible = false;
            this.grille.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grille.Size = new System.Drawing.Size(800, 550);
            this.grille.TabIndex = 2;
            this.grille.Name = "grille";
            this.grille.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grille_DataBindingComplete);
            this.grille.SelectionChanged += new System.EventHandler(this.grille_SelectionChanged);
            // 
            // panelFiltre
            // 
            this.panelFiltre.Controls.Add(this.lblRecherche);
            this.panelFiltre.Controls.Add(this.txtRecherche);
            this.panelFiltre.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltre.Location = new System.Drawing.Point(300, 0);
            this.panelFiltre.Padding = new System.Windows.Forms.Padding(10);
            this.panelFiltre.Size = new System.Drawing.Size(800, 50);
            this.panelFiltre.TabIndex = 1;
            this.panelFiltre.Name = "panelFiltre";
            // 
            // lblRecherche
            // 
            this.lblRecherche.Location = new System.Drawing.Point(10, 17);
            this.lblRecherche.AutoSize = true;
            this.lblRecherche.Text = "Rechercher :";
            this.lblRecherche.Name = "lblRecherche";
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(110, 13);
            this.txtRecherche.Size = new System.Drawing.Size(220, 23);
            this.txtRecherche.TabIndex = 0;
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);
            // 
            // panelSaisie
            // 
            this.panelSaisie.Controls.Add(this.lblNom);
            this.panelSaisie.Controls.Add(this.txtNom);
            this.panelSaisie.Controls.Add(this.lblPrenom);
            this.panelSaisie.Controls.Add(this.txtPrenom);
            this.panelSaisie.Controls.Add(this.lblEmail);
            this.panelSaisie.Controls.Add(this.txtEmail);
            this.panelSaisie.Controls.Add(this.lblSpecialite);
            this.panelSaisie.Controls.Add(this.txtSpecialite);
            this.panelSaisie.Controls.Add(this.btnAjouter);
            this.panelSaisie.Controls.Add(this.btnModifier);
            this.panelSaisie.Controls.Add(this.btnSupprimer);
            this.panelSaisie.Controls.Add(this.btnVider);
            this.panelSaisie.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelSaisie.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSaisie.Location = new System.Drawing.Point(0, 0);
            this.panelSaisie.Size = new System.Drawing.Size(300, 600);
            this.panelSaisie.TabIndex = 0;
            this.panelSaisie.Name = "panelSaisie";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(20, 20);
            this.lblNom.Text = "Nom *";
            this.lblNom.Name = "lblNom";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(20, 42);
            this.txtNom.Size = new System.Drawing.Size(260, 23);
            this.txtNom.TabIndex = 0;
            this.txtNom.Name = "txtNom";
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(20, 78);
            this.lblPrenom.Text = "Prénom *";
            this.lblPrenom.Name = "lblPrenom";
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(20, 100);
            this.txtPrenom.Size = new System.Drawing.Size(260, 23);
            this.txtPrenom.TabIndex = 1;
            this.txtPrenom.Name = "txtPrenom";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 136);
            this.lblEmail.Text = "Email *";
            this.lblEmail.Name = "lblEmail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(20, 158);
            this.txtEmail.Size = new System.Drawing.Size(260, 23);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Name = "txtEmail";
            // 
            // lblSpecialite
            // 
            this.lblSpecialite.AutoSize = true;
            this.lblSpecialite.Location = new System.Drawing.Point(20, 194);
            this.lblSpecialite.Text = "Spécialité *";
            this.lblSpecialite.Name = "lblSpecialite";
            // 
            // txtSpecialite
            // 
            this.txtSpecialite.Location = new System.Drawing.Point(20, 216);
            this.txtSpecialite.Size = new System.Drawing.Size(260, 23);
            this.txtSpecialite.TabIndex = 3;
            this.txtSpecialite.Name = "txtSpecialite";
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(20, 262);
            this.btnAjouter.Size = new System.Drawing.Size(125, 38);
            this.btnAjouter.TabIndex = 4;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.SteelBlue;
            this.btnModifier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.Location = new System.Drawing.Point(155, 262);
            this.btnModifier.Size = new System.Drawing.Size(125, 38);
            this.btnModifier.TabIndex = 5;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Firebrick;
            this.btnSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(20, 308);
            this.btnSupprimer.Size = new System.Drawing.Size(125, 38);
            this.btnSupprimer.TabIndex = 6;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnVider
            // 
            this.btnVider.BackColor = System.Drawing.Color.Gray;
            this.btnVider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVider.ForeColor = System.Drawing.Color.White;
            this.btnVider.Location = new System.Drawing.Point(155, 308);
            this.btnVider.Size = new System.Drawing.Size(125, 38);
            this.btnVider.TabIndex = 7;
            this.btnVider.Text = "Vider";
            this.btnVider.UseVisualStyleBackColor = false;
            this.btnVider.Name = "btnVider";
            this.btnVider.Click += new System.EventHandler(this.btnVider_Click);
            // 
            // FormEnseignants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.grille);
            this.Controls.Add(this.panelFiltre);
            this.Controls.Add(this.panelSaisie);
            this.Name = "FormEnseignants";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion des enseignants";
            this.Load += new System.EventHandler(this.FormEnseignants_Load);
            this.panelFiltre.ResumeLayout(false);
            this.panelFiltre.PerformLayout();
            this.panelSaisie.ResumeLayout(false);
            this.panelSaisie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grille)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grille;
        private System.Windows.Forms.Panel panelFiltre;
        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.Panel panelSaisie;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblSpecialite;
        private System.Windows.Forms.TextBox txtSpecialite;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnVider;
    }
}