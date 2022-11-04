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
    public partial class MFormInfirmerie : Form
    {
        public MFormInfirmerie()
        {
            InitializeComponent();
            cc.ActualiserDesign(pnlSousMenu);
        }
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        public string statut = "";
        
        public Form activeForm = null;
        private void btnConsultation_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormAgenda());
        }

        private void FormInfirmerie_Load(object sender, EventArgs e)
        {

        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnPatient_Click(object sender, EventArgs e)
        {
            statut = "nouveau";
            cm.AfficherSousForm(this, new FormPatient());
        }

        private void btnIntervention_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormTraitement());
        }

        private void btnPatientAncien_Click(object sender, EventArgs e)
        {
            statut = "ancien";
            cm.AfficherSousForm(this, new FormPatient());
        }

        private void btnEncaisser_Click(object sender, EventArgs e)
        {
            cc.AfficherSousMenu(pnlSousMenu);
        }

        private void btnBonEncaisser_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormBonRecette());
        }

        private void btnFactureService_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormFactureService());
        }

        private void btnFactureProduit_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormFactureProduit());
        }
    }
}
