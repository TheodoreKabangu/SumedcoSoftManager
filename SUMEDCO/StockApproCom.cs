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
    public partial class StockApproCom : Form
    {
        public StockApproCom()
        {
            InitializeComponent();
            for (int i = 0; i < dgvAppro.ColumnCount; i++)
            {
                dgvAppro.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < dgvCommande.ColumnCount; i++)
            {
                dgvCommande.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassStock cs = new ClassStock();
        ClasseElements ce = new ClasseElements();
        public string poste;
        public int idexercice = 0,
            idpharma= 0,
            idcom = 0,
            idstock = 0,
            idproduit = 0,
            qte_reste= 0,
            idcat = 0;
        public bool bon_valide;
        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCommande.RowCount > 0)
            {
                idcom = int.Parse(dgvCommande.CurrentRow.Cells[0].Value.ToString());
                idstock = int.Parse(dgvCommande.CurrentRow.Cells[6].Value.ToString());
                if (poste == "comptable") 
                    cs.TrouverApproCommande(this);
                else 
                    cs.TrouverApproCommandePha(this);               
                btnRetirer.Enabled = true;
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Voulez-vous retirer cette commande ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //retirer
                if (cs.RetirerCommande(idcom, "stock"))
                {
                    dgvCommande.Rows.RemoveAt(dgvCommande.CurrentRow.Index);
                    btnRetirer.Enabled = false;
                }
            }
        }
        private void btnServir_Click(object sender, EventArgs e)
        {
            cs.ApprovisionnerStock(this, new StockApprov());
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            if (poste == "comptable") 
                cs.AfficherCommande(this, "");
            else 
                cs.AfficherCommandePha(this, "");
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cs.ImprimerBonCommande(this, new FormImpression());
        }
        private void cboCategorie_DropDown(object sender, EventArgs e)
        {
            ce.ChargerCombo("categorie", cboCategorie, 0);
        }

        private void cboCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCommande.Rows.Clear();
            dgvAppro.Rows.Clear();
            idcat = ce.TrouverId("categorie", cboCategorie.Text);
            if (poste == "comptable") 
                btnNouveauProduit.Enabled = true;
        }

        private void btnRecherche2_Click(object sender, EventArgs e)
        {
            if (poste == "comptable") cs.AfficherCommande(this, "recherche");
            else cs.AfficherCommandePha(this, "recherche");
        }

        private void btnNouveauProduit_Click(object sender, EventArgs e)
        {
            cs.ApprovisionnerStock2(this, new StockApproAutre());
        }

        private void dgvAppro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAppro.RowCount != 0)
                btnMiseAjour.Enabled = true;
        }

        private void btnMiseAjour_Click(object sender, EventArgs e)
        {
            btnMiseAjour.Enabled = false;
            cs.MiseAJourAppro(this);
        }

        private void cboDepot_DropDown(object sender, EventArgs e)
        {
            ce.ChargerCombo("pharma", cboDepot, 0);
        }

        private void cboDepot_SelectedIndexChanged(object sender, EventArgs e)
        {
            idpharma = ce.TrouverId("pharma", cboDepot.Text);
        }
    }
}
