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
        public int idpatient = 0, 
            idligneagenda = 0, 
            idmedecin =0, 
            idtypepatient = 0,
            idemploye = 0,
            idabonne = 0,
            identreprise = 0,
            idtypeabonne = 0;
        public string statut= "", cas = "", 
            poste= "",
            refabonne;
        private void FormPatient_Shown(object sender, EventArgs e)
        {
            cm.CompterCasMedecin(this);            
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (cboTypePatient.Text != "" && cboMedecin.Text != "" && txtNom.Text != "" && cboSexe.Text != "" && txtAnnee.Text != "" && txtAdresse.Text != "")
            {
                if (MessageBox.Show("S'agit-il d'une consultation d'urgence", "Question sur le cas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    cas = "urgence";
                else
                    cas = "nouveau";
                cm.Enregistrer(this);
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void cboMedecin_DropDown(object sender, EventArgs e)
        {
            cm.ChargerCombo(cboMedecin, "médecin");
        }

        private void cboMedecin_SelectedIndexChanged(object sender, EventArgs e)
        {
            idmedecin = cm.TrouverId("medecin", cboMedecin.Text);
        }

        private void btnAffecter_Click(object sender, EventArgs e)
        {
            if (cboMedecin.Text != "")
            {
                cm.Annuler(this);
                if (cm.VerifierCasAgenda(this) == 0)
                {
                    if (MessageBox.Show("S'agit-il d'une consultation d'urgence", "Question sur le cas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        cas = "urgence";
                    else
                    {
                        if (cm.CompterConsultation(idpatient) != 0)
                            cas = "ancien"; //un ancien cas doit avoir au moins une consultation dan le système
                        else
                        {
                            MessageBox.Show("Aucune consultation n'a été trouvée pour ce patient.\nLe système le considère comme un cas d'urgence");
                            cas = "urgence";
                        }
                    }
                    cm.EnregistrerAgenda(this);
                    MessageBox.Show("Affectation effectuée avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Ce cas est déjà affecté", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvPatient.Rows.RemoveAt(dgvPatient.CurrentRow.Index);

            }
            else
            {
                MessageBox.Show("Aucun médecin n'a été sélectionné", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMedecin.Select();
            }
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvPatient.RowCount !=0)
            {
                btnAffecter.Enabled = true;
                btnReaffecter.Enabled = true;
                btnRetirer.Enabled = true;
                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
                idpatient = int.Parse(dgvPatient.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void txtRecherche_Enter(object sender, EventArgs e)
        {
            if(txtRecherche.Text =="Nom du patient") txtRecherche.Text = "";
            txtRecherche.Focus();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.Afficher(this, "recherche");
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (btnModifier.Text == "Modifier")
            {
                btnEnregistrer.Enabled = false;
                btnModifier.Text = "Confirmer";
                cm.Recuperer(this);
            }
            else
            {
                cm.Modifier(this);
            }
        }

        private void btnReaffecter_Click(object sender, EventArgs e)
        {
            if (cboMedecin.Text != "")
            {
                if (MessageBox.Show("S'agit-il d'une consultation d'urgence", "Question sur le cas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    cas = "urgence";
                else cas = cm.TrouverNom("casconsultation", idpatient);
                if (cm.ModifierAgenda(this, ""))
                {
                    cm.Annuler(this);
                    MessageBox.Show("Affectation modifiée avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPatient.Rows.RemoveAt(dgvPatient.CurrentRow.Index);
                }
            }
            else
            {
                MessageBox.Show("Aucun médecin n'a été sélectionné", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMedecin.Select();
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if (cm.ModifierAgenda(this, "retirer"))
            {
                cm.Annuler(this);
                MessageBox.Show("Affectation retirée avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPatient.Rows.RemoveAt(dgvPatient.CurrentRow.Index);
            }
        }

        private void cboSexe_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMois.Focus();
        }

        private void cboTypePatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            idtypepatient = cm.TrouverId("typepatient", cboTypePatient.Text);
            if(cboTypePatient.Text == "abonné")
            {
                if(statut=="nouveau")
                    cm.Abonne(this, new FormAbonne());
            }
        }

        private void txtNom_Enter(object sender, EventArgs e)
        {
            if (cboMedecin.Text == "")
            {
                MessageBox.Show("Aucun médecin n'a été sélectionné", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void cboMedecin_Enter(object sender, EventArgs e)
        {
            if (statut == "nouveau" && cboTypePatient.Text == "")
            {
                MessageBox.Show("Aucun type de patient n'a été sélectionné", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypePatient.Select();
            }
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
            if (poste == "reception")
            {
                cboTypePatient.Items.Clear();
                cboTypePatient.Items.Add("payant");
            }
            else if (poste == "abonne")
            {
                cboTypePatient.Items.Remove("payant");
            }
        }

    }
}
