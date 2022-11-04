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
    public partial class FormComAutre : Form
    {
        public FormComAutre()
        {
            InitializeComponent();
        }
        public int idproduit = 0;
        public bool fermeture_succes;
        public string motif = "";
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
			this.Hide();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!txtQteServie.Enabled)
            {
                if (txtQteCom.Text != "")
                {
                    fermeture_succes = true;
                    this.Hide();
                }
                else
                    MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtQteCom.Text != "" && txtQteServie.Text != "" && txtDest.Text != "")
                {
                    fermeture_succes = true;
                    this.Hide();
                }
                else
                    MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                    else
                    {
                        if (motif == "requisition" && int.Parse(txtQteCom.Text) > int.Parse(txtQteStock.Text))
                        {
                            MessageBox.Show("La quantité commandée ne doit pas dépasser la quantité en stock", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtQteCom.Text = txtQteCom.Text.Substring(0, txtQteCom.Text.Length - 1);
                            btnAnnuler.Select();
                        }
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
                    else
                    {
                        if (motif == "requisition" && int.Parse(txtQteServie.Text) > int.Parse(txtQteCom.Text))
                        {
                            MessageBox.Show("La quantité servie ne doit pas dépasser la quantité commandée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtQteServie.Text = txtQteServie.Text.Substring(0, txtQteServie.Text.Length - 1);
                            btnAnnuler.Select();
                        }
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
