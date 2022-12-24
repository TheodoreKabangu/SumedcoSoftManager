﻿namespace SUMEDCO
{
    partial class FormFactureService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFactureService));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtPayeur = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateOperation = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.lblTaux = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDate = new System.Windows.Forms.Button();
            this.cboTypeFacture = new System.Windows.Forms.ComboBox();
            this.dgvFacture = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRetirer = new System.Windows.Forms.Button();
            this.btnRetirerTout = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnRecherche = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnService = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cboPayeurDiffere = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacture)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPayeur
            // 
            this.txtPayeur.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPayeur.Location = new System.Drawing.Point(119, 107);
            this.txtPayeur.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtPayeur.MaxLength = 75;
            this.txtPayeur.Name = "txtPayeur";
            this.txtPayeur.Size = new System.Drawing.Size(422, 21);
            this.txtPayeur.TabIndex = 2;
            this.txtPayeur.Enter += new System.EventHandler(this.txtPayeur_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 540;
            this.label1.Text = "Payeur :";
            // 
            // lblDateOperation
            // 
            this.lblDateOperation.ForeColor = System.Drawing.Color.IndianRed;
            this.lblDateOperation.Location = new System.Drawing.Point(116, 49);
            this.lblDateOperation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDateOperation.Name = "lblDateOperation";
            this.lblDateOperation.Size = new System.Drawing.Size(80, 15);
            this.lblDateOperation.TabIndex = 540;
            this.lblDateOperation.Text = "jj/mm/aaaa";
            this.lblDateOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 15);
            this.label3.TabIndex = 540;
            this.label3.Text = "Date d\'édition :";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.Transparent;
            this.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnnuler.FlatAppearance.BorderSize = 0;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("btnAnnuler.Image")));
            this.btnAnnuler.Location = new System.Drawing.Point(219, 138);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(30, 27);
            this.btnAnnuler.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnAnnuler, "Annuler le bon");
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.Transparent;
            this.btnEnregistrer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnregistrer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEnregistrer.FlatAppearance.BorderSize = 0;
            this.btnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.Image = ((System.Drawing.Image)(resources.GetObject("btnEnregistrer.Image")));
            this.btnEnregistrer.Location = new System.Drawing.Point(261, 138);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(30, 27);
            this.btnEnregistrer.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnEnregistrer, "Enregistrer le bon");
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // lblTaux
            // 
            this.lblTaux.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTaux.Location = new System.Drawing.Point(330, 49);
            this.lblTaux.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTaux.Name = "lblTaux";
            this.lblTaux.Size = new System.Drawing.Size(91, 15);
            this.lblTaux.TabIndex = 540;
            this.lblTaux.Text = "0000";
            this.lblTaux.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 540;
            this.label4.Text = "Taux du jour :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 540;
            this.label2.Text = "Type de facture :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 27);
            this.panel2.TabIndex = 590;
            // 
            // btnDate
            // 
            this.btnDate.BackColor = System.Drawing.Color.Transparent;
            this.btnDate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDate.BackgroundImage")));
            this.btnDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDate.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnDate.FlatAppearance.BorderSize = 0;
            this.btnDate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDate.Location = new System.Drawing.Point(202, 47);
            this.btnDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(30, 21);
            this.btnDate.TabIndex = 591;
            this.toolTip1.SetToolTip(this.btnDate, "Changer la date");
            this.btnDate.UseVisualStyleBackColor = false;
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
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
            this.cboTypeFacture.Location = new System.Drawing.Point(119, 76);
            this.cboTypeFacture.MaxDropDownItems = 10;
            this.cboTypeFacture.Name = "cboTypeFacture";
            this.cboTypeFacture.Size = new System.Drawing.Size(172, 23);
            this.cboTypeFacture.TabIndex = 1;
            this.cboTypeFacture.SelectedIndexChanged += new System.EventHandler(this.cboTypeFacture_SelectedIndexChanged);
            // 
            // dgvFacture
            // 
            this.dgvFacture.AllowUserToAddRows = false;
            this.dgvFacture.AllowUserToDeleteRows = false;
            this.dgvFacture.AllowUserToOrderColumns = true;
            this.dgvFacture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvFacture.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvFacture.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFacture.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFacture.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvFacture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacture.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column3,
            this.Column8,
            this.Column1});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFacture.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvFacture.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvFacture.Location = new System.Drawing.Point(119, 173);
            this.dgvFacture.MultiSelect = false;
            this.dgvFacture.Name = "dgvFacture";
            this.dgvFacture.ReadOnly = true;
            this.dgvFacture.RowHeadersVisible = false;
            this.dgvFacture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacture.Size = new System.Drawing.Size(572, 246);
            this.dgvFacture.TabIndex = 595;
            this.dgvFacture.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacture_CellClick);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "id";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            this.Column4.Width = 40;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "N°";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 40;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "Motif";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column1.HeaderText = "Prix unitaire";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
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
            this.btnRetirer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirer.Image = ((System.Drawing.Image)(resources.GetObject("btnRetirer.Image")));
            this.btnRetirer.Location = new System.Drawing.Point(302, 137);
            this.btnRetirer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRetirer.Name = "btnRetirer";
            this.btnRetirer.Size = new System.Drawing.Size(30, 27);
            this.btnRetirer.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnRetirer, "Rétirer la ligne");
            this.btnRetirer.UseVisualStyleBackColor = false;
            this.btnRetirer.Click += new System.EventHandler(this.btnRetirer_Click);
            // 
            // btnRetirerTout
            // 
            this.btnRetirerTout.BackColor = System.Drawing.Color.Transparent;
            this.btnRetirerTout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRetirerTout.Enabled = false;
            this.btnRetirerTout.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRetirerTout.FlatAppearance.BorderSize = 0;
            this.btnRetirerTout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRetirerTout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetirerTout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirerTout.Image = ((System.Drawing.Image)(resources.GetObject("btnRetirerTout.Image")));
            this.btnRetirerTout.Location = new System.Drawing.Point(342, 137);
            this.btnRetirerTout.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRetirerTout.Name = "btnRetirerTout";
            this.btnRetirerTout.Size = new System.Drawing.Size(30, 27);
            this.btnRetirerTout.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnRetirerTout, "Rétirer tout");
            this.btnRetirerTout.UseVisualStyleBackColor = false;
            this.btnRetirerTout.Click += new System.EventHandler(this.btnRetirerTout_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtTotal.Location = new System.Drawing.Point(563, 427);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(128, 14);
            this.txtTotal.TabIndex = 615;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(482, 427);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 614;
            this.label7.Text = "Total Gén. :";
            // 
            // btnRecherche
            // 
            this.btnRecherche.BackColor = System.Drawing.Color.Transparent;
            this.btnRecherche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecherche.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRecherche.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRecherche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecherche.Image = ((System.Drawing.Image)(resources.GetObject("btnRecherche.Image")));
            this.btnRecherche.Location = new System.Drawing.Point(541, 107);
            this.btnRecherche.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(30, 21);
            this.btnRecherche.TabIndex = 618;
            this.toolTip1.SetToolTip(this.btnRecherche, "Attacher à un malade");
            this.btnRecherche.UseVisualStyleBackColor = false;
            this.btnRecherche.Click += new System.EventHandler(this.btnRecherche_Click);
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
            this.btnExit.TabIndex = 616;
            this.toolTip1.SetToolTip(this.btnExit, "Fermer");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnService
            // 
            this.btnService.BackColor = System.Drawing.Color.Transparent;
            this.btnService.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnService.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnService.FlatAppearance.BorderSize = 0;
            this.btnService.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnService.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnService.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnService.Image = ((System.Drawing.Image)(resources.GetObject("btnService.Image")));
            this.btnService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnService.Location = new System.Drawing.Point(119, 138);
            this.btnService.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnService.Name = "btnService";
            this.btnService.Size = new System.Drawing.Size(88, 27);
            this.btnService.TabIndex = 707;
            this.btnService.Text = "Facturier";
            this.btnService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnService, "Ajouter les services");
            this.btnService.UseVisualStyleBackColor = false;
            this.btnService.Click += new System.EventHandler(this.btnService_Click);
            this.btnService.Enter += new System.EventHandler(this.btnService_Enter);
            // 
            // cboPayeurDiffere
            // 
            this.cboPayeurDiffere.DropDownHeight = 150;
            this.cboPayeurDiffere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPayeurDiffere.Enabled = false;
            this.cboPayeurDiffere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPayeurDiffere.FormattingEnabled = true;
            this.cboPayeurDiffere.IntegralHeight = false;
            this.cboPayeurDiffere.Items.AddRange(new object[] {
            "immédiat",
            "différé"});
            this.cboPayeurDiffere.Location = new System.Drawing.Point(297, 76);
            this.cboPayeurDiffere.MaxDropDownItems = 10;
            this.cboPayeurDiffere.Name = "cboPayeurDiffere";
            this.cboPayeurDiffere.Size = new System.Drawing.Size(274, 23);
            this.cboPayeurDiffere.TabIndex = 706;
            this.cboPayeurDiffere.SelectedIndexChanged += new System.EventHandler(this.cboPayeurDiffere_SelectedIndexChanged);
            // 
            // FormFactureService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.btnService);
            this.Controls.Add(this.cboPayeurDiffere);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnRetirer);
            this.Controls.Add(this.btnRetirerTout);
            this.Controls.Add(this.dgvFacture);
            this.Controls.Add(this.cboTypeFacture);
            this.Controls.Add(this.btnDate);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.txtPayeur);
            this.Controls.Add(this.lblTaux);
            this.Controls.Add(this.lblDateOperation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(719, 490);
            this.Name = "FormFactureService";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormFacturation";
            this.Shown += new System.EventHandler(this.FormFacturation_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtPayeur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnDate;
        public System.Windows.Forms.ComboBox cboTypeFacture;
        public System.Windows.Forms.DataGridView dgvFacture;
        public System.Windows.Forms.Button btnRetirer;
        public System.Windows.Forms.Button btnRetirerTout;
        public System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.Label lblDateOperation;
        public System.Windows.Forms.Button btnAnnuler;
        public System.Windows.Forms.Button btnEnregistrer;
        public System.Windows.Forms.Button btnRecherche;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.Label lblTaux;
        public System.Windows.Forms.ComboBox cboPayeurDiffere;
        public System.Windows.Forms.Button btnService;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}