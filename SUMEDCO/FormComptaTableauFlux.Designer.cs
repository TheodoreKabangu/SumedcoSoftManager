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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboLibelle = new System.Windows.Forms.ComboBox();
            this.btnImprimer = new System.Windows.Forms.Button();
            this.dgvTFT = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpDateA = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateDe = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCalculer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTFT)).BeginInit();
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
            "_Flux de trésorerie provenant des activités opérationnelles",
            "FA_Capacité d\'Autofinancement Globale (CAFG)",
            "FB_Actif circulant HAO (1)_-",
            "FC_Variation des stocks_-",
            "FD_Variation des créances_-",
            "FE_Variation du passif circulant (1)_+",
            "_Variation du BF lié aux activités opérationnelles FB+FC+FD+FE :",
            "ZB_Flux de trésorerie provenant des activités opérationnelles  (Somme FA à FE)_B",
            "_Flux de trésorerie provenant des activités d’investissements",
            "FF_Décaissements liés aux acquisitions d\'immobilisations incorporelles_-",
            "FG_Décaissements liés aux acquisitions d\'immobilisations corporelles_-",
            "FH_Décaissements liés aux acquisitions d\'immobilisations financières_-",
            "FI_Encaissements liés aux cessions d’immobilisations incorporelles et corporelles" +
                "_+",
            "FJ_Encaissements liés aux cessions d’immobilisations financières_+",
            "ZC_Flux de trésorerie provenant des activités d’investissement (somme FF à FJ)_C",
            "_Flux de trésorerie provenant du financement par les capitaux propres",
            "FK_Augmentations de capital par apports nouveaux_+",
            "FL_Subventions d\'investissement reçues_+",
            "FM_Prélèvements sur le capital_-",
            "FN_Dividendes versés_-",
            "ZD_Flux de trésorerie provenant des capitaux propres (somme FK à FN)_D",
            "_Trésorerie provenant du financement par les capitaux étrangers",
            "FO_Emprunts_+",
            "FP_Autres dettes financières_+",
            "FQ_Remboursements des emprunts et autres dettes financières_-",
            "ZE_Flux de trésorerie provenant des capitaux étrangers (somme FO à FQ)_E",
            "ZF_Flux de trésorerie provenant des activités de financement (D+E)_F",
            "ZG_VARIATION DE LA TRÉSORERIE NETTE DE LA PÉRIODE (B+C+F)_G",
            "ZH_Trésorerie nette au 31 Décembre (G+A) Contrôle : Trésorerie actif N - Trésorer" +
                "ie passif N_H"});
            this.cboLibelle.Location = new System.Drawing.Point(526, 36);
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
            this.btnImprimer.Location = new System.Drawing.Point(336, 36);
            this.btnImprimer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.Size = new System.Drawing.Size(30, 23);
            this.btnImprimer.TabIndex = 675;
            this.btnImprimer.UseVisualStyleBackColor = false;
            this.btnImprimer.Click += new System.EventHandler(this.btnImprimer_Click);
            // 
            // dgvTFT
            // 
            this.dgvTFT.AllowUserToAddRows = false;
            this.dgvTFT.AllowUserToDeleteRows = false;
            this.dgvTFT.AllowUserToOrderColumns = true;
            this.dgvTFT.AllowUserToResizeColumns = false;
            this.dgvTFT.AllowUserToResizeRows = false;
            this.dgvTFT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTFT.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvTFT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTFT.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTFT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTFT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTFT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.Column1,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTFT.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTFT.EnableHeadersVisualStyles = false;
            this.dgvTFT.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.dgvTFT.Location = new System.Drawing.Point(12, 67);
            this.dgvTFT.MultiSelect = false;
            this.dgvTFT.Name = "dgvTFT";
            this.dgvTFT.ReadOnly = true;
            this.dgvTFT.RowHeadersVisible = false;
            this.dgvTFT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTFT.Size = new System.Drawing.Size(679, 372);
            this.dgvTFT.TabIndex = 673;
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
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn27.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn27.HeaderText = "Note";
            this.dataGridViewTextBoxColumn27.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn28
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn28.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn28.HeaderText = "Exercice N";
            this.dataGridViewTextBoxColumn28.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
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
            // dtpDateA
            // 
            this.dtpDateA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateA.Location = new System.Drawing.Point(176, 34);
            this.dtpDateA.Name = "dtpDateA";
            this.dtpDateA.Size = new System.Drawing.Size(113, 28);
            this.dtpDateA.TabIndex = 681;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 22);
            this.label2.TabIndex = 683;
            this.label2.Text = "à :";
            // 
            // dtpDateDe
            // 
            this.dtpDateDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDe.Location = new System.Drawing.Point(44, 34);
            this.dtpDateDe.Name = "dtpDateDe";
            this.dtpDateDe.Size = new System.Drawing.Size(113, 28);
            this.dtpDateDe.TabIndex = 682;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 22);
            this.label1.TabIndex = 684;
            this.label1.Text = "De :";
            // 
            // btnCalculer
            // 
            this.btnCalculer.BackColor = System.Drawing.Color.Transparent;
            this.btnCalculer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCalculer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCalculer.FlatAppearance.BorderSize = 0;
            this.btnCalculer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCalculer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculer.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnCalculer.Image = ((System.Drawing.Image)(resources.GetObject("btnCalculer.Image")));
            this.btnCalculer.Location = new System.Drawing.Point(296, 34);
            this.btnCalculer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCalculer.Name = "btnCalculer";
            this.btnCalculer.Size = new System.Drawing.Size(30, 23);
            this.btnCalculer.TabIndex = 680;
            this.btnCalculer.UseVisualStyleBackColor = false;
            this.btnCalculer.Click += new System.EventHandler(this.btnCalculer_Click);
            // 
            // FormComptaTableauFlux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.dtpDateA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDateDe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCalculer);
            this.Controls.Add(this.cboLibelle);
            this.Controls.Add(this.btnImprimer);
            this.Controls.Add(this.dgvTFT);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormComptaTableauFlux";
            this.Text = "FormComptaTableauFlux";
            this.Shown += new System.EventHandler(this.FormComptaTableauFlux_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTFT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cboLibelle;
        public System.Windows.Forms.Button btnImprimer;
        public System.Windows.Forms.DataGridView dgvTFT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        public System.Windows.Forms.DateTimePicker dtpDateA;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpDateDe;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnCalculer;
    }
}