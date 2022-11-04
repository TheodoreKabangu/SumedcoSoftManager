namespace SUMEDCO
{
    partial class FormCom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCom));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQteStock = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQteCom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQteServie = new System.Windows.Forms.TextBox();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.txtLibelle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDest = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 27);
            this.panel1.TabIndex = 623;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.Transparent;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnAnnuler.Location = new System.Drawing.Point(123, 221);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(80, 26);
            this.btnAnnuler.TabIndex = 5;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 625;
            this.label1.Text = "Qté en stock :";
            // 
            // txtQteStock
            // 
            this.txtQteStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtQteStock.Enabled = false;
            this.txtQteStock.Location = new System.Drawing.Point(123, 97);
            this.txtQteStock.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtQteStock.MaxLength = 75;
            this.txtQteStock.Name = "txtQteStock";
            this.txtQteStock.Size = new System.Drawing.Size(172, 21);
            this.txtQteStock.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 131);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 625;
            this.label2.Text = "Qté commandée :";
            // 
            // txtQteCom
            // 
            this.txtQteCom.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtQteCom.Location = new System.Drawing.Point(123, 128);
            this.txtQteCom.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtQteCom.MaxLength = 75;
            this.txtQteCom.Name = "txtQteCom";
            this.txtQteCom.Size = new System.Drawing.Size(172, 21);
            this.txtQteCom.TabIndex = 3;
            this.txtQteCom.TextChanged += new System.EventHandler(this.txtQteCom_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 625;
            this.label3.Text = "Qté servie :";
            // 
            // txtQteServie
            // 
            this.txtQteServie.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtQteServie.Location = new System.Drawing.Point(123, 159);
            this.txtQteServie.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtQteServie.MaxLength = 75;
            this.txtQteServie.Name = "txtQteServie";
            this.txtQteServie.Size = new System.Drawing.Size(172, 21);
            this.txtQteServie.TabIndex = 4;
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
            this.btnEnregistrer.Location = new System.Drawing.Point(215, 221);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(80, 26);
            this.btnEnregistrer.TabIndex = 6;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // txtLibelle
            // 
            this.txtLibelle.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtLibelle.Enabled = false;
            this.txtLibelle.Location = new System.Drawing.Point(123, 44);
            this.txtLibelle.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtLibelle.MaxLength = 75;
            this.txtLibelle.Multiline = true;
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(407, 43);
            this.txtLibelle.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 625;
            this.label4.Text = "Libellé produit :";
            // 
            // txtDest
            // 
            this.txtDest.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtDest.Location = new System.Drawing.Point(123, 190);
            this.txtDest.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtDest.MaxLength = 75;
            this.txtDest.Name = "txtDest";
            this.txtDest.Size = new System.Drawing.Size(172, 21);
            this.txtDest.TabIndex = 639;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 193);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 640;
            this.label5.Text = "Destination :";
            // 
            // FormCom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(545, 258);
            this.ControlBox = false;
            this.Controls.Add(this.txtDest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLibelle);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.txtQteServie);
            this.Controls.Add(this.txtQteCom);
            this.Controls.Add(this.txtQteStock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(561, 278);
            this.Name = "FormCom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Commande de produits";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtQteStock;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtQteCom;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtQteServie;
        public System.Windows.Forms.Button btnEnregistrer;
        public System.Windows.Forms.TextBox txtLibelle;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtDest;
        private System.Windows.Forms.Label label5;

    }
}

