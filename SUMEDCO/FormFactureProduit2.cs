using System;
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
        private void txtProduit_TextChanged(object sender, EventArgs e)
        {
            cs.ChargerCompte(txtProduit, listProduit, "produit");
        }

        private void listProduit_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProduit.Text = listProduit.Text;
            idproduit = cs.TrouverId("produit", txtProduit.Text);
            listProduit.Visible = false;
            cs.ChargerLigneStock(this);
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvStock.RowCount != 0)
            {
                txtQte.Enabled = true;
                txtQte.Focus();
            }
        }

        private void txtQte_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtQte);
            if (txtQte.Text != "")
                btnAjouter.Enabled = true;
            else
                btnAjouter.Enabled = false;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            cc.ValiderLigne(this);
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }

        private void btnEnregistrerAutrePresc_Click(object sender, EventArgs e)
        {
            fermeture_succes = true;
            this.Hide();
        }

        private void dgvFacture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFacture.RowCount != 0)
                btnRetirer.Enabled = true;
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            dgvFacture.Rows.RemoveAt(dgvFacture.CurrentRow.Index);
            txtTotal.Text = "0";
            if (dgvFacture.RowCount != 0)
            {
                for (int i = 0; i < dgvFacture.RowCount; i++)
                {
                    txtTotal.Text = (double.Parse(txtTotal.Text) + double.Parse(dgvFacture.Rows[i].Cells[5].Value.ToString())).ToString();
                }
            }
        }
    }
}
