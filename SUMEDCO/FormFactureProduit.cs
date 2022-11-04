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
    public partial class FormFactureProduit : Form
    {
        public FormFactureProduit()
        {
            InitializeComponent();
        }
        DateTaux d = new DateTaux();
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        ClassStock cs = new ClassStock();
        public int numbon = 0,
            numbonP = 0,
            idproduit = 0,
            idstock = 0,
            idpatient = 0,
            idoperation = 0,
            id = 0;
        public double prixunitaire=0;
        public bool ajoutvalide;
        public string numcompte = "",
            numcompteDiffere ="";
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormFactureProduit_Shown(object sender, EventArgs e)
        {
            numcompte = cc.TrouverId("numcompte", "Ventes des médicaments").ToString();
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
                cboTypeFacture.Select();
            }
            else
            {
                lblDateOperation.Text = DateTime.Now.ToShortDateString();
                lblTaux.Text = cc.VerifierTaux(DateTime.Now.Date, "valeur").ToString() + " CDF";
                cboTypeFacture.Select();
            }
        }
        private void txtPayeur_Enter(object sender, EventArgs e)
        {
            if (cboTypeFacture.Text == "")
            {
                MessageBox.Show("Aucun type de facture n'a été sélectionné", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypeFacture.Select();
            }
            else if(cboTypeFacture.Text=="différé" && cboPayeurDiffere.Text =="")
            {
                MessageBox.Show("Renseignez à qui est destinée la facture différée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPayeurDiffere.Select();
            }
        }
        FormFacture f = new FormFacture();
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            if (cboTypeFacture.Text == "")
            {
                MessageBox.Show("Aucun type de facture n'a été sélectionné", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypeFacture.Select();
            }
            else if (cboTypeFacture.Text == "différé")
            {
                f.ShowDialog();
                if (f.fermeture_succes)
                {
                    txtPayeur.Text = f.lblPatient.Text;
                    idpatient = int.Parse(f.txtIdPatient.Text);
                }
            }
            else
            {
                MessageBox.Show("Le type de la facture doit être différé pour référencer un patient", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypeFacture.Select();
            }
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cc.Annuler(this);
        }


        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cc.Enregistrer(this);
        }
        private void btnDate_Click(object sender, EventArgs e)
        {
            cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
            cboTypeFacture.Select();
        }

        private void cboTypeFacture_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTypeFacture.Text == "différé")
            {
                cc.ChargerCombo("payeurdifféré", cboPayeurDiffere, 0);
                cboPayeurDiffere.Enabled = true;
                cboPayeurDiffere.Select();
                txtPayeur.Enabled = false;
            }
            else
            {
                cboPayeurDiffere.Items.Clear();
                cboPayeurDiffere.Enabled = false;
                txtPayeur.Enabled = true;
                txtPayeur.Focus();
            }
        }

        private void cboPayeurDiffere_SelectedIndexChanged(object sender, EventArgs e)
        {
            numcompteDiffere = cc.TrouverId("numcompte", cboPayeurDiffere.Text).ToString();
            btnRecherche.Select();
        }
        private void btnFacturier_Click(object sender, EventArgs e)
        {
            cc.Facturier(this, new FormFactureProduit2());
        }

        private void btnFacturier_Enter(object sender, EventArgs e)
        {
            if (txtPayeur.Text == "")
            {
                MessageBox.Show("Le payeur n'est pas fourni pour cette recette", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypeFacture.Focus();
            }
        }
    }
}
