namespace SUMEDCO
{
    partial class FormRequisition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRequisition));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnRetirer = new System.Windows.Forms.Button();
            this.btnNonServies = new System.Windows.Forms.Button();
            this.btnServies = new System.Windows.Forms.Button();
            this.btnToutStock = new System.Windows.Forms.Button();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCompte = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dtpDateEntree = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateEntree = new System.Windows.Forms.Label();
            this.dgvRequisition = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listProduit = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisition)).BeginInit();
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
            this.btnRetirer.Location = new System.Drawing.Point(492, 67);
            this.btnRetirer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRetirer.Name = "btnRetirer";
            this.btnRetirer.Size = new System.Drawing.Size(30, 21);
            this.btnRetirer.TabIndex = 748;
            this.toolTip1.SetToolTip(this.btnRetirer, "Retirer cette réquisition");
            this.btnRetirer.UseVisualStyleBackColor = false;
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
            this.btnNonServies.TabIndex = 746;
            this.toolTip1.SetToolTip(this.btnNonServies, "Réquisitions non servies");
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
            this.btnServies.TabIndex = 745;
            this.toolTip1.SetToolTip(this.btnServies, "Réquisitions servies");
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
            this.btnToutStock.TabIndex = 744;
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
            this.btnRecherche.TabIndex = 740;
            this.toolTip1.SetToolTip(this.btnRecherche, "Afficher pour cette période");
            this.btnRecherche.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 27);
            this.panel2.TabIndex = 657;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 743;
            this.label3.Text = "Nom produit :";
            // 
            // txtCompte
            // 
            this.txtCompte.Location = new System.Drawing.Point(92, 40);
            this.txtCompte.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCompte.MaxLength = 75;
            this.txtCompte.Name = "txtCompte";
            this.txtCompte.Size = new System.Drawing.Size(347, 21);
            this.txtCompte.TabIndex = 741;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(250, 68);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(113, 21);
            this.dateTimePicker1.TabIndex = 736;
            // 
            // dtpDateEntree
            // 
            this.dtpDateEntree.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateEntree.Location = new System.Drawing.Point(92, 68);
            this.dtpDateEntree.Name = "dtpDateEntree";
            this.dtpDateEntree.Size = new System.Drawing.Size(113, 21);
            this.dtpDateEntree.TabIndex = 737;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 738;
            this.label1.Text = "à :";
            // 
            // lblDateEntree
            // 
            this.lblDateEntree.AutoSize = true;
            this.lblDateEntree.Location = new System.Drawing.Point(9, 73);
            this.lblDateEntree.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDateEntree.Name = "lblDateEntree";
            this.lblDateEntree.Size = new System.Drawing.Size(29, 15);
            this.lblDateEntree.TabIndex = 739;
            this.lblDateEntree.Text = "De :";
            // 
            // dgvRequisition
            // 
            this.dgvRequisition.AllowUserToAddRows = false;
            this.dgvRequisition.AllowUserToDeleteRows = false;
            this.dgvRequisition.AllowUserToOrderColumns = true;
            this.dgvRequisition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRequisition.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvRequisition.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRequisition.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRequisition.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRequisition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequisition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column10,
            this.Column5,
            this.Column2,
            this.Column7,
            this.Column8,
            this.Column6,
            this.Column11});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRequisition.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRequisition.Location = new System.Drawing.Point(12, 96);
            this.dgvRequisition.MultiSelect = false;
            this.dgvRequisition.Name = "dgvRequisition";
            this.dgvRequisition.ReadOnly = true;
            this.dgvRequisition.RowHeadersVisible = false;
            this.dgvRequisition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequisition.Size = new System.Drawing.Size(679, 343);
            this.dgvRequisition.TabIndex = 735;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "N°";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Date";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "idstock";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "idproduit";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Produit";
            this.Column5.MinimumWidth = 150;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Condit.";
            this.Column2.MinimumWidth = 100;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "Dosage";
            this.Column7.MinimumWidth = 100;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Forme";
            this.Column8.MinimumWidth = 100;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Qté com.";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Qté servie";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // listProduit
            // 
            this.listProduit.FormattingEnabled = true;
            this.listProduit.ItemHeight = 15;
            this.listProduit.Location = new System.Drawing.Point(92, 63);
            this.listProduit.Name = "listProduit";
            this.listProduit.Size = new System.Drawing.Size(347, 154);
            this.listProduit.TabIndex = 742;
            this.listProduit.Visible = false;
            // 
            // FormRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.btnRetirer);
            this.Controls.Add(this.btnNonServies);
            this.Controls.Add(this.btnServies);
            this.Controls.Add(this.btnToutStock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCompte);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dtpDateEntree);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDateEntree);
            this.Controls.Add(this.dgvRequisition);
            this.Controls.Add(this.listProduit);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(719, 490);
            this.Name = "FormRequisition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Requisitions";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnRetirer;
        public System.Windows.Forms.Button btnNonServies;
        public System.Windows.Forms.Button btnServies;
        public System.Windows.Forms.Button btnToutStock;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtCompte;
        public System.Windows.Forms.Button btnRecherche;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.DateTimePicker dtpDateEntree;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblDateEntree;
        public System.Windows.Forms.DataGridView dgvRequisition;
        public System.Windows.Forms.ListBox listProduit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    }
}