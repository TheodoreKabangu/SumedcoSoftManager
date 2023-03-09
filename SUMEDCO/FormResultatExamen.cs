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
    public partial class FormResultatExamen : Form
    {
        public FormResultatExamen()
        {
            InitializeComponent();
        }
        public int idconsultation;
        public string categorie;
        ClassMalade cm = new ClassMalade();
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cm.ModifierPrescriptionService(this);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cm.SupprimerPrescriptionService(this);
        }

        private void dgvExamen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvExamen.RowCount != 0)
            {
                btnEnregistrer.Enabled = true;
                btnSupprimer.Enabled = true;
            }
        }
    }
}
