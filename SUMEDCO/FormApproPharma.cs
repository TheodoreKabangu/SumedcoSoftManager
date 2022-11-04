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
    public partial class FormApproPharma : Form
    {
        public FormApproPharma()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassCompta cc = new ClassCompta();
        public bool fermeture_succes;
        public float prixvente = 0;
        public int idstock = 0, 
            idmvmt = 0;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if(txtTaux.Text !="" && txtPrixAchat.Text !="" && txtNumLot.Text !="" && cboMois.Text !="" && txtQteAppro.Text != "" && txtQteAjout.Text !="")
            {
                if(nudAnnee.Value >= dtpDateJour.Value.Year)
                {
                    fermeture_succes = true;
                    this.Hide();
                }
                else
                    MessageBox.Show("Désolé! Le lot fourni a déjà expiré par rapport à la date actuelle.", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }

        private void txtPrixAchat_TextChanged(object sender, EventArgs e)
        {
            if (txtPrixAchat.Text != "")
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
            else txtPrixVente.Text = "";
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
            if(txtQteAjout.Text !="")
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
        private void txtQteAppro_TextChanged(object sender, EventArgs e)
        {
            if(txtQteAppro.Text != "")
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
        private void FormApproPharma_Shown(object sender, EventArgs e)
        {
            lblPrix.Text = "Prix stock : ";
            prixvente = cs.PrixStock(idstock);
            lblPrix.Text = lblPrix.Text + prixvente + " CDF";
        }
    }
}
