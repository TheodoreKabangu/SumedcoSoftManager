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
    public partial class FormFactureProduit2 : Form
    {
        public FormFactureProduit2()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        public int idproduit;
        public bool fermeture_succes,
            ajoutvalide;

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }


        private void btnRetirer_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            dgvStock.Rows.RemoveAt(dgvStock.CurrentRow.Index);
        }
        private void btnValider_Click(object sender, EventArgs e)
        {
            fermeture_succes = true;
            this.Hide();
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvStock.RowCount != 0)
                btnRetirer.Enabled = true;
        }

        private void txtNbfois_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtNbfois);
        }

        private void txtQte_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtQte);
        }

        private void txtNbjour_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtNbjour);
        }

        private void btnAffecter_Click(object sender, EventArgs e)
        {
            if (txtNbfois.Text != "" && txtQte.Text != "" && txtNbjour.Text != "")
            {
                for (int i = 0; i < dgvStock.RowCount; i++)
                {
                    if (dgvStock.Rows[i].Selected)
                        dgvStock.Rows[i].Cells[6].Value = int.Parse(txtNbfois.Text) * int.Parse(txtQte.Text) * int.Parse(txtNbjour.Text);
                }
            }
            else
                MessageBox.Show("Vérifiez que les trois champs de la posologie sont remplis de nombres entiers", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void FormFactureProduit2_Shown(object sender, EventArgs e)
        {
            if(dgvStock.RowCount == 0)
            {
                groupBox1.Enabled = false;
                //txtNbfois.Enabled = false;
                //txtNbjour.Enabled = false;
                //txtQte.Enabled = false;
                //btnAffecter.Enabled = false;
            }
        }
    }
}
