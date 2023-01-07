namespace SUMEDCO
{
    partial class FormAutorisation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutorisation));
            this.cboUtilisateur = new System.Windows.Forms.ComboBox();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.cboAutorisation = new System.Windows.Forms.ComboBox();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.btnActiver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboUtilisateur
            // 
            this.cboUtilisateur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUtilisateur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUtilisateur.Enabled = false;
            this.cboUtilisateur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboUtilisateur.FormattingEnabled = true;
            this.cboUtilisateur.Location = new System.Drawing.Point(23, 136);
            this.cboUtilisateur.Name = "cboUtilisateur";
            this.cboUtilisateur.Size = new System.Drawing.Size(233, 23);
            this.cboUtilisateur.TabIndex = 653;
            this.cboUtilisateur.DropDown += new System.EventHandler(this.cboUtilisateur_DropDown);
            this.cboUtilisateur.SelectedIndexChanged += new System.EventHandler(this.cboUtilisateur_SelectedIndexChanged);
            // 
            // btnConnexion
            // 
            this.btnConnexion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnexion.BackColor = System.Drawing.Color.Transparent;
            this.btnConnexion.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnConnexion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnConnexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnexion.ForeColor = System.Drawing.Color.Navy;
            this.btnConnexion.Location = new System.Drawing.Point(23, 187);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(233, 27);
            this.btnConnexion.TabIndex = 652;
            this.btnConnexion.Text = "Connexion";
            this.btnConnexion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConnexion.UseVisualStyleBackColor = false;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // cboAutorisation
            // 
            this.cboAutorisation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAutorisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAutorisation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAutorisation.FormattingEnabled = true;
            this.cboAutorisation.Location = new System.Drawing.Point(23, 107);
            this.cboAutorisation.Name = "cboAutorisation";
            this.cboAutorisation.Size = new System.Drawing.Size(233, 23);
            this.cboAutorisation.TabIndex = 653;
            this.cboAutorisation.DropDown += new System.EventHandler(this.cboAutorisation_DropDown);
            this.cboAutorisation.SelectedIndexChanged += new System.EventHandler(this.cboAutorisation_SelectedIndexChanged);
            // 
            // btnQuitter
            // 
            this.btnQuitter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitter.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitter.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnQuitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.ForeColor = System.Drawing.Color.Navy;
            this.btnQuitter.Location = new System.Drawing.Point(23, 220);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(233, 27);
            this.btnQuitter.TabIndex = 654;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 50);
            this.panel1.TabIndex = 655;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 292);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 50);
            this.panel2.TabIndex = 656;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 125;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 15F);
            this.label10.ForeColor = System.Drawing.Color.MediumBlue;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(0, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(274, 40);
            this.label10.TabIndex = 657;
            this.label10.Text = "Sélection du poste";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnActiver
            // 
            this.btnActiver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActiver.BackColor = System.Drawing.Color.Transparent;
            this.btnActiver.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnActiver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnActiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiver.ForeColor = System.Drawing.Color.Navy;
            this.btnActiver.Location = new System.Drawing.Point(23, 253);
            this.btnActiver.Name = "btnActiver";
            this.btnActiver.Size = new System.Drawing.Size(233, 27);
            this.btnActiver.TabIndex = 658;
            this.btnActiver.Text = "Activer";
            this.btnActiver.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActiver.UseVisualStyleBackColor = false;
            this.btnActiver.Visible = false;
            this.btnActiver.Click += new System.EventHandler(this.btnActiver_Click);
            // 
            // FormAutorisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(274, 342);
            this.Controls.Add(this.btnActiver);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.cboAutorisation);
            this.Controls.Add(this.cboUtilisateur);
            this.Controls.Add(this.btnConnexion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAutorisation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Selection compte";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox cboUtilisateur;
        public System.Windows.Forms.Button btnConnexion;
        public System.Windows.Forms.ComboBox cboAutorisation;
        public System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Button btnActiver;
    }
}