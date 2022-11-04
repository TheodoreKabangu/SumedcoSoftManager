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
    public partial class FormStockPharma : Form
    {
        public FormStockPharma()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        public int idproduit = 0,
            idstock = 0;
        public string poste = "";
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditerCommande_Click(object sender, EventArgs e)
        {
            if(poste=="pharmacie") 
                cs.EditerCommande(this, new FormCommande(), "commande");
            else
                cs.EditerCommande(this, new FormCommande(), "demandeAppro");
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            cs.AfficherStocksProduit(this);
        }

        private void btnFicheStock_Click(object sender, EventArgs e)
        {
            cs.FicheStock(this);
        }

        private void btnEntrees_Click(object sender, EventArgs e)
        {
            cs.EntreesStock(this);
        }

        private void btnSorties_Click(object sender, EventArgs e)
        {
            cs.SortiesStock(this);
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvStock.RowCount > 0)
            {
                btnFicheStock.Enabled = true;
                btnStock.Enabled = true;
                btnEntrees.Enabled = true;
                btnSorties.Enabled = true;
                btnEditerCommande.Enabled = true;
                idproduit = int.Parse(dgvStock.CurrentRow.Cells[1].Value.ToString());

                if (poste == "pharmacie") btnEditerRequisition.Enabled = true;

                if (dgvStock.CurrentRow.DefaultCellStyle.BackColor == Color.IndianRed)
                    dgvStock.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.OrangeRed;
            }
        }

        private void btnCommandes_Click(object sender, EventArgs e)
        {
            cs.HistoriqueCommandes(this, new FormCommandeRapport());
        }

        private void btnAlertes_Click(object sender, EventArgs e)
        {
            cs.AlertesStock(this);
        }

        private void btnEditerRequisition_Click(object sender, EventArgs e)
        {
            cs.EditerCommande(this, new FormCommande(), "requisition");
        }

        private void btnDemande_Click(object sender, EventArgs e)
        {
            if (poste == "pharmacie")
                new FormRequisition().Show();
            else
                cs.HistoriqueApproStockPharma(new FormApproStockPharma());
        }

        private void listProduit_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProduit.Text = listProduit.Text;
            idproduit = cs.TrouverId("produit", txtProduit.Text);
            listProduit.Visible = false;
            btnStock.Enabled = true;
        }

        private void btnNouveauStock_Click(object sender, EventArgs e)
        {
            new FormProduitPharmaStock().ShowDialog();
        }

        private void btnNouveauAutreStock_Click(object sender, EventArgs e)
        {
            
        }

        private void txtProduit_TextChanged(object sender, EventArgs e)
        {
            cs.ChargerCompte(txtProduit, listProduit, "produit");
        }

        private void btnStockTout_Click(object sender, EventArgs e)
        {
            cs.AfficherToutStock(this);
        }
    }
}
