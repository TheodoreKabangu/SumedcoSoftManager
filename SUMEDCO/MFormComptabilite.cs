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
    public partial class MFormComptabilite : Form
    {
        public MFormComptabilite()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();
        public Form activeForm = null;
        public int idutilisateur;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();          
        }
        private void btnCompte_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormBonRecetteJournal());
        }

        private void btnEcriture_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptabilite());
        }

        private void btnAppro_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormApproCommande());
        }
        public bool afficher_journal;
        private void btnVisualisation_Click(object sender, EventArgs e)
        {
            afficher_journal = true;
            cc.AfficherSousForm(this, new FormComptaOperation());
        }

        private void btnRapportDepense_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormDepenseRapport());
        }

        private void btnBilan__Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptaBilan());
        }

        private void btnBalance__Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptaBalance());
        }

        private void btnTabFluxT_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptaTableauFlux());
        }
        private void btnResultat_Click(object sender, EventArgs e)
        {
			cc.AfficherSousForm(this, new FormComptaResultat());
        }

        private void btnGrandLivre_Click(object sender, EventArgs e)
        {
            afficher_journal = false;
            cc.AfficherSousForm(this, new FormComptaOperation());
        }
    }
}
