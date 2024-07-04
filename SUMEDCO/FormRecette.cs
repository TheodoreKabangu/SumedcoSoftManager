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
    public partial class FormRecette : Form
    {
        public FormRecette()
        {
            InitializeComponent();
            for (int i = 0; i < dgvPatient.ColumnCount; i++)
            {
                dgvPatient.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < dgvRecette.ColumnCount; i++)
            {
                dgvRecette.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();

        public string caisse="", 
            payeur, 
            poste = "",
            numcompte = "";
        public int idutilisateur,
            tauxjour = 0,
            idpayement= 0,
            idrecette = 0, 
            idexercice = 0,
            idoperation = 0,
            id = 0;
        public double taux = 0, total_payement;
        public bool supprimer_bon, supprimer_ligne;

        private void FormBon_Shown(object sender, EventArgs e)
        {
            cc.AfficherRecette(this, "");
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                taux = cc.ChangerDate(new DateTaux(), this, lblDateJour, lblTaux);
                if(taux > 0)
                    cc.SoldesCaisse(lblCaisseCDF, lblCaisseUSD, "recette");
            }
            else
            {
                lblDateJour.Text = DateTime.Now.ToShortDateString();
                taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
                lblTaux.Text = taux + " CDF";
                cc.SoldesCaisse(lblCaisseCDF, lblCaisseUSD, "recette");
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDate_Click(object sender, EventArgs e)
        {
            taux = cc.ChangerDate(new DateTaux(), this, lblDateJour, lblTaux);
        }
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.AfficherRecette(this, "recherche");
        }
        private void btnValider_Click(object sender, EventArgs e)
        {
            if (dgvRecette.CurrentRow.Index < dgvRecette.RowCount - 1)
            {
                if (cboMonnaie.Text != "")
                    cc.ValiderPayement(this);
                else
                {
                    MessageBox.Show("Précisez la monnaie pour l'encaissement", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMonnaie.Select();
                }
            }
            else
                MessageBox.Show("Sélectionnez une ligne de recette valide", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        int progress = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            progress += 1;
            if (progress == 60)
            {
                cc.AfficherRecette(this, "");
                progress = 0;
            }
        }

        private void cboCaisseRecette_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonnaie.Text == "CDF")
                numcompte = "571101";
            else
                numcompte = "571201";
            caisse = cc.TrouverNom("compte", Convert.ToInt32(numcompte));
        }
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                timer1.Start();
                progress = 0;
            }
            else
            {
                timer1.Stop();
            }
        }
        private void btnAnnulerPayement_Click(object sender, EventArgs e)
        {
            if (dgvRecette.RowCount != 0) 
                cc.AnnulerPayement(this, new FormPayements());
            btnAnnulerPayement.Enabled = false;
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPatient.RowCount != 0)
            {
                cc.TrouverRecettePatient(this);
            }
        }

        private void dgvRecette_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecette.RowCount != 0 && dgvRecette.CurrentRow.Index < dgvRecette.RowCount-1)
            {
                if (dgvRecette.CurrentRow.Cells[5].Value.ToString() == "")
                {
                    btnValider.Enabled = true;
                    btnAnnulerPayement.Enabled = false;
                }
                else
                {
                    btnAnnulerPayement.Enabled = true;
                    btnValider.Enabled = false;
                }
            }
        }
    }
}
