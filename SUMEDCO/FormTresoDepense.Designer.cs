namespace SUMEDCO
{
    partial class FormTresoDepense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTresoDepense));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboAnnulation = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnValider = new System.Windows.Forms.Button();
            this.cboMonnaie = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMontant = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 27);
            this.panel1.TabIndex = 714;
            // 
            // cboAnnulation
            // 
            this.cboAnnulation.DropDownHeight = 150;
            this.cboAnnulation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnnulation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAnnulation.FormattingEnabled = true;
            this.cboAnnulation.IntegralHeight = false;
            this.cboAnnulation.Items.AddRange(new object[] {
            "erreur sur le payeur",
            "modification du montant",
            "remboursement"});
            this.cboAnnulation.Location = new System.Drawing.Point(116, 177);
            this.cboAnnulation.MaxDropDownItems = 10;
            this.cboAnnulation.Name = "cboAnnulation";
            this.cboAnnulation.Size = new System.Drawing.Size(356, 30);
            this.cboAnnulation.Sorted = true;
            this.cboAnnulation.TabIndex = 717;
            this.cboAnnulation.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 183);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 22);
            this.label4.TabIndex = 716;
            this.label4.Text = "Annuler pour :";
            this.label4.Visible = false;
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnValider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValider.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnValider.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.Location = new System.Drawing.Point(392, 215);
            this.btnValider.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(80, 27);
            this.btnValider.TabIndex = 718;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = false;
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
            this.cboMonnaie.Location = new System.Drawing.Point(400, 51);
            this.cboMonnaie.MaxDropDownItems = 10;
            this.cboMonnaie.Name = "cboMonnaie";
            this.cboMonnaie.Size = new System.Drawing.Size(62, 30);
            this.cboMonnaie.Sorted = true;
            this.cboMonnaie.TabIndex = 721;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(330, 55);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 22);
            this.label10.TabIndex = 722;
            this.label10.Text = "CDF/USD :";
            // 
            // txtMontant
            // 
            this.txtMontant.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMontant.Location = new System.Drawing.Point(106, 51);
            this.txtMontant.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMontant.MaxLength = 10;
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(221, 28);
            this.txtMontant.TabIndex = 719;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 22);
            this.label2.TabIndex = 720;
            this.label2.Text = "Montant :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 22);
            this.label1.TabIndex = 720;
            this.label1.Text = "Bénéficiaire :";
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(106, 21);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBox1.MaxLength = 75;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(356, 28);
            this.textBox1.TabIndex = 719;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 22);
            this.label3.TabIndex = 720;
            this.label3.Text = "Motif :";
            // 
            // textBox2
            // 
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Location = new System.Drawing.Point(106, 83);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBox2.MaxLength = 75;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(356, 28);
            this.textBox2.TabIndex = 719;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboMonnaie);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtMontant);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 123);
            this.groupBox1.TabIndex = 723;
            this.groupBox1.TabStop = false;
            // 
            // FormTresoDepense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(495, 257);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.cboAnnulation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(517, 313);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(517, 313);
            this.Name = "FormTresoDepense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SSM - Mise à jour dépense";
            this.Load += new System.EventHandler(this.FormTresoDepense_Load);
            this.Shown += new System.EventHandler(this.FormFrequentation_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ComboBox cboAnnulation;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnValider;
        public System.Windows.Forms.ComboBox cboMonnaie;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox txtMontant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}