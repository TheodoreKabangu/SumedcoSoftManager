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
    public partial class RecetteMDI : Form
    {
        ClassCompta cc = new ClassCompta();
        public Form activeForm = null;
        public int idutilisateur;
        public RecetteMDI()
        {
            InitializeComponent();
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRecette_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormRecette());
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormRecetteJournal());
        }

        private void btnPayement_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormPayements());
        }
        RecetteTraceClasse rtc = new RecetteTraceClasse();
        private void btnTrace_Click(object sender, EventArgs e)
        {
            rtc.AfficherTrace(this, new RecetteTrace());
        }

    }
}
