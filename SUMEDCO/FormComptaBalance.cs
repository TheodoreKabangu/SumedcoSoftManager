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
    public partial class FormComptaBalance : Form
    {
        public FormComptaBalance()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public int taux = 0;
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.CalculerBalance(this);
            btnImprimer.Enabled = true;
        }

        private void FormComptaBalance_Shown(object sender, EventArgs e)
        {
            taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
            if (taux != 0)
            {
                cc.RubriquesBalances(this);
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cc.ImprimerBalance(this, new FormImpression());
        }

        private void cboBalance_SelectedIndexChanged(object sender, EventArgs e)
        {
            cc.ComptesBalance(this);
        }
    }
}
