﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SUMEDCO
{
    public partial class FormFacture : Form
    {
        public FormFacture()
        {
            InitializeComponent();
        }
        public bool fermeture_succes;
        public string numcompte, type_patient;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            fermeture_succes = true;
            this.Hide();
        }
        string chaine = "";

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }

        private void btnPlusExamPhys_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            dgv.Columns[1].ReadOnly = false;
            dgv.Columns[2].ReadOnly = false;
            dgv.Rows.Add();
            dgv.Rows[dgv.RowCount - 1].Cells[0].Value = dgv.RowCount;
            dgv.Rows[dgv.RowCount - 1].Cells[1].Value = "";
            dgv.Rows[dgv.RowCount - 1].Cells[2].Value = "0";
        }

        private void btnRetirerExamPhys_Click(object sender, EventArgs e)
        {
            if(dgv.RowCount != 0)
                dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
        }
        ClassCompta cc = new ClassCompta();
        private void FormExamenPhysique_Shown(object sender, EventArgs e)
        {
            
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            if (txtRecherche.Text != "")
                cc.TrouverService(this, "recherche");
            else
                cc.TrouverService(this, "");
        }
    }
}
