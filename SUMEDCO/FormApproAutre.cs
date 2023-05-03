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

            for (int i = 0; i < dgvProduit.ColumnCount; i++)
            {
                dgvProduit.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public int idproduit = 0, idAppro = 0, idstock = 0, idcat= 0;
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
                nudAnnee.Value = DateTime.Now.Year;
                txtNumLot.Enabled = false;
                cboMois.Enabled = false;
                nudAnnee.Enabled = false;
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cs.Annuler(this);
            chboxLot_Click(null, null);
        }
        public string[] valeurstock;
        public string expirationlot = "RAS";
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (txtProduit.Text != "" && cboForme.Text != "" && txtPrixAchat.Text != "" && txtPrixVente.Text != "" && txtQteAppro.Text != "")
            {
                if (categorie_produit.ToLower() == "pharmaceutique")
                {
                    if (txtTaux.Text != "" && txtNumLot.Text != "" && cboMois.Text != "" && nudAnnee.Value >= DateTime.Now.Year)
                    {
                        expirationlot = string.Format("{0}/{1}", cboMois.Text, nudAnnee.Value);
                        cs.AjouterApproAutre(this);
                    }
                    else
                        MessageBox.Show("Erruer! Véirifiez que :\n1. le taux est fourni\n2. le lot est fourni\n3. ce lot n'a pas encore expiré.", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (chboxLot.Checked)
                    {
                        if (txtNumLot.Text != "" && cboMois.Text != "" && nudAnnee.Value >= DateTime.Now.Year)
                        {
                            expirationlot = string.Format("{0}/{1}", cboMois.Text, nudAnnee.Value);
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
                    txtPrixVente.Text = (float.Parse(txtPrixAchat.Text) + float.Parse(txtPrixAchat.Text) * float.Parse(txtTaux.Text) / 100).ToString("0.00");
                    txtPrixVente.Text = (Convert.ToInt32(txtValeurMin.Text) * Math.Ceiling(Convert.ToDouble(txtPrixVente.Text) / 50)).ToString("0.00");
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
            if (txtQteAppro.Text != "")
            {
                try
                {
                    txtQteAppro.Text = Math.Abs(int.Parse(txtQteAppro.Text)) + "";
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
        ClassMalade cm = new ClassMalade();
        private void txtValeurMin_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtValeurMin);
        }
    }
}
