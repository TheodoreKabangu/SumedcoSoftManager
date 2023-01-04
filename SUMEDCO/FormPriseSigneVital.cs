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
            idconsultation = 0,
            nbligne_trouve=0;
        public bool fermeture_succes;
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
            /*
             * si affecter alors nouvel enregistrement dans PriseSigneVital
             * si reaffecter alors update idmedecin = le nouveau idmedecin
             */
            fermeture_succes = false;
            this.Hide();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.RowCount != 0)
            {
                
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            cm.ValiderLigne(this);
        }

        private void FormExamen_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            
        }

        private void cboMedecin_SelectedIndexChanged(object sender, EventArgs e)
        {
            idmedecin = cm.TrouverId("medecin", cboMedecin.Text);
        }
    }

}
