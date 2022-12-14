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
    public partial class MFormConsultation : Form
    {
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        public int idmedecin = 0;
        public MFormConsultation()
        {
            InitializeComponent();
            //cc.ActualiserDesign(pnlSousMenu);
        }

        private void btnConsultation_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormAgenda());
            
            //cm.AfficherSousForm(this, new FormAgenda());
            //cc.CacherSousMenu(pnlSousMenu);

            //cm.AfficherSousForm(this, new FormExamen());
            //cc.CacherSousMenu(pnlSousMenu);

            //cm.AfficherSousForm(this, new FormPrescription());
            //cc.CacherSousMenu(pnlSousMenu);
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnIntervention_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormConsultationDossier());
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormMedecinHistoChat());
        }
    }
}
