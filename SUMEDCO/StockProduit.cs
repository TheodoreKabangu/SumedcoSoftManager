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
    public partial class StockProduit : Form
    {
        
        public StockProduit()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassCompta cc = new ClassCompta();
        public int idcat = 0, 
            idproduit = 0,
            idstock = 0,
            idpharma = 0, qtedem;
        public string poste = "", nomproduit="";
        public bool fermeture_succes;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnFicheStock_Click(object sender, EventArgs e)
        {
            cs.FicheStock(this, new StockFicheStock(), "");
        }

        private void btnEntrees_Click(object sender, EventArgs e)
        {
            cs.FicheStock(this, new StockFicheStock(), "entrée");
        }

        private void btnSorties_Click(object sender, EventArgs e)
        {
            cs.FicheStock(this, new StockFicheStock(), "sortie");
        }
        private void btnDemande_Click(object sender, EventArgs e)
        {
            cs.ServirSortieStock(this, new StockSortie());
        }

        private void btnNouveauStock_Click(object sender, EventArgs e)
        {
            cs.NouveauStock(this, new StockNouveau());
        }
        private void cboCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            idcat = cs.TrouverId("categorie", cboCategorie.Text);
            dgvStock.Rows.Clear();
        }

        private void cboCategorie_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("categorie", cboCategorie, 0);
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            if (cboCategorie.Text != "")
                cs.Stocks(this);
            else
                MessageBox.Show("Acune catégorie n'est sélectionnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public bool valider_vente, vente_effectue;
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
                    if (cboCategorie.Text.ToLower() == "pharmaceutique")
                        btnDemande.Enabled = false;
                }
            }
        }

        private void btnPerte_Click(object sender, EventArgs e)
        {
            cs.PerteSortieStock(this, new StockSortie());
        }
        private void btnRetour_Click(object sender, EventArgs e)
        {
            cs.RetourEnStock(this, new StockRetour());
        }
        private void btnCmdPrep_Click(object sender, EventArgs e)
        {
            cs.PreparerCommandde(this, new StockAlerte());
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                if(cboCategorie.Text != "")
                {
                    cs.AlerteStock(this);
                    btnCmdPrep.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Acucune catégorie n'est sélectionnez dans la liste","Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkBox2.Checked = false;
                    cboCategorie.Select();
                }
            }
            else
            {
                btnCmdPrep.Enabled = false;
            }
        }

        private void btnPharmacie_Click(object sender, EventArgs e)
        {
            cs.AjouterPharmacie(this, new StockPharmacie());
        }
    }
}
