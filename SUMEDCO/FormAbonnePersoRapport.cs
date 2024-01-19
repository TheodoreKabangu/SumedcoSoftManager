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
    public partial class FormAbonnePersoRapport : Form
    {
        public FormAbonnePersoRapport()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        public int identreprise;
        public string numcompte = "";

        //public DataGridView dgv = new DataGridView();
        public ComboBox cbonumcompte = new ComboBox();

        private void cboEntreprise_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dgvRapport.RowCount != 0)
            {
                dgvRapport.Rows.Clear();
                for (int i = dgvRapport.ColumnCount-1; i >=6 ; i--)
                {
                    dgvRapport.Columns.RemoveAt(i);
                }
            }
            identreprise = cc.TrouverId("entreprise", cboEntreprise.Text); 
            cc.AfficherAbonnePerso(this);
            if (dgvRapport.RowCount != 0) 
                btnImprimer.Enabled = true;
        }

        private void cboEntreprise_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("entreprise", cboEntreprise, 0);
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
            cc.VerouillerColonne(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cc.ImprimerRapport(this);
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (dgvRapport.RowCount != 0)
                {
                    dgvRapport.Rows.Clear();
                    for (int i = dgvRapport.ColumnCount - 1; i >= 6; i--)
                    {
                        dgvRapport.Columns.RemoveAt(i);
                    }
                }
                cc.AfficherAbonnePerso(this);
                if (dgvRapport.RowCount != 0)
                    btnImprimer.Enabled = true;
            }
            else
            {
                if (dgvRapport.RowCount != 0)
                {
                    dgvRapport.Rows.Clear();
                    for (int i = dgvRapport.ColumnCount - 1; i >= 6; i--)
                    {
                        dgvRapport.Columns.RemoveAt(i);
                    }
                }
            }
        }
    }
}
