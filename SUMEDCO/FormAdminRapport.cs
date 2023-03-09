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
    public partial class FormAdminRapport : Form
    {
        public FormAdminRapport()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();
        private void FormAdminRapport_Shown(object sender, EventArgs e)
        {
            cs.ChargerRubriques(this);
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
            }
            else
            {
                lblDateOperation.Text = DateTime.Now.ToShortDateString();
                lblTaux.Text = cc.VerifierTaux(DateTime.Now.Date, "valeur").ToString() + " CDF";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMotif_SelectedIndexChanged(object sender, EventArgs e)
        {
            cs.AbonneTypePatient(this, cboMotif.Text);
        }
    }
}
