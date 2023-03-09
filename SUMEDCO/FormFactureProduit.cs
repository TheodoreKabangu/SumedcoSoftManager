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
            id,
            idoperation = 0,
            idutilisateur,
            idpayeur,
            idrecette;
        public double prixunitaire=0;
        public bool ajoutvalide, recettePatientConsulte, fermeture_succes;
        public string type_patient= "", poste="", numcompte = "",
            numcomptediffere = "4711";
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormFactureProduit_Shown(object sender, EventArgs e)
        {
            numcompte = cc.TrouverId("numcompte", "Ventes des médicaments").ToString();
            if (!recettePatientConsulte)
            {
                if (poste == "abonné")
                {
                    cboTypeFacture.Items.Remove("immédiat");
                    cboPayeur.Items.Remove("passant");
                }
                cc.ChargerProduit(this, "");
            }
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
            else if(cboTypeFacture.Text=="différé" && cboPayeur.Text =="")
            {
                MessageBox.Show("Renseignez à qui est destinée la facture différée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPayeur.Select();
            }
        }
        FormFacturePatient f = new FormFacturePatient();
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            if(txtRecherche.Text != "")
                cc.ChargerProduit(this, "recherche");
            else
                cc.ChargerProduit(this, "");
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cc.Annuler(this);
        }


        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (cboTypeFacture.Text != "" && cboPayeur.Text != "")
            {
                if (cboPayeur.Text == "passant")
                {
                    if (txtPayeur.Text != "" && txtContacts.Text != "")
                        cc.Enregistrer(this);
                    else
                        MessageBox.Show("Rassurez-vous que tous les champs ont des valeurs", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    cc.Enregistrer(this);
            }
            else
				MessageBox.Show("Rassurez-vous que tous les champs ont des valeurs", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnDate_Click(object sender, EventArgs e)
        {
            cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
            cboTypeFacture.Select();
        }

        private void cboTypeFacture_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPayeur.Select();
        }
        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv1.RowCount != 0)
            {
                if (dgv1.CurrentRow.Cells[1].Selected)
                    cc.ChargerStockProduit(this, new FormFactureProduit2());
            }
        }

        private void cboPayeur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPayeur.Text == "patient")
            {
                txtPayeur.Enabled = false;
                txtContacts.Enabled = false;
                cm.TrouverPatient(this, new FormFacturePatient());
            }
            else
            {
                txtPayeur.Enabled = true;
                txtContacts.Enabled = true;
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if (dgvFacture.RowCount != 0)
            {
                dgvFacture.Rows.RemoveAt(dgvFacture.CurrentRow.Index);
                cc.CalculerTotal(dgvFacture, 5, txtTotal);
                cm.RemplirNumLigne(dgvFacture, 1);
            }
            btnRetirerTout.Enabled = false;
            btnRetirer.Enabled = false;
        }

        private void btnRetirerTout_Click(object sender, EventArgs e)
        {
            btnRetirerTout.Enabled = false;
            dgvFacture.Rows.Clear();
            txtTotal.Text = "0";
        }
    }
}
