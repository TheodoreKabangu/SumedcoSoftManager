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
    public partial class FormAbon : Form
    {
        public FormAbon()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public int idabonne = 0,
            identreprise = 0;
        public string nomabonne = "";
        public bool fermeture_succes;
        private void cboEntreprise_SelectedIndexChanged(object sender, EventArgs e)
        {
            identreprise = cc.TrouverId("entreprise", cboEntreprise.Text);
            cc.Afficher2(this);
            if(dgvAbonne.RowCount != 0)
            {
                for (int i = 0; i < dgvAbonne.RowCount; i++)
                {
                    dgvAbonne.Rows[i].Cells[2].Value = cm.TrouverNom("patient", int.Parse(dgvAbonne.Rows[i].Cells[1].Value.ToString()));
                }
            }
        }

        private void dgvAbonne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvAbonne.RowCount !=0) btnValider.Enabled = true;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
			idabonne = int.Parse(dgvAbonne.CurrentRow.Cells[0].Value.ToString());
            nomabonne = dgvAbonne.CurrentRow.Cells[1].Value.ToString();
            fermeture_succes = true;
            this.Hide();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }

        private void cboEntreprise_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("entreprise", cboEntreprise, 0);
        }
    }
}
