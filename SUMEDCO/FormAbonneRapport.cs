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
    public partial class FormAbonneRapport : Form
    {
        public FormAbonneRapport()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public int identreprise = 0;
        private void FormAbonneRapport_Shown(object sender, EventArgs e)
        {
            dgvAbonneService.Rows.Add(50);
            dgvAbonneProduit.Rows.Add(50);
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboEntreprise_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("entreprise", cboEntreprise, 0);
        }

        private void cboEntreprise_SelectedIndexChanged(object sender, EventArgs e)
        {
            identreprise = cc.TrouverId("entreprise", cboEntreprise.Text);
            dtpDe.Select();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.RapportAbonne(this);
        }

        private void txtTaux_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtTaux);
        }
    }
}
