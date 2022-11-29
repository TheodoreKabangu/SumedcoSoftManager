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
    public partial class FormAdminStatService : Form
    {
        public FormAdminStatService()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public int nbjours,
            nbcolonne,
            sommeligne;
        public string colonne;
        private void FormRapportTrim_Shown(object sender, EventArgs e)
        {
            cc.RubriqueStatService(this);
            //colonne = "01/2022";
            //nbjours = DateTime.DaysInMonth(int.Parse(colonne.Substring(3)), int.Parse(colonne.Substring(0, 2)));
            //MessageBox.Show("" + nbjours);
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.AjouterColonneMois(this);
            if (dgvRapport.ColumnCount > 3)
            {
                cc.AfficherCasConsultation(this);
                cc.AfficherCas(this);
            }
        }

        private void dgvRapport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRapport.CurrentRow.DefaultCellStyle.ForeColor == Color.MediumBlue)
                dgvRapport.CurrentRow.DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
        }
    }
}
