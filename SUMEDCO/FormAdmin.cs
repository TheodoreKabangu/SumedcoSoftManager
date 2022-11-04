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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        public Form activeForm = null;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUtilisateur_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormUtilisateur());
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormService());
        }

        private void btnMedecin_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormMedecin());
        }

        private void btnSigneVital_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormSigneVital());
        }
    }
}
