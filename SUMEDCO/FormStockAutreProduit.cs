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
    public partial class FormStockAutreProduit : Form
    {
        public FormStockAutreProduit()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        public int idproduit;
        public string poste;
        private void listProduit_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProduit.Text = listProduit.Text;
            idproduit = cs.TrouverId("autreproduit", txtProduit.Text);
            listProduit.Visible = false;
            btnStock.Enabled = true;
        }

        private void btnNouveauAutreStock_Click(object sender, EventArgs e)
        {
            new FormProduitAutreStock().ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProduit_TextChanged(object sender, EventArgs e)
        {
            cs.ChargerCompte(txtProduit, listProduit, "Autreproduit");
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            cs.AfficherStocksProduit(this);
        }

        private void btnStockTout_Click(object sender, EventArgs e)
        {
            cs.AfficherToutStock(this);
        }

        private void btnDemande_Click(object sender, EventArgs e)
        {
            cs.HistoriqueApproStockAutre(new FormApproStockAutre());
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvStock.RowCount != 0)
            {
                btnFicheStock.Enabled = true;
                btnStock.Enabled = true;
                btnEntrees.Enabled = true;
                btnSorties.Enabled = true;
                btnEditerCommande.Enabled = true;
                btnEditerRequisition.Enabled = true;
                idproduit = int.Parse(dgvStock.CurrentRow.Cells[1].Value.ToString());
                
                if (dgvStock.CurrentRow.DefaultCellStyle.BackColor == Color.IndianRed)
                    dgvStock.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.OrangeRed;
            }
        }

        private void btnEditerCommande_Click(object sender, EventArgs e)
        {
            cs.EditerCommande(this, new FormCommandePharma(), "commande");
        }

        private void btnEditerRequisition_Click(object sender, EventArgs e)
        {
            cs.EditerCommande(this, new FormCommandePharma(), "requisition");
        }

        private void btnCommandes_Click(object sender, EventArgs e)
        {
            cs.HistoriqueCommandes(this, new FormCommandeRapport2());
        }

        private void btnAlertes_Click(object sender, EventArgs e)
        {

        }
    }
}
