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
    public partial class FormApproAutre : Form
    {
        public FormApproAutre()
        {
            InitializeComponent();
        }
        public int idproduit = 0, idmvmt = 0;
        public string descriptif = "RAS";
        public bool fermeture_succes;
        private void chboxLot_Click(object sender, EventArgs e)
        {
            if (chboxLot.Checked)
            {
                txtNumLot.Enabled = true;
                cboMois.Enabled = true;
                nudAnnee.Enabled = true;
                txtNumLot.Focus();
            }
            else
            {
                txtNumLot.Text = "";
                cboMois.DropDownStyle = ComboBoxStyle.DropDown;
                cboMois.SelectedText = "";
                cboMois.DropDownStyle = ComboBoxStyle.DropDownList;
                nudAnnee.Value = 2021;
                txtNumLot.Enabled = false;
                cboMois.Enabled = false;
                nudAnnee.Enabled = false;
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }
        public string[] valeurstock;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (txtPrixAchat.Text != "" && txtQteAppro.Text != "" && txtQteAjout.Text != "")
            {
                if(chboxLot.Checked)
                {
                    if(txtNumLot.Text != "" && cboMois.Text != "" && nudAnnee.Value >= dtpDateJour.Value.Year)
                    {
                        fermeture_succes = true;
                        valeurstock = new string[5];
                        descriptif = string.Format("{0} {1}/{2}", txtNumLot.Text, cboMois.Text, nudAnnee.Value);
                        this.Hide();
                    }
                    else
                        MessageBox.Show("Vérfiez que le numéro de lot et sa date d'expiration sont fournis, et que le lot fourni n'a pas encore expiré par rapport à la date actuelle.", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    fermeture_succes = true;
                    this.Hide();
                }
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtPrixAchat_TextChanged(object sender, EventArgs e)
        {
            if (txtPrixAchat.Text != "")
            {
                try
                {
                    float.Parse(txtPrixAchat.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rassurez-vous que le prix d'achat est une valeur numérique", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrixAchat.Text = txtPrixAchat.Text.Substring(0, txtPrixAchat.Text.Length - 1);
                    btnAnnuler.Select();
                }
            }
        }

        private void txtQteAppro_TextChanged(object sender, EventArgs e)
        {
            if (txtQteAppro.Text != "")
            {
                try
                {
                    if (int.Parse(txtQteAppro.Text) <= 0)
                    {
                        MessageBox.Show("Saisissez une valeur supérieure à 0", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQteAppro.Text = "";
                    }
                    else
                    {
                        if (int.Parse(txtQteAppro.Text) > int.Parse(txtQteDem.Text))
                        {
                            MessageBox.Show("La quantité d'approvisionnement ne doit pas dépasser la quantité demandée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtQteAppro.Text = txtQteAppro.Text.Substring(0, txtQteAppro.Text.Length - 1);
                            btnAnnuler.Select();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Caractère interdit! Saisissez seuls les nombres entiers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQteAppro.Text = txtQteAppro.Text.Substring(0, txtQteAppro.Text.Length - 1);
                    btnAnnuler.Select();
                }
            }
        }

        private void txtQteAjout_TextChanged(object sender, EventArgs e)
        {
            if (txtQteAjout.Text != "")
            {
                try
                {
                    if (int.Parse(txtQteAjout.Text) <= 0)
                    {
                        MessageBox.Show("Saisissez une valeur supérieure à 0", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQteAjout.Text = "";
                    }
                    else
                    {
                        if (int.Parse(txtQteAjout.Text) > int.Parse(txtQteAppro.Text))
                        {
                            MessageBox.Show("La quantité ajoutée ne doit pas dépasser la quantité d'approvisionnement", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtQteAjout.Text = txtQteAjout.Text.Substring(0, txtQteAjout.Text.Length - 1);
                            btnAnnuler.Select();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Caractère interdit! Saisissez seuls les nombres entiers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQteAjout.Text = txtQteAjout.Text.Substring(0, txtQteAjout.Text.Length - 1);
                    btnAnnuler.Select();
                }
            }
        }
    }
}
