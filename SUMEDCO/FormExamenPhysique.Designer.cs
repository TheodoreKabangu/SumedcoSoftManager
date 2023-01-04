namespace SUMEDCO
{
    partial class FormExamenPhysique
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExamenPhysique));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnRetirerExamPhys = new System.Windows.Forms.Button();
            this.btnPlusExamPhys = new System.Windows.Forms.Button();
            this.cboExamenPhysique = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column8,
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgv.Location = new System.Drawing.Point(12, 33);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(346, 371);
            this.dgv.TabIndex = 649;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "N°";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            this.Column3.Width = 40;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "Examen";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Prix";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnregistrer.BackColor = System.Drawing.Color.Lavender;
            this.btnEnregistrer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEnregistrer.Location = new System.Drawing.Point(278, 411);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(80, 26);
            this.btnEnregistrer.TabIndex = 653;
            this.btnEnregistrer.Text = "Valider";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 27);
            this.panel1.TabIndex = 655;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnnuler.BackColor = System.Drawing.Color.Lavender;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAnnuler.Location = new System.Drawing.Point(188, 411);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(80, 26);
            this.btnAnnuler.TabIndex = 656;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnRetirerExamPhys
            // 
            this.btnRetirerExamPhys.BackColor = System.Drawing.Color.Transparent;
            this.btnRetirerExamPhys.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRetirerExamPhys.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRetirerExamPhys.FlatAppearance.BorderSize = 0;
            this.btnRetirerExamPhys.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRetirerExamPhys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetirerExamPhys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirerExamPhys.Image = ((System.Drawing.Image)(resources.GetObject("btnRetirerExamPhys.Image")));
            this.btnRetirerExamPhys.Location = new System.Drawing.Point(153, 411);
            this.btnRetirerExamPhys.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRetirerExamPhys.Name = "btnRetirerExamPhys";
            this.btnRetirerExamPhys.Size = new System.Drawing.Size(30, 26);
            this.btnRetirerExamPhys.TabIndex = 665;
            this.toolTip1.SetToolTip(this.btnRetirerExamPhys, "Retirer");
            this.btnRetirerExamPhys.UseVisualStyleBackColor = false;
            this.btnRetirerExamPhys.Click += new System.EventHandler(this.btnRetirerExamPhys_Click);
            // 
            // btnPlusExamPhys
            // 
            this.btnPlusExamPhys.BackColor = System.Drawing.Color.Transparent;
            this.btnPlusExamPhys.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPlusExamPhys.Enabled = false;
            this.btnPlusExamPhys.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPlusExamPhys.FlatAppearance.BorderSize = 0;
            this.btnPlusExamPhys.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPlusExamPhys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlusExamPhys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlusExamPhys.Image = ((System.Drawing.Image)(resources.GetObject("btnPlusExamPhys.Image")));
            this.btnPlusExamPhys.Location = new System.Drawing.Point(113, 411);
            this.btnPlusExamPhys.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPlusExamPhys.Name = "btnPlusExamPhys";
            this.btnPlusExamPhys.Size = new System.Drawing.Size(30, 26);
            this.btnPlusExamPhys.TabIndex = 666;
            this.toolTip1.SetToolTip(this.btnPlusExamPhys, "Nouvel examen");
            this.btnPlusExamPhys.UseVisualStyleBackColor = false;
            this.btnPlusExamPhys.Click += new System.EventHandler(this.btnPlusExamPhys_Click);
            // 
            // cboExamenPhysique
            // 
            this.cboExamenPhysique.DropDownHeight = 150;
            this.cboExamenPhysique.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExamenPhysique.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboExamenPhysique.FormattingEnabled = true;
            this.cboExamenPhysique.IntegralHeight = false;
            this.cboExamenPhysique.Items.AddRange(new object[] {
            "Etat général",
            "Tête",
            "Cou",
            "Coeur",
            "Poumon",
            "Abdomen",
            "Colonne vertébrale",
            "Membres supérieurs",
            "Membres inférieurs",
            "Organes génitaux"});
            this.cboExamenPhysique.Location = new System.Drawing.Point(0, 427);
            this.cboExamenPhysique.MaxDropDownItems = 10;
            this.cboExamenPhysique.Name = "cboExamenPhysique";
            this.cboExamenPhysique.Size = new System.Drawing.Size(16, 23);
            this.cboExamenPhysique.TabIndex = 667;
            this.cboExamenPhysique.Visible = false;
            // 
            // FormExamenPhysique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(370, 473);
            this.ControlBox = false;
            this.Controls.Add(this.cboExamenPhysique);
            this.Controls.Add(this.btnRetirerExamPhys);
            this.Controls.Add(this.btnPlusExamPhys);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.dgv);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(386, 512);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(386, 512);
            this.Name = "FormExamenPhysique";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Examens physiques";
            this.Shown += new System.EventHandler(this.FormExamenPhysique_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv;
        public System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnAnnuler;
        public System.Windows.Forms.Button btnRetirerExamPhys;
        public System.Windows.Forms.Button btnPlusExamPhys;
        public System.Windows.Forms.ComboBox cboExamenPhysique;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}