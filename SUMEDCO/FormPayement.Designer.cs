namespace SUMEDCO
{
    partial class FormPayement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPayement));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.txtPayeur = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMontant = new System.Windows.Forms.TextBox();
            this.txtMontantLettre = new System.Windows.Forms.TextBox();
            this.cboMonnaie = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblDateOperation = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboAnnulation = new System.Windows.Forms.ComboBox();
            this.dgvCompte = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompte)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(446, 27);
            this.panel2.TabIndex = 618;
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnAjouter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAjouter.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAjouter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.Location = new System.Drawing.Point(351, 199);
            this.btnAjouter.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(80, 27);
            this.btnAjouter.TabIndex = 638;
            this.btnAjouter.Text = "Enregistrer";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(259, 199);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(80, 27);
            this.btnAnnuler.TabIndex = 639;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // txtPayeur
            // 
            this.txtPayeur.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPayeur.Enabled = false;
            this.txtPayeur.Location = new System.Drawing.Point(75, 86);
            this.txtPayeur.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtPayeur.MaxLength = 75;
            this.txtPayeur.Name = "txtPayeur";
            this.txtPayeur.Size = new System.Drawing.Size(356, 21);
            this.txtPayeur.TabIndex = 640;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 641;
            this.label1.Text = "Payeur :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 641;
            this.label2.Text = "Montant :";
            // 
            // txtMontant
            // 
            this.txtMontant.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMontant.Location = new System.Drawing.Point(75, 117);
            this.txtMontant.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMontant.MaxLength = 75;
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(221, 21);
            this.txtMontant.TabIndex = 640;
            this.txtMontant.Leave += new System.EventHandler(this.txtMontant_Leave);
            // 
            // txtMontantLettre
            // 
            this.txtMontantLettre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtMontantLettre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMontantLettre.Enabled = false;
            this.txtMontantLettre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontantLettre.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtMontantLettre.Location = new System.Drawing.Point(75, 148);
            this.txtMontantLettre.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMontantLettre.MaxLength = 200;
            this.txtMontantLettre.Multiline = true;
            this.txtMontantLettre.Name = "txtMontantLettre";
            this.txtMontantLettre.Size = new System.Drawing.Size(356, 41);
            this.txtMontantLettre.TabIndex = 642;
            // 
            // cboMonnaie
            // 
            this.cboMonnaie.DropDownHeight = 150;
            this.cboMonnaie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonnaie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMonnaie.FormattingEnabled = true;
            this.cboMonnaie.IntegralHeight = false;
            this.cboMonnaie.Items.AddRange(new object[] {
            "CDF",
            "USD"});
            this.cboMonnaie.Location = new System.Drawing.Point(369, 117);
            this.cboMonnaie.MaxDropDownItems = 10;
            this.cboMonnaie.Name = "cboMonnaie";
            this.cboMonnaie.Size = new System.Drawing.Size(62, 23);
            this.cboMonnaie.Sorted = true;
            this.cboMonnaie.TabIndex = 676;
            this.cboMonnaie.SelectedIndexChanged += new System.EventHandler(this.cboMonnaie_SelectedIndexChanged);
            this.cboMonnaie.Leave += new System.EventHandler(this.cboMonnaie_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(299, 121);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 15);
            this.label10.TabIndex = 677;
            this.label10.Text = "CDF/USD :";
            // 
            // lblDateOperation
            // 
            this.lblDateOperation.ForeColor = System.Drawing.Color.IndianRed;
            this.lblDateOperation.Location = new System.Drawing.Point(72, 205);
            this.lblDateOperation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDateOperation.Name = "lblDateOperation";
            this.lblDateOperation.Size = new System.Drawing.Size(80, 15);
            this.lblDateOperation.TabIndex = 678;
            this.lblDateOperation.Text = "jj/mm/aaaa";
            this.lblDateOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 205);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 679;
            this.label3.Text = "Perçu le :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 15);
            this.label4.TabIndex = 683;
            this.label4.Text = "Raison d\'annulation :";
            // 
            // cboAnnulation
            // 
            this.cboAnnulation.DropDownHeight = 150;
            this.cboAnnulation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnnulation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAnnulation.FormattingEnabled = true;
            this.cboAnnulation.IntegralHeight = false;
            this.cboAnnulation.Items.AddRange(new object[] {
            "erreur sur le payeur",
            "modification du montant",
            "remboursement"});
            this.cboAnnulation.Location = new System.Drawing.Point(75, 55);
            this.cboAnnulation.MaxDropDownItems = 10;
            this.cboAnnulation.Name = "cboAnnulation";
            this.cboAnnulation.Size = new System.Drawing.Size(356, 23);
            this.cboAnnulation.Sorted = true;
            this.cboAnnulation.TabIndex = 684;
            // 
            // dgvCompte
            // 
            this.dgvCompte.AllowUserToAddRows = false;
            this.dgvCompte.AllowUserToDeleteRows = false;
            this.dgvCompte.AllowUserToOrderColumns = true;
            this.dgvCompte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCompte.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvCompte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCompte.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCompte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompte.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCompte.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvCompte.Location = new System.Drawing.Point(75, 234);
            this.dgvCompte.MultiSelect = false;
            this.dgvCompte.Name = "dgvCompte";
            this.dgvCompte.RowHeadersVisible = false;
            this.dgvCompte.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCompte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCompte.Size = new System.Drawing.Size(356, 137);
            this.dgvCompte.TabIndex = 685;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "numcompte";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Compte";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "Montant";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // FormPayement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(446, 383);
            this.ControlBox = false;
            this.Controls.Add(this.dgvCompte);
            this.Controls.Add(this.cboAnnulation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDateOperation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboMonnaie);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMontantLettre);
            this.Controls.Add(this.txtMontant);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPayeur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(462, 240);
            this.Name = "FormPayement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Sélection de services";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnAjouter;
        public System.Windows.Forms.Button btnAnnuler;
        public System.Windows.Forms.TextBox txtPayeur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtMontant;
        public System.Windows.Forms.TextBox txtMontantLettre;
        public System.Windows.Forms.ComboBox cboMonnaie;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lblDateOperation;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cboAnnulation;
        public System.Windows.Forms.DataGridView dgvCompte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}