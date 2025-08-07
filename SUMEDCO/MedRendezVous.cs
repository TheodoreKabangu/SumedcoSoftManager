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
    public partial class MedRendezVous : Form
    {
        public MedRendezVous()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public int idrdv, idconsultation = 0;
        public bool fermeture_succes;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cm.Enregistrer(this);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cm.Modifier(this);
        }
        private void dgvRdv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvRdv.RowCount != 0)
            {
                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
                idrdv = int.Parse(dgvRdv.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cm.Supprimer(this);
        }

        private void FormConsulterRendezVous_Shown(object sender, EventArgs e)
        {
            //cm.Afficher(this);
        }
    }
}
