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
    public partial class FormBonRecette : Form
    {
        public FormBonRecette()
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
        public double taux = 0;
        public bool supprimer_bon, supprimer_ligne;

        private void FormBon_Shown(object sender, EventArgs e)
        {
            cc.AfficherRecette(this, "");
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
            }
            else
            {
                lblDateOperation.Text = DateTime.Now.ToShortDateString();
                lblTaux.Text = cc.VerifierTaux(DateTime.Now.Date, "valeur").ToString() + " CDF";
            }

            if (poste == "pharmacie")
            {
                cboCaisseRecette.Enabled = false;
                lblDateOperation.Text = DateTime.Now.ToShortDateString();
                lblTaux.Text = cc.VerifierTaux(DateTime.Now.Date, "valeur").ToString() + " CDF";
            }
            else
            {
                lblCaisseUSD.Text = string.Format("{0} USD", cc.MontantCompte("571101"));
                lblCaisseCDF.Text = string.Format("{0} CDF", cc.MontantCompte("571201"));
            }
            taux = double.Parse(lblTaux.Text.Substring(0, lblTaux.Text.IndexOf(" ")));
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDate_Click(object sender, EventArgs e)
        {
            cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
        }
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.AfficherRecette(this, "recherche");
        }
        private void btnValider_Click(object sender, EventArgs e)
        {
            if (cboCaisseRecette.Text != "" && dgvRecette.RowCount != 0)
            {
                cc.ValiderPayement(this);
            }
            else
            {
                MessageBox.Show("Sélectionnez le bon à encaisser dans la liste et/ou précisez la monnaie pour l'encaissement", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCaisseRecette.Select();
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
                //numbon = int.Parse(dgvRecette.CurrentRow.Cells[0].Value.ToString());
                //idpayement = int.Parse(dgvRecette.CurrentRow.Cells[4].Value.ToString());
                //payeur = dgvRecette.CurrentRow.Cells[3].Value.ToString();

                //cc.AfficherDetailsBon2(this);
            }
        }

        private void cboCaisseRecette_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCaisseRecette.Text == "CDF")
            {
                numcompte = "571101";
                caisse = "Caisse en CDF Recettes";
            }
            else
            {
                numcompte = "571201";
                caisse = "Caisse en USD Recettes";
            }
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
            cc.PayerRecetteDiffere(this, new FormPayement());
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
