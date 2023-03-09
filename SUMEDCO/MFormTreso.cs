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
    public partial class MFormTreso : Form
    {
        ClassCompta cc = new ClassCompta();
        public Form activeForm = null;
        public int idutilisateur;
        public MFormTreso()
        {
            InitializeComponent();
        }

        private void btnDepense_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormTresoSortie());
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormDepenseRapport());
        }

        private void btnPayement_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormTresoEntree());
        }
    }
}
