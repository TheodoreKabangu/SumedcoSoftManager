﻿namespace SUMEDCO
{
    partial class FormComptabilite
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComptabilite));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMontant = new System.Windows.Forms.TextBox();
            this.txtNumPiece = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.dgvEcriture = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblCompte1 = new System.Windows.Forms.Label();
            this.txtMotif = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboMonnaie = new System.Windows.Forms.ComboBox();
            this.cboTypeJournal = new System.Windows.Forms.ComboBox();
            this.btnDate = new System.Windows.Forms.Button();
            this.lblTaux = new System.Windows.Forms.Label();
            this.lblDateOperation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNouveauJournal = new System.Windows.Forms.Button();
            this.btnRetirer = new System.Windows.Forms.Button();
            this.btnRetirerTout = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnValider = new System.Windows.Forms.Button();
            this.txtCompte1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCompte1 = new System.Windows.Forms.Button();
            this.cboDebitCredit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCompte2 = new System.Windows.Forms.Label();
            this.txtCompte2 = new System.Windows.Forms.TextBox();
            this.btnCompte2 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEcriture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(707, 30);
            this.panel2.TabIndex = 620;
            // 
            // txtMontant
            // 
            this.txtMontant.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtMontant.Location = new System.Drawing.Point(300, 145);
            this.txtMontant.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMontant.MaxLength = 16;
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(125, 24);
            this.txtMontant.TabIndex = 6;
            this.txtMontant.Enter += new System.EventHandler(this.txtMontant_Enter);
            this.txtMontant.Leave += new System.EventHandler(this.txtMontant_Leave);
            // 
            // txtNumPiece
            // 
            this.txtNumPiece.Location = new System.Drawing.Point(109, 85);
            this.txtNumPiece.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtNumPiece.MaxLength = 30;
            this.txtNumPiece.Name = "txtNumPiece";
            this.txtNumPiece.Size = new System.Drawing.Size(171, 24);
            this.txtNumPiece.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 85);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(107, 18);
            this.label20.TabIndex = 642;
            this.label20.Text = "N° de la pièce :";
            // 
            // dgvEcriture
            // 
            this.dgvEcriture.AllowUserToAddRows = false;
            this.dgvEcriture.AllowUserToDeleteRows = false;
            this.dgvEcriture.AllowUserToOrderColumns = true;
            this.dgvEcriture.AllowUserToResizeColumns = false;
            this.dgvEcriture.AllowUserToResizeRows = false;
            this.dgvEcriture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEcriture.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvEcriture.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEcriture.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEcriture.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEcriture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEcriture.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.Column1,
            this.dataGridViewTextBoxColumn10,
            this.Column3});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEcriture.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvEcriture.EnableHeadersVisualStyles = false;
            this.dgvEcriture.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.dgvEcriture.Location = new System.Drawing.Point(109, 245);
            this.dgvEcriture.MultiSelect = false;
            this.dgvEcriture.Name = "dgvEcriture";
            this.dgvEcriture.ReadOnly = true;
            this.dgvEcriture.RowHeadersVisible = false;
            this.dgvEcriture.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvEcriture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEcriture.Size = new System.Drawing.Size(580, 194);
            this.dgvEcriture.TabIndex = 638;
            this.dgvEcriture.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEcriture_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 18);
            this.label4.TabIndex = 627;
            this.label4.Text = "Journal :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(238, 148);
            this.label22.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 18);
            this.label22.TabIndex = 625;
            this.label22.Text = "Montant :";
            // 
            // lblCompte1
            // 
            this.lblCompte1.AutoSize = true;
            this.lblCompte1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCompte1.Location = new System.Drawing.Point(238, 116);
            this.lblCompte1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCompte1.Name = "lblCompte1";
            this.lblCompte1.Size = new System.Drawing.Size(50, 18);
            this.lblCompte1.TabIndex = 623;
            this.lblCompte1.Text = "Débit :";
            // 
            // txtMotif
            // 
            this.txtMotif.Location = new System.Drawing.Point(109, 175);
            this.txtMotif.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMotif.MaxLength = 25;
            this.txtMotif.Name = "txtMotif";
            this.txtMotif.Size = new System.Drawing.Size(286, 24);
            this.txtMotif.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 176);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 18);
            this.label10.TabIndex = 628;
            this.label10.Text = "Motif :";
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
            this.cboMonnaie.Location = new System.Drawing.Point(492, 145);
            this.cboMonnaie.MaxDropDownItems = 10;
            this.cboMonnaie.Name = "cboMonnaie";
            this.cboMonnaie.Size = new System.Drawing.Size(60, 26);
            this.cboMonnaie.Sorted = true;
            this.cboMonnaie.TabIndex = 7;
            this.cboMonnaie.SelectedIndexChanged += new System.EventHandler(this.cboMonnaie_SelectedIndexChanged);
            this.cboMonnaie.Enter += new System.EventHandler(this.cboMonnaie_Enter);
            // 
            // cboTypeJournal
            // 
            this.cboTypeJournal.DropDownHeight = 150;
            this.cboTypeJournal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeJournal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTypeJournal.FormattingEnabled = true;
            this.cboTypeJournal.IntegralHeight = false;
            this.cboTypeJournal.Location = new System.Drawing.Point(350, 83);
            this.cboTypeJournal.MaxDropDownItems = 10;
            this.cboTypeJournal.Name = "cboTypeJournal";
            this.cboTypeJournal.Size = new System.Drawing.Size(202, 26);
            this.cboTypeJournal.Sorted = true;
            this.cboTypeJournal.TabIndex = 2;
            this.cboTypeJournal.DropDown += new System.EventHandler(this.cboTypeJournal_DropDown);
            this.cboTypeJournal.SelectedIndexChanged += new System.EventHandler(this.cboTypeJournal_SelectedIndexChanged);
            this.cboTypeJournal.Enter += new System.EventHandler(this.cboTypeJournal_Enter);
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
            this.btnDate.Location = new System.Drawing.Point(192, 55);
            this.btnDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(30, 21);
            this.btnDate.TabIndex = 653;
            this.toolTip1.SetToolTip(this.btnDate, "Changer la date");
            this.btnDate.UseVisualStyleBackColor = false;
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            // 
            // lblTaux
            // 
            this.lblTaux.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTaux.Location = new System.Drawing.Point(318, 57);
            this.lblTaux.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTaux.Name = "lblTaux";
            this.lblTaux.Size = new System.Drawing.Size(91, 15);
            this.lblTaux.TabIndex = 649;
            this.lblTaux.Text = "0000";
            this.lblTaux.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDateOperation
            // 
            this.lblDateOperation.ForeColor = System.Drawing.Color.IndianRed;
            this.lblDateOperation.Location = new System.Drawing.Point(106, 57);
            this.lblDateOperation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDateOperation.Name = "lblDateOperation";
            this.lblDateOperation.Size = new System.Drawing.Size(80, 15);
            this.lblDateOperation.TabIndex = 650;
            this.lblDateOperation.Text = "jj/mm/aaaa";
            this.lblDateOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 651;
            this.label1.Text = "Taux du jour :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 652;
            this.label3.Text = "Date du jour :";
            // 
            // btnNouveauJournal
            // 
            this.btnNouveauJournal.BackColor = System.Drawing.Color.Transparent;
            this.btnNouveauJournal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNouveauJournal.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnNouveauJournal.FlatAppearance.BorderSize = 0;
            this.btnNouveauJournal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNouveauJournal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouveauJournal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouveauJournal.Image = ((System.Drawing.Image)(resources.GetObject("btnNouveauJournal.Image")));
            this.btnNouveauJournal.Location = new System.Drawing.Point(556, 83);
            this.btnNouveauJournal.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnNouveauJournal.Name = "btnNouveauJournal";
            this.btnNouveauJournal.Size = new System.Drawing.Size(30, 23);
            this.btnNouveauJournal.TabIndex = 655;
            this.toolTip1.SetToolTip(this.btnNouveauJournal, "Ajouter un journal");
            this.btnNouveauJournal.UseVisualStyleBackColor = false;
            this.btnNouveauJournal.Click += new System.EventHandler(this.btnNouveauJournal_Click);
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
            this.btnRetirer.Location = new System.Drawing.Point(192, 206);
            this.btnRetirer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRetirer.Name = "btnRetirer";
            this.btnRetirer.Size = new System.Drawing.Size(30, 30);
            this.btnRetirer.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnRetirer, "Retirer");
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
            this.btnRetirerTout.Location = new System.Drawing.Point(232, 206);
            this.btnRetirerTout.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRetirerTout.Name = "btnRetirerTout";
            this.btnRetirerTout.Size = new System.Drawing.Size(30, 30);
            this.btnRetirerTout.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnRetirerTout, "Retirer tout");
            this.btnRetirerTout.UseVisualStyleBackColor = false;
            this.btnRetirerTout.Click += new System.EventHandler(this.btnRetirerTout_Click);
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
            this.btnEnregistrer.Location = new System.Drawing.Point(151, 207);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(30, 30);
            this.btnEnregistrer.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnEnregistrer, "Enregistrer");
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
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
            this.btnAnnuler.Location = new System.Drawing.Point(109, 207);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(30, 30);
            this.btnAnnuler.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnAnnuler, "Annuler");
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.Transparent;
            this.btnValider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValider.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnValider.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.Image = ((System.Drawing.Image)(resources.GetObject("btnValider.Image")));
            this.btnValider.Location = new System.Drawing.Point(395, 175);
            this.btnValider.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(30, 21);
            this.btnValider.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnValider, "Valider");
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // txtCompte1
            // 
            this.txtCompte1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtCompte1.Enabled = false;
            this.txtCompte1.Location = new System.Drawing.Point(300, 114);
            this.txtCompte1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCompte1.MaxLength = 10;
            this.txtCompte1.Name = "txtCompte1";
            this.txtCompte1.Size = new System.Drawing.Size(95, 24);
            this.txtCompte1.TabIndex = 678;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(428, 148);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 18);
            this.label7.TabIndex = 623;
            this.label7.Text = "CDF/USD :";
            // 
            // btnCompte1
            // 
            this.btnCompte1.BackColor = System.Drawing.Color.Transparent;
            this.btnCompte1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCompte1.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCompte1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCompte1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompte1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompte1.Image = ((System.Drawing.Image)(resources.GetObject("btnCompte1.Image")));
            this.btnCompte1.Location = new System.Drawing.Point(395, 114);
            this.btnCompte1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCompte1.Name = "btnCompte1";
            this.btnCompte1.Size = new System.Drawing.Size(30, 21);
            this.btnCompte1.TabIndex = 4;
            this.btnCompte1.UseVisualStyleBackColor = false;
            this.btnCompte1.Click += new System.EventHandler(this.btnCompte1_Click);
            // 
            // cboDebitCredit
            // 
            this.cboDebitCredit.DropDownHeight = 150;
            this.cboDebitCredit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDebitCredit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDebitCredit.FormattingEnabled = true;
            this.cboDebitCredit.IntegralHeight = false;
            this.cboDebitCredit.Items.AddRange(new object[] {
            "Crédit",
            "Débit"});
            this.cboDebitCredit.Location = new System.Drawing.Point(109, 114);
            this.cboDebitCredit.MaxDropDownItems = 10;
            this.cboDebitCredit.Name = "cboDebitCredit";
            this.cboDebitCredit.Size = new System.Drawing.Size(125, 26);
            this.cboDebitCredit.Sorted = true;
            this.cboDebitCredit.TabIndex = 3;
            this.cboDebitCredit.SelectedIndexChanged += new System.EventHandler(this.cboDebitCredit_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 18);
            this.label5.TabIndex = 681;
            this.label5.Text = "Débit/Crédit :";
            // 
            // lblCompte2
            // 
            this.lblCompte2.AutoSize = true;
            this.lblCompte2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCompte2.Location = new System.Drawing.Point(16, 148);
            this.lblCompte2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCompte2.Name = "lblCompte2";
            this.lblCompte2.Size = new System.Drawing.Size(55, 18);
            this.lblCompte2.TabIndex = 623;
            this.lblCompte2.Text = "Crédit :";
            // 
            // txtCompte2
            // 
            this.txtCompte2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtCompte2.Enabled = false;
            this.txtCompte2.Location = new System.Drawing.Point(109, 145);
            this.txtCompte2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCompte2.MaxLength = 10;
            this.txtCompte2.Name = "txtCompte2";
            this.txtCompte2.Size = new System.Drawing.Size(95, 24);
            this.txtCompte2.TabIndex = 7;
            // 
            // btnCompte2
            // 
            this.btnCompte2.BackColor = System.Drawing.Color.Transparent;
            this.btnCompte2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCompte2.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCompte2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCompte2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompte2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompte2.Image = ((System.Drawing.Image)(resources.GetObject("btnCompte2.Image")));
            this.btnCompte2.Location = new System.Drawing.Point(204, 145);
            this.btnCompte2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCompte2.Name = "btnCompte2";
            this.btnCompte2.Size = new System.Drawing.Size(30, 21);
            this.btnCompte2.TabIndex = 5;
            this.btnCompte2.UseVisualStyleBackColor = false;
            this.btnCompte2.Click += new System.EventHandler(this.btnCompte2_Click);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Compte";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Libellé";
            this.Column1.MaxInputLength = 250;
            this.Column1.MinimumWidth = 200;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn10.HeaderText = "Débit";
            this.dataGridViewTextBoxColumn10.MaxInputLength = 16;
            this.dataGridViewTextBoxColumn10.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column3.HeaderText = "Crédit";
            this.Column3.MaxInputLength = 16;
            this.Column3.MinimumWidth = 100;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // FormComptabilite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(707, 460);
            this.Controls.Add(this.cboDebitCredit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCompte2);
            this.Controls.Add(this.btnCompte1);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.txtCompte2);
            this.Controls.Add(this.txtCompte1);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnRetirer);
            this.Controls.Add(this.btnRetirerTout);
            this.Controls.Add(this.btnNouveauJournal);
            this.Controls.Add(this.btnDate);
            this.Controls.Add(this.lblTaux);
            this.Controls.Add(this.lblDateOperation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTypeJournal);
            this.Controls.Add(this.cboMonnaie);
            this.Controls.Add(this.txtMontant);
            this.Controls.Add(this.txtNumPiece);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.dgvEcriture);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblCompte2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblCompte1);
            this.Controls.Add(this.txtMotif);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(725, 507);
            this.Name = "FormComptabilite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Opération comptable";
            this.Shown += new System.EventHandler(this.FormComptabilite_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEcriture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox txtMontant;
        public System.Windows.Forms.TextBox txtNumPiece;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.DataGridView dgvEcriture;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblCompte1;
        public System.Windows.Forms.TextBox txtMotif;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cboMonnaie;
        public System.Windows.Forms.ComboBox cboTypeJournal;
        public System.Windows.Forms.Button btnDate;
        public System.Windows.Forms.Label lblTaux;
        public System.Windows.Forms.Label lblDateOperation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnNouveauJournal;
        public System.Windows.Forms.Button btnRetirer;
        public System.Windows.Forms.Button btnRetirerTout;
        public System.Windows.Forms.Button btnEnregistrer;
        public System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.TextBox txtCompte1;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button btnValider;
        public System.Windows.Forms.Button btnCompte1;
        public System.Windows.Forms.ComboBox cboDebitCredit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCompte2;
        public System.Windows.Forms.TextBox txtCompte2;
        public System.Windows.Forms.Button btnCompte2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}