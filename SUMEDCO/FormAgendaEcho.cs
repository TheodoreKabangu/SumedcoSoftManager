using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.IO.Pipes;

namespace SUMEDCO
{
    public partial class FormAgendaEcho : Form
    {
        public FormAgendaEcho()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public int idutilisateur = 0;

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.AfficherAgendaEcho(this);
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvPatient.RowCount != 0)
            {
                cm.AfficherServiceAgenda(this);
                btnAppeler.Enabled = true;
            }
        }
        int progress = 0;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            progress += 1;
            if (progress == 60)
            {
                cm.AfficherAgendaEcho(this);
                progress = 0;
            }
        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvService.RowCount != 0)
                btnServir.Enabled = true;
        }

        private void btnServir_Click(object sender, EventArgs e)
        {
            cm.ServirCasEcho(this);
        }
        SpeechSynthesizer ss = new SpeechSynthesizer();
        public void Prononcer(string texte)
        {
            ss.Rate = 0;
            ss.Volume = 100;
            ss.SpeakAsync(texte);
        }
        private void btnAppeler_Click(object sender, EventArgs e)
        {
            btnAppeler.Enabled = false;
            Prononcer("Numéro "+dgvPatient.CurrentRow.Cells[1].Value.ToString());
        }

        
        private void FormAgendaEcho_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
