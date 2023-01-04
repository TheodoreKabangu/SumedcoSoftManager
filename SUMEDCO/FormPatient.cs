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
            idmedecin =0, 
            idtypepatient = 0,
            identreprise = 0,
            idtypeabonne = 0,
            idrecette,
            idservice,
            idpayeur;
        public string statut= "", cas = "", 
            poste= "",
            num_service;
        private void FormPatient_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
                cboTypePatient.Select();
            }
            else
            {
                lblDateOperation.Text = DateTime.Now.ToShortDateString();
                cboTypePatient.Select();
            }
            if (poste == "abonné")
                cboTypeFacture.Items.Remove("immédiat");
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if(statut == "nouveau") cm.Annuler(this);
        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (cboTypePatient.Text != "" && cboTypeFacture.Text != "" && txtNom.Text != "" && cboSexe.Text != "" && txtAnnee.Text != "" && txtAdresse.Text != "" && service != "")
            {
                //if (service.Contains("urgence"))
                //    cas = "urgence";
                //else
                //    cas = "nouveau";
                cm.EnregistrerPatient(this);
            }
            else
            {
                MessageBox.Show("Désolé! Certaines informations obligatoire(s) sont vide(s)\nRenseignez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            if (txtAnnee.Text != "")
            {
                try
                {
                    if (int.Parse(txtAnnee.Text) > DateTime.Now.Year)
                    {
                        MessageBox.Show("L'année de naissance doit être inférieure ou égale à l'année en cours", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAnnee.Text = txtAnnee.Text.Substring(0, txtAnnee.Text.Length - 1);
                        btnAnnuler.Select();
                    }
                    else if (int.Parse(txtAnnee.Text) == DateTime.Now.Year)
                    {
                        if (int.Parse(txtMois.Text) > DateTime.Now.Month)
                        {
                            MessageBox.Show("Le mois de naissance doit être inférieur ou égal au mois en cours", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtMois.Text = txtMois.Text.Substring(0, txtMois.Text.Length - 1);
                            btnAnnuler.Select();
                        }
                        else
                        {
                            if (txtAnnee.Text.Length == 4)
                            {
                                age = cm.AgePatient(txtMois.Text + "/" + txtAnnee.Text);
                                lblAge.Text = string.Format("Age : {0}", age);
                            }
                        }
                    }
                    else
                    {
                        if (txtAnnee.Text.Length == 4)
                        {
                            age = cm.AgePatient(txtMois.Text + "/" + txtAnnee.Text);
                            lblAge.Text = string.Format("Age : {0}", age);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Caractère interdit! Saisissez seuls les nombres entiers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAnnee.Text = txtAnnee.Text.Substring(0, txtAnnee.Text.Length - 1);
                    btnAnnuler.Select();
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
            if (service != "")
            {
                if (service.Contains("urgence"))
                    cas = "urgence";
                else
                {
                    cas = "ancien";
                    //if (cm.NbConsultationPatient(idpatient, "Consultation") != 0)
                    //    cas = "ancien"; //un ancien cas doit avoir au moins une consultation dan le système
                    //else
                    //{
                    //    MessageBox.Show("Aucune consultation trouvée pour ce patient.\nC'est un cas d'urgence pour le système");
                    //    cas = "urgence";
                    //}
                }
                //Ajout ancien cas
                cm.AjouterRecetteCas(this);
            }
            else
            {
                MessageBox.Show("Aucune consultation n'a été sélectionnée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvPatient.RowCount !=0)
            {
                btnAffecter.Enabled = true;
                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
                idpatient = int.Parse(dgvPatient.CurrentRow.Cells[0].Value.ToString());
                idpayeur = int.Parse(dgvPatient.CurrentRow.Cells[1].Value.ToString());
            }
        }

        private void txtRecherche_Enter(object sender, EventArgs e)
        {
            if(txtRecherche.Text =="Nom du patient") txtRecherche.Text = "";
            txtRecherche.Focus();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.AfficherPatient(dgvPatient, txtRecherche, "recherche", poste, idpatient);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (btnModifier.ForeColor == SystemColors.ControlText)
            {
                btnEnregistrer.Enabled = false;
                btnModifier.ForeColor = Color.MediumBlue;
                btnModifier.BackColor = Color.LightSteelBlue;
                cm.Recuperer(this);
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
                if(statut=="nouveau")
                    cm.AjouterAbonne(this, new FormAbonne());
            }
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
            if (txtAnnee.Text.Length < 4)
            {
                MessageBox.Show("L'année de naissance doit avoir quatre chiffres", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypePatient.Select();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cm.Supprimer(this);
        }
        public string age;
        private void txtAge_Leave(object sender, EventArgs e)
        {
            if (txtAnnee.Text.Length < 4)
            {
                MessageBox.Show("L'année de naissance doit avoir quatre chiffres", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnnee.Select();
            }
            else
            {
                age = cm.AgePatient(txtMois.Text + "/" + txtAnnee.Text);
                lblAge.Text = string.Format("Age : {0}", age);
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
        public string service;
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

    }
}
