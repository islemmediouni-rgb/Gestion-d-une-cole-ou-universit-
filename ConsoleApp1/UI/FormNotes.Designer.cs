namespace GestionEcole.UI
{
    partial class FormNotes
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
            this.lblFiltreEtudiant = new System.Windows.Forms.Label();
            this.cmbFiltreEtudiant = new System.Windows.Forms.ComboBox();
            this.lblMoyenne = new System.Windows.Forms.Label();
            this.panelSaisie = new System.Windows.Forms.Panel();
            this.lblEtudiant = new System.Windows.Forms.Label();
            this.cmbEtudiant = new System.Windows.Forms.ComboBox();
            this.lblMatiere = new System.Windows.Forms.Label();
            this.cmbMatiere = new System.Windows.Forms.ComboBox();
            this.lblValeur = new System.Windows.Forms.Label();
            this.numValeur = new System.Windows.Forms.NumericUpDown();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnVider = new System.Windows.Forms.Button();
            this.panelFiltre.SuspendLayout();
            this.panelSaisie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grille)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValeur)).BeginInit();
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
            this.panelFiltre.Controls.Add(this.lblFiltreEtudiant);
            this.panelFiltre.Controls.Add(this.cmbFiltreEtudiant);
            this.panelFiltre.Controls.Add(this.lblMoyenne);
            this.panelFiltre.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltre.Location = new System.Drawing.Point(300, 0);
            this.panelFiltre.Padding = new System.Windows.Forms.Padding(10);
            this.panelFiltre.Size = new System.Drawing.Size(800, 50);
            this.panelFiltre.TabIndex = 1;
            this.panelFiltre.Name = "panelFiltre";
            // 
            // lblFiltreEtudiant
            // 
            this.lblFiltreEtudiant.Location = new System.Drawing.Point(10, 17);
            this.lblFiltreEtudiant.AutoSize = true;
            this.lblFiltreEtudiant.Text = "Étudiant :";
            this.lblFiltreEtudiant.Name = "lblFiltreEtudiant";
            // 
            // cmbFiltreEtudiant
            // 
            this.cmbFiltreEtudiant.Location = new System.Drawing.Point(80, 13);
            this.cmbFiltreEtudiant.Size = new System.Drawing.Size(260, 23);
            this.cmbFiltreEtudiant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltreEtudiant.FormattingEnabled = true;
            this.cmbFiltreEtudiant.TabIndex = 0;
            this.cmbFiltreEtudiant.Name = "cmbFiltreEtudiant";
            this.cmbFiltreEtudiant.SelectedIndexChanged += new System.EventHandler(this.cmbFiltreEtudiant_SelectedIndexChanged);
            // 
            // lblMoyenne
            // 
            this.lblMoyenne.Location = new System.Drawing.Point(360, 17);
            this.lblMoyenne.AutoSize = true;
            this.lblMoyenne.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMoyenne.Text = "Moyenne : -";
            this.lblMoyenne.Name = "lblMoyenne";
            // 
            // panelSaisie
            // 
            this.panelSaisie.Controls.Add(this.lblEtudiant);
            this.panelSaisie.Controls.Add(this.cmbEtudiant);
            this.panelSaisie.Controls.Add(this.lblMatiere);
            this.panelSaisie.Controls.Add(this.cmbMatiere);
            this.panelSaisie.Controls.Add(this.lblValeur);
            this.panelSaisie.Controls.Add(this.numValeur);
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
            // lblEtudiant
            // 
            this.lblEtudiant.AutoSize = true;
            this.lblEtudiant.Location = new System.Drawing.Point(20, 20);
            this.lblEtudiant.Text = "Étudiant *";
            this.lblEtudiant.Name = "lblEtudiant";
            // 
            // cmbEtudiant
            // 
            this.cmbEtudiant.Location = new System.Drawing.Point(20, 42);
            this.cmbEtudiant.Size = new System.Drawing.Size(260, 23);
            this.cmbEtudiant.TabIndex = 0;
            this.cmbEtudiant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEtudiant.FormattingEnabled = true;
            this.cmbEtudiant.Name = "cmbEtudiant";
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
            // lblValeur
            // 
            this.lblValeur.AutoSize = true;
            this.lblValeur.Location = new System.Drawing.Point(20, 136);
            this.lblValeur.Text = "Note sur 20 *";
            this.lblValeur.Name = "lblValeur";
            // 
            // numValeur
            // 
            this.numValeur.Location = new System.Drawing.Point(20, 158);
            this.numValeur.Size = new System.Drawing.Size(260, 23);
            this.numValeur.TabIndex = 2;
            this.numValeur.DecimalPlaces = 2;
            this.numValeur.Increment = new decimal(new int[] { 25, 0, 0, 131072 });
            this.numValeur.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.numValeur.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numValeur.Value = new decimal(new int[] { 10, 0, 0, 0 });
            this.numValeur.Name = "numValeur";
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(20, 204);
            this.btnAjouter.Size = new System.Drawing.Size(125, 38);
            this.btnAjouter.TabIndex = 3;
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
            this.btnModifier.Location = new System.Drawing.Point(155, 204);
            this.btnModifier.Size = new System.Drawing.Size(125, 38);
            this.btnModifier.TabIndex = 4;
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
            this.btnSupprimer.Location = new System.Drawing.Point(20, 250);
            this.btnSupprimer.Size = new System.Drawing.Size(125, 38);
            this.btnSupprimer.TabIndex = 5;
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
            this.btnVider.Location = new System.Drawing.Point(155, 250);
            this.btnVider.Size = new System.Drawing.Size(125, 38);
            this.btnVider.TabIndex = 6;
            this.btnVider.Text = "Vider";
            this.btnVider.UseVisualStyleBackColor = false;
            this.btnVider.Name = "btnVider";
            this.btnVider.Click += new System.EventHandler(this.btnVider_Click);
            // 
            // FormNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.grille);
            this.Controls.Add(this.panelFiltre);
            this.Controls.Add(this.panelSaisie);
            this.Name = "FormNotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion des notes";
            this.Load += new System.EventHandler(this.FormNotes_Load);
            this.panelFiltre.ResumeLayout(false);
            this.panelFiltre.PerformLayout();
            this.panelSaisie.ResumeLayout(false);
            this.panelSaisie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grille)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValeur)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grille;
        private System.Windows.Forms.Panel panelFiltre;
        private System.Windows.Forms.Label lblFiltreEtudiant;
        private System.Windows.Forms.ComboBox cmbFiltreEtudiant;
        private System.Windows.Forms.Label lblMoyenne;
        private System.Windows.Forms.Panel panelSaisie;
        private System.Windows.Forms.Label lblEtudiant;
        private System.Windows.Forms.ComboBox cmbEtudiant;
        private System.Windows.Forms.Label lblMatiere;
        private System.Windows.Forms.ComboBox cmbMatiere;
        private System.Windows.Forms.Label lblValeur;
        private System.Windows.Forms.NumericUpDown numValeur;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnVider;
    }
}