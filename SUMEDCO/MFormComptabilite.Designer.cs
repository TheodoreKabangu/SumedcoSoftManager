namespace SUMEDCO
{
    partial class MFormComptabilite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFormComptabilite));
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnChat = new System.Windows.Forms.Button();
            this.pnlCompta = new System.Windows.Forms.Panel();
            this.btnResultat = new System.Windows.Forms.Button();
            this.btnTabFluxT = new System.Windows.Forms.Button();
            this.btnBalance_ = new System.Windows.Forms.Button();
            this.btnBilan_ = new System.Windows.Forms.Button();
            this.btnGrandLivre = new System.Windows.Forms.Button();
            this.btnVisualisation = new System.Windows.Forms.Button();
            this.btnCompta = new System.Windows.Forms.Button();
            this.pnlRapport = new System.Windows.Forms.Panel();
            this.btnCasMedecin = new System.Windows.Forms.Button();
            this.btnRapportGlobal = new System.Windows.Forms.Button();
            this.btnRapportDepense = new System.Windows.Forms.Button();
            this.btnRapportRecette = new System.Windows.Forms.Button();
            this.btnRapport = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnAppro = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.pnlSide.SuspendLayout();
            this.pnlCompta.SuspendLayout();
            this.pnlRapport.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.AutoScroll = true;
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.pnlSide.Controls.Add(this.btnChat);
            this.pnlSide.Controls.Add(this.pnlCompta);
            this.pnlSide.Controls.Add(this.btnCompta);
            this.pnlSide.Controls.Add(this.pnlRapport);
            this.pnlSide.Controls.Add(this.btnRapport);
            this.pnlSide.Controls.Add(this.btnQuitter);
            this.pnlSide.Controls.Add(this.btnAppro);
            this.pnlSide.Controls.Add(this.pnlLogo);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(180, 474);
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
            this.btnChat.Location = new System.Drawing.Point(0, 617);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(154, 45);
            this.btnChat.TabIndex = 600;
            this.btnChat.Text = "Messagerie";
            this.btnChat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChat.UseVisualStyleBackColor = true;
            // 
            // pnlCompta
            // 
            this.pnlCompta.AutoScroll = true;
            this.pnlCompta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.pnlCompta.Controls.Add(this.btnResultat);
            this.pnlCompta.Controls.Add(this.btnTabFluxT);
            this.pnlCompta.Controls.Add(this.btnBilan_);
            this.pnlCompta.Controls.Add(this.btnGrandLivre);
            this.pnlCompta.Controls.Add(this.btnBalance_);
            this.pnlCompta.Controls.Add(this.btnVisualisation);
            this.pnlCompta.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCompta.Location = new System.Drawing.Point(0, 343);
            this.pnlCompta.Name = "pnlCompta";
            this.pnlCompta.Size = new System.Drawing.Size(154, 274);
            this.pnlCompta.TabIndex = 596;
            // 
            // btnResultat
            // 
            this.btnResultat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnResultat.FlatAppearance.BorderSize = 0;
            this.btnResultat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnResultat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResultat.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnResultat.Image = ((System.Drawing.Image)(resources.GetObject("btnResultat.Image")));
            this.btnResultat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResultat.Location = new System.Drawing.Point(0, 225);
            this.btnResultat.Name = "btnResultat";
            this.btnResultat.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnResultat.Size = new System.Drawing.Size(154, 45);
            this.btnResultat.TabIndex = 602;
            this.btnResultat.Text = "Compte de résultat";
            this.btnResultat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResultat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResultat.UseVisualStyleBackColor = true;
            this.btnResultat.Click += new System.EventHandler(this.btnResultat_Click);
            // 
            // btnTabFluxT
            // 
            this.btnTabFluxT.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTabFluxT.FlatAppearance.BorderSize = 0;
            this.btnTabFluxT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnTabFluxT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabFluxT.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnTabFluxT.Image = ((System.Drawing.Image)(resources.GetObject("btnTabFluxT.Image")));
            this.btnTabFluxT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTabFluxT.Location = new System.Drawing.Point(0, 180);
            this.btnTabFluxT.Name = "btnTabFluxT";
            this.btnTabFluxT.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTabFluxT.Size = new System.Drawing.Size(154, 45);
            this.btnTabFluxT.TabIndex = 601;
            this.btnTabFluxT.Text = "TFT";
            this.btnTabFluxT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTabFluxT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTabFluxT.UseVisualStyleBackColor = true;
            this.btnTabFluxT.Click += new System.EventHandler(this.btnTabFluxT_Click);
            // 
            // btnBalance_
            // 
            this.btnBalance_.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBalance_.FlatAppearance.BorderSize = 0;
            this.btnBalance_.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnBalance_.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBalance_.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnBalance_.Image = ((System.Drawing.Image)(resources.GetObject("btnBalance_.Image")));
            this.btnBalance_.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBalance_.Location = new System.Drawing.Point(0, 45);
            this.btnBalance_.Name = "btnBalance_";
            this.btnBalance_.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnBalance_.Size = new System.Drawing.Size(154, 45);
            this.btnBalance_.TabIndex = 600;
            this.btnBalance_.Text = "Balance";
            this.btnBalance_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBalance_.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBalance_.UseVisualStyleBackColor = true;
            this.btnBalance_.Click += new System.EventHandler(this.btnBalance__Click);
            // 
            // btnBilan_
            // 
            this.btnBilan_.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBilan_.FlatAppearance.BorderSize = 0;
            this.btnBilan_.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnBilan_.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBilan_.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnBilan_.Image = ((System.Drawing.Image)(resources.GetObject("btnBilan_.Image")));
            this.btnBilan_.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilan_.Location = new System.Drawing.Point(0, 135);
            this.btnBilan_.Name = "btnBilan_";
            this.btnBilan_.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnBilan_.Size = new System.Drawing.Size(154, 45);
            this.btnBilan_.TabIndex = 599;
            this.btnBilan_.Text = "Bilan";
            this.btnBilan_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilan_.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBilan_.UseVisualStyleBackColor = true;
            this.btnBilan_.Click += new System.EventHandler(this.btnBilan__Click);
            // 
            // btnGrandLivre
            // 
            this.btnGrandLivre.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGrandLivre.FlatAppearance.BorderSize = 0;
            this.btnGrandLivre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGrandLivre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrandLivre.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnGrandLivre.Image = ((System.Drawing.Image)(resources.GetObject("btnGrandLivre.Image")));
            this.btnGrandLivre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrandLivre.Location = new System.Drawing.Point(0, 90);
            this.btnGrandLivre.Name = "btnGrandLivre";
            this.btnGrandLivre.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnGrandLivre.Size = new System.Drawing.Size(154, 45);
            this.btnGrandLivre.TabIndex = 598;
            this.btnGrandLivre.Text = "Grand livre";
            this.btnGrandLivre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrandLivre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGrandLivre.UseVisualStyleBackColor = true;
            this.btnGrandLivre.Click += new System.EventHandler(this.btnGrandLivre_Click);
            // 
            // btnVisualisation
            // 
            this.btnVisualisation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVisualisation.FlatAppearance.BorderSize = 0;
            this.btnVisualisation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnVisualisation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualisation.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnVisualisation.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualisation.Image")));
            this.btnVisualisation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisualisation.Location = new System.Drawing.Point(0, 0);
            this.btnVisualisation.Name = "btnVisualisation";
            this.btnVisualisation.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnVisualisation.Size = new System.Drawing.Size(154, 45);
            this.btnVisualisation.TabIndex = 596;
            this.btnVisualisation.Text = "Opérations";
            this.btnVisualisation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisualisation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVisualisation.UseVisualStyleBackColor = true;
            this.btnVisualisation.Click += new System.EventHandler(this.btnVisualisation_Click);
            // 
            // btnCompta
            // 
            this.btnCompta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCompta.FlatAppearance.BorderSize = 0;
            this.btnCompta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnCompta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompta.ForeColor = System.Drawing.Color.Black;
            this.btnCompta.Image = ((System.Drawing.Image)(resources.GetObject("btnCompta.Image")));
            this.btnCompta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompta.Location = new System.Drawing.Point(0, 298);
            this.btnCompta.Name = "btnCompta";
            this.btnCompta.Size = new System.Drawing.Size(154, 45);
            this.btnCompta.TabIndex = 597;
            this.btnCompta.Text = "Comptabilité";
            this.btnCompta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCompta.UseVisualStyleBackColor = true;
            this.btnCompta.Click += new System.EventHandler(this.btnCompta_Click);
            // 
            // pnlRapport
            // 
            this.pnlRapport.AutoScroll = true;
            this.pnlRapport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.pnlRapport.Controls.Add(this.btnCasMedecin);
            this.pnlRapport.Controls.Add(this.btnRapportGlobal);
            this.pnlRapport.Controls.Add(this.btnRapportDepense);
            this.pnlRapport.Controls.Add(this.btnRapportRecette);
            this.pnlRapport.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRapport.Location = new System.Drawing.Point(0, 117);
            this.pnlRapport.Name = "pnlRapport";
            this.pnlRapport.Size = new System.Drawing.Size(154, 181);
            this.pnlRapport.TabIndex = 598;
            // 
            // btnCasMedecin
            // 
            this.btnCasMedecin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCasMedecin.FlatAppearance.BorderSize = 0;
            this.btnCasMedecin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCasMedecin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCasMedecin.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnCasMedecin.Image = ((System.Drawing.Image)(resources.GetObject("btnCasMedecin.Image")));
            this.btnCasMedecin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCasMedecin.Location = new System.Drawing.Point(0, 135);
            this.btnCasMedecin.Name = "btnCasMedecin";
            this.btnCasMedecin.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnCasMedecin.Size = new System.Drawing.Size(154, 45);
            this.btnCasMedecin.TabIndex = 603;
            this.btnCasMedecin.Text = "Cas par médecin";
            this.btnCasMedecin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCasMedecin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCasMedecin.UseVisualStyleBackColor = true;
            this.btnCasMedecin.Click += new System.EventHandler(this.btnCasMedecin_Click);
            // 
            // btnRapportGlobal
            // 
            this.btnRapportGlobal.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRapportGlobal.FlatAppearance.BorderSize = 0;
            this.btnRapportGlobal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRapportGlobal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapportGlobal.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnRapportGlobal.Image = ((System.Drawing.Image)(resources.GetObject("btnRapportGlobal.Image")));
            this.btnRapportGlobal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapportGlobal.Location = new System.Drawing.Point(0, 90);
            this.btnRapportGlobal.Name = "btnRapportGlobal";
            this.btnRapportGlobal.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnRapportGlobal.Size = new System.Drawing.Size(154, 45);
            this.btnRapportGlobal.TabIndex = 594;
            this.btnRapportGlobal.Text = "Rapport global";
            this.btnRapportGlobal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapportGlobal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRapportGlobal.UseVisualStyleBackColor = true;
            this.btnRapportGlobal.Click += new System.EventHandler(this.btnRapportGlobal_Click);
            // 
            // btnRapportDepense
            // 
            this.btnRapportDepense.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRapportDepense.FlatAppearance.BorderSize = 0;
            this.btnRapportDepense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRapportDepense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapportDepense.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnRapportDepense.Image = ((System.Drawing.Image)(resources.GetObject("btnRapportDepense.Image")));
            this.btnRapportDepense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapportDepense.Location = new System.Drawing.Point(0, 45);
            this.btnRapportDepense.Name = "btnRapportDepense";
            this.btnRapportDepense.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnRapportDepense.Size = new System.Drawing.Size(154, 45);
            this.btnRapportDepense.TabIndex = 592;
            this.btnRapportDepense.Text = "Rapport dépenses";
            this.btnRapportDepense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapportDepense.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRapportDepense.UseVisualStyleBackColor = true;
            this.btnRapportDepense.Click += new System.EventHandler(this.btnRapportDepense_Click);
            // 
            // btnRapportRecette
            // 
            this.btnRapportRecette.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRapportRecette.FlatAppearance.BorderSize = 0;
            this.btnRapportRecette.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRapportRecette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapportRecette.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnRapportRecette.Image = ((System.Drawing.Image)(resources.GetObject("btnRapportRecette.Image")));
            this.btnRapportRecette.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapportRecette.Location = new System.Drawing.Point(0, 0);
            this.btnRapportRecette.Name = "btnRapportRecette";
            this.btnRapportRecette.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnRapportRecette.Size = new System.Drawing.Size(154, 45);
            this.btnRapportRecette.TabIndex = 591;
            this.btnRapportRecette.Text = "Rapport recettes";
            this.btnRapportRecette.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapportRecette.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRapportRecette.UseVisualStyleBackColor = true;
            this.btnRapportRecette.Click += new System.EventHandler(this.btnRapportRecette_Click);
            // 
            // btnRapport
            // 
            this.btnRapport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRapport.FlatAppearance.BorderSize = 0;
            this.btnRapport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnRapport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapport.ForeColor = System.Drawing.Color.Black;
            this.btnRapport.Image = ((System.Drawing.Image)(resources.GetObject("btnRapport.Image")));
            this.btnRapport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.Location = new System.Drawing.Point(0, 72);
            this.btnRapport.Name = "btnRapport";
            this.btnRapport.Size = new System.Drawing.Size(154, 45);
            this.btnRapport.TabIndex = 599;
            this.btnRapport.Text = "Rapports";
            this.btnRapport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRapport.UseVisualStyleBackColor = true;
            this.btnRapport.Click += new System.EventHandler(this.btnRapport_Click);
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
            this.btnQuitter.Location = new System.Drawing.Point(0, 662);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(154, 45);
            this.btnQuitter.TabIndex = 585;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnAppro
            // 
            this.btnAppro.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAppro.FlatAppearance.BorderSize = 0;
            this.btnAppro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnAppro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppro.ForeColor = System.Drawing.Color.Black;
            this.btnAppro.Image = ((System.Drawing.Image)(resources.GetObject("btnAppro.Image")));
            this.btnAppro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppro.Location = new System.Drawing.Point(0, 27);
            this.btnAppro.Name = "btnAppro";
            this.btnAppro.Size = new System.Drawing.Size(154, 45);
            this.btnAppro.TabIndex = 1;
            this.btnAppro.Text = "Approvisionner stocks";
            this.btnAppro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAppro.UseVisualStyleBackColor = true;
            this.btnAppro.Click += new System.EventHandler(this.btnAppro_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(154, 27);
            this.pnlLogo.TabIndex = 0;
            // 
            // pnlChildForm
            // 
            this.pnlChildForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlChildForm.BackgroundImage")));
            this.pnlChildForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildForm.Location = new System.Drawing.Point(180, 0);
            this.pnlChildForm.Name = "pnlChildForm";
            this.pnlChildForm.Size = new System.Drawing.Size(708, 474);
            this.pnlChildForm.TabIndex = 585;
            // 
            // MFormComptabilite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(888, 474);
            this.Controls.Add(this.pnlChildForm);
            this.Controls.Add(this.pnlSide);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(910, 530);
            this.Name = "MFormComptabilite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Comptabilite";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSide.ResumeLayout(false);
            this.pnlCompta.ResumeLayout(false);
            this.pnlRapport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Button btnQuitter;
        public System.Windows.Forms.Button btnAppro;
        private System.Windows.Forms.Panel pnlLogo;
        public System.Windows.Forms.Panel pnlChildForm;
        private System.Windows.Forms.Panel pnlCompta;
        public System.Windows.Forms.Button btnResultat;
        public System.Windows.Forms.Button btnTabFluxT;
        public System.Windows.Forms.Button btnBalance_;
        public System.Windows.Forms.Button btnBilan_;
        public System.Windows.Forms.Button btnGrandLivre;
        public System.Windows.Forms.Button btnVisualisation;
        public System.Windows.Forms.Button btnCompta;
        private System.Windows.Forms.Panel pnlRapport;
        public System.Windows.Forms.Button btnRapport;
        public System.Windows.Forms.Button btnRapportGlobal;
        public System.Windows.Forms.Button btnRapportDepense;
        public System.Windows.Forms.Button btnRapportRecette;
        public System.Windows.Forms.Button btnChat;
        public System.Windows.Forms.Button btnCasMedecin;
    }
}