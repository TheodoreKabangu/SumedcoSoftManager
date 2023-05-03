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
    public partial class FormComptaBalance : Form
    {
        public FormComptaBalance()
        {
            InitializeComponent();
            for (int i = 0; i < dgvBalance.ColumnCount; i++)
            {
                dgvBalance.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        public int idexercice=0, taux = 0;
        private void FormComptaBalance_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
                taux = cc.ChangerDate(this, new DateTaux());
            else
                taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cc.ImprimerBalance(this, new FormImpression());
        }
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            if (dtpDateDe.Value.Year == dtpDateA.Value.Year && dtpDateDe.Value.Date <= dtpDateA.Value.Date)
            {
                cc.CalculerBalance(this);
                btnImprimer.Enabled = true;
            }
            else
                MessageBox.Show("La première date doit être inférieure ou égale à la deuxième et l'année doit être la même", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
