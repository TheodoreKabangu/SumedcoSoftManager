namespace SUMEDCO
{
    partial class FormComptaTableauFlux
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormComptaTableauFlux));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboLibelle = new System.Windows.Forms.ComboBox();
            this.btnImprimer = new System.Windows.Forms.Button();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.dgvTFT = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResultat = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTFT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultat)).BeginInit();
            this.SuspendLayout();
            // 
            // cboLibelle
            // 
            this.cboLibelle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboLibelle.BackColor = System.Drawing.SystemColors.Window;
            this.cboLibelle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLibelle.DropDownWidth = 10;
            this.cboLibelle.FormattingEnabled = true;
            this.cboLibelle.Items.AddRange(new object[] {
            "ZA_Trésorerie nette au 1er janvier (Trésorerie actif N-1 - Trésorerie passif N-1)" +
                "_A",
            "Flux de trésorerie provenant des activités opérationnelles",
            "FA_Capacité d\'Autofinancement Globale (CAFG)",
            "FB_- Actif circulant HAO (1)",
            "FC_- Variation des stocks",
            "FD_- Variation des créances",
            "FE_+ Variation du passif circulant (1)",
            "Variation du BF lié aux activités opérationnelles FB+FC+FD+FE :",
            "ZB_Flux de trésorerie provenant des activités opérationnelles  (Somme FA à FE)_B",
            "Flux de trésorerie provenant des activités d’investissements",
            "FF_- Décaissements liés aux acquisitions d\'immobilisations incorporelles",
            "FG_- Décaissements liés aux acquisitions d\'immobilisations corporelles",
            "FH_- Décaissements liés aux acquisitions d\'immobilisations financières",
            "FI_+ Encaissements liés aux cessions d’immobilisations incorporelles et corporell" +
                "es",
            "FJ_+ Encaissements liés aux cessions d’immobilisations financières",
            "ZC_Flux de trésorerie provenant des activités d’investissement (somme FF à FJ)_C",
            "Flux de trésorerie provenant du financement par les capitaux propres",
            "FK_+ Augmentations de capital par apports nouveaux",
            "FL_+ Subventions d\'investissement reçues",
            "FM_- Prélèvements sur le capital",
            "FN_- Dividendes versés",
            "ZD_Flux de trésorerie provenant des capitaux propres (somme FK à FN)_D",
            "Trésorerie provenant du financement par les capitaux étrangers",
            "FO_+ Emprunts",
            "FP_+ Autres dettes financières",
            "FQ_- Remboursements des emprunts et autres dettes financières",
            "ZE_Flux de trésorerie provenant des capitaux étrangers (somme FO à FQ)_E",
            "ZF_Flux de trésorerie provenant des activités de financement (D+E)_F",
            "ZG_VARIATION DE LA TRÉSORERIE NETTE DE LA PÉRIODE (B+C+F)_G",
            "ZH_Trésorerie nette au 31 Décembre (G+A) Contrôle : Trésorerie actif N - Trésorer" +
                "ie passif N_H"});
            this.cboLibelle.Location = new System.Drawing.Point(141, 36);
            this.cboLibelle.Name = "cboLibelle";
            this.cboLibelle.Size = new System.Drawing.Size(10, 30);
            this.cboLibelle.TabIndex = 676;
            this.cboLibelle.Visible = false;
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
            this.btnImprimer.TabIndex = 675;
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
            this.btnRecherche.TabIndex = 674;
            this.btnRecherche.Text = "Calculer";
            this.btnRecherche.UseVisualStyleBackColor = false;
            this.btnRecherche.Click += new System.EventHandler(this.btnRecherche_Click);
            // 
            // dgvTFT
            // 
            this.dgvTFT.AllowUserToAddRows = false;
            this.dgvTFT.AllowUserToDeleteRows = false;
            this.dgvTFT.AllowUserToOrderColumns = true;
            this.dgvTFT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTFT.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvTFT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTFT.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTFT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvTFT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTFT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.Column1,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn29});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTFT.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvTFT.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvTFT.Location = new System.Drawing.Point(12, 67);
            this.dgvTFT.MultiSelect = false;
            this.dgvTFT.Name = "dgvTFT";
            this.dgvTFT.ReadOnly = true;
            this.dgvTFT.RowHeadersVisible = false;
            this.dgvTFT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTFT.Size = new System.Drawing.Size(679, 372);
            this.dgvTFT.TabIndex = 673;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 27);
            this.panel2.TabIndex = 672;
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
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 30;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 30;
            // 
            // dataGridViewTextBoxColumn27
            // 
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.dataGridViewTextBoxColumn27.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn27.HeaderText = "Note";
            this.dataGridViewTextBoxColumn27.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn28
            // 
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.dataGridViewTextBoxColumn28.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn28.HeaderText = "Exercice N";
            this.dataGridViewTextBoxColumn28.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn29
            // 
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.dataGridViewTextBoxColumn29.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn29.HeaderText = "Exercice N-1";
            this.dataGridViewTextBoxColumn29.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            // 
            // dgvResultat
            // 
            this.dgvResultat.AllowUserToAddRows = false;
            this.dgvResultat.AllowUserToDeleteRows = false;
            this.dgvResultat.AllowUserToOrderColumns = true;
            this.dgvResultat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResultat.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvResultat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResultat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResultat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvResultat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResultat.DefaultCellStyle = dataGridViewCellStyle21;
            this.dgvResultat.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvResultat.Location = new System.Drawing.Point(666, 36);
            this.dgvResultat.MultiSelect = false;
            this.dgvResultat.Name = "dgvResultat";
            this.dgvResultat.ReadOnly = true;
            this.dgvResultat.RowHeadersVisible = false;
            this.dgvResultat.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvResultat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultat.Size = new System.Drawing.Size(25, 25);
            this.dgvResultat.TabIndex = 677;
            this.dgvResultat.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Réf.";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Libellé";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 250;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn3.HeaderText = "";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 30;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle18.Format = "N2";
            dataGridViewCellStyle18.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn4.HeaderText = "Note";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle19.Format = "N2";
            dataGridViewCellStyle19.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn5.HeaderText = "Exercice N";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle20.Format = "N2";
            dataGridViewCellStyle20.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn6.HeaderText = "Exercice N-1";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // FormComptaTableauFlux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.dgvResultat);
            this.Controls.Add(this.cboLibelle);
            this.Controls.Add(this.btnImprimer);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.dgvTFT);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormComptaTableauFlux";
            this.Text = "FormComptaTableauFlux";
            this.Shown += new System.EventHandler(this.FormComptaTableauFlux_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTFT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox cboLibelle;
        public System.Windows.Forms.Button btnImprimer;
        public System.Windows.Forms.Button btnRecherche;
        public System.Windows.Forms.DataGridView dgvTFT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        public System.Windows.Forms.DataGridView dgvResultat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}