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
    public partial class InfPatientList : Form
    {
        public InfPatientList()
        {
            InitializeComponent();
            for (int i = 0; i < dgvAgenda.ColumnCount; i++)
            {
                dgvAgenda.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public string utilisateur = "";
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        public int idmedecin = 0, idpatient = 0;
        private void FormAgenda_Shown(object sender, EventArgs e)
        {
            cm.ChargerAgenda(this, "");
            txtNom.Focus();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            cm.AffecterCas(this, new InfPriseSigneVital());
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAgenda.RowCount != 0)
            {
                idpatient = Convert.ToInt32(dgvAgenda.CurrentRow.Cells[6].Value);
                btnAffecter.Enabled = true;
                btnReaffecter.Enabled = true;
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
        int progress = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            progress += 1;
            if (progress == 60)
            {
                cm.ChargerAgenda(this, "");
                progress = 0;
            }
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.ChargerAgenda(this, "recherche");
        }

        private void btnReaffecter_Click(object sender, EventArgs e)
        {
            cm.ReaffecterCas(this, new InfPriseSigneVital());
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                cm.ChargerAgenda(this, "recherche");
            }
            else
            {
                cm.ChargerAgenda(this, "recherche");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
