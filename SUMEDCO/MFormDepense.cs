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
    public partial class MFormDepense : Form
    {
        ClassCompta cc = new ClassCompta();
        public Form activeForm = null;
        public int idutilisateur;
        public MFormDepense()
        {
            InitializeComponent();
        }

        private void btnDepense_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormDepense());
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormDepenseRapport());
        }
    }
}
