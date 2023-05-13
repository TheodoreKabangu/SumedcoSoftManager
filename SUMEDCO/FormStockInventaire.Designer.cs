namespace SUMEDCO
{
    partial class FormStockInventaire
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStockInventaire));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.dtpDateA = new System.Windows.Forms.DateTimePicker();
            this.dtpDateDe = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateEntree = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnQuitter = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDepot = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 27);
            this.panel1.TabIndex = 702;
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToDeleteRows = false;
            this.dgvStock.AllowUserToOrderColumns = true;
            this.dgvStock.AllowUserToResizeColumns = false;
            this.dgvStock.AllowUserToResizeRows = false;
            this.dgvStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStock.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.Column1,
            this.Column5,
            this.Column6,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column7});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStock.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvStock.EnableHeadersVisualStyles = false;
            this.dgvStock.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.dgvStock.Location = new System.Drawing.Point(12, 104);
            this.dgvStock.MultiSelect = false;
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.RowHeadersVisible = false;
            this.dgvStock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(679, 334);
            this.dgvStock.TabIndex = 763;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "ID";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Produit";
            this.Column1.MinimumWidth = 150;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Forme";
            this.Column5.MinimumWidth = 100;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Dosage";
            this.Column6.MinimumWidth = 100;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column2
            // 
            dataGridViewCellStyle14.Format = "N0";
            dataGridViewCellStyle14.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle14;
            this.Column2.HeaderText = "Qté stock";
            this.Column2.MinimumWidth = 100;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle15.Format = "N0";
            dataGridViewCellStyle15.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle15;
            this.Column3.HeaderText = "Qté entée";
            this.Column3.MinimumWidth = 100;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle16.Format = "N0";
            dataGridViewCellStyle16.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle16;
            this.Column4.HeaderText = "Qté sotie";
            this.Column4.MinimumWidth = 100;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column7
            // 
            dataGridViewCellStyle17.Format = "N2";
            dataGridViewCellStyle17.NullValue = null;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle17;
            this.Column7.HeaderText = "Valeur";
            this.Column7.MinimumWidth = 100;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
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
            this.btnRecherche.Location = new System.Drawing.Point(306, 40);
            this.btnRecherche.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(30, 21);
            this.btnRecherche.TabIndex = 768;
            this.toolTip1.SetToolTip(this.btnRecherche, "Afficher");
            this.btnRecherche.UseVisualStyleBackColor = false;
            this.btnRecherche.Click += new System.EventHandler(this.btnRecherche_Click);
            // 
            // dtpDateA
            // 
            this.dtpDateA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateA.Location = new System.Drawing.Point(196, 41);
            this.dtpDateA.Name = "dtpDateA";
            this.dtpDateA.Size = new System.Drawing.Size(105, 28);
            this.dtpDateA.TabIndex = 764;
            // 
            // dtpDateDe
            // 
            this.dtpDateDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDe.Location = new System.Drawing.Point(68, 41);
            this.dtpDateDe.Name = "dtpDateDe";
            this.dtpDateDe.Size = new System.Drawing.Size(105, 28);
            this.dtpDateDe.TabIndex = 765;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 22);
            this.label1.TabIndex = 766;
            this.label1.Text = "à :";
            // 
            // lblDateEntree
            // 
            this.lblDateEntree.AutoSize = true;
            this.lblDateEntree.Location = new System.Drawing.Point(8, 42);
            this.lblDateEntree.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDateEntree.Name = "lblDateEntree";
            this.lblDateEntree.Size = new System.Drawing.Size(43, 22);
            this.lblDateEntree.TabIndex = 767;
            this.lblDateEntree.Text = "De :";
            // 
            // btnQuitter
            // 
            this.btnQuitter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitter.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitter.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnQuitter.FlatAppearance.BorderSize = 0;
            this.btnQuitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitter.Image")));
            this.btnQuitter.Location = new System.Drawing.Point(674, 27);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(30, 30);
            this.btnQuitter.TabIndex = 769;
            this.toolTip1.SetToolTip(this.btnQuitter, "Fermer");
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 72);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 22);
            this.label8.TabIndex = 771;
            this.label8.Text = "Dépôt :";
            // 
            // cboDepot
            // 
            this.cboDepot.DropDownHeight = 150;
            this.cboDepot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDepot.FormattingEnabled = true;
            this.cboDepot.IntegralHeight = false;
            this.cboDepot.Items.AddRange(new object[] {
            "ampoule",
            "baxtère",
            "boite",
            "capsule",
            "comprimé",
            "flacon",
            "litre",
            "ovule",
            "pièce",
            "pot",
            "rouleau",
            "sachet",
            "sirop",
            "suppositoire",
            "tube"});
            this.cboDepot.Location = new System.Drawing.Point(68, 69);
            this.cboDepot.MaxDropDownItems = 10;
            this.cboDepot.Name = "cboDepot";
            this.cboDepot.Size = new System.Drawing.Size(268, 30);
            this.cboDepot.Sorted = true;
            this.cboDepot.TabIndex = 770;
            this.cboDepot.DropDown += new System.EventHandler(this.cboDepot_DropDown);
            this.cboDepot.SelectedIndexChanged += new System.EventHandler(this.cboDepot_SelectedIndexChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.Color.MediumBlue;
            this.checkBox2.Location = new System.Drawing.Point(344, 41);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(161, 26);
            this.checkBox2.TabIndex = 779;
            this.checkBox2.Text = "Tous les stocks";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Click += new System.EventHandler(this.checkBox2_Click);
            // 
            // FormStockInventaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.cboDepot);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.dtpDateA);
            this.Controls.Add(this.dtpDateDe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDateEntree);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(725, 507);
            this.Name = "FormStockInventaire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.FormStockInventaire_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dgvStock;
        public System.Windows.Forms.Button btnRecherche;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.DateTimePicker dtpDateA;
        public System.Windows.Forms.DateTimePicker dtpDateDe;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblDateEntree;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        public System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox cboDepot;
        public System.Windows.Forms.CheckBox checkBox2;
    }
}