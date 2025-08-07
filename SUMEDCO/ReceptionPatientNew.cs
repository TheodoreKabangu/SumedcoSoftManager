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
    public partial class ReceptionPatientNew : Form
    {
        public ReceptionPatientNew()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        public int idpatient = 0, 
            idexercice =0, 
            idtypepatient = 0,
            identreprise = 0,
            idtypeabonne = 0,
            idrecette = 0,
            idservice,
            idoperation = 0;
        public string type_patient= "",
            type_facture = "immédiat",
            numcompte= "",
            numcomptediffere = "",
            statut= "",
            poste= "",
            num_service="";
        ReceptionFactureClasse rfc = new ReceptionFactureClasse();
        private void FormPatient_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                cc.ChangerDate(new DateTaux(), this, lblDate, lblTaux);
                cboTypePatient.Select();
            }
            else
            {
                lblDate.Text = DateTime.Now.ToShortDateString();
                cboTypePatient.Select();
            }
            if (poste == "abonné")
            {
                type_facture = "différé";
                chbTypeFcture.Enabled = false;

            }
            rfc.RechercheService(dgv1, "", statut);
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if(statut == "nouveau") cm.Annuler(this);
        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentRow.Index >= 0)
            {
                if (cboTypePatient.Text.Contains("abonné"))
                {
                    if (cboEntreprise.Text != "" && cboTypeAbonne.Text != "" && txtNumService.Text != "")
                    {
                        cm.EnregistrerPatient(this);
                    }
                    else
                        MessageBox.Show("Renseignez la relation entre le patient et son entreprise abonnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cm.EnregistrerPatient(this);
                }
            }
            else MessageBox.Show("Sélectionnez une consultation dans la liste", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        ClasseElements ce = new ClasseElements();
        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            ce.TestEntier(txtTel);
        }

        private void txtTelContact_TextChanged(object sender, EventArgs e)
        {
            ce.TestEntier(txtTelContact);
        }

        private void btnAffecter_Click(object sender, EventArgs e)
        {
            if (dgv1.CurrentRow.Index >= 0)
            {
                rfc.AjouterRecette(
                    type_facture,
                    lblDate.Text,
                    dgv1.CurrentRow.Cells[4].Value.ToString(),
                    dgv1.CurrentRow.Cells[1].Value.ToString(),
                    1,
                    Convert.ToDouble(dgv1.CurrentRow.Cells[2].Value),
                    "service",
                    idpatient);
                MessageBox.Show("Ajouté avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Sélectionnez une consultation dans la liste", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (cboTypePatient.Text.Contains("abonné"))
            {
                if (cboTypePatient.Text != "" && cboEntreprise.Text != "" && cboTypeAbonne.Text != "" && txtNumService.Text != "")
                {
                    cm.Modifier(this);
                }
                else
                    MessageBox.Show("Renseignez la relation entre le patient et son entreprise abonnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cm.Modifier(this);
            }
        }

        private void cboSexe_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMois.Focus();
        }

        private void cboTypePatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            idtypepatient = cm.TrouverId("typepatient", cboTypePatient.Text);
            if (cboTypePatient.Text.Contains("abonné"))
            {
                groupBox2.Enabled = true;
                cboEntreprise.Select();
            }
            else
                txtNom.Focus();
        }

        private void txtMois_TextChanged(object sender, EventArgs e)
        {
            ce.TestEntier(txtMois);
        }
        private void cboTypePatient_DropDown(object sender, EventArgs e)
        {
            cm.ChargerCombo(cboTypePatient, "typepatient");
            if (poste == "réception")
            {
                cboTypePatient.Items.Remove("abonné");
                cboTypePatient.Items.Remove("employé");
                cboTypePatient.Items.Remove("abonné forfaitaire");
            }
            else if (poste == "abonné")
            {
                cboTypePatient.Items.Remove("payant");
                cboTypePatient.Items.Remove("cas social");
            }
        }
        public string service= "";

        public string zonesante = "HZS";
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                zonesante = "ZS";
            else
                zonesante = "HZS";
        }

        private void cboEntreprise_SelectedIndexChanged(object sender, EventArgs e)
        {
            identreprise = cc.TrouverId("entreprise", cboEntreprise.Text);
            cc.ChargerCombo("typeabonne", cboTypeAbonne, identreprise);
            cboTypeAbonne.Select();
        }

        private void cboTypeAbonne_SelectedIndexChanged(object sender, EventArgs e)
        {
            idtypeabonne = cc.TrouverId("typeabonne", cboTypeAbonne.Text);
            txtNumService.Focus();
        }

        private void cboEntreprise_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("entreprise", cboEntreprise, 0);
        }

        private void txtAnnee_Leave(object sender, EventArgs e)
        {
            if (txtAnnee.Text != "")
            {
                if (Convert.ToInt16(txtAnnee.Text) < 1900 || Convert.ToInt16(txtAnnee.Text) > DateTime.Now.Year)
                {
                    MessageBox.Show("L'année de naissance doit être compris entre 1900 et " + DateTime.Now.Year, "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAnnee.Select();
                }
            }
        }

        private void txtMois_Leave(object sender, EventArgs e)
        {
            if (txtMois.Text != "")
            {
                if (Convert.ToInt16(txtMois.Text) > 12 || Convert.ToInt16(txtMois.Text) <= 0)
                {
                    MessageBox.Show("La valeur doit être entre 1 et 12", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMois.Select();
                }
                if (txtAnnee.Text != "")
                {
                    if (Convert.ToInt16(txtAnnee.Text) == DateTime.Now.Year && Convert.ToInt16(txtMois.Text) > DateTime.Now.Month)
                    {
                        MessageBox.Show("Etant né(e) cette année, le mois de naissance doit être inférieur ou égal au mois en cours", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMois.Select();
                    }
                }               
            }
        }

        private void txtAnnee_TextChanged(object sender, EventArgs e)
        {
            ce.TestEntier(txtAnnee);
        }

        private void chbTypeFcture_Click(object sender, EventArgs e)
        {
            if (chbTypeFcture.Checked)
                type_facture = "différé";
            else
                type_facture = "immédiat";
        }
    }
}
