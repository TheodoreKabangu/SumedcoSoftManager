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
    public partial class FormConsulterPrise : Form
    {
        public FormConsulterPrise()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();

        public int idmedecin;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormConsulterPrise_Shown(object sender, EventArgs e)
        {
            cm.ChargerPriseSigneVitaux(this, "");
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.ChargerPriseSigneVitaux(this, "recherche");
        }

        private void btnConsulter_Click(object sender, EventArgs e)
        {
            cm.Consultation(this, new FormConsulter());
        }

        private void dgvPrise_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPrise.RowCount != 0)
                btnConsulter.Enabled = true;
        }
        int progress = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            progress += 1;
            if (progress == 60)
            {
                cm.ChargerPriseSigneVitaux(this, "");
                progress = 0;
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                timer1.Start();
                progress = 0;
            }
            else
            {
                timer1.Stop();
            }
        }
    }
}
