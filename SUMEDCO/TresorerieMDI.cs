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
    public partial class TresorerieMDI : Form
    {
        TresorerieClasse tc = new TresorerieClasse();
        public Form activeForm = null;
        public int idutilisateur;
        public TresorerieMDI()
        {
            InitializeComponent();
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public string affectation;
        private void btnRapport_Click(object sender, EventArgs e)
        {
            //tc.AfficherSousForm(this, new TresoRapport());
            ///
            /// Build the report form sop that it shows a summary of input,
            /// output, cancelled operations, and balance in USD and CDF 
            /// over a selected period
            ///
        }
        private void btnFlux_Click(object sender, EventArgs e)
        {
            affectation = "routine";
            tc.AfficherSousForm(this, new TresoFlux());
        }

        private void btnFluxFFL_Click(object sender, EventArgs e)
        {
            affectation = "FFL";
            tc.AfficherSousForm(this, new TresoFlux());
        }
    }
}
