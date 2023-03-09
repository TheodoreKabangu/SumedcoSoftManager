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
    public partial class FormHistoCommande : Form
    {
        public FormHistoCommande()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();

        public int idproduit,
            idcommande = 0,
            idAppro = 0,
            idrequisition = 0,
            idmvmt = 0,
            qteprise= 0,
            idcom = 0,
            idpharma=0,
            idcat = 0;
        public string poste="",
            motif = "";
        private void btnQteCom_Click(object sender, EventArgs e)
        {
            //if(poste == "stock")
            //    cs.ValiderCommande(this, new FormCom(), "demandeAppro");
            //else
            //{
            //    if(dgvCommande.Columns[9].Visible)
            //        cs.ValiderCommande(this, new FormCom(), "requisition");
            //    else
            //        cs.ValiderCommande(this, new FormCom(), "commande");
            //}
        }
        private void dgvCommande_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCommande.RowCount > 0)
            {
                idcom = int.Parse(dgvCommande.CurrentRow.Cells[0].Value.ToString());
                btnRetirer.Enabled = true;
                btnModifier.Enabled = true;
            }
        }

        private void btnRecherche2_Click(object sender, EventArgs e)
        {
            cs.AfficherCommande(this, "recherche");
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cs.AfficherCommande(this, "");
        }

        private void cboCategorie_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("categorie", cboCategorie, 0);
        }

        private void cboCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvCommande.Rows.Clear();
            idcat = cs.TrouverId("categorie", cboCategorie.Text);
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cs.ImprimerHistoCommande(this, new FormImpression());
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous retirer cette commande ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //retirer
                if (cs.RetirerCommande(idcom, poste))
                {
                    dgvCommande.Rows.RemoveAt(dgvCommande.CurrentRow.Index);
                    btnRetirer.Enabled = false;
                }
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            btnValider.Enabled = true;
            txtQte.Enabled = true;
            txtQte.Focus();
            btnModifier.Enabled = false;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            cs.MiseAJourCommande(this, poste);
        }

        private void txtQte_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtQte);
        }

    }
}
