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
    public partial class ReceptionMDI : Form
    {
        ClassCompta cc = new ClassCompta();
        ReceptionFactureClasse rfc = new ReceptionFactureClasse();
        public string statut = "";
        public int idutilisateur;
        public bool infirmier_autorise;
        public ReceptionMDI()
        {
            InitializeComponent();
        }
        public Form activeForm = null;
        private void btnConsultation_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormPatientRecherche());
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFactureService_Click(object sender, EventArgs e)
        {
            rfc.FactureService(this, new ReceptionFacturation());
        }
        private void btnRapport_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormReceptionRapport());
        }

        private void btnChat_Click(object sender, EventArgs e)
        {

        }
    }
}
