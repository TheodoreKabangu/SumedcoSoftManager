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
    public partial class FormStockInventaire : Form
    {
        public FormStockInventaire()
        {
            InitializeComponent();
            for (int i = 0; i < dgvProduit.ColumnCount; i++)
            {
                dgvProduit.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassStock cs = new ClassStock();
        ClassCompta cc = new ClassCompta();
        public bool fermeture_succes;
        public double prixvente = 0;
        public int idstock = 0,
            idoperation = 0;
        public string poste= "", categorie_produit = "";
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            
        }

        private void txtPrixAchat_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTaux_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTaux_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtQteAjout_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void txtQteAppro_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void FormApproPharma_Shown(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtQteAjout_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtQteAjout_Leave(object sender, EventArgs e)
        {
                       
        }

        private void txtQteAppro_Leave(object sender, EventArgs e)
        {
                       
        }

        private void txtPrixVente_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void txtPrixVente_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtPrixVente_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
