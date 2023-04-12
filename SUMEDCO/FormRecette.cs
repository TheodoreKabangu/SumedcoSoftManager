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
        }
        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();

        public string caisse="", 
            payeur, 
            poste = "",
            numcompte = "";
        public int tauxjour = 0,
            idpayement= 0,
            idrecette = 0, 
            numbon = 0,
            idoperation = 0,
            id = 0;
        public double taux = 0, total_payement;
        public bool supprimer_bon, supprimer_ligne;

        private void FormBon_Shown(object sender, EventArgs e)
        {
            cc.AfficherRecette(this, "");
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                cc.ChangerDate(this, new DateTaux());                
            }
            else
            {
                lblDateOperation.Text = DateTime.Now.ToShortDateString();
                lblTaux.Text = cc.VerifierTaux(DateTime.Now.Date, "valeur").ToString() + " CDF";
                taux = double.Parse(lblTaux.Text.Substring(0, lblTaux.Text.IndexOf(" ")));
                lblCaisseUSD.Text = string.Format("{0} USD", cc.MontantCompte("571201"));
                lblCaisseCDF.Text = string.Format("{0} CDF", cc.MontantCompte("571101"));
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDate_Click(object sender, EventArgs e)
        {
            cc.ChangerDate(this, new DateTaux());
        }
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.AfficherRecette(this, "recherche");
        }
        private void btnValider_Click(object sender, EventArgs e)
        {
            if (cboMonnaie.Text != "" && dgvRecette.RowCount != 0)
            {
                cc.ValiderPayement(this, new FormPayement());
            }
            else
            {
                MessageBox.Show("Sélectionnez le bon à encaisser dans la liste et/ou précisez la monnaie pour l'encaissement", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMonnaie.Select();
            }
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

        private void dgvRecette_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecette.RowCount != 0)
            {
                idrecette = int.Parse(dgvRecette.CurrentRow.Cells[0].Value.ToString());
                if (dgvRecette.CurrentRow.Cells[1].Value.ToString() == "immédiat")
                {
                    btnValider.Enabled = true;
                    btnPayer.Enabled = false;
                    btnAnnulerPayement.Enabled = false;
                }
                else
                {
                    btnValider.Enabled = false;
                    btnPayer.Enabled = true;
                    btnAnnulerPayement.Enabled = false;
                }
                cc.TrouverPayementRecette(this); 
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

        private void checkBox1_MouseEnter(object sender, EventArgs e)
        {
            //if(checkBox1.Checked)
            //    checkBox1
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

        private void dgvPayement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvPayement.RowCount != 0)
            {
                btnValider.Enabled = false;
                btnPayer.Enabled = false;
                btnAnnulerPayement.Enabled = true;
            }
        }

        private void btnPayer_Click(object sender, EventArgs e)
        {
            if (cboMonnaie.Text != "" && dgvRecette.RowCount != 0)
            {
                cc.PayerRecetteDiffere(this, new FormPayement());
            }
            else
            {
                MessageBox.Show("Sélectionnez le bon à encaisser dans la liste et/ou précisez la monnaie pour l'encaissement", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMonnaie.Select();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnAnnulerPayement_Click(object sender, EventArgs e)
        {
            if (dgvPayement.RowCount != 0) 
                cc.AnnulerPayement(this, new FormPayement());
            btnAnnulerPayement.Enabled = false;
        }
    }
}
