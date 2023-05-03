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
    public partial class FormTresoRapport : Form
    {
        public FormTresoRapport()
        {
            InitializeComponent();
            for (int i = 0; i < dgvBon.ColumnCount; i++)
            {
                dgvBon.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        public double taux = 0, somme = 0;

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.AfficherTresoJournal(this);
        }

        private void FormDepenseJournal_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                taux = cc.ChangerDate(this, new DateTaux());
            }
            else
                taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
        }
    }
}
