namespace SUMEDCO
{
    partial class FormApproAutre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApproAutre));
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudAnnee = new System.Windows.Forms.NumericUpDown();
            this.cboMois = new System.Windows.Forms.ComboBox();
            this.txtNumLot = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDateEntree = new System.Windows.Forms.Label();
            this.txtLibelle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtPrixAchat = new System.Windows.Forms.TextBox();
            this.txtQteDem = new System.Windows.Forms.TextBox();
            this.txtQteAppro = new System.Windows.Forms.TextBox();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDateJour = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQteAjout = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chboxLot = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnnee)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 27);
            this.panel1.TabIndex = 704;
            // 
            // nudAnnee
            // 
            this.nudAnnee.Enabled = false;
            this.nudAnnee.Location = new System.Drawing.Point(157, 237);
            this.nudAnnee.Maximum = new decimal(new int[] {
            2121,
            0,
            0,
            0});
            this.nudAnnee.Minimum = new decimal(new int[] {
            1999,
            0,
            0,
            0});
            this.nudAnnee.Name = "nudAnnee";
            this.nudAnnee.Size = new System.Drawing.Size(172, 21);
            this.nudAnnee.TabIndex = 731;
            this.nudAnnee.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            // 
            // cboMois
            // 
            this.cboMois.DropDownHeight = 150;
            this.cboMois.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMois.Enabled = false;
            this.cboMois.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMois.FormattingEnabled = true;
            this.cboMois.IntegralHeight = false;
            this.cboMois.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cboMois.Location = new System.Drawing.Point(157, 207);
            this.cboMois.MaxDropDownItems = 10;
            this.cboMois.Name = "cboMois";
            this.cboMois.Size = new System.Drawing.Size(172, 23);
            this.cboMois.Sorted = true;
            this.cboMois.TabIndex = 730;
            // 
            // txtNumLot
            // 
            this.txtNumLot.Enabled = false;
            this.txtNumLot.Location = new System.Drawing.Point(157, 176);
            this.txtNumLot.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtNumLot.MaxLength = 20;
            this.txtNumLot.Name = "txtNumLot";
            this.txtNumLot.Size = new System.Drawing.Size(172, 21);
            this.txtNumLot.TabIndex = 726;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.MediumBlue;
            this.label5.Location = new System.Drawing.Point(49, 179);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 727;
            this.label5.Text = "N° de lot :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.MediumBlue;
            this.label8.Location = new System.Drawing.Point(49, 241);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 15);
            this.label8.TabIndex = 728;
            this.label8.Text = "Année expiration :";
            // 
            // lblDateEntree
            // 
            this.lblDateEntree.AutoSize = true;
            this.lblDateEntree.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblDateEntree.Location = new System.Drawing.Point(49, 210);
            this.lblDateEntree.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDateEntree.Name = "lblDateEntree";
            this.lblDateEntree.Size = new System.Drawing.Size(97, 15);
            this.lblDateEntree.TabIndex = 729;
            this.lblDateEntree.Text = "Mois expiration :";
            // 
            // txtLibelle
            // 
            this.txtLibelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtLibelle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLibelle.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtLibelle.Enabled = false;
            this.txtLibelle.Location = new System.Drawing.Point(157, 41);
            this.txtLibelle.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtLibelle.MaxLength = 75;
            this.txtLibelle.Multiline = true;
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(427, 43);
            this.txtLibelle.TabIndex = 724;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 725;
            this.label4.Text = "Libellé produit :";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(296, 121);
            this.textBox3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(31, 21);
            this.textBox3.TabIndex = 723;
            this.textBox3.Text = "CDF";
            // 
            // txtPrixAchat
            // 
            this.txtPrixAchat.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtPrixAchat.Location = new System.Drawing.Point(157, 121);
            this.txtPrixAchat.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtPrixAchat.MaxLength = 10;
            this.txtPrixAchat.Name = "txtPrixAchat";
            this.txtPrixAchat.Size = new System.Drawing.Size(139, 21);
            this.txtPrixAchat.TabIndex = 712;
            this.txtPrixAchat.TextChanged += new System.EventHandler(this.txtPrixAchat_TextChanged);
            // 
            // txtQteDem
            // 
            this.txtQteDem.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtQteDem.Enabled = false;
            this.txtQteDem.Location = new System.Drawing.Point(157, 266);
            this.txtQteDem.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtQteDem.MaxLength = 10;
            this.txtQteDem.Name = "txtQteDem";
            this.txtQteDem.Size = new System.Drawing.Size(170, 21);
            this.txtQteDem.TabIndex = 713;
            // 
            // txtQteAppro
            // 
            this.txtQteAppro.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtQteAppro.Location = new System.Drawing.Point(157, 297);
            this.txtQteAppro.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtQteAppro.MaxLength = 10;
            this.txtQteAppro.Name = "txtQteAppro";
            this.txtQteAppro.Size = new System.Drawing.Size(170, 21);
            this.txtQteAppro.TabIndex = 714;
            this.txtQteAppro.TextChanged += new System.EventHandler(this.txtQteAppro_TextChanged);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.Transparent;
            this.btnEnregistrer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnEnregistrer.Location = new System.Drawing.Point(247, 357);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(80, 26);
            this.btnEnregistrer.TabIndex = 717;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.Transparent;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnAnnuler.Location = new System.Drawing.Point(157, 357);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(80, 26);
            this.btnAnnuler.TabIndex = 716;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 269);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 15);
            this.label1.TabIndex = 720;
            this.label1.Text = "Quantité demandée :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 124);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 15);
            this.label6.TabIndex = 721;
            this.label6.Text = "Prix unit. d\'achat :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 300);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 15);
            this.label7.TabIndex = 722;
            this.label7.Text = "Quantité appro :";
            // 
            // dtpDateJour
            // 
            this.dtpDateJour.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateJour.Location = new System.Drawing.Point(157, 92);
            this.dtpDateJour.Name = "dtpDateJour";
            this.dtpDateJour.Size = new System.Drawing.Size(170, 21);
            this.dtpDateJour.TabIndex = 711;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 331);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 719;
            this.label2.Text = "Qté ajoutée :";
            // 
            // txtQteAjout
            // 
            this.txtQteAjout.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQteAjout.Location = new System.Drawing.Point(157, 328);
            this.txtQteAjout.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtQteAjout.MaxLength = 10;
            this.txtQteAjout.Name = "txtQteAjout";
            this.txtQteAjout.Size = new System.Drawing.Size(170, 21);
            this.txtQteAjout.TabIndex = 715;
            this.txtQteAjout.TextChanged += new System.EventHandler(this.txtQteAjout_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 718;
            this.label3.Text = "Date du jour :";
            // 
            // chboxLot
            // 
            this.chboxLot.AutoSize = true;
            this.chboxLot.ForeColor = System.Drawing.Color.MediumBlue;
            this.chboxLot.Location = new System.Drawing.Point(157, 150);
            this.chboxLot.Name = "chboxLot";
            this.chboxLot.Size = new System.Drawing.Size(119, 19);
            this.chboxLot.TabIndex = 732;
            this.chboxLot.Text = "Renseigner le lot";
            this.chboxLot.UseVisualStyleBackColor = true;
            this.chboxLot.Click += new System.EventHandler(this.chboxLot_Click);
            // 
            // FormApproAutre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(596, 400);
            this.ControlBox = false;
            this.Controls.Add(this.chboxLot);
            this.Controls.Add(this.nudAnnee);
            this.Controls.Add(this.cboMois);
            this.Controls.Add(this.txtNumLot);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblDateEntree);
            this.Controls.Add(this.txtLibelle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtPrixAchat);
            this.Controls.Add(this.txtQteDem);
            this.Controls.Add(this.txtQteAppro);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpDateJour);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQteAjout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(612, 439);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(612, 439);
            this.Name = "FormApproAutre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servir une demande";
            ((System.ComponentModel.ISupportInitialize)(this.nudAnnee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.NumericUpDown nudAnnee;
        public System.Windows.Forms.ComboBox cboMois;
        public System.Windows.Forms.TextBox txtNumLot;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblDateEntree;
        public System.Windows.Forms.TextBox txtLibelle;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox txtPrixAchat;
        public System.Windows.Forms.TextBox txtQteDem;
        public System.Windows.Forms.TextBox txtQteAppro;
        public System.Windows.Forms.Button btnEnregistrer;
        public System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DateTimePicker dtpDateJour;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtQteAjout;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox chboxLot;

    }
}