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
    public partial class StockApprov : Form
    {
        public StockApprov()
        {
            InitializeComponent();
            ce.FigerColonne(dgvAppro);
        }
        ClassStock cs = new ClassStock();
        ClassCompta cc = new ClassCompta();
        public int idexercice = 0,
            idoperation = 0,
            idAppro = 0, idposte;
        public string compteFournis = "",
            poste = "",
            depot = "",
            categorie_produit = "";
        public double prixvente = 0, 
            prix_achat = 0,
            taux = 0;
        public bool lotvalide;

        private void FormApprov_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                taux = cc.ChangerDate(this, new DateTaux());
            }
            else
                taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (poste == "comptable")
            {
                if (txtTaux.Text != "")
                    cs.Approvisionner(this);
                else
                    MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                cs.Approvisionner(this);
        }

        private void dgvAppro_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            cs.CalculLigne(this);            
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                if(dgvAppro.RowCount != 0)
                {
                    dgvAppro.CurrentRow.Cells[2].ReadOnly = false;
                    dgvAppro.CurrentRow.Cells[3].ReadOnly = false;
                    dgvAppro.CurrentRow.Cells[14].Value = "OUI";
                }
                
            }
            else
            {
                if (dgvAppro.RowCount != 0)
                {
                    dgvAppro.CurrentRow.Cells[2].Value = "";
                    dgvAppro.CurrentRow.Cells[3].Value = "";
                    dgvAppro.CurrentRow.Cells[14].Value = "NON";
                    dgvAppro.CurrentRow.Cells[2].ReadOnly = true;
                    dgvAppro.CurrentRow.Cells[3].ReadOnly = true;
                }
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if (dgvAppro.RowCount != 0)
            {
                if (dgvAppro.CurrentRow.Index < dgvAppro.RowCount - 1)
                dgvAppro.Rows.RemoveAt(dgvAppro.CurrentRow.Index);
            }
        }
        ClasseElements ce = new ClasseElements();
        private void txtValeurMin_TextChanged(object sender, EventArgs e)
        {
            ce.TestEntier(txtValeurMin);
        }
        ComptaComptes compte;
        private void btnNewFournisseur_Click(object sender, EventArgs e)
        {
            
        }

        private void txtTaux_TextChanged(object sender, EventArgs e)
        {
            ce.TestEntier(txtTaux);
        }       
    }
}
