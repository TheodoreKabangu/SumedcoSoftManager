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
    public partial class FormExamen : Form
    {
        public FormExamen()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public int idlignedoublon = 0,
            idpatient = 0,
            idmedecin = 0,
            idcatservice = 0,
            idconsultation = 0,
            nbligne_trouve=0;
        public bool ajoutvalide;
        public string numcompte = "";
        private void cboCatService_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("catservice2", cboCatService, 0);
        }

        private void cboCatService_SelectedIndexChanged(object sender, EventArgs e)
        {
            numcompte = cc.TrouverId("numcompte", cboCatService.Text).ToString();
            cc.ChargerCombo("service", cboService, int.Parse(numcompte));
        }

        private void cboService_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm.ValiderLigne(this);
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            dgv1.Rows.RemoveAt(dgv1.CurrentRow.Index);
            cm.RemplirNumLigne(dgv1, 0);
            //
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            //cm.Enregistrer(this);
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.RowCount != 0)
            {
                if (cboService.Enabled) 
                {
                    btnRetirer.Enabled = true;
                }
                else txtLibelle.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
                txtLibelle.Select();
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            cm.ValiderLigne(this);
        }

        private void FormExamen_Shown(object sender, EventArgs e)
        {
            if (!cboService.Enabled)
            {
                cm.MesConsultations(this, new FormConsultation());
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            cm.ExamenPhysique(this, new FormExamenPhysique());
        }
    }

}
