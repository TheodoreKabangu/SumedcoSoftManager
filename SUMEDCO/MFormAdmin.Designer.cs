namespace SUMEDCO
{
    partial class MFormAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFormAdmin));
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnChat = new System.Windows.Forms.Button();
            this.pnlSousMenu = new System.Windows.Forms.Panel();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnRecetteDepense = new System.Windows.Forms.Button();
            this.btnMaladeMedecin = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnRapports = new System.Windows.Forms.Button();
            this.btnRapportStat = new System.Windows.Forms.Button();
            this.btnMiseAJour = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.pnlSide.SuspendLayout();
            this.pnlSousMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.pnlSide.Controls.Add(this.btnChat);
            this.pnlSide.Controls.Add(this.pnlSousMenu);
            this.pnlSide.Controls.Add(this.btnQuitter);
            this.pnlSide.Controls.Add(this.btnRapports);
            this.pnlSide.Controls.Add(this.btnRapportStat);
            this.pnlSide.Controls.Add(this.btnMiseAJour);
            this.pnlSide.Controls.Add(this.pnlLogo);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(180, 471);
            this.pnlSide.TabIndex = 584;
            // 
            // btnChat
            // 
            this.btnChat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChat.FlatAppearance.BorderSize = 0;
            this.btnChat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChat.ForeColor = System.Drawing.Color.Black;
            this.btnChat.Image = ((System.Drawing.Image)(resources.GetObject("btnChat.Image")));
            this.btnChat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChat.Location = new System.Drawing.Point(0, 303);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(180, 45);
            this.btnChat.TabIndex = 589;
            this.btnChat.Text = "Messagerie";
            this.btnChat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // pnlSousMenu
            // 
            this.pnlSousMenu.Controls.Add(this.btnStock);
            this.pnlSousMenu.Controls.Add(this.btnRecetteDepense);
            this.pnlSousMenu.Controls.Add(this.btnMaladeMedecin);
            this.pnlSousMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSousMenu.Location = new System.Drawing.Point(0, 162);
            this.pnlSousMenu.Name = "pnlSousMenu";
            this.pnlSousMenu.Size = new System.Drawing.Size(180, 141);
            this.pnlSousMenu.TabIndex = 586;
            // 
            // btnStock
            // 
            this.btnStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStock.FlatAppearance.BorderSize = 0;
            this.btnStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnStock.Location = new System.Drawing.Point(0, 70);
            this.btnStock.Name = "btnStock";
            this.btnStock.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.btnStock.Size = new System.Drawing.Size(180, 35);
            this.btnStock.TabIndex = 9;
            this.btnStock.Text = "Stocks des produits ph.";
            this.btnStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnRecetteDepense
            // 
            this.btnRecetteDepense.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRecetteDepense.FlatAppearance.BorderSize = 0;
            this.btnRecetteDepense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRecetteDepense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecetteDepense.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnRecetteDepense.Location = new System.Drawing.Point(0, 35);
            this.btnRecetteDepense.Name = "btnRecetteDepense";
            this.btnRecetteDepense.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.btnRecetteDepense.Size = new System.Drawing.Size(180, 35);
            this.btnRecetteDepense.TabIndex = 10;
            this.btnRecetteDepense.Text = "Recettes et Dépenses";
            this.btnRecetteDepense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecetteDepense.UseVisualStyleBackColor = true;
            this.btnRecetteDepense.Click += new System.EventHandler(this.btnRecetteDepense_Click);
            // 
            // btnMaladeMedecin
            // 
            this.btnMaladeMedecin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMaladeMedecin.FlatAppearance.BorderSize = 0;
            this.btnMaladeMedecin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMaladeMedecin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaladeMedecin.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnMaladeMedecin.Location = new System.Drawing.Point(0, 0);
            this.btnMaladeMedecin.Name = "btnMaladeMedecin";
            this.btnMaladeMedecin.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.btnMaladeMedecin.Size = new System.Drawing.Size(180, 35);
            this.btnMaladeMedecin.TabIndex = 8;
            this.btnMaladeMedecin.Text = "Cas par médecin";
            this.btnMaladeMedecin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaladeMedecin.UseVisualStyleBackColor = true;
            this.btnMaladeMedecin.Click += new System.EventHandler(this.btnMaladeMedecin_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnQuitter.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnQuitter.FlatAppearance.BorderSize = 0;
            this.btnQuitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.ForeColor = System.Drawing.Color.Black;
            this.btnQuitter.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitter.Image")));
            this.btnQuitter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitter.Location = new System.Drawing.Point(0, 426);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(180, 45);
            this.btnQuitter.TabIndex = 11;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnRapports
            // 
            this.btnRapports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRapports.FlatAppearance.BorderSize = 0;
            this.btnRapports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnRapports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapports.ForeColor = System.Drawing.Color.Black;
            this.btnRapports.Image = ((System.Drawing.Image)(resources.GetObject("btnRapports.Image")));
            this.btnRapports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapports.Location = new System.Drawing.Point(0, 117);
            this.btnRapports.Name = "btnRapports";
            this.btnRapports.Size = new System.Drawing.Size(180, 45);
            this.btnRapports.TabIndex = 7;
            this.btnRapports.Text = "Rapports";
            this.btnRapports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRapports.UseVisualStyleBackColor = true;
            this.btnRapports.Click += new System.EventHandler(this.btnRapports_Click);
            // 
            // btnRapportStat
            // 
            this.btnRapportStat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRapportStat.FlatAppearance.BorderSize = 0;
            this.btnRapportStat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnRapportStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapportStat.ForeColor = System.Drawing.Color.Black;
            this.btnRapportStat.Image = ((System.Drawing.Image)(resources.GetObject("btnRapportStat.Image")));
            this.btnRapportStat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapportStat.Location = new System.Drawing.Point(0, 72);
            this.btnRapportStat.Name = "btnRapportStat";
            this.btnRapportStat.Size = new System.Drawing.Size(180, 45);
            this.btnRapportStat.TabIndex = 587;
            this.btnRapportStat.Text = "Statistiques par service";
            this.btnRapportStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapportStat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRapportStat.UseVisualStyleBackColor = true;
            this.btnRapportStat.Click += new System.EventHandler(this.btnRapportStat_Click);
            // 
            // btnMiseAJour
            // 
            this.btnMiseAJour.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMiseAJour.FlatAppearance.BorderSize = 0;
            this.btnMiseAJour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnMiseAJour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiseAJour.ForeColor = System.Drawing.Color.Black;
            this.btnMiseAJour.Image = ((System.Drawing.Image)(resources.GetObject("btnMiseAJour.Image")));
            this.btnMiseAJour.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMiseAJour.Location = new System.Drawing.Point(0, 27);
            this.btnMiseAJour.Name = "btnMiseAJour";
            this.btnMiseAJour.Size = new System.Drawing.Size(180, 45);
            this.btnMiseAJour.TabIndex = 1;
            this.btnMiseAJour.Text = "Mise à jour de données";
            this.btnMiseAJour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMiseAJour.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMiseAJour.UseVisualStyleBackColor = true;
            this.btnMiseAJour.Click += new System.EventHandler(this.btnMiseAJour_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(180, 27);
            this.pnlLogo.TabIndex = 0;
            // 
            // pnlChildForm
            // 
            this.pnlChildForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlChildForm.BackgroundImage")));
            this.pnlChildForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildForm.Location = new System.Drawing.Point(180, 0);
            this.pnlChildForm.Name = "pnlChildForm";
            this.pnlChildForm.Size = new System.Drawing.Size(714, 471);
            this.pnlChildForm.TabIndex = 585;
            // 
            // MFormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(894, 471);
            this.Controls.Add(this.pnlChildForm);
            this.Controls.Add(this.pnlSide);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(910, 510);
            this.Name = "MFormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Administration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.MFormAdmin_Shown);
            this.pnlSide.ResumeLayout(false);
            this.pnlSousMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Button btnQuitter;
        public System.Windows.Forms.Button btnRapports;
        public System.Windows.Forms.Button btnMiseAJour;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Panel pnlSousMenu;
        public System.Windows.Forms.Button btnStock;
        public System.Windows.Forms.Button btnMaladeMedecin;
        public System.Windows.Forms.Button btnRecetteDepense;
        public System.Windows.Forms.Panel pnlChildForm;
        public System.Windows.Forms.Button btnRapportStat;
        public System.Windows.Forms.Button btnChat;
    }
}