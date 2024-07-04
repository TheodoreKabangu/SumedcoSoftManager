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
    public partial class FormComptaTableauFlux : Form
    {
        public FormComptaTableauFlux()
        {
            InitializeComponent();
            for (int i = 0; i < dgvTFT.ColumnCount; i++)
			{
                dgvTFT.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
        }
        ClassCompta cc = new ClassCompta();
        public double som_Treso_Actif = 0, som_Treso_Passif = 0;
        public int idexercice = 0;
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cc.ImprimerTFT(this, new FormImpression());
        }

        private void FormComptaTableauFlux_Shown(object sender, EventArgs e)
        {
            cc.RubriquesTFT(this);
            
        }

        private void btnCalculer_Click(object sender, EventArgs e)
        {
            if (dtpDateDe.Value.Year == dtpDateA.Value.Year && dtpDateDe.Value.Date <= dtpDateA.Value.Date)
            {
                cc.CalculerTFT(this);
                btnImprimer.Enabled = true;
            }
            else
                MessageBox.Show("La première date doit être inférieure ou égale à la deuxième et l'année doit être la même", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
