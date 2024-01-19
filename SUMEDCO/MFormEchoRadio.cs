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
    public partial class MFormEchoRadio : Form
    {
        public MFormEchoRadio()
        {
            InitializeComponent();
        }
        public int idutilisateur = 0;
        ClassMalade cm = new ClassMalade();
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAbonne_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormAgendaEcho());
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormAgendaLaboResult());
        }
    }
}
