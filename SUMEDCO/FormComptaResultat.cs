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
    public partial class FormComptaResultat : Form
    {
        public FormComptaResultat()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public double sommeRef = 0, sommeSoldeAnte = 0;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormComptaResultat_Shown(object sender, EventArgs e)
        {
            cc.RubriquesResultat(this);
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.CalculerResultat(this);
            btnImprimer.Enabled = true;
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cc.ImprimerResultat(this, new FormImpression());
        }
    }
}
