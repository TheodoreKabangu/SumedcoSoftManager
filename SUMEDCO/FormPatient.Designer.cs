namespace SUMEDCO
{
    partial class FormPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatient));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAffecter = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.dgvPatient = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.lblAge = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtAdresse = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtPersonContact = new System.Windows.Forms.TextBox();
            this.txtTelContact = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAnnee = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboSexe = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTypePatient = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMois = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbNouveau = new System.Windows.Forms.RadioButton();
            this.rbUrgence = new System.Windows.Forms.RadioButton();
            this.cboTypeFacture = new System.Windows.Forms.ComboBox();
            this.lblDateOperation = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTaux = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 30);
            this.panel2.TabIndex = 558;
            // 
            // btnAffecter
            // 
            this.btnAffecter.BackColor = System.Drawing.Color.Transparent;
            this.btnAffecter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAffecter.Enabled = false;
            this.btnAffecter.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAffecter.FlatAppearance.BorderSize = 0;
            this.btnAffecter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAffecter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAffecter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAffecter.Image = ((System.Drawing.Image)(resources.GetObject("btnAffecter.Image")));
            this.btnAffecter.Location = new System.Drawing.Point(501, 308);
            this.btnAffecter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAffecter.Name = "btnAffecter";
            this.btnAffecter.Size = new System.Drawing.Size(30, 21);
            this.btnAffecter.TabIndex = 642;
            this.toolTip1.SetToolTip(this.btnAffecter, "Ajouter ce cas");
            this.btnAffecter.UseVisualStyleBackColor = false;
            this.btnAffecter.Click += new System.EventHandler(this.btnAffecter_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnnuler.FlatAppearance.BorderSize = 0;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("btnAnnuler.Image")));
            this.btnAnnuler.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnnuler.Location = new System.Drawing.Point(95, 275);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(30, 23);
            this.btnAnnuler.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnAnnuler, "Annuler");
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnModifier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnModifier.Enabled = false;
            this.btnModifier.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnModifier.FlatAppearance.BorderSize = 0;
            this.btnModifier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.Image = ((System.Drawing.Image)(resources.GetObject("btnModifier.Image")));
            this.btnModifier.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModifier.Location = new System.Drawing.Point(179, 275);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(30, 23);
            this.btnModifier.TabIndex = 14;
            this.toolTip1.SetToolTip(this.btnModifier, "Modifier");
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnEnregistrer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnregistrer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEnregistrer.FlatAppearance.BorderSize = 0;
            this.btnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.Image = ((System.Drawing.Image)(resources.GetObject("btnEnregistrer.Image")));
            this.btnEnregistrer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnregistrer.Location = new System.Drawing.Point(137, 275);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(30, 23);
            this.btnEnregistrer.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnEnregistrer, "Enregistrer");
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnSupprimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSupprimer.Enabled = false;
            this.btnSupprimer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSupprimer.FlatAppearance.BorderSize = 0;
            this.btnSupprimer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.Image = ((System.Drawing.Image)(resources.GetObject("btnSupprimer.Image")));
            this.btnSupprimer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSupprimer.Location = new System.Drawing.Point(221, 275);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(30, 23);
            this.btnSupprimer.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnSupprimer, "Supprimer");
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
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
            this.btnQuitter.Location = new System.Drawing.Point(671, 31);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(30, 30);
            this.btnQuitter.TabIndex = 646;
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(95, 308);
            this.txtRecherche.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtRecherche.MaxLength = 25;
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(366, 28);
            this.txtRecherche.TabIndex = 639;
            this.txtRecherche.Text = "Nom du patient";
            this.txtRecherche.Enter += new System.EventHandler(this.txtRecherche_Enter);
            // 
            // dgvPatient
            // 
            this.dgvPatient.AllowUserToAddRows = false;
            this.dgvPatient.AllowUserToDeleteRows = false;
            this.dgvPatient.AllowUserToOrderColumns = true;
            this.dgvPatient.AllowUserToResizeColumns = false;
            this.dgvPatient.AllowUserToResizeRows = false;
            this.dgvPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPatient.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvPatient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPatient.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn24,
            this.Column6,
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.Column1,
            this.dataGridViewTextBoxColumn29,
            this.dataGridViewTextBoxColumn30,
            this.dataGridViewTextBoxColumn31,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatient.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPatient.EnableHeadersVisualStyles = false;
            this.dgvPatient.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.dgvPatient.Location = new System.Drawing.Point(14, 336);
            this.dgvPatient.MultiSelect = false;
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.ReadOnly = true;
            this.dgvPatient.RowHeadersVisible = false;
            this.dgvPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatient.Size = new System.Drawing.Size(676, 103);
            this.dgvPatient.TabIndex = 646;
            this.dgvPatient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatient_CellClick);
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.HeaderText = "N°";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Width = 50;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "idpayeur";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn25.HeaderText = "Noms";
            this.dataGridViewTextBoxColumn25.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.HeaderText = "Sexe";
            this.dataGridViewTextBoxColumn26.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            this.dataGridViewTextBoxColumn26.Width = 40;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn27.HeaderText = "Age";
            this.dataGridViewTextBoxColumn27.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn28.HeaderText = "Adresse";
            this.dataGridViewTextBoxColumn28.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ZS/HZS";
            this.Column1.MinimumWidth = 60;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.HeaderText = "Tél.";
            this.dataGridViewTextBoxColumn29.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.HeaderText = "P. Contact";
            this.dataGridViewTextBoxColumn30.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            this.dataGridViewTextBoxColumn30.Width = 150;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.HeaderText = "Tél. contact";
            this.dataGridViewTextBoxColumn31.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Type";
            this.Column2.MinimumWidth = 100;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "T. abonné";
            this.Column3.MinimumWidth = 100;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Entreprise";
            this.Column4.MinimumWidth = 150;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "N° service";
            this.Column5.MinimumWidth = 100;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // btnRecherche
            // 
            this.btnRecherche.BackColor = System.Drawing.Color.Transparent;
            this.btnRecherche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecherche.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRecherche.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRecherche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecherche.Image = ((System.Drawing.Image)(resources.GetObject("btnRecherche.Image")));
            this.btnRecherche.Location = new System.Drawing.Point(461, 308);
            this.btnRecherche.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(30, 21);
            this.btnRecherche.TabIndex = 640;
            this.btnRecherche.UseVisualStyleBackColor = false;
            this.btnRecherche.Click += new System.EventHandler(this.btnRecherche_Click);
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblAge.Location = new System.Drawing.Point(413, 94);
            this.lblAge.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(59, 25);
            this.lblAge.TabIndex = 632;
            this.lblAge.Text = "Age :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 22);
            this.label1.TabIndex = 624;
            this.label1.Text = "Noms :";
            // 
            // txtNom
            // 
            this.txtNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNom.Location = new System.Drawing.Point(307, 62);
            this.txtNom.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtNom.MaxLength = 75;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(327, 28);
            this.txtNom.TabIndex = 4;
            this.txtNom.Enter += new System.EventHandler(this.txtNom_Enter);
            // 
            // txtAdresse
            // 
            this.txtAdresse.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtAdresse.Location = new System.Drawing.Point(307, 120);
            this.txtAdresse.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtAdresse.MaxLength = 75;
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(327, 28);
            this.txtAdresse.TabIndex = 8;
            this.txtAdresse.Enter += new System.EventHandler(this.txtTel_Enter);
            // 
            // txtTel
            // 
            this.txtTel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTel.Location = new System.Drawing.Point(95, 120);
            this.txtTel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTel.MaxLength = 15;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(141, 28);
            this.txtTel.TabIndex = 9;
            this.txtTel.TextChanged += new System.EventHandler(this.txtTel_TextChanged);
            this.txtTel.Enter += new System.EventHandler(this.txtTel_Enter);
            // 
            // txtPersonContact
            // 
            this.txtPersonContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPersonContact.Location = new System.Drawing.Point(95, 166);
            this.txtPersonContact.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPersonContact.MaxLength = 75;
            this.txtPersonContact.Name = "txtPersonContact";
            this.txtPersonContact.Size = new System.Drawing.Size(288, 28);
            this.txtPersonContact.TabIndex = 11;
            this.txtPersonContact.Enter += new System.EventHandler(this.txtTel_Enter);
            // 
            // txtTelContact
            // 
            this.txtTelContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelContact.Location = new System.Drawing.Point(415, 166);
            this.txtTelContact.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTelContact.MaxLength = 15;
            this.txtTelContact.Name = "txtTelContact";
            this.txtTelContact.Size = new System.Drawing.Size(143, 28);
            this.txtTelContact.TabIndex = 10;
            this.txtTelContact.TextChanged += new System.EventHandler(this.txtTelContact_TextChanged);
            this.txtTelContact.Enter += new System.EventHandler(this.txtTel_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 22);
            this.label5.TabIndex = 625;
            this.label5.Text = "Adresse :";
            // 
            // txtAnnee
            // 
            this.txtAnnee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAnnee.Location = new System.Drawing.Point(349, 91);
            this.txtAnnee.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtAnnee.MaxLength = 4;
            this.txtAnnee.Name = "txtAnnee";
            this.txtAnnee.Size = new System.Drawing.Size(59, 28);
            this.txtAnnee.TabIndex = 7;
            this.txtAnnee.TextChanged += new System.EventHandler(this.txtAge_TextChanged);
            this.txtAnnee.Enter += new System.EventHandler(this.txtAge_Enter);
            this.txtAnnee.Leave += new System.EventHandler(this.txtAge_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 123);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 22);
            this.label7.TabIndex = 626;
            this.label7.Text = "Téléphone :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 169);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 22);
            this.label8.TabIndex = 627;
            this.label8.Text = "Pers. contact : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(385, 169);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 22);
            this.label9.TabIndex = 628;
            this.label9.Text = "Tél. :";
            // 
            // cboSexe
            // 
            this.cboSexe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSexe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSexe.FormattingEnabled = true;
            this.cboSexe.Items.AddRange(new object[] {
            "F",
            "M"});
            this.cboSexe.Location = new System.Drawing.Point(95, 90);
            this.cboSexe.Name = "cboSexe";
            this.cboSexe.Size = new System.Drawing.Size(141, 30);
            this.cboSexe.TabIndex = 5;
            this.cboSexe.SelectedIndexChanged += new System.EventHandler(this.cboSexe_SelectedIndexChanged);
            this.cboSexe.Enter += new System.EventHandler(this.cboSexe_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 94);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 22);
            this.label6.TabIndex = 630;
            this.label6.Text = "Sexe :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 631;
            this.label2.Text = "Né(e) en :";
            // 
            // cboTypePatient
            // 
            this.cboTypePatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypePatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTypePatient.FormattingEnabled = true;
            this.cboTypePatient.Location = new System.Drawing.Point(95, 61);
            this.cboTypePatient.Name = "cboTypePatient";
            this.cboTypePatient.Size = new System.Drawing.Size(141, 30);
            this.cboTypePatient.TabIndex = 1;
            this.cboTypePatient.DropDown += new System.EventHandler(this.cboTypePatient_DropDown);
            this.cboTypePatient.SelectedIndexChanged += new System.EventHandler(this.cboTypePatient_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 22);
            this.label3.TabIndex = 636;
            this.label3.Text = "Type :";
            // 
            // txtMois
            // 
            this.txtMois.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMois.Location = new System.Drawing.Point(307, 91);
            this.txtMois.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMois.MaxLength = 2;
            this.txtMois.Name = "txtMois";
            this.txtMois.Size = new System.Drawing.Size(40, 28);
            this.txtMois.TabIndex = 6;
            this.txtMois.TextChanged += new System.EventHandler(this.txtMois_TextChanged);
            this.txtMois.Enter += new System.EventHandler(this.txtMois_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 22);
            this.label4.TabIndex = 648;
            this.label4.Text = "Consultation :";
            // 
            // rbNouveau
            // 
            this.rbNouveau.AutoSize = true;
            this.rbNouveau.ForeColor = System.Drawing.Color.MediumBlue;
            this.rbNouveau.Location = new System.Drawing.Point(97, 15);
            this.rbNouveau.Name = "rbNouveau";
            this.rbNouveau.Size = new System.Drawing.Size(140, 26);
            this.rbNouveau.TabIndex = 649;
            this.rbNouveau.TabStop = true;
            this.rbNouveau.Text = "Nouveau cas";
            this.rbNouveau.UseVisualStyleBackColor = true;
            this.rbNouveau.Click += new System.EventHandler(this.rbNouveau_Click);
            // 
            // rbUrgence
            // 
            this.rbUrgence.AutoSize = true;
            this.rbUrgence.ForeColor = System.Drawing.Color.MediumBlue;
            this.rbUrgence.Location = new System.Drawing.Point(97, 40);
            this.rbUrgence.Name = "rbUrgence";
            this.rbUrgence.Size = new System.Drawing.Size(103, 26);
            this.rbUrgence.TabIndex = 649;
            this.rbUrgence.TabStop = true;
            this.rbUrgence.Text = "Urgence";
            this.rbUrgence.UseVisualStyleBackColor = true;
            this.rbUrgence.Click += new System.EventHandler(this.rbUrgence_Click);
            // 
            // cboTypeFacture
            // 
            this.cboTypeFacture.DropDownHeight = 50;
            this.cboTypeFacture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeFacture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTypeFacture.FormattingEnabled = true;
            this.cboTypeFacture.IntegralHeight = false;
            this.cboTypeFacture.Items.AddRange(new object[] {
            "immédiat",
            "différé"});
            this.cboTypeFacture.Location = new System.Drawing.Point(288, 17);
            this.cboTypeFacture.MaxDropDownItems = 10;
            this.cboTypeFacture.Name = "cboTypeFacture";
            this.cboTypeFacture.Size = new System.Drawing.Size(142, 30);
            this.cboTypeFacture.TabIndex = 650;
            // 
            // lblDateOperation
            // 
            this.lblDateOperation.ForeColor = System.Drawing.Color.IndianRed;
            this.lblDateOperation.Location = new System.Drawing.Point(285, 44);
            this.lblDateOperation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDateOperation.Name = "lblDateOperation";
            this.lblDateOperation.Size = new System.Drawing.Size(80, 15);
            this.lblDateOperation.TabIndex = 651;
            this.lblDateOperation.Text = "jj/mm/aaaa";
            this.lblDateOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(202, 42);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 22);
            this.label11.TabIndex = 652;
            this.label11.Text = "Date :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(202, 20);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 22);
            this.label12.TabIndex = 653;
            this.label12.Text = "Type facture :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTaux);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.rbUrgence);
            this.groupBox1.Controls.Add(this.cboTypeFacture);
            this.groupBox1.Controls.Add(this.rbNouveau);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblDateOperation);
            this.groupBox1.Location = new System.Drawing.Point(95, 194);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 73);
            this.groupBox1.TabIndex = 654;
            this.groupBox1.TabStop = false;
            // 
            // lblTaux
            // 
            this.lblTaux.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTaux.Location = new System.Drawing.Point(375, 44);
            this.lblTaux.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTaux.Name = "lblTaux";
            this.lblTaux.Size = new System.Drawing.Size(55, 15);
            this.lblTaux.TabIndex = 654;
            this.lblTaux.Text = "0000";
            this.lblTaux.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTaux.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.checkBox1.Location = new System.Drawing.Point(566, 168);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(100, 26);
            this.checkBox1.TabIndex = 655;
            this.checkBox1.Text = "ZS/HZS";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // FormPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMois);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.cboTypePatient);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnAffecter);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.dgvPatient);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtAdresse);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtPersonContact);
            this.Controls.Add(this.txtTelContact);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAnnee);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboSexe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormPatient";
            this.ShowIcon = false;
            this.Text = "FormPatient";
            this.Shown += new System.EventHandler(this.FormPatient_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button btnQuitter;
        public System.Windows.Forms.Button btnAffecter;
        public System.Windows.Forms.TextBox txtRecherche;
        public System.Windows.Forms.DataGridView dgvPatient;
        public System.Windows.Forms.Button btnRecherche;
        public System.Windows.Forms.Button btnEnregistrer;
        public System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtNom;
        public System.Windows.Forms.TextBox txtAdresse;
        public System.Windows.Forms.TextBox txtTel;
        public System.Windows.Forms.TextBox txtPersonContact;
        public System.Windows.Forms.TextBox txtTelContact;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtAnnee;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cboSexe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cboTypePatient;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnModifier;
        public System.Windows.Forms.Button btnSupprimer;
        public System.Windows.Forms.TextBox txtMois;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.RadioButton rbNouveau;
        public System.Windows.Forms.RadioButton rbUrgence;
        public System.Windows.Forms.ComboBox cboTypeFacture;
        public System.Windows.Forms.Label lblDateOperation;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lblTaux;
        public System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        public System.Windows.Forms.Button btnAnnuler;

    }
}