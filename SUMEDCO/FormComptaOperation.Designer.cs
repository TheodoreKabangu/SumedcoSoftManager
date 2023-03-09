namespace SUMEDCO
{
    partial class FormComptaOperation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComptaOperation));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvOperation = new System.Windows.Forms.DataGridView();
            this.cboTypeJournal = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDateA = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateDe = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.btnRecherche2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGdLivre = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboCompte = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperation)).BeginInit();
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
            // dgvOperation
            // 
            this.dgvOperation.AllowUserToAddRows = false;
            this.dgvOperation.AllowUserToDeleteRows = false;
            this.dgvOperation.AllowUserToOrderColumns = true;
            this.dgvOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOperation.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvOperation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOperation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOperation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOperation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column16,
            this.dataGridViewTextBoxColumn7,
            this.Column5,
            this.Column7,
            this.Column8,
            this.Column1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOperation.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOperation.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvOperation.Location = new System.Drawing.Point(12, 117);
            this.dgvOperation.MultiSelect = false;
            this.dgvOperation.Name = "dgvOperation";
            this.dgvOperation.ReadOnly = true;
            this.dgvOperation.RowHeadersVisible = false;
            this.dgvOperation.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvOperation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperation.Size = new System.Drawing.Size(679, 322);
            this.dgvOperation.TabIndex = 624;
            // 
            // cboTypeJournal
            // 
            this.cboTypeJournal.DropDownHeight = 150;
            this.cboTypeJournal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeJournal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTypeJournal.FormattingEnabled = true;
            this.cboTypeJournal.IntegralHeight = false;
            this.cboTypeJournal.Location = new System.Drawing.Point(115, 45);
            this.cboTypeJournal.MaxDropDownItems = 10;
            this.cboTypeJournal.Name = "cboTypeJournal";
            this.cboTypeJournal.Size = new System.Drawing.Size(224, 30);
            this.cboTypeJournal.Sorted = true;
            this.cboTypeJournal.TabIndex = 628;
            this.cboTypeJournal.DropDown += new System.EventHandler(this.cboTypeJournal_DropDown);
            this.cboTypeJournal.SelectedIndexChanged += new System.EventHandler(this.cboTypeJournal_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 22);
            this.label4.TabIndex = 629;
            this.label4.Text = "Type de journal :";
            // 
            // dtpDateA
            // 
            this.dtpDateA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateA.Location = new System.Drawing.Point(509, 47);
            this.dtpDateA.Name = "dtpDateA";
            this.dtpDateA.Size = new System.Drawing.Size(113, 28);
            this.dtpDateA.TabIndex = 649;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(490, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 22);
            this.label2.TabIndex = 651;
            this.label2.Text = "à :";
            // 
            // dtpDateDe
            // 
            this.dtpDateDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDe.Location = new System.Drawing.Point(377, 47);
            this.dtpDateDe.Name = "dtpDateDe";
            this.dtpDateDe.Size = new System.Drawing.Size(113, 28);
            this.dtpDateDe.TabIndex = 650;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 22);
            this.label1.TabIndex = 652;
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
            this.btnRecherche.Location = new System.Drawing.Point(630, 47);
            this.btnRecherche.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(30, 21);
            this.btnRecherche.TabIndex = 648;
            this.toolTip1.SetToolTip(this.btnRecherche, "Afficher");
            this.btnRecherche.UseVisualStyleBackColor = false;
            this.btnRecherche.Click += new System.EventHandler(this.btnRecherche_Click);
            // 
            // txtRecherche
            // 
            this.txtRecherche.Enabled = false;
            this.txtRecherche.Location = new System.Drawing.Point(115, 83);
            this.txtRecherche.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtRecherche.MaxLength = 75;
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(85, 28);
            this.txtRecherche.TabIndex = 759;
            // 
            // btnRecherche2
            // 
            this.btnRecherche2.BackColor = System.Drawing.Color.Transparent;
            this.btnRecherche2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecherche2.Enabled = false;
            this.btnRecherche2.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRecherche2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRecherche2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecherche2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecherche2.Image = ((System.Drawing.Image)(resources.GetObject("btnRecherche2.Image")));
            this.btnRecherche2.Location = new System.Drawing.Point(200, 83);
            this.btnRecherche2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRecherche2.Name = "btnRecherche2";
            this.btnRecherche2.Size = new System.Drawing.Size(30, 21);
            this.btnRecherche2.TabIndex = 758;
            this.toolTip1.SetToolTip(this.btnRecherche2, "Afficher pour ce compte");
            this.btnRecherche2.UseVisualStyleBackColor = false;
            this.btnRecherche2.Click += new System.EventHandler(this.btnRecherche2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 22);
            this.label3.TabIndex = 629;
            this.label3.Text = "Compte: ";
            // 
            // btnGdLivre
            // 
            this.btnGdLivre.BackColor = System.Drawing.Color.Transparent;
            this.btnGdLivre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGdLivre.Enabled = false;
            this.btnGdLivre.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnGdLivre.FlatAppearance.BorderSize = 0;
            this.btnGdLivre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGdLivre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGdLivre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGdLivre.Image = ((System.Drawing.Image)(resources.GetObject("btnGdLivre.Image")));
            this.btnGdLivre.Location = new System.Drawing.Point(242, 82);
            this.btnGdLivre.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnGdLivre.Name = "btnGdLivre";
            this.btnGdLivre.Size = new System.Drawing.Size(30, 21);
            this.btnGdLivre.TabIndex = 760;
            this.toolTip1.SetToolTip(this.btnGdLivre, "Afficher le grand livre");
            this.btnGdLivre.UseVisualStyleBackColor = false;
            this.btnGdLivre.Click += new System.EventHandler(this.btnGdLivre_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "N°";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "N° pièce";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.HeaderText = "Libellé";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Compte";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Débit";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Crédit";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Solde ant.";
            this.Column1.MinimumWidth = 100;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // cboCompte
            // 
            this.cboCompte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboCompte.BackColor = System.Drawing.SystemColors.Window;
            this.cboCompte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompte.DropDownWidth = 10;
            this.cboCompte.FormattingEnabled = true;
            this.cboCompte.Location = new System.Drawing.Point(681, 79);
            this.cboCompte.Name = "cboCompte";
            this.cboCompte.Size = new System.Drawing.Size(10, 30);
            this.cboCompte.TabIndex = 761;
            this.cboCompte.Visible = false;
            // 
            // FormComptaOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.cboCompte);
            this.Controls.Add(this.btnGdLivre);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.btnRecherche2);
            this.Controls.Add(this.dtpDateA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDateDe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.cboTypeJournal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvOperation);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormComptaOperation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormComptaOperation";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView dgvOperation;
        public System.Windows.Forms.ComboBox cboTypeJournal;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtpDateA;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpDateDe;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnRecherche;
        public System.Windows.Forms.TextBox txtRecherche;
        public System.Windows.Forms.Button btnRecherche2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnGdLivre;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        public System.Windows.Forms.ComboBox cboCompte;
    }
}