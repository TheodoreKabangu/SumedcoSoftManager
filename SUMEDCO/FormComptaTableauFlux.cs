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
    public partial class FormComptaTableauFlux : Form
    {
        public FormComptaTableauFlux()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public double sommeRef = 0, sommeSoldeAnte = 0;
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.RubriquesResultat(this);
            cc.CalculerResultat(this);
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
           
        }

        private void FormComptaTableauFlux_Shown(object sender, EventArgs e)
        {
            cc.RubriquesTFT(this);
        }
    }
}
