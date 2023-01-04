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
    public partial class MFormReception : Form
    {
        ClassCompta cc = new ClassCompta();
        public string statut = "";
        public int idutilisateur;

        public MFormReception()
        {
            InitializeComponent();
        }
        public Form activeForm = null;
        private void btnConsultation_Click(object sender, EventArgs e)
        {
            statut = "nouveau";
            cc.AfficherSousForm(this, new FormPatient());
        }
        private void btnBonCaisse_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormBonRecette());
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFactureService_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormFactureService());
        }

        private void btnFactureProduit_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormFactureProduit());
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            /*
             * Ici on aura:
             * un form pour présenter tous les malades qui sont entrés à une date ou pour une période donnée
             * un form pour les factures des services, le montant global (pour immédiat, pour différé et le tout)
             * un form pour les factures des produits, le montant global (pour immédiat, pour différé et le tout)
             * 
             */
        }

        private void btnAncien_Click(object sender, EventArgs e)
        {
            statut = "ancien";
            cc.AfficherSousForm(this, new FormPatient());
        }
    }
}
