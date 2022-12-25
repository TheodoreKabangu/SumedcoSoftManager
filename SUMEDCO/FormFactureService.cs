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
        public int numbon = 0,
            numbonS = 0,
            idservice = 0,
            idpatient = 0,
            idoperation = 0,
            id = 0;
        public bool ajoutvalide, nouveau_patient;
        public string numcompte="",
            numcompteDiffere= "";

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
            cc.ChargerCategorie(this);
        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cc.Enregistrer(this);
            if (nouveau_patient)
            {
                this.Hide();
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if (dgvFacture.RowCount != 0)
            {
                txtTotal.Text = (int.Parse(txtTotal.Text) - int.Parse(dgvFacture.CurrentRow.Cells[3].Value.ToString())).ToString("0.00");
                dgvFacture.Rows.RemoveAt(dgvFacture.CurrentRow.Index);
                cm.RemplirNumLigne(dgvFacture, 1);
            }
            btnRetirerTout.Enabled = false;
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
                if(!nouveau_patient)
                {
                    btnRetirer.Enabled = true;
                    btnRetirerTout.Enabled = true;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cc.Annuler(this);
            if(nouveau_patient)
            {
                nouveau_patient = false;
                this.Hide();
            }
        }
        public string cas = "";

        private void txtPayeur_Enter(object sender, EventArgs e)
        {
            if (cboTypeFacture.Text == "")
            {
                MessageBox.Show("Aucun type de facture n'a été sélectionné", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypeFacture.Select();
            }
            else if (cboTypeFacture.Text == "différé" && cboPayeurDiffere.Text == "")
            {
                MessageBox.Show("Renseignez à qui est destinée la facture différée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboPayeurDiffere.Select();
            }
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

        private void cboService_Enter(object sender, EventArgs e)
        {

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
                    btnService.Select();
                }
                else
                    txtPayeur.Focus();
            }
            else
            {
                MessageBox.Show("Le type de la facture doit être différé pour référencer un patient", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypeFacture.Select();
            }
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
            cboTypeFacture.Select();
        }

        private void cboPayeurDiffere_SelectedIndexChanged(object sender, EventArgs e)
        {
            numcompteDiffere = cc.TrouverId("numcompte", cboPayeurDiffere.Text).ToString();
            btnRecherche.Select();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            cc.SelectionService(this, new FormFactureService2());
        }

        private void btnService_Enter(object sender, EventArgs e)
        {
            if (txtPayeur.Text == "")
            {
                MessageBox.Show("Le payeur n'est pas fourni pour cette recette", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypeFacture.Select();
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.RowCount != 0)
            {
                if (dgv1.CurrentRow.Cells[1].Selected)
                    cc.ChargerService(this, new FormExamenPhysique());
            }
        }

    }
}
