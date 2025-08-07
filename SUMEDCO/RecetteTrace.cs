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
    public partial class RecetteTrace : Form
    {
        
        public int idpatient = 0,
            idutilisateur,
            identreprise,
            idexercice;
        public string poste = "";
        public bool infirmier_autorise;
        public RecetteTrace()
        {
            InitializeComponent();
            
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {

        }

        private void RecetteTrace_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
