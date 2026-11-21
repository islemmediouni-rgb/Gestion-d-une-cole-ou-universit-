namespace GestionEcole.UI
{
    partial class FormSalles
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
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblCapacite = new System.Windows.Forms.Label();
            this.numCapacite = new System.Windows.Forms.NumericUpDown();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnVider = new System.Windows.Forms.Button();
            this.panelFiltre.SuspendLayout();
            this.panelSaisie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grille)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacite)).BeginInit();
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
            this.panelSaisie.Controls.Add(this.lblNumero);
            this.panelSaisie.Controls.Add(this.txtNumero);
            this.panelSaisie.Controls.Add(this.lblCapacite);
            this.panelSaisie.Controls.Add(this.numCapacite);
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
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(20, 20);
            this.lblNumero.Text = "Numéro de salle *";
            this.lblNumero.Name = "lblNumero";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(20, 42);
            this.txtNumero.Size = new System.Drawing.Size(260, 23);
            this.txtNumero.TabIndex = 0;
            this.txtNumero.Name = "txtNumero";
            // 
            // lblCapacite
            // 
            this.lblCapacite.AutoSize = true;
            this.lblCapacite.Location = new System.Drawing.Point(20, 78);
            this.lblCapacite.Text = "Capacité (places) *";
            this.lblCapacite.Name = "lblCapacite";
            // 
            // numCapacite
            // 
            this.numCapacite.Location = new System.Drawing.Point(20, 100);
            this.numCapacite.Size = new System.Drawing.Size(260, 23);
            this.numCapacite.TabIndex = 1;
            this.numCapacite.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.numCapacite.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numCapacite.Value = new decimal(new int[] { 30, 0, 0, 0 });
            this.numCapacite.Name = "numCapacite";
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(20, 146);
            this.btnAjouter.Size = new System.Drawing.Size(125, 38);
            this.btnAjouter.TabIndex = 2;
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
            this.btnModifier.Location = new System.Drawing.Point(155, 146);
            this.btnModifier.Size = new System.Drawing.Size(125, 38);
            this.btnModifier.TabIndex = 3;
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
            this.btnSupprimer.Location = new System.Drawing.Point(20, 192);
            this.btnSupprimer.Size = new System.Drawing.Size(125, 38);
            this.btnSupprimer.TabIndex = 4;
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
            this.btnVider.Location = new System.Drawing.Point(155, 192);
            this.btnVider.Size = new System.Drawing.Size(125, 38);
            this.btnVider.TabIndex = 5;
            this.btnVider.Text = "Vider";
            this.btnVider.UseVisualStyleBackColor = false;
            this.btnVider.Name = "btnVider";
            this.btnVider.Click += new System.EventHandler(this.btnVider_Click);
            // 
            // FormSalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.grille);
            this.Controls.Add(this.panelFiltre);
            this.Controls.Add(this.panelSaisie);
            this.Name = "FormSalles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestion des salles";
            this.Load += new System.EventHandler(this.FormSalles_Load);
            this.panelFiltre.ResumeLayout(false);
            this.panelFiltre.PerformLayout();
            this.panelSaisie.ResumeLayout(false);
            this.panelSaisie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grille)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grille;
        private System.Windows.Forms.Panel panelFiltre;
        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.Panel panelSaisie;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblCapacite;
        private System.Windows.Forms.NumericUpDown numCapacite;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnVider;
    }
}