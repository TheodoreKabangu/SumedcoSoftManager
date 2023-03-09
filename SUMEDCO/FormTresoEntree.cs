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
                numcompte = cc.TrouverId("numcompte", caisse).ToString();
            }
            else
            {
                caisse = "Caisse en USD Dépenses";
                numcompte = cc.TrouverId("numcompte", caisse).ToString();
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
    }
}
