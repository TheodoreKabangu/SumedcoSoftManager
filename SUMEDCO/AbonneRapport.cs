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
    public partial class AbonneRapport : Form
    {
        ClasseElements ce = new ClasseElements();
        public AbonneRapport()
        {
            InitializeComponent();
            ce.FigerColonne(dgvRapport);
            //ce.AjouterCategorieRecette(dgvRapport);
        }
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        AbonneTraceClasse atc = new AbonneTraceClasse();
        public int identreprise;
        string filename = "";

        //public DataGridView dgv = new DataGridView();
        private void cboEntreprise_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void cboEntreprise_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo(cboEntreprise, "entreprise");
        }
        public int taux;
        private void FormAbonnePersoRapport_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                taux = cc.ChangerDate(this, new DateTaux());
            }
            else
                taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
            lblTaux.Text =  taux + " CDF";
            atc.RapportAbonne(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            dgvRapport.SelectAll();
            DataObject copydata = dgvRapport.GetClipboardContent();
            if (copydata != null) Clipboard.SetDataObject(copydata);
            filename = string.Format(@"C:\Users\Public\Documents\RapportAbonne{0}_{1}_{2}_{3}.xlsx", 
                cboEntreprise.Text,
                DateTime.Now.Day,
                DateTime.Now.Month,
                DateTime.Now.Year);
            atc.ExporterVersExcel(filename);
        }

        private void cboEntreprise_SelectionChangeCommitted(object sender, EventArgs e)
        {
            identreprise = Convert.ToInt32(cboEntreprise.GetItemText(cboEntreprise.SelectedValue));
            atc.RapportAbonne(this);
        }
    }
}
