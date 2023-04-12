namespace SUMEDCO
{
    partial class FormComptaResultat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComptaResultat));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImprimer = new System.Windows.Forms.Button();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.dgvResultat = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboLibelle = new System.Windows.Forms.ComboBox();
            this.btnQuitter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultat)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 27);
            this.panel2.TabIndex = 621;
            // 
            // btnImprimer
            // 
            this.btnImprimer.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimer.Enabled = false;
            this.btnImprimer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnImprimer.FlatAppearance.BorderSize = 0;
            this.btnImprimer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnImprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimer.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnImprimer.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimer.Image")));
            this.btnImprimer.Location = new System.Drawing.Point(102, 36);
            this.btnImprimer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.Size = new System.Drawing.Size(30, 23);
            this.btnImprimer.TabIndex = 670;
            this.btnImprimer.UseVisualStyleBackColor = false;
            this.btnImprimer.Click += new System.EventHandler(this.btnImprimer_Click);
            // 
            // btnRecherche
            // 
            this.btnRecherche.BackColor = System.Drawing.Color.Transparent;
            this.btnRecherche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecherche.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRecherche.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRecherche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecherche.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnRecherche.Location = new System.Drawing.Point(12, 34);
            this.btnRecherche.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(80, 26);
            this.btnRecherche.TabIndex = 669;
            this.btnRecherche.Text = "Calculer";
            this.btnRecherche.UseVisualStyleBackColor = false;
            this.btnRecherche.Click += new System.EventHandler(this.btnRecherche_Click);
            // 
            // dgvResultat
            // 
            this.dgvResultat.AllowUserToAddRows = false;
            this.dgvResultat.AllowUserToDeleteRows = false;
            this.dgvResultat.AllowUserToOrderColumns = true;
            this.dgvResultat.AllowUserToResizeColumns = false;
            this.dgvResultat.AllowUserToResizeRows = false;
            this.dgvResultat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResultat.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvResultat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResultat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResultat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResultat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.Column1,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn29});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResultat.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvResultat.EnableHeadersVisualStyles = false;
            this.dgvResultat.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.dgvResultat.Location = new System.Drawing.Point(12, 67);
            this.dgvResultat.MultiSelect = false;
            this.dgvResultat.Name = "dgvResultat";
            this.dgvResultat.ReadOnly = true;
            this.dgvResultat.RowHeadersVisible = false;
            this.dgvResultat.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvResultat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultat.Size = new System.Drawing.Size(679, 372);
            this.dgvResultat.TabIndex = 668;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.HeaderText = "Réf.";
            this.dataGridViewTextBoxColumn25.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            this.dataGridViewTextBoxColumn25.Width = 30;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn26.HeaderText = "Libellé";
            this.dataGridViewTextBoxColumn26.MinimumWidth = 250;
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 30;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 30;
            // 
            // dataGridViewTextBoxColumn27
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn27.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn27.HeaderText = "Note";
            this.dataGridViewTextBoxColumn27.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn28
            // 
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn28.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn28.HeaderText = "Exercice N";
            this.dataGridViewTextBoxColumn28.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn29
            // 
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn29.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn29.HeaderText = "Exercice N-1";
            this.dataGridViewTextBoxColumn29.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            // 
            // cboLibelle
            // 
            this.cboLibelle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboLibelle.BackColor = System.Drawing.SystemColors.Window;
            this.cboLibelle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLibelle.DropDownWidth = 10;
            this.cboLibelle.FormattingEnabled = true;
            this.cboLibelle.Items.AddRange(new object[] {
            "TA_Ventes de marchandises_21_+",
            "RA_Achats de marchandises_22_-",
            "RB_Variation de stocks de marchandises_6_-/+",
            "XA_MARGE  COMMERCIALE  (Somme TA à RB)",
            "TB_Ventes de produits fabriqués_21_+",
            "TC_Travaux, services vendus_21_+",
            "TD_Produits accessoires_21_+",
            "XB_CHIFFRE D\'AFFAIRES (TA + TB + TC + TD)",
            "TE_Production stockée (ou déstockage)_6_-/+",
            "TF_Production immobilisée_21",
            "TG_Subventions d’exploitation_21",
            "TH_Autres produits_21_+",
            "TI_Transferts de charges d\'exploitation_12_+",
            "RC_Achats de matières premières et fournitures liées_22_-",
            "RD_Variation de stocks de matières premières et fournitures liées_6_-/+",
            "RE_Autres achats_22_-",
            "RF_Variation de stocks d’autres approvisionnements_6_-/+",
            "RG_Transports_23_-",
            "RH_Services extérieurs_24_-",
            "RI_Impôts et taxes_25_-",
            "RJ_Autres charges_26_-",
            "XC_VALEUR AJOUTEE (XB +RA+RB) + (somme TE à RJ)",
            "RK_Charges de personnel_27_-",
            "XD_EXCEDENT BRUT D\'EXPLOITATION (XC+RK)",
            "TJ_Reprises d’amortissements, provisions et dépréciations_28_+",
            "RL_Dotations aux amortissements, aux provisions et dépréciations_3C et 28_-",
            "XE_RESULTAT D\'EXPLOITATION (XD+TJ+ RL)",
            "TK_Revenus financiers et assimilés_29_+",
            "TL_Reprises de provisions  et dépréciations financières_28_+",
            "TM_Transferts de charges financières_12_+",
            "RM_Frais financiers et charges assimilées_29_-",
            "RN_Dotations aux provisions et aux dépréciations financières_3C et 28_-",
            "XF_RESULTAT  FINANCIER  (somme TK à RN)",
            "XG_RESULTAT  DES ACTIVITES ORDINAIRES (XE+XF)",
            "TN_Produits des cessions d\'immobilisations_3D_+",
            "TO_Autres Produits HAO_30_+",
            "RO_Valeurs comptables des cessions d\'immobilisations_3D_-",
            "RP_Autres Charges HAO_30_-",
            "XH_RESULTAT HORS ACTIVITES ORDINAIRES (somme TN à RP)",
            "RQ_Participation des travailleurs_30_-",
            "RS_Impôts sur le résultat_37_-",
            "XI_RESULTAT NET (XG+XH+RQ+RS)"});
            this.cboLibelle.Location = new System.Drawing.Point(141, 36);
            this.cboLibelle.Name = "cboLibelle";
            this.cboLibelle.Size = new System.Drawing.Size(10, 30);
            this.cboLibelle.TabIndex = 671;
            this.cboLibelle.Visible = false;
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
            this.btnQuitter.Location = new System.Drawing.Point(671, 28);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(30, 30);
            this.btnQuitter.TabIndex = 674;
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // FormComptaResultat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.cboLibelle);
            this.Controls.Add(this.btnImprimer);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.dgvResultat);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormComptaResultat";
            this.Text = "FormComptaResultat";
            this.Shown += new System.EventHandler(this.FormComptaResultat_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnImprimer;
        public System.Windows.Forms.Button btnRecherche;
        public System.Windows.Forms.DataGridView dgvResultat;
        public System.Windows.Forms.ComboBox cboLibelle;
        public System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
    }
}