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
    public partial class PharmacieFacturation : Form
    {
        public PharmacieFacturation()
        {
            InitializeComponent();
        }
        public int idrecette = 0,
            idservice = 0,
            idpayeur = 0,
            idoperation = 0,
            idexercice = 0,
            idutilisateur,
            idpharma;
        public bool ajoutvalide, recettePatientConsulte, fermeture_succes;
        public string poste = "",
            type_facture = "immédiat",
            type_patient = "",
            numcompte = "",
            numcomptediffere = "4711";

        private void chbTypeFcture_Click(object sender, EventArgs e)
        {
            if (chbTypeFcture.Checked)
                type_facture = "différé";
            else
                type_facture = "immédiat";
        }
        ReceptionFactureClasse rfc = new ReceptionFactureClasse();
        ClassCompta cc = new ClassCompta();
        ClasseExercice exer = new ClasseExercice();
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            rfc.Annuler(this);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (txtPayeur.Enabled)
            {
                if (txtPayeur.Text != "" && cboSexe.Text != "")
                    rfc.EnregistrerFactureProduit(this);
                else
                    MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                rfc.EnregistrerFactureProduit(this);
        }
        ClasseElements ce = new ClasseElements();
        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ce.TesterValeurDGV(dgv1, 7, 1);
            if (Convert.ToInt16(dgv1.CurrentRow.Cells[7].Value) > Convert.ToInt32(dgv1.CurrentRow.Cells[4].Value) + Convert.ToInt32(dgv1.CurrentRow.Cells[5].Value))
            {
                MessageBox.Show("Désolé! La quantité demandée ne peut dépasser le stock disponible", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgv1.CurrentRow.Cells[7].Value = 1;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            btnRetirerTout.Enabled = false;
            btnRetirer.Enabled = false;
            rfc.RetirerDelaFacture(dgvFacture);
        }

        private void btnRetirerTout_Click(object sender, EventArgs e)
        {
            btnRetirerTout.Enabled = false;
            btnRetirer.Enabled = false;
            dgvFacture.Rows.Clear();
        }

        private void dgvFacture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFacture.RowCount != 0)
            {
                btnRetirer.Enabled = true;
                btnRetirerTout.Enabled = true;
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.RowCount != 0) btnAjouter.Enabled = true;
        }

        private void cboSexe_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTel.Focus();
        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            ce.TestEntier(txtTel);
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            rfc.RechercheProduit(dgv1, txtRecherche.Text, "facture", idpharma);
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            cc.ChangerDate(new DateTaux(), this, lblDate, lblTaux);
        }

        private void PharmacieFacturation_Shown(object sender, EventArgs e)
        {
            if (exer.NbExerciceEncours() == 1)
                idexercice = exer.ExerciceEncours();
            else
            {
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
                cc.ChangerDate(new DateTaux(), this, lblDate, lblTaux);
            else
            {
                lblDate.Text = DateTime.Now.ToShortDateString();
                lblTaux.Text = cc.VerifierTaux(DateTime.Now.Date, "valeur").ToString() + " CDF";
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            btnAjouter.Enabled = false;
            rfc.AjouterAlaFacture(dgv1, dgvFacture, "produit");
        }
    }
}
