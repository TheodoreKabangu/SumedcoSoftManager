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
    public partial class FormTresoEntree : Form
    {
        public FormTresoEntree()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public string caisse= "", numcompte = "";
        public double taux = 0;
        public int idoperation = 0;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboEncaisser_SelectedIndexChanged(object sender, EventArgs e)
        {
            cc.Encaisser(this);
        }

        private void cboCaisseDepense_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCaisseDepense.Text == "CDF")
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

        private void btnDate_Click(object sender, EventArgs e)
        {
            cc.ChangerDate(this, new DateTaux());
        }

        private void FormDepense2_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                cc.ChangerDate(this, new DateTaux());
            }
            else
            {
                lblDateOperation.Text = DateTime.Now.ToShortDateString();
                lblTaux.Text = cc.VerifierTaux(DateTime.Now.Date, "valeur").ToString() + " CDF";
                taux = double.Parse(lblTaux.Text.Substring(0, lblTaux.Text.IndexOf(" ")));
                lblCaisseUSD.Text = string.Format("{0} USD", cc.MontantCompte("571202"));
                lblCaisseCDF.Text = string.Format("{0} CDF", cc.MontantCompte("571102"));
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
                if (cboCaisseDepense.Text != "")
                    txtMontant.Focus();
                else
                    cboCaisseDepense.Select();
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cc.Annuler(this);
        }

        private void txtMontant_Enter(object sender, EventArgs e)
        {
            if (cboCaisseDepense.Text == "" && cboEncaisser.Text == "payement par les abonnés")
            {
                MessageBox.Show("Aucune monnaie n'est sélectionné pour cette opération", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCaisseDepense.Select();
            }
        }
    }
}
