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
    public partial class FormConsulterPresc : Form
    {
        public FormConsulterPresc()
        {
            InitializeComponent();
        }
        public int idconsultation;
        public string categorie;
        ClassMalade cm = new ClassMalade();
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cm.ModifierPrescription(this);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cm.SupprimerPrescription(this);
        }

        private void dgvPresc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPresc.RowCount != 0)
            {
                btnEnregistrer.Enabled = true;
                btnSupprimer.Enabled = true;
            }
        }
        FormAgendaLaboResult agr; 
        private void btnLabo_Click(object sender, EventArgs e)
        {
            agr = new FormAgendaLaboResult();
            agr.poste = "labo";
            agr.btnModifier.Enabled = false;
            agr.Show();
            if (agr.fermeture_succes)
            {
                dgvPresc.CurrentRow.Cells[2].Value = agr.dgvResult.CurrentRow.Cells[4].Value;
                dgvPresc.CurrentRow.Cells[3].Value = agr.dgvResult.CurrentRow.Cells[1].Value;
            }
            agr.Close();
        }

        private void btnEcho_Click(object sender, EventArgs e)
        {
            agr = new FormAgendaLaboResult();
            agr.poste = "echo";
            agr.btnModifier.Enabled = false;
            agr.Show();
            if(agr.fermeture_succes)
            {
                dgvPresc.CurrentRow.Cells[2].Value = agr.dgvResult.CurrentRow.Cells[4].Value;
                dgvPresc.CurrentRow.Cells[3].Value = agr.dgvResult.CurrentRow.Cells[1].Value;
            }
            agr.Close();
        }
    }
}
