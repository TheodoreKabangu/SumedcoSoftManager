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
    public partial class FormPriseSigneVital : Form
    {
        public FormPriseSigneVital()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public int idlignedoublon = 0,
            idpatient = 0,
            idmedecin = 0,
            idprise = 0,
            idrecette = 0,
            nbligne_trouve=0;
        public bool fermeture_succes, reaffecter;
        public string numcompte = "";
        private void cboCatService_DropDown(object sender, EventArgs e)
        {
            
        }

        private void cboCatService_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboService_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm.ValiderLigne(this);
        }


        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cm.AjouterPrise(this);           
        }
        private void FormExamen_Shown(object sender, EventArgs e)
        {
            if(!reaffecter) cm.ChargerSignesVitaux(this);
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }
        private void cboMedecin_SelectedIndexChanged(object sender, EventArgs e)
        {
            idmedecin = cm.TrouverId("medecin", cboMedecin.Text);
        }

        private void cboMedecin_DropDown(object sender, EventArgs e)
        {
            cm.ChargerCombo(cboMedecin, "médecin");
        }

        private void dgvSigne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSigne.RowCount != 0)
            {
                if (dgvSigne.CurrentRow.Cells[2].Selected && dgvSigne.CurrentRow.Index > 0)
                {
                    for (int i = 0; i < dgvSigne.CurrentRow.Index; i++)
                    {
                        if (dgvSigne.Rows[i].Cells[2].Value.ToString() == "")
                        {
                            MessageBox.Show("Au moins une valeur manquante dans les lignes précédentes", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dgvSigne.Rows[0].Cells[2].Selected = true;
                            i += dgvSigne.RowCount;
                        }
                    }
                }
            }
        }
    }

}
