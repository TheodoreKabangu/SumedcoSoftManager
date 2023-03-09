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
    public partial class FormStockServir : Form
    {
        public FormStockServir()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();
        public int idsortie = 0,
            idstock = 0,
            idposte = 0;
        public string poste = "";
        public bool ajout_perte;
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cs.Annuler(this);
        }

        private void cboPoste_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("poste", cboPoste, 0);
        }

        private void cboPoste_SelectedIndexChanged(object sender, EventArgs e)
        {
            idposte = cs.TrouverId("poste", cboPoste.Text);
        }

        private void txtQteCom_TextChanged(object sender, EventArgs e)
        {
            if (txtQteCom.Text != "")
            {
                try
                {
                    if (int.Parse(txtQteCom.Text) <= 0)
                    {
                        MessageBox.Show("Saisissez une valeur supérieure à 0", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQteCom.Text = "";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Caractère interdit! Saisissez seuls les nombres entiers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQteCom.Text = txtQteCom.Text.Substring(0, txtQteCom.Text.Length - 1);
                    btnAnnuler.Select();
                }
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cs.AjouterSortieStock(this);
        }

        private void txtQteServie_TextChanged(object sender, EventArgs e)
        {
            if (txtQteServie.Text != "")
            {
                try
                {
                    if (int.Parse(txtQteServie.Text) <= 0)
                    {
                        MessageBox.Show("Saisissez une valeur supérieure à 0", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQteServie.Text = "";
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Caractère interdit! Saisissez seuls les nombres entiers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQteServie.Text = txtQteServie.Text.Substring(0, txtQteServie.Text.Length - 1);
                    btnAnnuler.Select();
                }
            }
        }
    }
}
