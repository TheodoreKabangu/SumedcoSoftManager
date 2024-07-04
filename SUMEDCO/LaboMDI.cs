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
    public partial class LaboMDI : Form
    {
        public LaboMDI()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public int idutilisateur;

        private void btnPatient_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormAgendaLabo());
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormAgendaLaboResult());
        }
        
    }
}
