namespace SUMEDCO
{
    partial class FormUtilisation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUtilisation));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvProduit = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.dtpDateA = new System.Windows.Forms.DateTimePicker();
            this.dtpDateDe = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateEntree = new System.Windows.Forms.Label();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.btnRecherche2 = new System.Windows.Forms.Button();
            this.lblQte = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduit)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(673, 28);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 619;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 27);
            this.panel2.TabIndex = 618;
            // 
            // dgvProduit
            // 
            this.dgvProduit.AllowUserToAddRows = false;
            this.dgvProduit.AllowUserToDeleteRows = false;
            this.dgvProduit.AllowUserToOrderColumns = true;
            this.dgvProduit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProduit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvProduit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProduit.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProduit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column8,
            this.Column7});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProduit.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProduit.Location = new System.Drawing.Point(12, 73);
            this.dgvProduit.MultiSelect = false;
            this.dgvProduit.Name = "dgvProduit";
            this.dgvProduit.ReadOnly = true;
            this.dgvProduit.RowHeadersVisible = false;
            this.dgvProduit.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProduit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduit.Size = new System.Drawing.Size(679, 369);
            this.dgvProduit.TabIndex = 745;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "N°";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Produit";
            this.Column5.MinimumWidth = 150;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Forme";
            this.Column8.MinimumWidth = 100;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Dosage";
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
            this.btnRecherche.Location = new System.Drawing.Point(262, 41);
            this.btnRecherche.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(30, 21);
            this.btnRecherche.TabIndex = 763;
            this.btnRecherche.UseVisualStyleBackColor = false;
            this.btnRecherche.Click += new System.EventHandler(this.btnRecherche_Click);
            // 
            // dtpDateA
            // 
            this.dtpDateA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateA.Location = new System.Drawing.Point(168, 42);
            this.dtpDateA.Name = "dtpDateA";
            this.dtpDateA.Size = new System.Drawing.Size(86, 21);
            this.dtpDateA.TabIndex = 759;
            // 
            // dtpDateDe
            // 
            this.dtpDateDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDe.Location = new System.Drawing.Point(46, 42);
            this.dtpDateDe.Name = "dtpDateDe";
            this.dtpDateDe.Size = new System.Drawing.Size(86, 21);
            this.dtpDateDe.TabIndex = 760;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 761;
            this.label1.Text = "à :";
            // 
            // lblDateEntree
            // 
            this.lblDateEntree.AutoSize = true;
            this.lblDateEntree.Location = new System.Drawing.Point(9, 43);
            this.lblDateEntree.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDateEntree.Name = "lblDateEntree";
            this.lblDateEntree.Size = new System.Drawing.Size(29, 15);
            this.lblDateEntree.TabIndex = 762;
            this.lblDateEntree.Text = "De :";
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(367, 40);
            this.txtRecherche.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtRecherche.MaxLength = 75;
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(85, 21);
            this.txtRecherche.TabIndex = 767;
            // 
            // btnRecherche2
            // 
            this.btnRecherche2.BackColor = System.Drawing.Color.Transparent;
            this.btnRecherche2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecherche2.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRecherche2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRecherche2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecherche2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecherche2.Image = ((System.Drawing.Image)(resources.GetObject("btnRecherche2.Image")));
            this.btnRecherche2.Location = new System.Drawing.Point(452, 40);
            this.btnRecherche2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRecherche2.Name = "btnRecherche2";
            this.btnRecherche2.Size = new System.Drawing.Size(30, 21);
            this.btnRecherche2.TabIndex = 766;
            this.btnRecherche2.UseVisualStyleBackColor = false;
            // 
            // lblQte
            // 
            this.lblQte.AutoSize = true;
            this.lblQte.Location = new System.Drawing.Point(303, 43);
            this.lblQte.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblQte.Name = "lblQte";
            this.lblQte.Size = new System.Drawing.Size(52, 15);
            this.lblQte.TabIndex = 765;
            this.lblQte.Text = "Produit :";
            // 
            // FormUtilisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.btnRecherche2);
            this.Controls.Add(this.lblQte);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.dtpDateA);
            this.Controls.Add(this.dtpDateDe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDateEntree);
            this.Controls.Add(this.dgvProduit);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(719, 490);
            this.Name = "FormUtilisation";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consommation";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView dgvProduit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        public System.Windows.Forms.Button btnRecherche;
        public System.Windows.Forms.DateTimePicker dtpDateA;
        public System.Windows.Forms.DateTimePicker dtpDateDe;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblDateEntree;
        public System.Windows.Forms.TextBox txtRecherche;
        public System.Windows.Forms.Button btnRecherche2;
        private System.Windows.Forms.Label lblQte;

    }
}