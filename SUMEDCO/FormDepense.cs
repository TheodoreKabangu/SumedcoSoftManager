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
    public partial class FormDepense : Form
    {
        public FormDepense()
        {
            InitializeComponent();            
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public int numbon = 0,
            idabonne =0,
            idcatdepense = 0,
            iddepense = 0,
            idoperation=0,
            id=0;
        public bool ajoutvalide;
        public string numcompte = "", 
            numcompteAchat = "",
            numcompteVariation = "",
            caisse="";
        public double taux= 0, 
            soldeCaisse = 0,
            montantdecaisse = 0;
        private void FormDepense_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
                txtCompte.Select();
            }
            else
            {
                lblDateOperation.Text = DateTime.Now.ToShortDateString();
                lblTaux.Text = cc.VerifierTaux(DateTime.Now.Date, "valeur").ToString() + " CDF";
                txtCompte.Select();
            }
            taux = double.Parse(lblTaux.Text.Substring(0, lblTaux.Text.IndexOf(" ")));
            lblCaisseUSD.Text = string.Format("{0} USD", cc.MontantCompte("571102"));
            lblCaisseCDF.Text = string.Format("{0} CDF", cc.MontantCompte("571202"));
            cboCibleDepense.Select();
        }
        private void cboMonnaie_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMontant.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cc.Annuler(this);
        }
        string montantLettre = "";
        private void txtMontant_Leave(object sender, EventArgs e)
        {
            if (txtMontant.Text != "")
            {
                montantLettre = cc.TestMontant(txtMontant);
                if (montantLettre !="")
                {
                    if (cboMonnaie.Text == "CDF")
                        txtMontantLettre.Text = montantLettre.Substring(0, 1).ToUpper() + montantLettre.Substring(1) + " francs congolais";
                    else
                        txtMontantLettre.Text = montantLettre.Substring(0, 1).ToUpper() + montantLettre.Substring(1) + " dollars américains";
                }
            }
        }

        FormAbon Abon = new FormAbon();
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                Abon.ShowDialog();
                if (!Abon.fermeture_succes)
                    this.Close();
                else
                {
                    idabonne = Abon.idabonne;
                    txtBeneficiaire.Text = Abon.nomabonne;
                    txtBeneficiaire.Enabled = false;
                    cboMonnaie.Select();
                }
            }
            else
            {
                txtBeneficiaire.Text = "";
                txtBeneficiaire.Enabled = true;
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cc.Enregistrer(this);
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
            txtCompte.Select();
        }
        private void cboMonnaie_Enter(object sender, EventArgs e)
        {
            if(txtBeneficiaire.Text == "")
            {
                MessageBox.Show("Aucun bénéficiaire n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCibleDepense.Select();
            }
        }

        private void txtMontant_Enter(object sender, EventArgs e)
        {
            if (cboMonnaie.Text == "")
            {
                MessageBox.Show("Aucune monnaie n'a été sélectionnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCibleDepense.Select();
            }
        }

        private void txtMotif_Enter(object sender, EventArgs e)
        {
            if (cboCaisseDepense.Text == "")
            {
                MessageBox.Show("Aucune caisse de dépense n'a été sélectionnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCibleDepense.Select();
            }
        }

        private void txtBeneficiaire_Enter(object sender, EventArgs e)
        {
            if (txtCompte.Text == "")
            {
                MessageBox.Show("Aucun compte n'a été sélectionné", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCibleDepense.Select();
            }
        }

        private void cboCibleDepense_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("cibledepense", cboCibleDepense, 0);
        }
        public string numcompteCategorie;
        private void cboCibleDepense_SelectedIndexChanged(object sender, EventArgs e)
        {
            numcompteCategorie = cc.TrouverId("numcompte", cboCibleDepense.Text).ToString();
            cc.CompteDepense(this, new FormDepenseCompte());
        }

        private void cboCaisseDepense_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboMonnaie.Text == "CDF")
            {
                if (cboCaisseDepense.Text == "CDF")
                {
                    caisse = "Caisse en CDF Dépenses";
                    montantdecaisse = double.Parse(txtMontant.Text);
                    soldeCaisse = cc.MontantCompte(cc.TrouverId("numcompte", caisse).ToString());
                    btnEnregistrer.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Le décaissement de dollars au lieu de francs n'est pas autorisé", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    montantdecaisse = 0;
                    btnEnregistrer.Enabled = false;
                }
            }
            else
            {
                if (cboCaisseDepense.Text == "CDF")
                {
                    caisse = "Caisse en CDF Dépenses";
                    montantdecaisse = double.Parse(txtMontant.Text) * taux;
                    soldeCaisse = cc.MontantCompte(cc.TrouverId("numcompte", caisse).ToString());
                }
                else
                {
                    caisse = "Caisse en USD Dépenses";
                    montantdecaisse = double.Parse(txtMontant.Text);
                    soldeCaisse = cc.MontantCompte(cc.TrouverId("numcompte", caisse).ToString());
                }
                btnEnregistrer.Enabled = true;
            }
        }

        private void txtNumRequisition_Enter(object sender, EventArgs e)
        {
            if (txtMotif.Text == "")
            {
                MessageBox.Show("Aucun motif n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCibleDepense.Select();
            }
        }

        private void cboCaisseDepense_Enter(object sender, EventArgs e)
        {
            if (txtMontant.Text == "")
            {
                MessageBox.Show("Aucun montant n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCibleDepense.Select();
            }
        }
    }
}
