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
    public partial class FormComptaBilan : Form
    {
        public FormComptaBilan()
        {
            InitializeComponent();
            for (int i = 0; i < dgvActif.ColumnCount; i++)
            {
                dgvActif.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < dgvPassif.ColumnCount; i++)
            {
                dgvPassif.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        public int idexercice= 0, taux = 0;
        public double sommeRef = 0, sommeSoldeAnte = 0;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            if (dtpDateDe.Value.Year == dtpDateA.Value.Year && dtpDateDe.Value.Date <= dtpDateA.Value.Date)
            {
                if (dgvActif.RowCount != 0)
                {                  
                    cc.Rubriques(this);
                    cc.AfficherBilan(this);
                }
                else
                    MessageBox.Show("Aucune ligne trouvée! Rassurez-vous que le taux du jour est enregistré", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("La première date doit être inférieure ou égale à la deuxième et l'année doit être la même", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void FormComptaBilan_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
                taux = cc.ChangerDate(this, new DateTaux());
            else
                taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
            if(taux !=0)
            {
                cc.Rubriques(this);
            }
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cc.ImprimerBilan(this);
        }

        private void cboBilan_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnImprimer.Enabled = true;
        }
        
    }
}
