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
    public partial class MedMaladieDiagno : Form
    {
        public MedMaladieDiagno()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public int id=0,
            idconsultation = 0,
            idmedecin = 0,
            idmaladie = 0,
            nbligne_trouve = 0;
        public bool ajoutvalide, fermeture_succes;
        private void btnNouveau_Click(object sender, EventArgs e)
        {
            new MedMaladie().ShowDialog();
        }

        private void cboMaladie_SelectedIndexChanged(object sender, EventArgs e)
        {
            idmaladie = cm.TrouverId("maladie", cboMaladie.Text);
            txtLibelle.Select();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            cm.ValiderLigne(this);
        }

        private void txtLibelle_Enter(object sender, EventArgs e)
        {
            if(!btnModifier.Enabled && cboMaladie.Text =="")
            {
                MessageBox.Show("Aucune maladie n'a été séléctionnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaladie.Select();
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            dgv1.Rows.RemoveAt(dgv1.CurrentRow.Index);
            cm.RemplirNumLigne(dgv1, 0);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cm.Enregistrer(this);
        }

        private void cboMaladie_DropDown(object sender, EventArgs e)
        {
            cm.ChargerCombo(cboMaladie, "maladie");
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv1.RowCount>0)
            {
                if (nbligne_trouve == 0) btnRetirer.Enabled = true;
                else
                {
                    btnModifier.Enabled = true;
                    btnSupprimer.Enabled = true;
                    id = int.Parse(dgv1.CurrentRow.Cells[0].Value.ToString());
                    txtLibelle.Text= dgv1.CurrentRow.Cells[3].Value.ToString();
                }
            }
        }

        private void FormMaladieDiagnostic_Shown(object sender, EventArgs e)
        {
            cm.Afficher(this);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cm.Modifier(this);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cm.Supprimer(this);
        }

    }
}
