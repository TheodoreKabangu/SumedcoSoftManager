namespace SUMEDCO
{
    partial class FormConnexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnexion));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.txtMotdePass = new System.Windows.Forms.TextBox();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.txtUtilisateur = new System.Windows.Forms.TextBox();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.linkModifier = new System.Windows.Forms.LinkLabel();
            this.cboUtilisateur = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 324);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 46);
            this.panel2.TabIndex = 152;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 46);
            this.panel1.TabIndex = 151;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 100;
            this.bunifuElipse1.TargetControl = this;
            // 
            // txtMotdePass
            // 
            this.txtMotdePass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtMotdePass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMotdePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotdePass.ForeColor = System.Drawing.Color.DarkGray;
            this.txtMotdePass.Location = new System.Drawing.Point(63, 124);
            this.txtMotdePass.MaxLength = 10;
            this.txtMotdePass.Name = "txtMotdePass";
            this.txtMotdePass.Size = new System.Drawing.Size(201, 28);
            this.txtMotdePass.TabIndex = 2;
            this.txtMotdePass.Text = "Mot de passe";
            this.txtMotdePass.Enter += new System.EventHandler(this.txtMotdePass_Enter);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.Transparent;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.ForeColor = System.Drawing.Color.Navy;
            this.btnAnnuler.Location = new System.Drawing.Point(21, 246);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(243, 27);
            this.btnAnnuler.TabIndex = 5;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // txtUtilisateur
            // 
            this.txtUtilisateur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtUtilisateur.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUtilisateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUtilisateur.ForeColor = System.Drawing.Color.DarkGray;
            this.txtUtilisateur.Location = new System.Drawing.Point(63, 85);
            this.txtUtilisateur.MaxLength = 10;
            this.txtUtilisateur.Name = "txtUtilisateur";
            this.txtUtilisateur.Size = new System.Drawing.Size(201, 28);
            this.txtUtilisateur.TabIndex = 1;
            this.txtUtilisateur.Text = "Utilisateur";
            this.txtUtilisateur.Click += new System.EventHandler(this.txtUtilisateur_Click);
            this.txtUtilisateur.TextChanged += new System.EventHandler(this.txtUtilisateur_TextChanged);
            // 
            // btnConnexion
            // 
            this.btnConnexion.BackColor = System.Drawing.Color.Transparent;
            this.btnConnexion.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnConnexion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnConnexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnexion.ForeColor = System.Drawing.Color.Navy;
            this.btnConnexion.Location = new System.Drawing.Point(21, 213);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(243, 27);
            this.btnConnexion.TabIndex = 4;
            this.btnConnexion.Text = "Connexion";
            this.btnConnexion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConnexion.UseVisualStyleBackColor = false;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel3.Location = new System.Drawing.Point(63, 146);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(201, 1);
            this.panel3.TabIndex = 19;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel4.Location = new System.Drawing.Point(63, 107);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(201, 1);
            this.panel4.TabIndex = 19;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(21, 74);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 35);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(21, 115);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 35);
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.checkBox1.Location = new System.Drawing.Point(127, 153);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(199, 26);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Voir le mot de passe";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // linkModifier
            // 
            this.linkModifier.AutoSize = true;
            this.linkModifier.DisabledLinkColor = System.Drawing.Color.MediumBlue;
            this.linkModifier.LinkColor = System.Drawing.Color.MediumBlue;
            this.linkModifier.Location = new System.Drawing.Point(74, 288);
            this.linkModifier.Name = "linkModifier";
            this.linkModifier.Size = new System.Drawing.Size(204, 22);
            this.linkModifier.TabIndex = 6;
            this.linkModifier.TabStop = true;
            this.linkModifier.Text = "Modifier le mot de passe";
            this.linkModifier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkModifier_LinkClicked);
            // 
            // cboUtilisateur
            // 
            this.cboUtilisateur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUtilisateur.Enabled = false;
            this.cboUtilisateur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboUtilisateur.FormattingEnabled = true;
            this.cboUtilisateur.Location = new System.Drawing.Point(21, 184);
            this.cboUtilisateur.Name = "cboUtilisateur";
            this.cboUtilisateur.Size = new System.Drawing.Size(243, 30);
            this.cboUtilisateur.TabIndex = 651;
            this.cboUtilisateur.SelectedIndexChanged += new System.EventHandler(this.cboUtilisateur_SelectedIndexChanged);
            // 
            // FormConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(290, 370);
            this.Controls.Add(this.cboUtilisateur);
            this.Controls.Add(this.linkModifier);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnConnexion);
            this.Controls.Add(this.txtUtilisateur);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.txtMotdePass);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(290, 370);
            this.Name = "FormConnexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Connexion";
            this.Load += new System.EventHandler(this.FormConnexion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.Button btnConnexion;
        public System.Windows.Forms.TextBox txtUtilisateur;
        public System.Windows.Forms.Button btnAnnuler;
        public System.Windows.Forms.TextBox txtMotdePass;
        public System.Windows.Forms.LinkLabel linkModifier;
        public System.Windows.Forms.ComboBox cboUtilisateur;
    }
}