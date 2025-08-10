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
    public partial class TresoFlux : Form
    {
        public TresoFlux()
        {
            InitializeComponent();
        }
        TresorerieClasse tc = new TresorerieClasse();
        public int idutilisateur = 0;
        public double sommeDepense = 0;
        public Form activForm = null;
        public string affectation, poste;
        public double taux;
        private void btnAfficher_Click(object sender, EventArgs e)
        {
            tc.AfficherFlux(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            tc.AnnulerFlux(this, new TresoAnnuler());
        }
        TresoFluxNew f;
        private void btnModifier_Click(object sender, EventArgs e)
        {
            tc.ModifierFlux(this, new TresoFluxNew());
        }

        private void btnEntree_Click(object sender, EventArgs e)
        {
            f = new TresoFluxNew();
            f.operation = "entrée";
            f.affectation = affectation;
            f.dgvEcriture.Columns[1].ReadOnly = true;//figer le beneficiaire
            if (affectation == "FFL") f.Text = "SSM - Flux FFL";
            f.ShowDialog();
            f.Close();
        }

        private void btnSortie_Click(object sender, EventArgs e)
        {
            f = new TresoFluxNew();
            f.operation = "sortie";
            f.affectation = affectation;
            f.chbCatRecette.Enabled = false;
            f.ShowDialog();
            f.Close();
        }
        private void btnExporter_Click(object sender, EventArgs e)
        {
            //Exporter vers Excel

        }
        private void chbSolde_Click(object sender, EventArgs e)
        {
            if(chbSolde.Checked) 
                tc.SoldeTreso(this);
            else
            {
                lblCDF.Text = "00,00";
                lblUSD.Text = "00,00";
            }
        }

        private void btnPrepEcriture_Click(object sender, EventArgs e)
        {
            tc.ComptabiliserFlux(this, new ComptaEcriture());
        }
        ClassCompta cc = new ClassCompta();
        private void TresoFlux_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                taux = cc.ChangerDate(new DateTaux(), this, new Label(), new Label());
            }
            else
            {
                taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
            }
        }

        private void btnEffectifs_Click(object sender, EventArgs e)
        {
            tc.AfficherFluxEffectif(this);
        }
    }
}
