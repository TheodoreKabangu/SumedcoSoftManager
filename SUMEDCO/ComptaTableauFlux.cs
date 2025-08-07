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
    public partial class ComptaTableauFlux : Form
    {
        public ComptaTableauFlux()
        {
            InitializeComponent();
            ce.FigerColonne(dgvTFT);
        }
        ClassCompta cc = new ClassCompta();
        ClasseElements ce = new ClasseElements();
        public string type_comptabilite = "";
        public double som_Treso_Actif = 0, som_Treso_Passif = 0;
        public int idexercice = 0;
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cc.ImprimerTFT(this, new FormImpression());
        }

        private void FormComptaTableauFlux_Shown(object sender, EventArgs e)
        {
            cc.RubriquesTFT(this);
        }

        private void btnCalculer_Click(object sender, EventArgs e)
        {
            //if (dtpDateDe.Value.Year == dtpDateA.Value.Year && dtpDateDe.Value.Date <= dtpDateA.Value.Date)
            //{
            //    cc.CalculerTFT(this);
            //    btnImprimer.Enabled = true;
            //}
            //else
            //    MessageBox.Show("La première date doit être inférieure ou égale à la deuxième et l'année doit être la même", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
