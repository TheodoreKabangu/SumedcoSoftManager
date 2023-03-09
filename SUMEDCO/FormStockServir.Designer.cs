namespace SUMEDCO
{
    partial class FormStockServir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStockServir));
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLibelle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDateJour = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQteStock = new System.Windows.Forms.TextBox();
            this.txtQteCom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQteServie = new System.Windows.Forms.TextBox();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.cboPoste = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 27);
            this.panel2.TabIndex = 619;
            // 
            // txtLibelle
            // 
            this.txtLibelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtLibelle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLibelle.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtLibelle.Enabled = false;
            this.txtLibelle.Location = new System.Drawing.Point(112, 48);
            this.txtLibelle.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtLibelle.MaxLength = 200;
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(388, 21);
            this.txtLibelle.TabIndex = 705;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 706;
            this.label4.Text = "Produit :";
            // 
            // dtpDateJour
            // 
            this.dtpDateJour.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateJour.Location = new System.Drawing.Point(112, 77);
            this.dtpDateJour.Name = "dtpDateJour";
            this.dtpDateJour.Size = new System.Drawing.Size(170, 21);
            this.dtpDateJour.TabIndex = 707;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 708;
            this.label3.Text = "Date du jour :";
            // 
            // txtQteStock
            // 
            this.txtQteStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtQteStock.Enabled = false;
            this.txtQteStock.Location = new System.Drawing.Point(112, 106);
            this.txtQteStock.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtQteStock.MaxLength = 10;
            this.txtQteStock.Name = "txtQteStock";
            this.txtQteStock.Size = new System.Drawing.Size(170, 21);
            this.txtQteStock.TabIndex = 709;
            // 
            // txtQteCom
            // 
            this.txtQteCom.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtQteCom.Location = new System.Drawing.Point(112, 137);
            this.txtQteCom.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtQteCom.MaxLength = 10;
            this.txtQteCom.Name = "txtQteCom";
            this.txtQteCom.Size = new System.Drawing.Size(170, 21);
            this.txtQteCom.TabIndex = 710;
            this.txtQteCom.TextChanged += new System.EventHandler(this.txtQteCom_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 109);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 713;
            this.label1.Text = "Qté stock :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 140);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 15);
            this.label7.TabIndex = 714;
            this.label7.Text = "Qté demandée :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 712;
            this.label2.Text = "Qté servie :";
            // 
            // txtQteServie
            // 
            this.txtQteServie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQteServie.Location = new System.Drawing.Point(112, 168);
            this.txtQteServie.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtQteServie.MaxLength = 10;
            this.txtQteServie.Name = "txtQteServie";
            this.txtQteServie.Size = new System.Drawing.Size(170, 21);
            this.txtQteServie.TabIndex = 711;
            this.txtQteServie.TextChanged += new System.EventHandler(this.txtQteServie_TextChanged);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.Transparent;
            this.btnEnregistrer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnEnregistrer.Location = new System.Drawing.Point(202, 231);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(80, 26);
            this.btnEnregistrer.TabIndex = 716;
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
            this.btnAnnuler.Location = new System.Drawing.Point(112, 231);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(80, 26);
            this.btnAnnuler.TabIndex = 715;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // cboPoste
            // 
            this.cboPoste.DropDownHeight = 150;
            this.cboPoste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPoste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPoste.FormattingEnabled = true;
            this.cboPoste.IntegralHeight = false;
            this.cboPoste.Items.AddRange(new object[] {
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
            this.cboPoste.Location = new System.Drawing.Point(112, 197);
            this.cboPoste.MaxDropDownItems = 10;
            this.cboPoste.Name = "cboPoste";
            this.cboPoste.Size = new System.Drawing.Size(170, 23);
            this.cboPoste.Sorted = true;
            this.cboPoste.TabIndex = 717;
            this.cboPoste.DropDown += new System.EventHandler(this.cboPoste_DropDown);
            this.cboPoste.SelectedIndexChanged += new System.EventHandler(this.cboPoste_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 200);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 712;
            this.label5.Text = "Destination :";
            // 
            // FormStockServir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(517, 271);
            this.Controls.Add(this.cboPoste);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.txtQteStock);
            this.Controls.Add(this.txtQteCom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQteServie);
            this.Controls.Add(this.dtpDateJour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLibelle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(533, 290);
            this.Name = "FormStockServir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Servir une demande";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox txtLibelle;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DateTimePicker dtpDateJour;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtQteStock;
        public System.Windows.Forms.TextBox txtQteCom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtQteServie;
        public System.Windows.Forms.Button btnEnregistrer;
        public System.Windows.Forms.Button btnAnnuler;
        public System.Windows.Forms.ComboBox cboPoste;
        private System.Windows.Forms.Label label5;
    }
}