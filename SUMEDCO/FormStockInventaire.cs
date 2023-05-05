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
            for (int i = 0; i < dgvStock.ColumnCount; i++)
            {
                dgvStock.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassStock cs = new ClassStock();
        ClassCompta cc = new ClassCompta();
        public bool fermeture_succes;
        public double prixvente = 0;
        public int idpharma, idstock = 0,
            idoperation = 0;
        public string poste= "", categorie_produit = "";
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStockInventaire_Shown(object sender, EventArgs e)
        {
			cs.AfficherStockProduit(this);
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cs.TrouverQteStock(this);
        }

        private void cboDepot_DropDown(object sender, EventArgs e)
        {
            cs.ChargerCombo(cboDepot, "pharma", 0);
        }

        private void cboDepot_SelectedIndexChanged(object sender, EventArgs e)
        {
            idpharma = cs.TrouverId("pharma", cboDepot.Text);
        }
    }
}
