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
    public partial class FormAdminRapportCasMedecin : Form
    {
        public FormAdminRapportCasMedecin()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAdminRapportCasMedecin_Load(object sender, EventArgs e)
        {

            //
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cs.AfficherResume(this);
        }
    }
}
