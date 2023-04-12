namespace SUMEDCO
{
    partial class FormAbonne
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbonne));
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboEntreprise = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTypeAbonne = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.Transparent;
            this.btnEnregistrer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnEnregistrer.Location = new System.Drawing.Point(281, 143);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(80, 26);
            this.btnEnregistrer.TabIndex = 8;
            this.btnEnregistrer.Text = "Valider";
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
            this.btnAnnuler.Location = new System.Drawing.Point(191, 143);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(80, 26);
            this.btnAnnuler.TabIndex = 7;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 22);
            this.label3.TabIndex = 540;
            this.label3.Text = "Entreprise :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(382, 27);
            this.panel2.TabIndex = 615;
            // 
            // txtReference
            // 
            this.txtReference.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReference.Location = new System.Drawing.Point(102, 113);
            this.txtReference.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtReference.MaxLength = 15;
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(259, 28);
            this.txtReference.TabIndex = 3;
            this.txtReference.Enter += new System.EventHandler(this.cboTypeAbonne_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 116);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 22);
            this.label5.TabIndex = 539;
            this.label5.Text = "Matricule :";
            // 
            // cboEntreprise
            // 
            this.cboEntreprise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntreprise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEntreprise.FormattingEnabled = true;
            this.cboEntreprise.Location = new System.Drawing.Point(102, 53);
            this.cboEntreprise.Name = "cboEntreprise";
            this.cboEntreprise.Size = new System.Drawing.Size(259, 30);
            this.cboEntreprise.TabIndex = 1;
            this.cboEntreprise.DropDown += new System.EventHandler(this.cboEntreprise_DropDown);
            this.cboEntreprise.SelectedIndexChanged += new System.EventHandler(this.cboEntreprise_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 85);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 22);
            this.label6.TabIndex = 540;
            this.label6.Text = "Type abonné :";
            // 
            // cboTypeAbonne
            // 
            this.cboTypeAbonne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeAbonne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTypeAbonne.FormattingEnabled = true;
            this.cboTypeAbonne.Location = new System.Drawing.Point(102, 82);
            this.cboTypeAbonne.Name = "cboTypeAbonne";
            this.cboTypeAbonne.Size = new System.Drawing.Size(259, 30);
            this.cboTypeAbonne.TabIndex = 2;
            this.cboTypeAbonne.SelectedIndexChanged += new System.EventHandler(this.cboTypeAbonne_SelectedIndexChanged);
            this.cboTypeAbonne.Enter += new System.EventHandler(this.cboTypeAbonne_Enter);
            // 
            // FormAbonne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(382, 181);
            this.ControlBox = false;
            this.Controls.Add(this.cboTypeAbonne);
            this.Controls.Add(this.cboEntreprise);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(404, 237);
            this.MinimumSize = new System.Drawing.Size(404, 237);
            this.Name = "FormAbonne";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Abonne";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnEnregistrer;
        public System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cboEntreprise;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cboTypeAbonne;
        private System.Windows.Forms.ToolTip toolTip1;


    }
}