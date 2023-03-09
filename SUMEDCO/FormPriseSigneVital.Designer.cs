namespace SUMEDCO
{
    partial class FormPriseSigneVital
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPriseSigneVital));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.dgvSigne = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMedecin = new System.Windows.Forms.ComboBox();
            this.dgvMedecin = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpDateDe = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSigne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedecin)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 27);
            this.panel2.TabIndex = 631;
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.Transparent;
            this.btnEnregistrer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnregistrer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.Location = new System.Drawing.Point(367, 411);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(80, 26);
            this.btnEnregistrer.TabIndex = 637;
            this.btnEnregistrer.Text = "Valider";
            this.toolTip1.SetToolTip(this.btnEnregistrer, "Enregistrer");
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // dgvSigne
            // 
            this.dgvSigne.AllowUserToAddRows = false;
            this.dgvSigne.AllowUserToDeleteRows = false;
            this.dgvSigne.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvSigne.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSigne.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSigne.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSigne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSigne.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column8,
            this.Column1,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSigne.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSigne.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvSigne.Location = new System.Drawing.Point(18, 253);
            this.dgvSigne.MultiSelect = false;
            this.dgvSigne.Name = "dgvSigne";
            this.dgvSigne.RowHeadersVisible = false;
            this.dgvSigne.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvSigne.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSigne.Size = new System.Drawing.Size(429, 150);
            this.dgvSigne.TabIndex = 636;
            this.dgvSigne.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSigne_CellClick);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "N°";
            this.Column3.MinimumWidth = 30;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 30;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "Signe vital";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Valeur";
            this.Column1.MaxInputLength = 30;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Unité";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // txtPatient
            // 
            this.txtPatient.Enabled = false;
            this.txtPatient.Location = new System.Drawing.Point(90, 195);
            this.txtPatient.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtPatient.MaxLength = 75;
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Size = new System.Drawing.Size(357, 21);
            this.txtPatient.TabIndex = 645;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 227);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 642;
            this.label2.Text = "Médecin :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 198);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 643;
            this.label4.Text = "Patient :";
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitter.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnQuitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.Location = new System.Drawing.Point(275, 411);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(80, 26);
            this.btnQuitter.TabIndex = 646;
            this.btnQuitter.Text = "Annuler";
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 171);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 657;
            this.label3.Text = "Date prise :";
            // 
            // cboMedecin
            // 
            this.cboMedecin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedecin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMedecin.FormattingEnabled = true;
            this.cboMedecin.Items.AddRange(new object[] {
            ""});
            this.cboMedecin.Location = new System.Drawing.Point(90, 224);
            this.cboMedecin.Name = "cboMedecin";
            this.cboMedecin.Size = new System.Drawing.Size(357, 23);
            this.cboMedecin.Sorted = true;
            this.cboMedecin.TabIndex = 658;
            this.cboMedecin.DropDown += new System.EventHandler(this.cboMedecin_DropDown);
            this.cboMedecin.SelectedIndexChanged += new System.EventHandler(this.cboMedecin_SelectedIndexChanged);
            // 
            // dgvMedecin
            // 
            this.dgvMedecin.AllowUserToAddRows = false;
            this.dgvMedecin.AllowUserToDeleteRows = false;
            this.dgvMedecin.AllowUserToOrderColumns = true;
            this.dgvMedecin.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvMedecin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMedecin.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMedecin.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMedecin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedecin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn32,
            this.dataGridViewTextBoxColumn33,
            this.dataGridViewTextBoxColumn34});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMedecin.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMedecin.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvMedecin.Location = new System.Drawing.Point(18, 46);
            this.dgvMedecin.MultiSelect = false;
            this.dgvMedecin.Name = "dgvMedecin";
            this.dgvMedecin.ReadOnly = true;
            this.dgvMedecin.RowHeadersVisible = false;
            this.dgvMedecin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedecin.Size = new System.Drawing.Size(429, 114);
            this.dgvMedecin.TabIndex = 659;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.HeaderText = "N°";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            this.dataGridViewTextBoxColumn32.Visible = false;
            this.dataGridViewTextBoxColumn32.Width = 50;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn33.HeaderText = "Médecin";
            this.dataGridViewTextBoxColumn33.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.HeaderText = "Nbre";
            this.dataGridViewTextBoxColumn34.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            // 
            // dtpDateDe
            // 
            this.dtpDateDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDe.Location = new System.Drawing.Point(90, 166);
            this.dtpDateDe.Name = "dtpDateDe";
            this.dtpDateDe.Size = new System.Drawing.Size(87, 21);
            this.dtpDateDe.TabIndex = 660;
            // 
            // FormPriseSigneVital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(462, 451);
            this.ControlBox = false;
            this.Controls.Add(this.dtpDateDe);
            this.Controls.Add(this.dgvMedecin);
            this.Controls.Add(this.cboMedecin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.txtPatient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.dgvSigne);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(478, 490);
            this.MinimumSize = new System.Drawing.Size(478, 490);
            this.Name = "FormPriseSigneVital";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Prise des signes vitaux";
            this.Shown += new System.EventHandler(this.FormExamen_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSigne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedecin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnEnregistrer;
        public System.Windows.Forms.DataGridView dgvSigne;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.TextBox txtPatient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cboMedecin;
        public System.Windows.Forms.DataGridView dgvMedecin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        public System.Windows.Forms.DateTimePicker dtpDateDe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}