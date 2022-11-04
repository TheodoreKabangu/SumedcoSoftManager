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
    public partial class FormAbonneProduit : Form
    {
        public FormAbonneProduit()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();
        ClassMalade cm = new ClassMalade();
        public int id = 0,
            idabonne = 0,
            idproduit = 0,
            idstock = 0;
        public string typepatient;

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cc.Annuler(this);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cc.Enregistrer(this);
            if (dgvAbonne.RowCount != 0)
                dgvAbonne.Rows[dgvAbonne.RowCount - 1].Cells[4].Value = cm.TrouverNom("patient", int.Parse(dgvAbonne.Rows[dgvAbonne.RowCount - 1].Cells[2].Value.ToString()));
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cc.Modifier(this, new FormFactureProduit2());
            if (dgvAbonne.RowCount != 0)
                dgvAbonne.Rows[dgvAbonne.RowCount - 1].Cells[4].Value = cm.TrouverNom("patient", int.Parse(dgvAbonne.Rows[dgvAbonne.RowCount - 1].Cells[2].Value.ToString()));

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cc.Supprimer(this);
            if (dgvAbonne.RowCount != 0)
                dgvAbonne.Rows[dgvAbonne.RowCount - 1].Cells[4].Value = cm.TrouverNom("patient", int.Parse(dgvAbonne.Rows[dgvAbonne.RowCount - 1].Cells[2].Value.ToString()));
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            cc.Afficher(this, "recherche");
            if (dgvAbonne.RowCount > 0)
            {
                for (int i = 0; i < dgvAbonne.RowCount; i++)
                {
                    dgvAbonne.Rows[i].Cells[4].Value = cm.TrouverNom("patient", int.Parse(dgvAbonne.Rows[i].Cells[2].Value.ToString()));
                }
            }
        }
        private void dgvAbonne_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cc.Recuperer(this);
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if (dgvFacture.RowCount != 0)
                dgvFacture.Rows.RemoveAt(dgvFacture.CurrentRow.Index);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            cc.Facturier(this, new FormFactureProduit2());
        }
    }
}
