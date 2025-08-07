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
    public partial class ComptaOperation : Form
    {
        public ComptaOperation()
        {
            InitializeComponent();
            for (int i = 0; i < dgvOperation.ColumnCount; i++)
            {
               dgvOperation.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        public string type_comptabilite = "";
        public int idexercice = 0,
            idtypejournal = 0;
        public double sommeDebit = 0, sommeCredit = 0;
        private void cboTypeJournal_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("typejournal", cboTypeJournal, 0);
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.Afficher(this);
        }

        private void cboTypeJournal_SelectedIndexChanged(object sender, EventArgs e)
        {
            idtypejournal = cc.TrouverId("typejournal", cboTypeJournal.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ComptaEcriture c;
        private void btnOperation_Click(object sender, EventArgs e)
        {
            c = new ComptaEcriture();
            c.type_comptabilite = type_comptabilite;
            c.idexercice = idexercice;
            c.ShowDialog();
            c.Close();
        }

        private void ComptaOperation_Shown(object sender, EventArgs e)
        {
            btnRecherche_Click(null, null);
        }
    }
}
