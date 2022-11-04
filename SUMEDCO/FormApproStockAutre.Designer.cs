namespace SUMEDCO
{
    partial class FormApproStockAutre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApproStockAutre));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnRetirer = new System.Windows.Forms.Button();
            this.btnServir = new System.Windows.Forms.Button();
            this.btnNonServies = new System.Windows.Forms.Button();
            this.btnServies = new System.Windows.Forms.Button();
            this.btnToutStock = new System.Windows.Forms.Button();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCompte = new System.Windows.Forms.TextBox();
            this.dtpDateA = new System.Windows.Forms.DateTimePicker();
            this.dtpDateDe = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateEntree = new System.Windows.Forms.Label();
            this.listProduit = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvAppro = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppro)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRetirer
            // 
            this.btnRetirer.BackColor = System.Drawing.Color.Transparent;
            this.btnRetirer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRetirer.Enabled = false;
            this.btnRetirer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRetirer.FlatAppearance.BorderSize = 0;
            this.btnRetirer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRetirer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetirer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirer.Image = ((System.Drawing.Image)(resources.GetObject("btnRetirer.Image")));
            this.btnRetirer.Location = new System.Drawing.Point(532, 67);
            this.btnRetirer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRetirer.Name = "btnRetirer";
            this.btnRetirer.Size = new System.Drawing.Size(30, 21);
            this.btnRetirer.TabIndex = 765;
            this.toolTip1.SetToolTip(this.btnRetirer, "Supprimer cette demande");
            this.btnRetirer.UseVisualStyleBackColor = false;
            // 
            // btnServir
            // 
            this.btnServir.BackColor = System.Drawing.Color.Transparent;
            this.btnServir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnServir.Enabled = false;
            this.btnServir.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnServir.FlatAppearance.BorderSize = 0;
            this.btnServir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnServir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServir.Image = ((System.Drawing.Image)(resources.GetObject("btnServir.Image")));
            this.btnServir.Location = new System.Drawing.Point(491, 68);
            this.btnServir.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnServir.Name = "btnServir";
            this.btnServir.Size = new System.Drawing.Size(30, 21);
            this.btnServir.TabIndex = 764;
            this.toolTip1.SetToolTip(this.btnServir, "Servir cette demande");
            this.btnServir.UseVisualStyleBackColor = false;
            this.btnServir.Click += new System.EventHandler(this.btnServir_Click);
            // 
            // btnNonServies
            // 
            this.btnNonServies.BackColor = System.Drawing.Color.Transparent;
            this.btnNonServies.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNonServies.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnNonServies.FlatAppearance.BorderSize = 0;
            this.btnNonServies.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNonServies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNonServies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonServies.Image = ((System.Drawing.Image)(resources.GetObject("btnNonServies.Image")));
            this.btnNonServies.Location = new System.Drawing.Point(451, 68);
            this.btnNonServies.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnNonServies.Name = "btnNonServies";
            this.btnNonServies.Size = new System.Drawing.Size(30, 21);
            this.btnNonServies.TabIndex = 763;
            this.toolTip1.SetToolTip(this.btnNonServies, "Demandes non servies");
            this.btnNonServies.UseVisualStyleBackColor = false;
            // 
            // btnServies
            // 
            this.btnServies.BackColor = System.Drawing.Color.Transparent;
            this.btnServies.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnServies.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnServies.FlatAppearance.BorderSize = 0;
            this.btnServies.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnServies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServies.Image = ((System.Drawing.Image)(resources.GetObject("btnServies.Image")));
            this.btnServies.Location = new System.Drawing.Point(411, 68);
            this.btnServies.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnServies.Name = "btnServies";
            this.btnServies.Size = new System.Drawing.Size(30, 21);
            this.btnServies.TabIndex = 762;
            this.toolTip1.SetToolTip(this.btnServies, "Demandes servies");
            this.btnServies.UseVisualStyleBackColor = false;
            // 
            // btnToutStock
            // 
            this.btnToutStock.BackColor = System.Drawing.Color.Transparent;
            this.btnToutStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnToutStock.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnToutStock.FlatAppearance.BorderSize = 0;
            this.btnToutStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnToutStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToutStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToutStock.Image = ((System.Drawing.Image)(resources.GetObject("btnToutStock.Image")));
            this.btnToutStock.Location = new System.Drawing.Point(441, 41);
            this.btnToutStock.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnToutStock.Name = "btnToutStock";
            this.btnToutStock.Size = new System.Drawing.Size(30, 21);
            this.btnToutStock.TabIndex = 761;
            this.toolTip1.SetToolTip(this.btnToutStock, "Afficher tout");
            this.btnToutStock.UseVisualStyleBackColor = false;
            this.btnToutStock.Click += new System.EventHandler(this.btnToutStock_Click);
            // 
            // btnRecherche
            // 
            this.btnRecherche.BackColor = System.Drawing.Color.Transparent;
            this.btnRecherche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecherche.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRecherche.FlatAppearance.BorderSize = 0;
            this.btnRecherche.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRecherche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecherche.Image = ((System.Drawing.Image)(resources.GetObject("btnRecherche.Image")));
            this.btnRecherche.Location = new System.Drawing.Point(371, 68);
            this.btnRecherche.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(30, 21);
            this.btnRecherche.TabIndex = 757;
            this.toolTip1.SetToolTip(this.btnRecherche, "Afficher pour cette période");
            this.btnRecherche.UseVisualStyleBackColor = false;
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
            this.btnExit.Location = new System.Drawing.Point(672, 28);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 695;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 760;
            this.label3.Text = "Nom produit :";
            // 
            // txtCompte
            // 
            this.txtCompte.Location = new System.Drawing.Point(92, 40);
            this.txtCompte.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCompte.MaxLength = 75;
            this.txtCompte.Name = "txtCompte";
            this.txtCompte.Size = new System.Drawing.Size(347, 21);
            this.txtCompte.TabIndex = 758;
            this.txtCompte.TextChanged += new System.EventHandler(this.txtCompte_TextChanged);
            // 
            // dtpDateA
            // 
            this.dtpDateA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateA.Location = new System.Drawing.Point(250, 68);
            this.dtpDateA.Name = "dtpDateA";
            this.dtpDateA.Size = new System.Drawing.Size(113, 21);
            this.dtpDateA.TabIndex = 753;
            // 
            // dtpDateDe
            // 
            this.dtpDateDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDe.Location = new System.Drawing.Point(92, 68);
            this.dtpDateDe.Name = "dtpDateDe";
            this.dtpDateDe.Size = new System.Drawing.Size(113, 21);
            this.dtpDateDe.TabIndex = 754;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 755;
            this.label1.Text = "à :";
            // 
            // lblDateEntree
            // 
            this.lblDateEntree.AutoSize = true;
            this.lblDateEntree.Location = new System.Drawing.Point(9, 73);
            this.lblDateEntree.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDateEntree.Name = "lblDateEntree";
            this.lblDateEntree.Size = new System.Drawing.Size(29, 15);
            this.lblDateEntree.TabIndex = 756;
            this.lblDateEntree.Text = "De :";
            // 
            // listProduit
            // 
            this.listProduit.FormattingEnabled = true;
            this.listProduit.ItemHeight = 15;
            this.listProduit.Location = new System.Drawing.Point(92, 63);
            this.listProduit.Name = "listProduit";
            this.listProduit.Size = new System.Drawing.Size(347, 154);
            this.listProduit.TabIndex = 759;
            this.listProduit.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 27);
            this.panel2.TabIndex = 766;
            // 
            // dgvAppro
            // 
            this.dgvAppro.AllowUserToAddRows = false;
            this.dgvAppro.AllowUserToDeleteRows = false;
            this.dgvAppro.AllowUserToOrderColumns = true;
            this.dgvAppro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAppro.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvAppro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAppro.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAppro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column13,
            this.Column6,
            this.Column8,
            this.Column2,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAppro.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAppro.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvAppro.Location = new System.Drawing.Point(12, 96);
            this.dgvAppro.MultiSelect = false;
            this.dgvAppro.Name = "dgvAppro";
            this.dgvAppro.ReadOnly = true;
            this.dgvAppro.RowHeadersVisible = false;
            this.dgvAppro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppro.Size = new System.Drawing.Size(679, 343);
            this.dgvAppro.TabIndex = 767;
            this.dgvAppro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellClick);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "N°";
            this.Column3.MinimumWidth = 50;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Date com.";
            this.Column13.MinimumWidth = 100;
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "idproduit";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "Nom du produit";
            this.Column8.MinimumWidth = 150;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Unité";
            this.Column2.MinimumWidth = 100;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Qté dem.";
            this.Column9.MinimumWidth = 100;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Qté appro.";
            this.Column10.MinimumWidth = 100;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Qté ajoutée";
            this.Column11.MinimumWidth = 100;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "P.A.U";
            this.Column12.MinimumWidth = 100;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // FormApproStockAutre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.dgvAppro);
            this.Controls.Add(this.btnRetirer);
            this.Controls.Add(this.btnServir);
            this.Controls.Add(this.btnNonServies);
            this.Controls.Add(this.btnServies);
            this.Controls.Add(this.btnToutStock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCompte);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.dtpDateA);
            this.Controls.Add(this.dtpDateDe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDateEntree);
            this.Controls.Add(this.listProduit);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormApproStockAutre";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SSM - Approvisionnement autres produits";
            this.Shown += new System.EventHandler(this.FormApproStockAutre_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.Button btnRetirer;
        public System.Windows.Forms.Button btnServir;
        public System.Windows.Forms.Button btnNonServies;
        public System.Windows.Forms.Button btnServies;
        public System.Windows.Forms.Button btnToutStock;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtCompte;
        public System.Windows.Forms.Button btnRecherche;
        public System.Windows.Forms.DateTimePicker dtpDateA;
        public System.Windows.Forms.DateTimePicker dtpDateDe;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblDateEntree;
        public System.Windows.Forms.ListBox listProduit;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView dgvAppro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
    }
}