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
    public partial class FormPatient : Form
    {
        public FormPatient()
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
            numcompte= "",
            numcomptediffere = "",
            statut= "",
            poste= "",
            num_service="";
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
                cboTypeFacture.Items.Remove("immédiat");
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if(statut == "nouveau") cm.Annuler(this);
        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (cboTypePatient.Text.Contains("abonné"))
            {
                if (cboTypePatient.Text != "" && cboEntreprise.Text != "" && cboTypeAbonne.Text != "" && txtNumService.Text != "")
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

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            if (txtAnnee.Text != "")
            {
                try
                {
                    if(Convert.ToInt32(txtAnnee.Text)>1900)
                        cm.AgePatient(this);
                }
                catch (Exception)
                {
                    MessageBox.Show("Caractère interdit! Saisissez seuls les nombres entiers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAnnee.Text = txtAnnee.Text.Substring(0, txtAnnee.Text.Length - 1);
                }
            }
        }
        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtTel);
        }

        private void txtTelContact_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtTelContact);
        }

        private void btnAffecter_Click(object sender, EventArgs e)
        {
            if (service != "" && cboTypeFacture.Text != "")
            {               
                cm.AjouterRecetteCas(this);
                MessageBox.Show("Ajouté avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
				MessageBox.Show("Type de consultation et/ou type de facture non renseignés", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void txtNom_Enter(object sender, EventArgs e)
        {
            if (cboTypePatient.Text == "")
            {
                MessageBox.Show("Aucun type patient n'est sélectionné", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypePatient.Select();
            }
        }

        private void cboSexe_Enter(object sender, EventArgs e)
        {
            if (txtNom.Text == "")
            {
                MessageBox.Show("Aucun nom de patient n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypePatient.Select();
            }
        }

        private void txtAge_Enter(object sender, EventArgs e)
        {
            if (txtMois.Text == "")
            {
                MessageBox.Show("Le mois de naissance n'est pas fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypePatient.Select();
            }
        }

        private void txtTel_Enter(object sender, EventArgs e)
        {
            if (txtAnnee.Text.Length < 4 || int.Parse(txtAnnee.Text) <= 1900)
            {
                MessageBox.Show("L'année de naissance doit être supérieure à 1900", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypePatient.Select();
            }
        }

        private void txtAge_Leave(object sender, EventArgs e)
        {
            if (txtAnnee.Text.Length < 4 || int.Parse(txtAnnee.Text) <= 1900)
            {
                MessageBox.Show("L'année de naissance doit être supérieure à 1900", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnnee.Select();
            }
            else
            {
                cm.AgePatient(this);
            }
        }

        private void txtMois_TextChanged(object sender, EventArgs e)
        {
            if (txtMois.Text != "")
            {
                try
                {
                    if (int.Parse(txtMois.Text) > 12 || int.Parse(txtMois.Text) <= 0)
                    {
                        MessageBox.Show("La valeur doit être entre 1 et 12", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMois.Text = txtMois.Text.Substring(0, txtMois.Text.Length - 1);
                        btnAnnuler.Select();
                    }
                    else
                    {
                        if (txtAnnee.Text.Length == 4 && int.Parse(txtAnnee.Text) > 1900)
							cm.AgePatient(this);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Caractère interdit! Saisissez seuls les nombres entiers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMois.Text = txtMois.Text.Substring(0, txtMois.Text.Length - 1);
                    btnAnnuler.Select();
                }
            }
        }

        private void txtMois_Enter(object sender, EventArgs e)
        {
            if (cboSexe.Text == "")
            {
                MessageBox.Show("Aucune valeur de sexe n'a été sélectionnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypePatient.Select();
            }
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
        private void rbNouveau_Click(object sender, EventArgs e)
        {
            service = string.Format("consultation {0}", rbNouveau.Text).ToLower();
        }

        private void rbUrgence_Click(object sender, EventArgs e)
        {
            service = string.Format("consultation {0}", rbUrgence.Text).ToLower();
        }
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

        private void cboTypeAbonne_Enter(object sender, EventArgs e)
        {
            if (cboEntreprise.Text == "")
            {
                MessageBox.Show("Aucune entreprise n'a été sélectionnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEntreprise.Select();
            }
        }

    }
}
