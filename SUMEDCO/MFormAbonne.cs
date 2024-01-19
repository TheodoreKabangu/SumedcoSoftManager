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
    public partial class MFormAbonne : Form
    {
        public MFormAbonne()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public Form activeForm = null;
        public string statut = "";
        public int idutilisateur;
        public bool infirmier_autorise;
        private void btnAbonne_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormPatientRecherche());
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormAbonnePersoRapport());
        }
    }
}
