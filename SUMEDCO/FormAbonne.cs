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
    public partial class FormAbonne : Form
    {
        public FormAbonne()
        {
            InitializeComponent();
        }
        public int idabonne= 0, 
            identreprise = 0,
            idtypepatient = 0,
            idtypeabonne = 0;
        public bool fermeture_succes, 
            recherche_valide,
            nouveau_patient;
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        private void btnService_Click(object sender, EventArgs e)
        {
            cc.Services(this, new FormAbonneService());
        }

        private void btnProduit_Click(object sender, EventArgs e)
        {
            cc.Produits(this, new FormAbonneProduit());
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
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
            txtReference.Focus();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }

        private void dgvAbonne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!nouveau_patient)
                cc.Recuperer(this);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            fermeture_succes = true;
            this.Hide();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cc.Modifier(this);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cc.Supprimer(this);
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            cc.Afficher(this);
            cm.AfficherPatient(dgvAbonne, 9, 6);
        }

        public string age;

        private void cboTypeAbonne_Enter(object sender, EventArgs e)
        {
            if (cboEntreprise.Text == "")
            {
                MessageBox.Show("Aucune entreprise n'a été sélectionnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEntreprise.Select();
            }
        }

        private void cboEntreprise_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("entreprise", cboEntreprise, 0);
        }

        private void cboTypePatient_DropDown(object sender, EventArgs e)
        {
            cm.ChargerCombo(cboTypePatient, "typepatient");
            cboTypePatient.Items.Remove("payant");
        }

        private void cboTypePatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            idtypepatient = cm.TrouverId("typepatient", cboTypePatient.Text);
            if(cboTypePatient.Text == "abonné")
            {
                cboEntreprise.Enabled = true;
                cboTypeAbonne.Enabled = true;
                txtReference.Enabled = true;
                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
                btnAfficher.Enabled = true;
                cc.Annuler(this);
                for (int i = 3; i <= 5; i++)
                    dgvAbonne.Columns[i].Visible = true;
            }
            else
            {
                cc.Annuler(this);
                cboEntreprise.Enabled = false;
                cboTypeAbonne.Enabled = false;
                txtReference.Enabled = false;
                btnModifier.Enabled = false;
                btnSupprimer.Enabled = false;
                btnAfficher.Enabled = false;
                for (int i = 3; i <= 5; i++)
                    dgvAbonne.Columns[i].Visible = false;

                cc.AfficherEmploye(this);
                cm.AfficherPatient(dgvAbonne, 9, 6);
            }
        }
    }
}
