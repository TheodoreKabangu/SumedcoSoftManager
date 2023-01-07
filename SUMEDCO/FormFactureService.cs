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
    public partial class FormFactureService : Form
    {
        public FormFactureService()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public int idrecette = 0,
            idservice = 0,
            idpayeur = 0,
            idoperation = 0,
            id = 0,
            idutilisateur;
        public bool ajoutvalide, recettePatientConsulte, fermeture_succes;
        public string poste,
            numcompte = "", 
            numcomptediffere = "411100";

        private void FormFacturation_Shown(object sender, EventArgs e)
        {
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
            
            if (!recettePatientConsulte)
            {
                if (poste == "abonné")
                {
                    cboTypeFacture.Items.Remove("immédiat");
                    cboPayeur.Items.Remove("passant");
                }
                cc.ChargerCategorie(this);
            }
        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cc.Enregistrer(this);
            if(recettePatientConsulte)
            {
                fermeture_succes = true;
                this.Hide();
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if (dgvFacture.RowCount != 0)
            {
                dgvFacture.Rows.RemoveAt(dgvFacture.CurrentRow.Index);
                cc.CalculerTotal(dgvFacture, 3, txtTotal);
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

        private void dgvFacture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvFacture.RowCount !=0)
            {
                btnRetirer.Enabled = true;
                btnRetirerTout.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cc.Annuler(this);
        }
        public string cas = "";

        private void txtPayeur_Enter(object sender, EventArgs e)
        {
            if (cboPayeur.Text == "")
            {
                MessageBox.Show("Aucun type de payeur n'a été sélectionné", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypeFacture.Select();
            }
        }

        private void cboTypeFacture_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPayeur.Select();
        }
        private void btnDate_Click(object sender, EventArgs e)
        {
            cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
            cboTypeFacture.Select();
        }
        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.RowCount != 0)
            {
                if (dgv1.CurrentRow.Cells[1].Selected)
                    cc.ChargerService(this, new FormExamenPhysique());
            }
        }

        private void cboPayeur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboPayeur.Text == "patient")
            {
                txtPayeur.Enabled = false ;
                txtContacts.Enabled = false;
                cm.TrouverPatient(this, new FormFacturePatient());
            }
            else
            {
                txtPayeur.Enabled = true;
                txtContacts.Enabled = true;
            }
        }

        private void cboPayeur_Enter(object sender, EventArgs e)
        {
            if (cboTypeFacture.Text == "")
            {
                MessageBox.Show("Aucun type de facture n'a été sélectionné", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypeFacture.Select();
            }
        }

        private void txtContacts_Enter(object sender, EventArgs e)
        {
            if (txtPayeur.Text == "")
            {
                MessageBox.Show("Aucun payeur n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypeFacture.Select();
            }
        }

    }
}
