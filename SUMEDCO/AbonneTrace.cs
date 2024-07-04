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
    public partial class AbonneTrace : Form
    {
        ClasseGeneraleDGV dgv = new ClasseGeneraleDGV();
        AbonneTraceClasse atc = new AbonneTraceClasse();
        public AbonneTrace()
        {
            InitializeComponent();
            dgv.FigerColonne(dgvRapport);
            dgv.AjouterCategorieRecette(dgvRapport);
        }

        public int idpatient = 0,
        identreprise,
        idexercice;
        public string poste = "";
        public bool infirmier_autorise;
        private void AbonneTrace_Shown(object sender, EventArgs e)
        {
            //atc.AjouterRubriques(this);
        }
    }
}
