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
    public partial class MFormInfirmerie : Form
    {
        public MFormInfirmerie()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        public string statut = "";
        public int idutilisateur;
        public Form activeForm = null;
        private void btnConsultation_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormAgenda());
        }

        private void FormInfirmerie_Load(object sender, EventArgs e)
        {

        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
