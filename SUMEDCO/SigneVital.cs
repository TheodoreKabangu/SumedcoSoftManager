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
    public partial class SigneVital : Form
    {
        public SigneVital()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public string motif = "";
        public int idconsultation;
        private void FormSigneVital_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvSigneVitaux_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvSigne.RowCount != 0)
            {
                if (motif == "soin" || motif == "consultation")
                {
                    if (dgvSigne.CurrentRow.Cells[3].Selected && dgvSigne.CurrentRow.Index > 0)
                    {
                        for (int i = 0; i < dgvSigne.CurrentRow.Index; i++)
                        {
                            if (dgvSigne.Rows[i].Cells[3].Value.ToString() == "")
                            {
                                MessageBox.Show("Au moins une valeur manquante dans les lignes précédentes", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dgvSigne.Rows[0].Cells[3].Selected = true;
                                i += dgvSigne.RowCount;
                            }
                        }
                    }
                }
                else
                {
                    idligne = int.Parse(dgvSigne.CurrentRow.Cells[1].Value.ToString());
                    txtSigneVital.Text = dgvSigne.CurrentRow.Cells[2].Value.ToString();
                    btnModifier.Enabled = true;
                    btnSupprimer.Enabled = true;
                }
            }
        }
        public int idligne = 0;
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnregistrer_Click_1(object sender, EventArgs e)
        {
            cm.EnregistrerSigneVital(this);
        }

        private void FormSigneVital_Shown(object sender, EventArgs e)
        {
            if (motif == "soin" || motif == "consultation")
            {
                txtSigneVital.Enabled = false;
                btnEnregistrer.Enabled = false;
                btnQuitter.Visible = false;
            }
            else
            {
                btnValider.Visible = false;
                btnMAJ.Visible = false;
                dgvSigne.Columns[3].Visible = false;
            }
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            cm.EnregistrerLigneSigneVital(this);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cm.ModifierSigneVital(this);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cm.Supprimer(this);
        }

        private void btnMAJ_Click(object sender, EventArgs e)
        {
            if (motif == "soin")
                cm.ModifierLigneSigneVital(this);
            else
                cm.ModifierSigneVitalConsultation(this);
        }
    }
}
