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
    public partial class FormPayement : Form
    {
        public FormPayement()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public int idpayement,
            idpayeur,
            idrecette,
            idoperation;
        public string caisse, numcompte;
        public double taux;
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool ajoutvalide;
        public bool selectionvalide;
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            cc.PayerRecette(this);
        }
        string montantLettre = "";

        private void txtMontant_Leave(object sender, EventArgs e)
        {
            if (txtMontant.Text != "")
            {
                montantLettre = cc.TestMontant(txtMontant);
                if (montantLettre != "")
                {
                    if (cboMonnaie.Text == "CDF")
                        txtMontantLettre.Text = montantLettre.Substring(0, 1).ToUpper() + montantLettre.Substring(1) + " francs congolais";
                    else
                        txtMontantLettre.Text = montantLettre.Substring(0, 1).ToUpper() + montantLettre.Substring(1) + " dollars américains";
                }
            }
        }

        private void cboMonnaie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonnaie.Text == "CDF")
            {
                numcompte = "571101";
                caisse = "Caisse en CDF Recettes";
            }
            else
            {
                numcompte = "571201";
                caisse = "Caisse en USD Recettes";
            }
        }
    }
}
