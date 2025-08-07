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
    public partial class Admin : Form
    {
        public Admin()
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
            cs.AfficherSousForm(this, new AdminUtilisateur());
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            new Service().ShowDialog();
        }

        private void btnMedecin_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new MedMedecin());
        }

        private void btnSigneVital_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new SigneVital());
        }

        private void btnActiver_Click(object sender, EventArgs e)
        {
            ConnexionAutorisation aut = new ConnexionAutorisation();
            aut.poste = "Admin";
            aut.btnConnexion.Enabled = false;
            aut.btnActiver.Visible = true;
            aut.ShowDialog();
        }
    }
}
