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
    public partial class Recette : Form
    {
        public Recette()
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
        ClassStock cs = new ClassStock();
        RecetteClasse rc = new RecetteClasse();
        public string caisse="", 
            payeur, 
            poste = "",
            numcompte = "";
        public int idutilisateur,
            tauxjour = 0,
            idpayement= 0,
            idrecette = 0, 
            idexercice = 0,
            idoperation = 0,
            id = 0;
        public double taux = 0;

        private void FormBon_Shown(object sender, EventArgs e)
        {
            rc.AfficherRecette(this, "");
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                taux = cc.ChangerDate(new DateTaux(), this, lblDateJour, lblTaux);
                if(taux > 0)
                    rc.SoldeCaisse(lblCaisseCDF, lblCaisseUSD, taux);
            }
            else
            {
                lblDateJour.Text = DateTime.Now.ToShortDateString();
                taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
                lblTaux.Text = taux + " CDF";
                rc.SoldeCaisse(lblCaisseCDF, lblCaisseUSD, taux);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDate_Click(object sender, EventArgs e)
        {
            taux = cc.ChangerDate(new DateTaux(), this, lblDateJour, lblTaux);
        }
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            rc.AfficherRecette(this, "recherche");
        }
        private void btnValider_Click(object sender, EventArgs e)
        {
            rc.ValiderPayement(this);
        }
        int progress = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            progress += 1;
            if (progress == 60)
            {
                rc.AfficherRecette(this, "");
                progress = 0;
            }
        }
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
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
                rc.TrouverRecettePatient(this);
            }
        }
        ReceptionFactureClasse rfc = new ReceptionFactureClasse();
        private void dgvRecette_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecette.RowCount != 0 && dgvRecette.CurrentRow.Index < dgvRecette.RowCount-1)
            {
                if (dgvRecette.CurrentRow.Cells[5].Value.ToString() == "")
                {
                    btnRetirer.Enabled = true;
                }
                else
                {
                    btnValider.Enabled = false;
                    btnRetirer.Enabled = false;
                }
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            rc.SupprimerRecette(dgvRecette);
        }
    }
}
