namespace SUMEDCO
{
    partial class TresoFlux
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TresoFlux));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboMonnaie = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnEntree = new System.Windows.Forms.Button();
            this.dgvFlux = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboOperation = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDateDe = new System.Windows.Forms.DateTimePicker();
            this.dtpDateA = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExporter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSortie = new System.Windows.Forms.Button();
            this.lblCDF = new System.Windows.Forms.Label();
            this.lblUSD = new System.Windows.Forms.Label();
            this.lblSolde = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chbSolde = new System.Windows.Forms.CheckBox();
            this.btnPrepEcriture = new System.Windows.Forms.Button();
            this.btnEffectifs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlux)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.btnExit.Location = new System.Drawing.Point(676, 31);
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
            this.panel2.Size = new System.Drawing.Size(707, 30);
            this.panel2.TabIndex = 618;
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
            this.cboMonnaie.Location = new System.Drawing.Point(506, 24);
            this.cboMonnaie.MaxDropDownItems = 10;
            this.cboMonnaie.Name = "cboMonnaie";
            this.cboMonnaie.Size = new System.Drawing.Size(69, 26);
            this.cboMonnaie.Sorted = true;
            this.cboMonnaie.TabIndex = 625;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(431, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 18);
            this.label7.TabIndex = 626;
            this.label7.Text = "CDF/USD:";
            // 
            // btnAfficher
            // 
            this.btnAfficher.BackColor = System.Drawing.Color.Transparent;
            this.btnAfficher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAfficher.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAfficher.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAfficher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAfficher.Location = new System.Drawing.Point(584, 24);
            this.btnAfficher.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Size = new System.Drawing.Size(85, 27);
            this.btnAfficher.TabIndex = 655;
            this.btnAfficher.Text = "Rechercher";
            this.btnAfficher.UseVisualStyleBackColor = false;
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.Transparent;
            this.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnnuler.Enabled = false;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(377, 139);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(80, 27);
            this.btnAnnuler.TabIndex = 658;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnEntree
            // 
            this.btnEntree.BackColor = System.Drawing.Color.Transparent;
            this.btnEntree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEntree.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEntree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEntree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntree.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntree.Image = ((System.Drawing.Image)(resources.GetObject("btnEntree.Image")));
            this.btnEntree.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntree.Location = new System.Drawing.Point(12, 139);
            this.btnEntree.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEntree.Name = "btnEntree";
            this.btnEntree.Size = new System.Drawing.Size(80, 27);
            this.btnEntree.TabIndex = 765;
            this.btnEntree.Text = "Entrée";
            this.btnEntree.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEntree.UseVisualStyleBackColor = false;
            this.btnEntree.Click += new System.EventHandler(this.btnEntree_Click);
            // 
            // dgvFlux
            // 
            this.dgvFlux.AllowUserToAddRows = false;
            this.dgvFlux.AllowUserToDeleteRows = false;
            this.dgvFlux.AllowUserToResizeRows = false;
            this.dgvFlux.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFlux.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFlux.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvFlux.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFlux.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFlux.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFlux.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFlux.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFlux.EnableHeadersVisualStyles = false;
            this.dgvFlux.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.dgvFlux.Location = new System.Drawing.Point(12, 174);
            this.dgvFlux.MultiSelect = false;
            this.dgvFlux.Name = "dgvFlux";
            this.dgvFlux.ReadOnly = true;
            this.dgvFlux.RowHeadersVisible = false;
            this.dgvFlux.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlux.Size = new System.Drawing.Size(683, 274);
            this.dgvFlux.TabIndex = 656;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboOperation);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpDateDe);
            this.groupBox1.Controls.Add(this.dtpDateA);
            this.groupBox1.Controls.Add(this.cboMonnaie);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAfficher);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 63);
            this.groupBox1.TabIndex = 764;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rechercher";
            // 
            // cboOperation
            // 
            this.cboOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboOperation.FormattingEnabled = true;
            this.cboOperation.Items.AddRange(new object[] {
            "entrée",
            "sortie"});
            this.cboOperation.Location = new System.Drawing.Point(316, 24);
            this.cboOperation.Name = "cboOperation";
            this.cboOperation.Size = new System.Drawing.Size(112, 26);
            this.cboOperation.Sorted = true;
            this.cboOperation.TabIndex = 694;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 695;
            this.label4.Text = "Opération :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 18);
            this.label5.TabIndex = 692;
            this.label5.Text = "à";
            // 
            // dtpDateDe
            // 
            this.dtpDateDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDe.Location = new System.Drawing.Point(36, 24);
            this.dtpDateDe.Name = "dtpDateDe";
            this.dtpDateDe.Size = new System.Drawing.Size(86, 24);
            this.dtpDateDe.TabIndex = 691;
            // 
            // dtpDateA
            // 
            this.dtpDateA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateA.Location = new System.Drawing.Point(142, 24);
            this.dtpDateA.Name = "dtpDateA";
            this.dtpDateA.Size = new System.Drawing.Size(86, 24);
            this.dtpDateA.TabIndex = 690;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 18);
            this.label3.TabIndex = 693;
            this.label3.Text = "De:";
            // 
            // btnExporter
            // 
            this.btnExporter.BackColor = System.Drawing.Color.Transparent;
            this.btnExporter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExporter.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnExporter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnExporter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExporter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExporter.Location = new System.Drawing.Point(193, 139);
            this.btnExporter.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnExporter.Name = "btnExporter";
            this.btnExporter.Size = new System.Drawing.Size(80, 27);
            this.btnExporter.TabIndex = 750;
            this.btnExporter.Text = "Exporter";
            this.btnExporter.UseVisualStyleBackColor = false;
            this.btnExporter.Click += new System.EventHandler(this.btnExporter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.Transparent;
            this.btnModifier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnModifier.Enabled = false;
            this.btnModifier.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnModifier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.Location = new System.Drawing.Point(468, 139);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(80, 27);
            this.btnModifier.TabIndex = 767;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSortie
            // 
            this.btnSortie.BackColor = System.Drawing.Color.Transparent;
            this.btnSortie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSortie.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSortie.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSortie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSortie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSortie.Image = ((System.Drawing.Image)(resources.GetObject("btnSortie.Image")));
            this.btnSortie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSortie.Location = new System.Drawing.Point(102, 139);
            this.btnSortie.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSortie.Name = "btnSortie";
            this.btnSortie.Size = new System.Drawing.Size(80, 27);
            this.btnSortie.TabIndex = 769;
            this.btnSortie.Text = "Sortie";
            this.btnSortie.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSortie.UseVisualStyleBackColor = false;
            this.btnSortie.Click += new System.EventHandler(this.btnSortie_Click);
            // 
            // lblCDF
            // 
            this.lblCDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCDF.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCDF.Location = new System.Drawing.Point(110, 39);
            this.lblCDF.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCDF.Name = "lblCDF";
            this.lblCDF.Size = new System.Drawing.Size(180, 15);
            this.lblCDF.TabIndex = 771;
            this.lblCDF.Text = "00,00";
            this.lblCDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUSD
            // 
            this.lblUSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUSD.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblUSD.Location = new System.Drawing.Point(403, 39);
            this.lblUSD.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUSD.Name = "lblUSD";
            this.lblUSD.Size = new System.Drawing.Size(180, 15);
            this.lblUSD.TabIndex = 771;
            this.lblUSD.Text = "00,00";
            this.lblUSD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSolde
            // 
            this.lblSolde.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSolde.Location = new System.Drawing.Point(9, 39);
            this.lblSolde.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSolde.Name = "lblSolde";
            this.lblSolde.Size = new System.Drawing.Size(89, 15);
            this.lblSolde.TabIndex = 771;
            this.lblSolde.Text = "Solde CDF:";
            this.lblSolde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(302, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 771;
            this.label1.Text = "Solde USD:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chbSolde
            // 
            this.chbSolde.AutoSize = true;
            this.chbSolde.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chbSolde.Location = new System.Drawing.Point(592, 36);
            this.chbSolde.Name = "chbSolde";
            this.chbSolde.Size = new System.Drawing.Size(68, 22);
            this.chbSolde.TabIndex = 778;
            this.chbSolde.Text = "Solde";
            this.chbSolde.UseVisualStyleBackColor = true;
            this.chbSolde.Click += new System.EventHandler(this.chbSolde_Click);
            // 
            // btnPrepEcriture
            // 
            this.btnPrepEcriture.BackColor = System.Drawing.Color.Transparent;
            this.btnPrepEcriture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrepEcriture.Enabled = false;
            this.btnPrepEcriture.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPrepEcriture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPrepEcriture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrepEcriture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrepEcriture.Location = new System.Drawing.Point(559, 139);
            this.btnPrepEcriture.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPrepEcriture.Name = "btnPrepEcriture";
            this.btnPrepEcriture.Size = new System.Drawing.Size(100, 27);
            this.btnPrepEcriture.TabIndex = 768;
            this.btnPrepEcriture.Text = "Comptabiliser";
            this.btnPrepEcriture.UseVisualStyleBackColor = false;
            this.btnPrepEcriture.Click += new System.EventHandler(this.btnPrepEcriture_Click);
            // 
            // btnEffectifs
            // 
            this.btnEffectifs.BackColor = System.Drawing.Color.Transparent;
            this.btnEffectifs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEffectifs.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEffectifs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEffectifs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEffectifs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEffectifs.Location = new System.Drawing.Point(285, 139);
            this.btnEffectifs.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnEffectifs.Name = "btnEffectifs";
            this.btnEffectifs.Size = new System.Drawing.Size(80, 27);
            this.btnEffectifs.TabIndex = 779;
            this.btnEffectifs.Text = "Effectifs";
            this.btnEffectifs.UseVisualStyleBackColor = false;
            this.btnEffectifs.Click += new System.EventHandler(this.btnEffectifs_Click);
            // 
            // TresoFlux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(707, 460);
            this.Controls.Add(this.btnEffectifs);
            this.Controls.Add(this.chbSolde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSolde);
            this.Controls.Add(this.lblUSD);
            this.Controls.Add(this.lblCDF);
            this.Controls.Add(this.btnSortie);
            this.Controls.Add(this.btnPrepEcriture);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnEntree);
            this.Controls.Add(this.btnExporter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.dgvFlux);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TresoFlux";
            this.ShowIcon = false;
            this.Shown += new System.EventHandler(this.TresoFlux_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlux)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.ComboBox cboMonnaie;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button btnAfficher;
        public System.Windows.Forms.DataGridView dgvFlux;
        public System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnExporter;
        public System.Windows.Forms.ComboBox cboOperation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DateTimePicker dtpDateDe;
        public System.Windows.Forms.DateTimePicker dtpDateA;
        public System.Windows.Forms.Button btnEntree;
        public System.Windows.Forms.Button btnModifier;
        public System.Windows.Forms.Button btnSortie;
        public System.Windows.Forms.Label lblCDF;
        public System.Windows.Forms.Label lblUSD;
        public System.Windows.Forms.Label lblSolde;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox chbSolde;
        public System.Windows.Forms.Button btnPrepEcriture;
        public System.Windows.Forms.Button btnEffectifs;
    }
}