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
    public partial class TresoEntree : Form
    {
        public TresoEntree()
        {
            InitializeComponent();
            for (int i = 0; i < dgvBon.ColumnCount; i++)
            {
                dgvBon.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        public string caisse= "", numcompte = "";
        public double taux = 0;
        public int idutilisateur, idexercice = 0, idoperation = 0;
        
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboEncaisser_SelectedIndexChanged(object sender, EventArgs e)
        {
            cc.Encaisser(this);
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            taux = cc.ChangerDate(new DateTaux(), this, lblDateJour, lblTaux);
        }

        private void FormDepense2_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                taux = cc.ChangerDate(new DateTaux(), this, lblDateJour, lblTaux);
                //if(taux > 0)
                    //cc.SoldesCaisse(lblCaisseCDF, lblCaisseUSD, "dépense");
            }
            else
            {
                lblDateJour.Text = DateTime.Now.ToShortDateString();
                taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
                lblTaux.Text = taux + " CDF";
                //cc.SoldesCaisse(lblCaisseCDF, lblCaisseUSD, "dépense");
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if(cboEncaisser.Text != "" && dgvBon.RowCount != 0) 
                cc.AjouterEncaissement(this);
        }

        private void dgvBon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cboEncaisser.Text != "rapport de recettes")
            {
                if (cboMonnaie.Text != "")
                    txtMontant.Focus();
                else
                    cboMonnaie.Select();
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cc.Annuler(this);
        }

        private void txtMontant_Enter(object sender, EventArgs e)
        {
            if (cboMonnaie.Text == "" && cboEncaisser.Text == "payement par les abonnés")
            {
                MessageBox.Show("Aucune monnaie n'est sélectionné pour cette opération", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMonnaie.Select();
            }
        }

        private void txtMontant_Leave(object sender, EventArgs e)
        {
            cc.TestMontant(txtMontant);
        }

        private void cboMonnaie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonnaie.Text == "CDF")
            {
                caisse = "Caisse en CDF Dépenses";
                numcompte = "571102";
            }
            else
            {
                caisse = "Caisse en USD Dépenses";
                numcompte = "571202";
            }
            txtMontant.Focus();
        }
    }
}
