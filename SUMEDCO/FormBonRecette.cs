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
            idpatient= 0,
            idrecette = 0, 
            numbon = 0,
            idoperation = 0,
            id = 0;
        public double taux = 0;
        public bool supprimer_bon, supprimer_ligne;

        private void FormBon_Shown(object sender, EventArgs e)
        {
            cc.AfficherRecette(this, "");

            if (poste == "pharmacie")
            {
                //txtMotif.Enabled = false;
                //btnValide.Enabled = false;
                btnSupprimer.Enabled = false;
                btnValiderBon.Enabled = false;
                cboCaisseRecette.Enabled = false;
                lblDateOperation.Text = DateTime.Now.ToShortDateString();
                lblTaux.Text = cc.VerifierTaux(DateTime.Now.Date, "valeur").ToString() + " CDF";
            }
            else
            {
                if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
                {
                    cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
                }
                else
                {
                    lblDateOperation.Text = DateTime.Now.ToShortDateString();
                    lblTaux.Text = cc.VerifierTaux(DateTime.Now.Date, "valeur").ToString() + " CDF";
                }
                if (poste == "reception" || poste == "infirmerie")
                {
                    btnValiderBon.Enabled = false;
                    cboCaisseRecette.Enabled = false;
                }
                else if (poste == "recette")
                {
                    //txtMotif.Enabled = false;
                    //btnValide.Enabled = false;
                    btnSupprimer.Enabled = false;
                    btnValiderBon.Enabled = true;
                    lblCaisseUSD.Text = string.Format("{0} USD", cc.MontantCompte("571101"));
                    lblCaisseCDF.Text = string.Format("{0} CDF", cc.MontantCompte("571201"));
                }
            }
            taux = double.Parse(lblTaux.Text.Substring(0, lblTaux.Text.IndexOf(" ")));
        }

        private void dgvFacture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvPayement.RowCount !=0)
            {
                if (poste == "reception")
                {
                    btnRetirer.Enabled = true;
                }
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Rassurez-vous de renseigner la cause de ce retrait", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //txtMotif.Enabled = true;
            //btnValide.Enabled = true;
            //txtMotif.Focus();
            //btnRetirer.Enabled = false;
            //supprimer_ligne = true;
            //supprimer_bon = false;
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            cc.AfficherRecette(this, "");
        }
        private void btnValiderBon_Click(object sender, EventArgs e)
        {
            if(cboCaisseRecette.Text !="" && dgvPayement.RowCount != 0)
            {
                if (cboCaisseRecette.Text == "CDF")
                    caisse = "Caisse en CDF Recettes";
                else
                    caisse = "Caisse en USD Recettes";
                if (dgvRecette.CurrentRow.Cells[1].Value.ToString() == "immédiat")
                {
                    MessageBox.Show("Rassurez-vous d'avoir bien compté : " + txtTotal.Text + " CDF", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numcompte = cc.TrouverId("numcompte", caisse).ToString();
                    cc.Enregistrer(this);
                }
                else
                {
                    if(txtTotal.Text != "0") cc.AgendaCaisse(this, new FormAgendaCaisse());
                }
            }
            else
            {
                MessageBox.Show("Sélectionnez le bon à encaisser dans la liste et/ou précisez la monnaie pour l'encaissement", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCaisseRecette.Select();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvBon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvRecette.RowCount !=0)
            {
                numbon = int.Parse(dgvRecette.CurrentRow.Cells[0].Value.ToString());
                idpatient = int.Parse(dgvRecette.CurrentRow.Cells[4].Value.ToString());
                payeur = dgvRecette.CurrentRow.Cells[3].Value.ToString();
                
                cc.AfficherDetailsBon2(this);
                if (poste == "reception")
                {
                    btnSupprimer.Enabled = true;
                    btnAfficherTout.Enabled = true;
                }
                else
                {
                    btnValiderBon.Enabled = true;
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            dgvRecette.Rows.Clear();
            dgvPayement.Rows.Clear();
        }

        private void btnAfficherTout_Click(object sender, EventArgs e)
        {
            cc.AfficherDetailsBon(this);
            btnAfficherTout.Enabled = false;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Rassurez-vous de renseigner la cause de cette suppression", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //txtMotif.Enabled = true;
            //btnValide.Enabled = true;
            //txtMotif.Focus();
            //btnSupprimer.Enabled = false;
            //supprimer_bon = true;
            //supprimer_ligne = false;
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
        }
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.AfficherRecette(this, "recherche");
        }

        private void btnTouteRecette_Click(object sender, EventArgs e)
        {
            cc.AfficherRecette(this, "tout");
        }
    }
}
