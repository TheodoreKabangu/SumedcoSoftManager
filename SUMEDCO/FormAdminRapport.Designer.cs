namespace SUMEDCO
{
    partial class FormAdminRapport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdminRapport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.cboMotif = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvRecette = new System.Windows.Forms.DataGridView();
            this.dtpDateA = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateDe = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.cboMonnaie = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDate = new System.Windows.Forms.Button();
            this.lblTaux = new System.Windows.Forms.Label();
            this.lblDateOperation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecette)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 30);
            this.panel2.TabIndex = 621;
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
            this.btnExit.Location = new System.Drawing.Point(673, 31);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 622;
            this.toolTip1.SetToolTip(this.btnExit, "Fermer");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cboMotif
            // 
            this.cboMotif.DropDownHeight = 150;
            this.cboMotif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMotif.FormattingEnabled = true;
            this.cboMotif.IntegralHeight = false;
            this.cboMotif.Items.AddRange(new object[] {
            "Abonné",
            "Type de patient"});
            this.cboMotif.Location = new System.Drawing.Point(221, 69);
            this.cboMotif.MaxDropDownItems = 10;
            this.cboMotif.Name = "cboMotif";
            this.cboMotif.Size = new System.Drawing.Size(151, 23);
            this.cboMotif.Sorted = true;
            this.cboMotif.TabIndex = 624;
            this.cboMotif.SelectedIndexChanged += new System.EventHandler(this.cboMotif_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 72);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 15);
            this.label7.TabIndex = 625;
            this.label7.Text = "Afficher par :";
            // 
            // dgvRecette
            // 
            this.dgvRecette.AllowUserToAddRows = false;
            this.dgvRecette.AllowUserToDeleteRows = false;
            this.dgvRecette.AllowUserToOrderColumns = true;
            this.dgvRecette.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecette.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvRecette.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecette.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecette.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRecette.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecette.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column7});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecette.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRecette.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvRecette.Location = new System.Drawing.Point(12, 98);
            this.dgvRecette.MultiSelect = false;
            this.dgvRecette.Name = "dgvRecette";
            this.dgvRecette.ReadOnly = true;
            this.dgvRecette.RowHeadersVisible = false;
            this.dgvRecette.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRecette.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecette.Size = new System.Drawing.Size(679, 341);
            this.dgvRecette.TabIndex = 653;
            // 
            // dtpDateA
            // 
            this.dtpDateA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateA.Location = new System.Drawing.Point(548, 70);
            this.dtpDateA.Name = "dtpDateA";
            this.dtpDateA.Size = new System.Drawing.Size(100, 21);
            this.dtpDateA.TabIndex = 689;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(522, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 15);
            this.label2.TabIndex = 691;
            this.label2.Text = "à :";
            // 
            // dtpDateDe
            // 
            this.dtpDateDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDe.Location = new System.Drawing.Point(417, 69);
            this.dtpDateDe.Name = "dtpDateDe";
            this.dtpDateDe.Size = new System.Drawing.Size(100, 21);
            this.dtpDateDe.TabIndex = 690;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 692;
            this.label1.Text = "De :";
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
            this.btnRecherche.Location = new System.Drawing.Point(656, 70);
            this.btnRecherche.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(30, 21);
            this.btnRecherche.TabIndex = 688;
            this.toolTip1.SetToolTip(this.btnRecherche, "Afficher");
            this.btnRecherche.UseVisualStyleBackColor = false;
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
            this.cboMonnaie.Location = new System.Drawing.Point(76, 69);
            this.cboMonnaie.MaxDropDownItems = 10;
            this.cboMonnaie.Name = "cboMonnaie";
            this.cboMonnaie.Size = new System.Drawing.Size(60, 23);
            this.cboMonnaie.Sorted = true;
            this.cboMonnaie.TabIndex = 693;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 694;
            this.label3.Text = "CDF/USD :";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "numcompte";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "N°";
            this.Column1.MinimumWidth = 30;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 30;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "Rubriques";
            this.Column7.MinimumWidth = 100;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // btnDate
            // 
            this.btnDate.BackColor = System.Drawing.Color.Transparent;
            this.btnDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDate.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnDate.FlatAppearance.BorderSize = 0;
            this.btnDate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDate.Image = ((System.Drawing.Image)(resources.GetObject("btnDate.Image")));
            this.btnDate.Location = new System.Drawing.Point(195, 44);
            this.btnDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(30, 21);
            this.btnDate.TabIndex = 699;
            this.toolTip1.SetToolTip(this.btnDate, "Changer la date");
            this.btnDate.UseVisualStyleBackColor = false;
            // 
            // lblTaux
            // 
            this.lblTaux.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTaux.Location = new System.Drawing.Point(313, 46);
            this.lblTaux.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTaux.Name = "lblTaux";
            this.lblTaux.Size = new System.Drawing.Size(78, 15);
            this.lblTaux.TabIndex = 695;
            this.lblTaux.Text = "0000";
            this.lblTaux.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDateOperation
            // 
            this.lblDateOperation.ForeColor = System.Drawing.Color.IndianRed;
            this.lblDateOperation.Location = new System.Drawing.Point(110, 46);
            this.lblDateOperation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDateOperation.Name = "lblDateOperation";
            this.lblDateOperation.Size = new System.Drawing.Size(80, 15);
            this.lblDateOperation.TabIndex = 696;
            this.lblDateOperation.Text = "jj/mm/aaaa";
            this.lblDateOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 697;
            this.label4.Text = "Taux du jour :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 15);
            this.label5.TabIndex = 698;
            this.label5.Text = "Date d\'édition :";
            // 
            // FormAdminRapport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.btnDate);
            this.Controls.Add(this.lblTaux);
            this.Controls.Add(this.lblDateOperation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboMonnaie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDateA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDateDe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.dgvRecette);
            this.Controls.Add(this.cboMotif);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(719, 490);
            this.Name = "FormAdminRapport";
            this.Text = "FormAdminRapport";
            this.Shown += new System.EventHandler(this.FormAdminRapport_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecette)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.ComboBox cboMotif;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DataGridView dgvRecette;
        public System.Windows.Forms.DateTimePicker dtpDateA;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpDateDe;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnRecherche;
        public System.Windows.Forms.ComboBox cboMonnaie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button btnDate;
        public System.Windows.Forms.Label lblTaux;
        public System.Windows.Forms.Label lblDateOperation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}