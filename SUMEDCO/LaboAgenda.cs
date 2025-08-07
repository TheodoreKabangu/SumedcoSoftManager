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
    public partial class LaboAgenda : Form
    {
        public LaboAgenda()
        {
            InitializeComponent();
            for (int i = 0; i < dgvPatient.ColumnCount; i++)
            {
                dgvPatient.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < dgvRecette.ColumnCount; i++)
            {
                dgvRecette.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        //FormAbon Abon = new FormAbon();
        public bool fermeture_succes, consulte; 
        public int idutilisateur = 0;
        public string numcompte = "";

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.AfficherAgendaLabo(this, "recherche");
        }
        int progress = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            progress += 1;
            if (progress == 60)
            {
                cm.AfficherAgendaLabo(this, "");
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

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPatient.RowCount != 0)
            {
                cm.TrouverRecettePatient(dgvRecette, Convert.ToInt32(dgvPatient.CurrentRow.Cells[0].Value), dtpDateDe, dtpDateA, "labo");
                btnAppeler.Enabled = true;
            }
        }

        private void FormAgendaLabo_Shown(object sender, EventArgs e)
        {
            cm.AfficherAgendaLabo(this, "");
        }

        private void dgvRecette_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecette.RowCount != 0)
            {
                btnServir.Enabled = true;
                btnAnnuler.Enabled = true;
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cm.AnnulerCasLabo(this);
        }

        private void btnServir_Click(object sender, EventArgs e)
        {
            cm.ServirCasLabo(this, new LaboResultNew());
        }
        SpeechSynthesizer ss = new SpeechSynthesizer();
        private void Prononcer(string texte)
        {
            ss.Rate = 0;
            ss.Volume = 100;
            ss.SpeakAsync(texte);
        }
        private void btnAppeler_Click(object sender, EventArgs e)
        {
            btnAppeler.Enabled = false;
            Prononcer("Numéro " + dgvPatient.CurrentRow.Cells[0].Value.ToString());
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
