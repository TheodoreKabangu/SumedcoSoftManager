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
    public partial class FormStockAlerte : Form
    {
        public FormStockAlerte()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassCompta cc = new ClassCompta();
        public int idcom = 0,
            idproduit = 0,
            idstock=0,
            qteprise = 0,
            idpharma = 0,
            idcat= 0;
        public string poste = "";
        public bool ajout_effectue;
        private void btnServir_Click(object sender, EventArgs e)
        {
            cs.AjouterCommande(this, poste);
        }
        private void FormCommandeRapport_Shown(object sender, EventArgs e)
        {

        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cs.ChargerProduit(this, "recherche");
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

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvStock.RowCount != 0)
            {
                btnRetirer.Enabled = true;
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            dgvStock.Rows.RemoveAt(dgvStock.CurrentRow.Index);
        }

        private void dgvProduit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduit.RowCount != 0)
            {
                idproduit = int.Parse(dgvProduit.CurrentRow.Cells[0].Value.ToString());
                cs.ChargerStockProduit(this);
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
