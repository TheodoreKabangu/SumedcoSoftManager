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
    public partial class MFormRecette : Form
    {
        ClassCompta cc = new ClassCompta();
        public Form activeForm = null;

        public MFormRecette()
        {
            InitializeComponent();
            cc.ActualiserDesign(pnlSousMenu);
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRecette_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormBonRecette());
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            cc.AfficherSousMenu(pnlSousMenu);
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            //cc.AfficherSousForm(this, new FormAgendaCaisse());
            cc.CacherSousMenu(pnlSousMenu);
        }

        private void btnBonService_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormBonRecetteJournal());
            cc.CacherSousMenu(pnlSousMenu);
        }
    }
}
