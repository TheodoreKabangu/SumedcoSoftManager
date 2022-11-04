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
    public partial class FormPrescription : Form
    {
        public FormPrescription()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        ClassStock cs = new ClassStock();
        public int idprescription=0,
            idstock = 0,
            idconsultation = 0,
            idmedecin = 0,
            prixunitaire = 0,
            idproduit = 0,
            numbon = 0,
            numbonP = 0,
            idpatient =0;
        public bool ajoutvalide;
        private void cboProduit_DropDown(object sender, EventArgs e)
        {
            cs.ChargerCombo(cboProduit, "produit", 0);
        }

        private void cboProduit_SelectedIndexChanged(object sender, EventArgs e)
        {
            idproduit = cs.TrouverId("produit", cboProduit.Text);
            cs.ChargerCombo(cboStock, "stock", idproduit);
            cboStock.Select();
        }

        private void cboStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            idstock = int.Parse(cboStock.Text);
            cs.DetailsStock(this);
            txtQte.Focus();
        }

        private void txtQte_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtQte);
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            cm.ValiderLigne(this);
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            dgvFacture.Rows.RemoveAt(dgvFacture.CurrentRow.Index);
            cm.RemplirNumLigne(dgvFacture, 1);
            txtTotal.Text = "0";
            if (dgvFacture.RowCount != 0)
            {
                for (int i = 0; i < dgvFacture.RowCount; i++)
                {
                    txtTotal.Text = (double.Parse(txtTotal.Text) + double.Parse(dgvFacture.Rows[i].Cells[5].Value.ToString())).ToString();
                }
            }
            else btnRetirerTout.Enabled = false;
        }

        private void btnRetirerTout_Click(object sender, EventArgs e)
        {
            btnRetirerTout.Enabled = false;
            dgvFacture.Rows.Clear();
            txtTotal.Text = "0";
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            //cm.Enregistrer(this);
        }

        private void FormPrescription_Shown(object sender, EventArgs e)
        {
            cm.MesConsultations(this, new FormConsultation());
        }

        private void dgvFacture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFacture.RowCount != 0)
            {
                btnRetirer.Enabled = true;
                btnRetirerTout.Enabled = true;
            }
        }
    }
}
