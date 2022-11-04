namespace SUMEDCO
{
    partial class MFormInfirmerie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFormInfirmerie));
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnEncaisser = new System.Windows.Forms.Button();
            this.btnPatientAncien = new System.Windows.Forms.Button();
            this.btnPatient = new System.Windows.Forms.Button();
            this.btnIntervention = new System.Windows.Forms.Button();
            this.btnConsultation = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.btnLogo = new System.Windows.Forms.Button();
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.pnlSousMenu = new System.Windows.Forms.Panel();
            this.btnFactureProduit = new System.Windows.Forms.Button();
            this.btnFactureService = new System.Windows.Forms.Button();
            this.btnBonEncaisser = new System.Windows.Forms.Button();
            this.pnlSide.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlSousMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.pnlSide.Controls.Add(this.pnlSousMenu);
            this.pnlSide.Controls.Add(this.btnEncaisser);
            this.pnlSide.Controls.Add(this.btnPatientAncien);
            this.pnlSide.Controls.Add(this.btnPatient);
            this.pnlSide.Controls.Add(this.btnIntervention);
            this.pnlSide.Controls.Add(this.btnConsultation);
            this.pnlSide.Controls.Add(this.btnQuitter);
            this.pnlSide.Controls.Add(this.pnlLogo);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(180, 471);
            this.pnlSide.TabIndex = 584;
            // 
            // btnEncaisser
            // 
            this.btnEncaisser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEncaisser.FlatAppearance.BorderSize = 0;
            this.btnEncaisser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnEncaisser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncaisser.ForeColor = System.Drawing.Color.Black;
            this.btnEncaisser.Image = ((System.Drawing.Image)(resources.GetObject("btnEncaisser.Image")));
            this.btnEncaisser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEncaisser.Location = new System.Drawing.Point(0, 252);
            this.btnEncaisser.Name = "btnEncaisser";
            this.btnEncaisser.Size = new System.Drawing.Size(180, 45);
            this.btnEncaisser.TabIndex = 588;
            this.btnEncaisser.Text = "Bons de caisse";
            this.btnEncaisser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEncaisser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEncaisser.UseVisualStyleBackColor = true;
            this.btnEncaisser.Click += new System.EventHandler(this.btnEncaisser_Click);
            // 
            // btnPatientAncien
            // 
            this.btnPatientAncien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPatientAncien.FlatAppearance.BorderSize = 0;
            this.btnPatientAncien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnPatientAncien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatientAncien.ForeColor = System.Drawing.Color.Black;
            this.btnPatientAncien.Image = ((System.Drawing.Image)(resources.GetObject("btnPatientAncien.Image")));
            this.btnPatientAncien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatientAncien.Location = new System.Drawing.Point(0, 207);
            this.btnPatientAncien.Name = "btnPatientAncien";
            this.btnPatientAncien.Size = new System.Drawing.Size(180, 45);
            this.btnPatientAncien.TabIndex = 587;
            this.btnPatientAncien.Text = "Ancien malade";
            this.btnPatientAncien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatientAncien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPatientAncien.UseVisualStyleBackColor = true;
            this.btnPatientAncien.Click += new System.EventHandler(this.btnPatientAncien_Click);
            // 
            // btnPatient
            // 
            this.btnPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPatient.FlatAppearance.BorderSize = 0;
            this.btnPatient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatient.ForeColor = System.Drawing.Color.Black;
            this.btnPatient.Image = ((System.Drawing.Image)(resources.GetObject("btnPatient.Image")));
            this.btnPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatient.Location = new System.Drawing.Point(0, 162);
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.Size = new System.Drawing.Size(180, 45);
            this.btnPatient.TabIndex = 586;
            this.btnPatient.Text = "Nouveau malade";
            this.btnPatient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPatient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPatient.UseVisualStyleBackColor = true;
            this.btnPatient.Click += new System.EventHandler(this.btnPatient_Click);
            // 
            // btnIntervention
            // 
            this.btnIntervention.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIntervention.FlatAppearance.BorderSize = 0;
            this.btnIntervention.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnIntervention.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIntervention.ForeColor = System.Drawing.Color.Black;
            this.btnIntervention.Image = ((System.Drawing.Image)(resources.GetObject("btnIntervention.Image")));
            this.btnIntervention.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIntervention.Location = new System.Drawing.Point(0, 117);
            this.btnIntervention.Name = "btnIntervention";
            this.btnIntervention.Size = new System.Drawing.Size(180, 45);
            this.btnIntervention.TabIndex = 3;
            this.btnIntervention.Text = "Traitements";
            this.btnIntervention.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIntervention.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIntervention.UseVisualStyleBackColor = true;
            this.btnIntervention.Click += new System.EventHandler(this.btnIntervention_Click);
            // 
            // btnConsultation
            // 
            this.btnConsultation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsultation.FlatAppearance.BorderSize = 0;
            this.btnConsultation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnConsultation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultation.ForeColor = System.Drawing.Color.Black;
            this.btnConsultation.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultation.Image")));
            this.btnConsultation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultation.Location = new System.Drawing.Point(0, 72);
            this.btnConsultation.Name = "btnConsultation";
            this.btnConsultation.Size = new System.Drawing.Size(180, 45);
            this.btnConsultation.TabIndex = 1;
            this.btnConsultation.Text = "Cas à consulter ";
            this.btnConsultation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultation.UseVisualStyleBackColor = true;
            this.btnConsultation.Click += new System.EventHandler(this.btnConsultation_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnQuitter.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnQuitter.FlatAppearance.BorderSize = 0;
            this.btnQuitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.ForeColor = System.Drawing.Color.Black;
            this.btnQuitter.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitter.Image")));
            this.btnQuitter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitter.Location = new System.Drawing.Point(0, 441);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(180, 30);
            this.btnQuitter.TabIndex = 585;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.btnLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(180, 72);
            this.pnlLogo.TabIndex = 0;
            // 
            // btnLogo
            // 
            this.btnLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.btnLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogo.Enabled = false;
            this.btnLogo.FlatAppearance.BorderSize = 0;
            this.btnLogo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.btnLogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.btnLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogo.Font = new System.Drawing.Font("Segoe Marker", 20F);
            this.btnLogo.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnLogo.Location = new System.Drawing.Point(0, 0);
            this.btnLogo.Name = "btnLogo";
            this.btnLogo.Size = new System.Drawing.Size(180, 72);
            this.btnLogo.TabIndex = 1;
            this.btnLogo.Text = "F.F.L.\r\nSUMEDCO";
            this.btnLogo.UseVisualStyleBackColor = false;
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
            // pnlSousMenu
            // 
            this.pnlSousMenu.Controls.Add(this.btnBonEncaisser);
            this.pnlSousMenu.Controls.Add(this.btnFactureProduit);
            this.pnlSousMenu.Controls.Add(this.btnFactureService);
            this.pnlSousMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSousMenu.Location = new System.Drawing.Point(0, 297);
            this.pnlSousMenu.Name = "pnlSousMenu";
            this.pnlSousMenu.Size = new System.Drawing.Size(180, 125);
            this.pnlSousMenu.TabIndex = 589;
            // 
            // btnFactureProduit
            // 
            this.btnFactureProduit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFactureProduit.FlatAppearance.BorderSize = 0;
            this.btnFactureProduit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnFactureProduit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFactureProduit.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnFactureProduit.Location = new System.Drawing.Point(0, 40);
            this.btnFactureProduit.Name = "btnFactureProduit";
            this.btnFactureProduit.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.btnFactureProduit.Size = new System.Drawing.Size(180, 40);
            this.btnFactureProduit.TabIndex = 2;
            this.btnFactureProduit.Text = "Facturer les produits";
            this.btnFactureProduit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFactureProduit.UseVisualStyleBackColor = true;
            this.btnFactureProduit.Click += new System.EventHandler(this.btnFactureProduit_Click);
            // 
            // btnFactureService
            // 
            this.btnFactureService.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFactureService.FlatAppearance.BorderSize = 0;
            this.btnFactureService.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnFactureService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFactureService.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnFactureService.Location = new System.Drawing.Point(0, 0);
            this.btnFactureService.Name = "btnFactureService";
            this.btnFactureService.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.btnFactureService.Size = new System.Drawing.Size(180, 40);
            this.btnFactureService.TabIndex = 0;
            this.btnFactureService.Text = "Facturer les services";
            this.btnFactureService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFactureService.UseVisualStyleBackColor = true;
            this.btnFactureService.Click += new System.EventHandler(this.btnFactureService_Click);
            // 
            // btnBonEncaisser
            // 
            this.btnBonEncaisser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBonEncaisser.FlatAppearance.BorderSize = 0;
            this.btnBonEncaisser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnBonEncaisser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBonEncaisser.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnBonEncaisser.Location = new System.Drawing.Point(0, 80);
            this.btnBonEncaisser.Name = "btnBonEncaisser";
            this.btnBonEncaisser.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.btnBonEncaisser.Size = new System.Drawing.Size(180, 40);
            this.btnBonEncaisser.TabIndex = 3;
            this.btnBonEncaisser.Text = "Bons à encaisser";
            this.btnBonEncaisser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBonEncaisser.UseVisualStyleBackColor = true;
            this.btnBonEncaisser.Click += new System.EventHandler(this.btnBonEncaisser_Click);
            // 
            // MFormInfirmerie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(894, 471);
            this.Controls.Add(this.pnlChildForm);
            this.Controls.Add(this.pnlSide);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(910, 510);
            this.Name = "MFormInfirmerie";
            this.Text = "SSM - Infirmerie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormInfirmerie_Load);
            this.pnlSide.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlSousMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Button btnQuitter;
        public System.Windows.Forms.Button btnIntervention;
        public System.Windows.Forms.Button btnConsultation;
        private System.Windows.Forms.Panel pnlLogo;
        public System.Windows.Forms.Button btnLogo;
        public System.Windows.Forms.Panel pnlChildForm;
        public System.Windows.Forms.Button btnPatient;
        public System.Windows.Forms.Button btnPatientAncien;
        public System.Windows.Forms.Button btnEncaisser;
        public System.Windows.Forms.Panel pnlSousMenu;
        public System.Windows.Forms.Button btnFactureProduit;
        public System.Windows.Forms.Button btnFactureService;
        public System.Windows.Forms.Button btnBonEncaisser;


    }
}