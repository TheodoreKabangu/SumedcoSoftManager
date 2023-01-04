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
    public partial class FormAgenda : Form
    {
        public FormAgenda()
        {
            InitializeComponent();
        }
        public string utilisateur = "";
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        public int idligne = 0, idmedecin = 0, idpatient = 0;
        private void FormAgenda_Shown(object sender, EventArgs e)
        {
            cm.ChargerAgenda(this);
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            cm.AffecterCas(this, new FormPriseSigneVital());
        }
        private void btnInvalider_Click(object sender, EventArgs e)
        {
            cm.InvaliderStatutCaisse(this);
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAgenda.RowCount != 0)
            {
                idligne = int.Parse(dgvAgenda.CurrentRow.Cells[0].Value.ToString());
                btnAffecter.Enabled = true;
                btnInvalider.Enabled = true;
            }
        }

    }
}
