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
    public partial class FormAdminRapportCas : Form
    {
        public FormAdminRapportCas()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMotif_SelectedIndexChanged(object sender, EventArgs e)
        {
            cs.AbonneTypePatient(this);
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cs.AfficherCas(this);
        }

        private void FormAdminRapport_Shown(object sender, EventArgs e)
        {
            cs.ChargerRubriques(this);
        }
    }
}
