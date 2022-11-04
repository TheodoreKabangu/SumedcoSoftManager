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
    public partial class FormAgendaCaisse : Form
    {
        public FormAgendaCaisse()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public string numcompte;
        public int id, idoperation = 0;
        private void txtMontantPaye_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(txtMontantPaye.Text) > double.Parse(txtReste.Text))
                {
                    MessageBox.Show("Le montant à payer ne peut dépasser le reste à payer", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMontantPaye.Focus();
                }
                else
                {
                    cc.PayementDette(this);
                    cc.Afficher(this, "");
                    this.Hide();
                    //cc.Annuler(this); j'ai besoin du montant payé
                    //ici il faut les écritures comptables après enregistrement
                    //diminuer la dette de malades hospitalisés au débit de la caisse
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Le montant à payer doit être un nombre\n"+ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cc.Recuperer(this);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cc.Modifier(this);
            //
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cc.Supprimer(this);
            //
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            if (txtNumBon.Text != "") cc.Afficher(this, "");
            else MessageBox.Show("Aucun numéro de bon n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
