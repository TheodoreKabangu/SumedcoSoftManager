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
    public partial class AbonneTrace : Form
    {
        ClasseElements ce = new ClasseElements();
        AbonneTraceClasse atc = new AbonneTraceClasse();
        public AbonneTrace()
        {
            InitializeComponent();
            ce.FigerColonne(dgvRapport);
            ce.AjouterCategorieRecette(dgvRapport);
        }

        public int idpatient = 0,
        identreprise,
        idexercice;
        public string poste = "";
        public bool infirmier_autorise;
              
        private void AbonneTrace_Shown(object sender, EventArgs e)
        {
            atc.ConsommationTrace(dgvRapport);
            dgvRapport.Rows.Add(10);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();

            dataGridView1 = dgvRapport;
            dataGridView1.SelectAll();
            DataObject copydata = dgvRapport.GetClipboardContent();
            if (copydata != null) Clipboard.SetDataObject(copydata);
            atc.ExporterVersExcel(@"C:\Users\Public\Documents\AbonneTraces__.xlsx");
            //MessageBox.Show(dataGridView1.Rows[0].Cells[6].Value.ToString());
        }
    }
}
