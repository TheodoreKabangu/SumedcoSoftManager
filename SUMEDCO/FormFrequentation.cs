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
    public partial class FormFrequentation : Form
    {
        public FormFrequentation()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormFrequentation_Shown(object sender, EventArgs e)
        {
            dgvConsultation.Columns.Add("column1", "Dr Michel");
            dgvConsultation.Columns.Add("column2", "Dr Alain");
            dgvConsultation.Columns.Add("column3", "Dr Touska");
            dgvConsultation.Rows.Add(3);
            dgvConsultation.Rows[0].Cells[0].Value = "Anciens cas";
            dgvConsultation.Rows[1].Cells[0].Value = "Nouveaux cas";
            dgvConsultation.Rows[2].Cells[0].Value = "Cas urgence";
            for (int i = 0; i < 3; i++)
            {
                dgvConsultation.Rows[i].Cells[1].Value = 5 + i;
                dgvConsultation.Rows[i].Cells[2].Value = 5/2 + i;
                dgvConsultation.Rows[i].Cells[3].Value = 5/2+1 + i;
            }
            string[] categorie = { "Adultes", "Hommes", "Femmes", "Femmes enceintes", "Enfants", "Enfants de 0 à 5 mois" };
            int somme = 0;
            dgvCas.Rows.Add(categorie.Length);
            for (int i = 0; i < dgvCas.RowCount; i++)
            {
                dgvCas.Rows[i].Cells[0].Value = categorie[i];
                dgvCas.Rows[i].Cells[1].Value = ((10 + i) * 5)/2;
                somme += ((10 + i) * 5) / 2;
            }
            for (int i = 0; i < dgvCas.RowCount; i++)
            {
                dgvCas.Rows[i].Cells[2].Value = (int.Parse(dgvCas.Rows[i].Cells[1].Value.ToString())*100.0/somme).ToString("0.00");
            }
        }
    }
}
