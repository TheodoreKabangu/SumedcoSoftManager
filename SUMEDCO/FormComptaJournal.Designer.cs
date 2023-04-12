namespace SUMEDCO
{
    partial class FormComptaJournal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComptaJournal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.txtCategorie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCategorie = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.cboCompte = new System.Windows.Forms.ComboBox();
            this.txtMotifCompte = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorie)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(672, 31);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 623;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 30);
            this.panel2.TabIndex = 622;
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.Transparent;
            this.btnModifier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnModifier.Enabled = false;
            this.btnModifier.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnModifier.FlatAppearance.BorderSize = 0;
            this.btnModifier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.Image = ((System.Drawing.Image)(resources.GetObject("btnModifier.Image")));
            this.btnModifier.Location = new System.Drawing.Point(207, 125);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(30, 21);
            this.btnModifier.TabIndex = 626;
            this.toolTip1.SetToolTip(this.btnModifier, "Modifier");
            this.btnModifier.UseVisualStyleBackColor = false;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.Transparent;
            this.btnSupprimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSupprimer.Enabled = false;
            this.btnSupprimer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSupprimer.FlatAppearance.BorderSize = 0;
            this.btnSupprimer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.Image = ((System.Drawing.Image)(resources.GetObject("btnSupprimer.Image")));
            this.btnSupprimer.Location = new System.Drawing.Point(247, 125);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(30, 21);
            this.btnSupprimer.TabIndex = 627;
            this.toolTip1.SetToolTip(this.btnSupprimer, "Supprimer");
            this.btnSupprimer.UseVisualStyleBackColor = false;
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.Transparent;
            this.btnEnregistrer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnregistrer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEnregistrer.FlatAppearance.BorderSize = 0;
            this.btnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.Image = ((System.Drawing.Image)(resources.GetObject("btnEnregistrer.Image")));
            this.btnEnregistrer.Location = new System.Drawing.Point(166, 124);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(30, 21);
            this.btnEnregistrer.TabIndex = 625;
            this.toolTip1.SetToolTip(this.btnEnregistrer, "Enregistrer");
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            // 
            // txtCategorie
            // 
            this.txtCategorie.Location = new System.Drawing.Point(124, 63);
            this.txtCategorie.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCategorie.MaxLength = 75;
            this.txtCategorie.Name = "txtCategorie";
            this.txtCategorie.Size = new System.Drawing.Size(430, 28);
            this.txtCategorie.TabIndex = 624;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 22);
            this.label3.TabIndex = 629;
            this.label3.Text = "Type de journal :";
            // 
            // dgvCategorie
            // 
            this.dgvCategorie.AllowUserToAddRows = false;
            this.dgvCategorie.AllowUserToOrderColumns = true;
            this.dgvCategorie.AllowUserToResizeColumns = false;
            this.dgvCategorie.AllowUserToResizeRows = false;
            this.dgvCategorie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvCategorie.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvCategorie.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCategorie.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCategorie.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategorie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.dataGridViewTextBoxColumn18,
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategorie.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCategorie.EnableHeadersVisualStyles = false;
            this.dgvCategorie.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.dgvCategorie.Location = new System.Drawing.Point(124, 154);
            this.dgvCategorie.MultiSelect = false;
            this.dgvCategorie.Name = "dgvCategorie";
            this.dgvCategorie.RowHeadersVisible = false;
            this.dgvCategorie.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCategorie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCategorie.Size = new System.Drawing.Size(528, 285);
            this.dgvCategorie.TabIndex = 628;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "N°";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 50;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn18.FillWeight = 98.47716F;
            this.dataGridViewTextBoxColumn18.HeaderText = "Type de journal";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Compte associé";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // btnRechercher
            // 
            this.btnRechercher.BackColor = System.Drawing.Color.Transparent;
            this.btnRechercher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRechercher.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRechercher.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRechercher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechercher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechercher.Image = ((System.Drawing.Image)(resources.GetObject("btnRechercher.Image")));
            this.btnRechercher.Location = new System.Drawing.Point(191, 94);
            this.btnRechercher.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(30, 21);
            this.btnRechercher.TabIndex = 661;
            this.btnRechercher.UseVisualStyleBackColor = false;
            // 
            // cboCompte
            // 
            this.cboCompte.DropDownHeight = 150;
            this.cboCompte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCompte.FormattingEnabled = true;
            this.cboCompte.IntegralHeight = false;
            this.cboCompte.Location = new System.Drawing.Point(330, 94);
            this.cboCompte.MaxDropDownItems = 10;
            this.cboCompte.Name = "cboCompte";
            this.cboCompte.Size = new System.Drawing.Size(165, 30);
            this.cboCompte.Sorted = true;
            this.cboCompte.TabIndex = 660;
            // 
            // txtMotifCompte
            // 
            this.txtMotifCompte.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtMotifCompte.Location = new System.Drawing.Point(124, 94);
            this.txtMotifCompte.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMotifCompte.MaxLength = 10;
            this.txtMotifCompte.Name = "txtMotifCompte";
            this.txtMotifCompte.Size = new System.Drawing.Size(67, 28);
            this.txtMotifCompte.TabIndex = 659;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(233, 97);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(128, 22);
            this.label13.TabIndex = 658;
            this.label13.Text = "N° de compte :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 22);
            this.label2.TabIndex = 657;
            this.label2.Text = "Classe :";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.Transparent;
            this.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnnuler.FlatAppearance.BorderSize = 0;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("btnAnnuler.Image")));
            this.btnAnnuler.Location = new System.Drawing.Point(124, 125);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(30, 21);
            this.btnAnnuler.TabIndex = 665;
            this.toolTip1.SetToolTip(this.btnAnnuler, "Annuler");
            this.btnAnnuler.UseVisualStyleBackColor = false;
            // 
            // FormComptaJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnRechercher);
            this.Controls.Add(this.cboCompte);
            this.Controls.Add(this.txtMotifCompte);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.txtCategorie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvCategorie);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormComptaJournal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormComptaJournal";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnModifier;
        public System.Windows.Forms.Button btnSupprimer;
        public System.Windows.Forms.Button btnEnregistrer;
        public System.Windows.Forms.TextBox txtCategorie;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dgvCategorie;
        public System.Windows.Forms.Button btnRechercher;
        public System.Windows.Forms.ComboBox cboCompte;
        public System.Windows.Forms.TextBox txtMotifCompte;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        public System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}