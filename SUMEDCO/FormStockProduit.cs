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
    public partial class FormStockProduit : Form
    {
        public FormStockProduit()
        {
            InitializeComponent();
            for (int i = 0; i < dgvProduit.ColumnCount; i++)
            {
                dgvProduit.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < dgvStock.ColumnCount; i++)
            {
                dgvStock.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassStock cs = new ClassStock();
        ClassCompta cc = new ClassCompta();
        public int idcat = 0, 
            idproduit = 0,
            idstock = 0,
            idpharma = 0;
        public string poste = "";
        public bool fermeture_succes;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditerCommande_Click(object sender, EventArgs e)
        {
            //if(poste=="pharmacie") 
            //    cs.EditerCommande(this, new FormCommande(), "commande");
            //else
            //    cs.EditerCommande(this, new FormCommande(), "demandeAppro");
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            
        }

        private void btnFicheStock_Click(object sender, EventArgs e)
        {
            cs.FicheStock(this, new FormStockFicheStock());
        }

        private void btnEntrees_Click(object sender, EventArgs e)
        {
            cs.FicheStock(this, new FormStockFicheStock());
        }

        private void btnSorties_Click(object sender, EventArgs e)
        {
            cs.FicheStock(this, new FormStockFicheStock());
        }
        private void btnCommandes_Click(object sender, EventArgs e)
        {
            //cs.HistoriqueCommandes(this, new FormCommandeRapport());
        }
        private void btnEditerRequisition_Click(object sender, EventArgs e)
        {
            //cs.EditerCommande(this, new FormCommande(), "requisition");
        }

        private void btnDemande_Click(object sender, EventArgs e)
        {
            cs.ServirSortieStock(this, new FormStockServir());
        }


        private void btnNouveauStock_Click(object sender, EventArgs e)
        {
            cs.NouveauStock(this, new FormStockNouveau());
        }

        private void btnNouveauAutreStock_Click(object sender, EventArgs e)
        {
            
        }

        private void txtProduit_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnStockTout_Click(object sender, EventArgs e)
        {
            
        }

        private void cboCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            idcat = cs.TrouverId("categorie", cboCategorie.Text);
            cs.ChargerProduit(this, "");
        }

        private void cboCategorie_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("categorie", cboCategorie, 0);
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            if (cboCategorie.Text != "")
                cs.ChargerProduit(this, "recherche");
            else
                MessageBox.Show("Acune catégorie n'est sélectionnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dgvProduit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduit.RowCount != 0)
            {
                idproduit = int.Parse(dgvProduit.CurrentRow.Cells[0].Value.ToString());
                cs.ChargerStockProduit(this);
                btnNouveauStock.Enabled = true;
            }
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvStock.RowCount != 0)
            {               
                btnDemande.Enabled = true;
                btnFicheStock.Enabled = true;
                btnEntrees.Enabled = true;
                btnSorties.Enabled = true;
                btnPerte.Enabled = true;
                btnRetour.Enabled = true;
                if (poste != "pharmacie")
                {
                    btnStockPha.Enabled = true;
                    if (cboCategorie.Text.ToLower() == "pharmaceutique")
                        btnDemande.Enabled = false;
                }
                else
                    btnVente.Enabled = true;
                idstock = int.Parse(dgvStock.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void btnPerte_Click(object sender, EventArgs e)
        {
            cs.PerteSortieStock(this, new FormStockServir());
        }

        private void btnStockPha_Click(object sender, EventArgs e)
        {
            cs.AjouterStockPha(this, new FormStockPha());
        }

        private void btnVente_Click(object sender, EventArgs e)
        {
            cs.VenteStockPharma(this, new FormStockServir());
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            cs.RetourEnStock(this, new FormStockRetour());
        }

    }
}
