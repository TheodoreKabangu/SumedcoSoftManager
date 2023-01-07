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
    public partial class FormAbonneService : Form
    {
        public FormAbonneService()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        //FormAbon Abon = new FormAbon();
        public bool fermeture_succes, consulte;
        public int id = 0,
            idabonne = 0,
            idservice = 0;
        public string numcompte,
            typepatient;

        private void cboService_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cc.Enregistrer(this);
            if(consulte)
            {
                fermeture_succes = true;
                this.Hide();
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvAbonne.RowCount != 0)
            {
                cc.Modifier(this, new FormPayement());
                dgvAbonne.Rows[dgvAbonne.RowCount - 1].Cells[4].Value = cm.TrouverNom("patient", int.Parse(dgvAbonne.Rows[dgvAbonne.RowCount - 1].Cells[2].Value.ToString()));
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if(dgvAbonne.RowCount != 0)
            {
                cc.Supprimer(this);
                dgvAbonne.Rows[dgvAbonne.RowCount - 1].Cells[4].Value = cm.TrouverNom("patient", int.Parse(dgvAbonne.Rows[dgvAbonne.RowCount - 1].Cells[2].Value.ToString()));
            }
        }

        private void dgvAbonne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cc.Recuperer(this);
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cc.Annuler(this);
            if (consulte)
            {
                fermeture_succes = false;
                this.Hide();
            }
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            cc.Afficher(this, "recherche");
            if(dgvAbonne.RowCount != 0)
            {
                for (int i = 0; i < dgvAbonne.RowCount; i++)
                {
                    dgvAbonne.Rows[i].Cells[4].Value = cm.TrouverNom("patient", int.Parse(dgvAbonne.Rows[i].Cells[2].Value.ToString()));
                }
            }
        }

        private void btnPlusPlainte_Click(object sender, EventArgs e)
        {
            //cc.SelectionService(this, new FormPayement());
        }

        private void btnRetirerPlainte_Click(object sender, EventArgs e)
        {
            if (dgvService.RowCount != 0)
                dgvService.Rows.RemoveAt(dgvService.CurrentRow.Index);
        }
    }
}
