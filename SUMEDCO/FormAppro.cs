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
    public partial class FormAppro : Form
    {
        public FormAppro()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassCompta cc = new ClassCompta();
        public bool fermeture_succes;
        public double prixvente = 0;
        public int idAppro, idcom = 0, 
            idstock = 0;
        public string poste= "", categorie_produit = "";
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (poste == "comptable")
                cs.ValiderApproStock(this);
            else
                cs.ValiderApproStock2(this);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
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
                    MessageBox.Show("Rassurez-vous que le prix d'achat et le taux sont des valeurs numériques", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrixAchat.Text = txtPrixAchat.Text.Substring(0, txtPrixAchat.Text.Length - 1);
                }
            }
            else
            {
                txtPrixAchat.Text = "0";
                txtTaux.Text = "20";
            }
        }

        private void txtTaux_TextChanged(object sender, EventArgs e)
        {
            if(txtTaux.Text !="")
            {
                try
                {
                    float.Parse(txtTaux.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rassurez-vous que le prix d'achat et le taux sont des valeurs numériques", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTaux.Text = txtTaux.Text.Substring(0, txtTaux.Text.Length - 1);
                }
            }
        }

        private void txtTaux_Leave(object sender, EventArgs e)
        {
            if(txtTaux.Text =="")
            {
                MessageBox.Show("Taux de calcul du prix de vente absent", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaux.Focus();
            }
        }

        private void txtQteAjout_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void txtQteAppro_TextChanged(object sender, EventArgs e)
        {
            if (poste == "stock")
                txtQteAjout.Text = txtQteAppro.Text;
        }
        private void FormApproPharma_Shown(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
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

        private void txtQteAjout_Enter(object sender, EventArgs e)
        {
            if(txtQteAppro.Text == "")
            {
                MessageBox.Show("Remplissez d'abord la quantité approvisionnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQteAppro.Focus();
            }
        }

        private void txtQteAjout_Leave(object sender, EventArgs e)
        {
            if (txtQteAjout.Text != "")
            {
                if (int.Parse(txtQteAjout.Text) > 0)
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
        }

        private void txtQteAppro_Leave(object sender, EventArgs e)
        {
            if (txtQteAppro.Text != "")
            {
                if (int.Parse(txtQteAppro.Text) > 0)
                {
                    try
                    {
                        if (int.Parse(txtQteAppro.Text) > int.Parse(txtQteDem.Text))
                        {
                            MessageBox.Show("La quantité d'approvisionnement ne doit pas dépasser la quantité demandée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtQteAppro.Text = txtQteAppro.Text.Substring(0, txtQteAppro.Text.Length - 1);
                            btnAnnuler.Select();
                        }
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
        }

        private void txtPrixVente_DoubleClick(object sender, EventArgs e)
        {
            if (txtPrixVente.Enabled == false) 
                txtPrixVente.Enabled = true;
            else
                txtPrixVente.Enabled = false;
        }

        private void txtPrixVente_Leave(object sender, EventArgs e)
        {
            if (txtPrixVente.Text != "" && txtPrixAchat.Text != "") 
                txtTaux.Text = ((double.Parse(txtPrixVente.Text) - double.Parse(txtPrixAchat.Text)) * 100 / double.Parse(txtPrixAchat.Text)).ToString("0.00");
            else
            {
                txtTaux.Text = "20";
                txtPrixVente.Text = "0";
                txtPrixAchat.Text = "";
            }
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
    }
}
