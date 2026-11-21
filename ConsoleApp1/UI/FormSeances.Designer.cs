namespace GestionEcole.UI
{
    partial class FormSeances
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
            this.lblFiltreClasse = new System.Windows.Forms.Label();
            this.cmbFiltreClasse = new System.Windows.Forms.ComboBox();
            this.btnEmploiDuTemps = new System.Windows.Forms.Button();
            this.panelSaisie = new System.Windows.Forms.Panel();
            this.lblClasse = new System.Windows.Forms.Label();
            this.cmbClasse = new System.Windows.Forms.ComboBox();
            this.lblMatiere = new System.Windows.Forms.Label();
            this.cmbMatiere = new System.Windows.Forms.ComboBox();
            this.lblSalle = new System.Windows.Forms.Label();
            this.cmbSalle = new System.Windows.Forms.ComboBox();
            this.lblJour = new System.Windows.Forms.Label();
            this.cmbJour = new System.Windows.Forms.ComboBox();
            this.lblDebut = new System.Windows.Forms.Label();
            this.dtpDebut = new System.Windows.Forms.DateTimePicker();
            this.lblFin = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
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
            this.panelFiltre.Controls.Add(this.lblFiltreClasse);
            this.panelFiltre.Controls.Add(this.cmbFiltreClasse);
            this.panelFiltre.Controls.Add(this.btnEmploiDuTemps);
            this.panelFiltre.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltre.Location = new System.Drawing.Point(300, 0);
            this.panelFiltre.Padding = new System.Windows.Forms.Padding(10);
            this.panelFiltre.Size = new System.Drawing.Size(800, 50);
            this.panelFiltre.TabIndex = 1;
            this.panelFiltre.Name = "panelFiltre";
            // 
            // lblFiltreClasse
            // 
            this.lblFiltreClasse.Location = new System.Drawing.Point(10, 17);
            this.lblFiltreClasse.AutoSize = true;
            this.lblFiltreClasse.Text = "Classe :";
            this.lblFiltreClasse.Name = "lblFiltreClasse";
            // 
            // cmbFiltreClasse
            // 
            this.cmbFiltreClasse.Location = new System.Drawing.Point(70, 13);
            this.cmbFiltreClasse.Size = new System.Drawing.Size(180, 23);
            this.cmbFiltreClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltreClasse.FormattingEnabled = true;
            this.cmbFiltreClasse.TabIndex = 0;
            this.cmbFiltreClasse.Name = "cmbFiltreClasse";
            this.cmbFiltreClasse.SelectedIndexChanged += new System.EventHandler(this.cmbFiltreClasse_SelectedIndexChanged);
            // 
            // btnEmploiDuTemps
            // 
            this.btnEmploiDuTemps.Location = new System.Drawing.Point(270, 13);
            this.btnEmploiDuTemps.Size = new System.Drawing.Size(220, 28);
            this.btnEmploiDuTemps.Text = "Afficher l'emploi du temps";
            this.btnEmploiDuTemps.TabIndex = 1;
            this.btnEmploiDuTemps.UseVisualStyleBackColor = true;
            this.btnEmploiDuTemps.Name = "btnEmploiDuTemps";
            this.btnEmploiDuTemps.Click += new System.EventHandler(this.btnEmploiDuTemps_Click);
            // 
            // panelSaisie
            // 
            this.panelSaisie.Controls.Add(this.lblClasse);
            this.panelSaisie.Controls.Add(this.cmbClasse);
            this.panelSaisie.Controls.Add(this.lblMatiere);
            this.panelSaisie.Controls.Add(this.cmbMatiere);
            this.panelSaisie.Controls.Add(this.lblSalle);
            this.panelSaisie.Controls.Add(this.cmbSalle);
            this.panelSaisie.Controls.Add(this.lblJour);
            this.panelSaisie.Controls.Add(this.cmbJour);
            this.panelSaisie.Controls.Add(this.lblDebut);
            this.panelSaisie.Controls.Add(this.dtpDebut);
            this.panelSaisie.Controls.Add(this.lblFin);
            this.panelSaisie.Controls.Add(this.dtpFin);
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
            // lblClasse
            // 
            this.lblClasse.AutoSize = true;
            this.lblClasse.Location = new System.Drawing.Point(20, 20);
            this.lblClasse.Text = "Classe *";
            this.lblClasse.Name = "lblClasse";
            // 
            // cmbClasse
            // 
            this.cmbClasse.Location = new System.Drawing.Point(20, 42);
            this.cmbClasse.Size = new System.Drawing.Size(260, 23);
            this.cmbClasse.TabIndex = 0;
            this.cmbClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClasse.FormattingEnabled = true;
            this.cmbClasse.Name = "cmbClasse";
            // 
            // lblMatiere
            // 
            this.lblMatiere.AutoSize = true;
            this.lblMatiere.Location = new System.Drawing.Point(20, 78);
            this.lblMatiere.Text = "Matière *";
            this.lblMatiere.Name = "lblMatiere";
            // 
            // cmbMatiere
            // 
            this.cmbMatiere.Location = new System.Drawing.Point(20, 100);
            this.cmbMatiere.Size = new System.Drawing.Size(260, 23);
            this.cmbMatiere.TabIndex = 1;
            this.cmbMatiere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMatiere.FormattingEnabled = true;
            this.cmbMatiere.Name = "cmbMatiere";
            // 
            // lblSalle
            // 
            this.lblSalle.AutoSize = true;
            this.lblSalle.Location = new System.Drawing.Point(20, 136);
            this.lblSalle.Text = "Salle *";
            this.lblSalle.Name = "lblSalle";
            // 
            // cmbSalle
            // 
            this.cmbSalle.Location = new System.Drawing.Point(20, 158);
            this.cmbSalle.Size = new System.Drawing.Size(260, 23);
            this.cmbSalle.TabIndex = 2;
            this.cmbSalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalle.FormattingEnabled = true;
            this.cmbSalle.Name = "cmbSalle";
            // 
            // lblJour
            // 
            this.lblJour.AutoSize = true;
            this.lblJour.Location = new System.Drawing.Point(20, 194);
            this.lblJour.Text = "Jour *";
            this.lblJour.Name = "lblJour";
            // 
            // cmbJour
            // 
            this.cmbJour.Location = new System.Drawing.Point(20, 216);
            this.cmbJour.Size = new System.Drawing.Size(260, 23);
            this.cmbJour.TabIndex = 3;
            this.cmbJour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJour.FormattingEnabled = true;
            this.cmbJour.Name = "cmbJour";
            // 
            // lblDebut
            // 
            this.lblDebut.AutoSize = true;
            this.lblDebut.Location = new System.Drawing.Point(20, 252);
            this.lblDebut.Text = "Heure de début *";
            this.lblDebut.Name = "lblDebut";
            // 
            // dtpDebut
            // 
            this.dtpDebut.Location = new System.Drawing.Point(20, 274);
            this.dtpDebut.Size = new System.Drawing.Size(260, 23);
            this.dtpDebut.TabIndex = 4;
            this.dtpDebut.CustomFormat = "HH:mm";
            this.dtpDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDebut.ShowUpDown = true;
            this.dtpDebut.Name = "dtpDebut";
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Location = new System.Drawing.Point(20, 310);
            this.lblFin.Text = "Heure de fin *";
            this.lblFin.Name = "lblFin";
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(20, 332);
            this.dtpFin.Size = new System.Drawing.Size(260, 23);
            this.dtpFin.TabIndex = 5;
            this.dtpFin.CustomFormat = "HH:mm";
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.ShowUpDown = true;
            this.dtpFin.Name = "dtpFin";
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(20, 378);
            this.btnAjouter.Size = new System.Drawing.Size(125, 38);
            this.btnAjouter.TabIndex = 6;
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
            this.btnModifier.Location = new System.Drawing.Point(155, 378);
            this.btnModifier.Size = new System.Drawing.Size(125, 38);
            this.btnModifier.TabIndex = 7;
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
            this.btnSupprimer.Location = new System.Drawing.Point(20, 424);
            this.btnSupprimer.Size = new System.Drawing.Size(125, 38);
            this.btnSupprimer.TabIndex = 8;
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
            this.btnVider.Location = new System.Drawing.Point(155, 424);
            this.btnVider.Size = new System.Drawing.Size(125, 38);
            this.btnVider.TabIndex = 9;
            this.btnVider.Text = "Vider";
            this.btnVider.UseVisualStyleBackColor = false;
            this.btnVider.Name = "btnVider";
            this.btnVider.Click += new System.EventHandler(this.btnVider_Click);
            // 
            // FormSeances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.grille);
            this.Controls.Add(this.panelFiltre);
            this.Controls.Add(this.panelSaisie);
            this.Name = "FormSeances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion des séances (emploi du temps)";
            this.Load += new System.EventHandler(this.FormSeances_Load);
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
        private System.Windows.Forms.Label lblFiltreClasse;
        private System.Windows.Forms.ComboBox cmbFiltreClasse;
        private System.Windows.Forms.Button btnEmploiDuTemps;
        private System.Windows.Forms.Panel panelSaisie;
        private System.Windows.Forms.Label lblClasse;
        private System.Windows.Forms.ComboBox cmbClasse;
        private System.Windows.Forms.Label lblMatiere;
        private System.Windows.Forms.ComboBox cmbMatiere;
        private System.Windows.Forms.Label lblSalle;
        private System.Windows.Forms.ComboBox cmbSalle;
        private System.Windows.Forms.Label lblJour;
        private System.Windows.Forms.ComboBox cmbJour;
        private System.Windows.Forms.Label lblDebut;
        private System.Windows.Forms.DateTimePicker dtpDebut;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnVider;
    }
}