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
    public partial class RecetteRapport : Form
    {
        public RecetteRapport()
        {
            InitializeComponent();
            ce.FigerColonne(dgvRecette);
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ClassCompta cc = new ClassCompta();
        private void cboAnnee_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("exercice", cboAnnee, 0);
        }
        ClasseElements ce = new ClasseElements();
        RecetteClasse rc = new RecetteClasse();
        private void cboAnnee_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ce.AjouterDateEnColonne(Convert.ToInt16(cboMois.Text), Convert.ToInt16(cboAnnee.Text), dgvRecette, 2);
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            rc.MontantRecette(this);
        }

        private void RecetteRapport_Shown(object sender, EventArgs e)
        {
            rc.RapportCaisse(this);
        }
    }
}
