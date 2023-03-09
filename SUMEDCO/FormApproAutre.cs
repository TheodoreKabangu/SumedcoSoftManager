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
        public int idproduit = 0, idAppro = 0, idstock = 0, idcat= 0;
        public string descriptif = "RAS";
        public bool fermeture_succes;

        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();
        public string categorie_produit = "";
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
                nudAnnee.Value = 2023;
                txtNumLot.Enabled = false;
                cboMois.Enabled = false;
                nudAnnee.Enabled = false;
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            txtProduit.Enabled = true;
            txtProduit.Text = "";
            cboForme.DropDownStyle = ComboBoxStyle.DropDown;
            cboForme.SelectedText = "";
            cboForme.DropDownStyle = ComboBoxStyle.DropDownList;
            txtCMM.Text = "0";
            txtDosage.Text = "";
            txtPrixAchat.Text = "0";
            txtTaux.Text = "20";
            chboxLot.Checked = false;
            chboxLot_Click(null, null);
            txtQteAppro.Text = "";
            txtQteAjout.Text = "";
            txtObs.Text = "";
        }
        public string[] valeurstock;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (txtPrixAchat.Text != "" && txtPrixVente.Text != "" && txtQteAppro.Text != "" && txtQteAjout.Text != "" && txtObs.Text != "")
            {
                if (categorie_produit.ToLower() == "pharmaceutique")
                {
                    if (txtTaux.Text != "" && txtNumLot.Text != "" && cboMois.Text != "" && nudAnnee.Value >= dtpDateJour.Value.Year)
                    {
                        cs.AjouterApproAutre(this);
                    }
                    else
                        MessageBox.Show("Erruer! Véirifiez que :\n1. le taux est fourni\n2. le lot est fourni\n3. ce lot n'a pas encore expiré.", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (chboxLot.Checked)
                    {
                        if (txtNumLot.Text != "" && cboMois.Text != "" && nudAnnee.Value >= dtpDateJour.Value.Year)
                        {
                            cs.AjouterApproAutre(this);
                        }
                        else
                            MessageBox.Show("Erreur! Vérifiez que Le lot est fourni et qu'il n'a pas encore expiré.", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        cs.AjouterApproAutre(this);
                    }
                }
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtPrixAchat_TextChanged(object sender, EventArgs e)
        {
            if (txtPrixAchat.Text != "" && txtTaux.Text != "")
            {
                try
                {
                    txtPrixVente.Text = (float.Parse(txtPrixAchat.Text) + float.Parse(txtPrixAchat.Text) * int.Parse(txtTaux.Text) / 100).ToString("0.00");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rassurez-vous que le prix d'achat est une valeur numérique", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrixAchat.Text = txtPrixAchat.Text.Substring(0, txtPrixAchat.Text.Length - 1);
                    btnAnnuler.Select();
                }
            }
            else
            {
                txtPrixAchat.Text = "0";
                txtTaux.Text = "20";
            }
        }

        private void txtQteAppro_TextChanged(object sender, EventArgs e)
        {
            if (txtQteAppro.Text != "" && int.Parse(txtQteAppro.Text) > 0)
            {
                try
                {
                    txtQteAppro.Text = int.Parse(txtQteAppro.Text) + "";
                }
                catch (Exception)
                {
                    MessageBox.Show("Caractère interdit! Saisissez seuls les nombres entiers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQteAppro.Text = txtQteAppro.Text.Substring(0, txtQteAppro.Text.Length - 1);
                    btnAnnuler.Select();
                }
            }
            else
            {
                MessageBox.Show("Saisissez une valeur supérieure à 0", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQteAppro.Text = "";
            }
        }

        private void txtQteAjout_TextChanged(object sender, EventArgs e)
        {
            if (txtQteAjout.Text != "")
            {
                try
                {
                    if (int.Parse(txtQteAjout.Text) > int.Parse(txtQteAppro.Text))
                    {
                        MessageBox.Show("La quantité ajoutée ne doit pas dépasser la quantité d'approvisionnement", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQteAjout.Text = txtQteAjout.Text.Substring(0, txtQteAjout.Text.Length - 1);
                        btnAnnuler.Select();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Caractère interdit! Saisissez seuls les nombres entiers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQteAjout.Text = txtQteAjout.Text.Substring(0, txtQteAjout.Text.Length - 1);
                    btnAnnuler.Select();
                }
            }
            else
            {
                MessageBox.Show("Saisissez une valeur supérieure à 0", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQteAjout.Text = "";
            }
        }

        private void txtPrixVente_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtPrixVente_DoubleClick(object sender, EventArgs e)
        {
            if (txtPrixVente.ReadOnly == false)
                txtPrixVente.ReadOnly = true;
            else
                txtPrixVente.ReadOnly = false;
        }

        private void txtPrixVente_TextChanged(object sender, EventArgs e)
        {
            if (txtPrixVente.Text != "" && txtPrixAchat.Text != "" && txtTaux.Text != "")
            {
                try
                {
                    txtPrixVente.Text = (double.Parse(txtPrixVente.Text)).ToString("0.00");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rassurez-vous que le prix d'achat est une valeur numérique", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrixVente.Text = txtPrixVente.Text.Substring(0, txtPrixVente.Text.Length - 1);
                    btnAnnuler.Select();
                }
            }
            else
                txtPrixVente.Text = "0";
        }

        private void dgvProduit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduit.RowCount != 0)
            {
				idproduit = int.Parse(dgvProduit.CurrentRow.Cells[0].Value.ToString());
                txtProduit.Text = dgvProduit.CurrentRow.Cells[1].Value.ToString();
                txtProduit.Enabled = false;
                cboForme.Select();
            }
        }

        private void cboForme_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCMM.Focus();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cs.ChargerProduit(this, "recherche");
        }
    }
}
