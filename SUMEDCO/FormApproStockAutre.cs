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
    public partial class FormApproStockAutre : Form
    {
        public FormApproStockAutre()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassCompta cc = new ClassCompta();
        public int idproduit = 0,
            idAppro = 0,
            idpatient = 0,
            idservice = 0;
        public string numcompte,
            poste = "";

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormApproStockAutre_Shown(object sender, EventArgs e)
        {
            
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAppro.RowCount > 0)
            {
                if (poste == "admin")
                {
                    idAppro = int.Parse(dgvAppro.CurrentRow.Cells[0].Value.ToString());
                    idproduit = int.Parse(dgvAppro.CurrentRow.Cells[2].Value.ToString());
                    btnServir.Enabled = true;
                }
                else
                    btnRetirer.Enabled = true;
            }
        }

        private void btnServir_Click(object sender, EventArgs e)
        {
            cs.ServirApproAutre(this, new FormApproAutre());
        }

        private void btnToutStock_Click(object sender, EventArgs e)
        {
            cs.AfficherTouteDemandeAppro(this);
        }

        private void txtCompte_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
