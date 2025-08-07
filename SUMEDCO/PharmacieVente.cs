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
    public partial class PharmacieVente : Form
    {
        public PharmacieVente()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ReceptionFactureClasse rfc = new ReceptionFactureClasse();
        RecetteClasse rc = new RecetteClasse();
        public int idpharma = 0,
            idpatient=0,
            idrecette = 0,
        idutilisateur = 0;
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            rfc.AfficherRecette(this, "recherche");
        }

        private void FormPhaVente_Shown(object sender, EventArgs e)
        {
            rfc.AfficherRecette(this, "");
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
                rfc.AfficherRecette(this, "");
                progress = 0;
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            rfc.ValiderVente(this);
        }
        private void dgvRecette_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecette.RowCount != 0)
            {
                if (dgvRecette.CurrentRow.Cells[5].Value.ToString() == "")
                    btnValider.Enabled = false;
                else
                    btnValider.Enabled = true;
                if (dgvRecette.CurrentRow.Cells[6].Value.ToString() == "")
                    btnRetirer.Enabled = false;
                else
                    btnRetirer.Enabled = true;
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            rc.SupprimerRecette(dgvRecette);
        }
    }
}
