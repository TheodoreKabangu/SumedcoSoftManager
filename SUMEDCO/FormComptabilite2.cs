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
    public partial class FormComptabilite2 : Form
    {
        public FormComptabilite2()
        {
            InitializeComponent();
        }
        public long idoperation = 0;
        ReceptionFactureClasse rfc = new ReceptionFactureClasse();

        private void Comptabilite_Load(object sender, EventArgs e)
        {
            
        }

        private void cboClasseDebit_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            
        }
        double montantdebit = 0, montantcredit = 0;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
                    }

        private void dgvCompte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRetirer.Enabled = true;         
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            
        }
        string compte = "";
        private void cboTypeJournal_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboNumCompte_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtLibelle_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtNumPiece_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtMontant_Enter(object sender, EventArgs e)
        {
            
        }

        private void cboDebitCredit_Enter(object sender, EventArgs e)
        {
            
        }

        private void cboAfficheJournal_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvGrandLivre_Click(object sender, EventArgs e)
        {
            
        }

        private void linkAfficherActif_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkAfficherPassif_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
        DateTaux d = new DateTaux();
        private void Comptabilite_Shown(object sender, EventArgs e)
        {        
            
        }

        private void linkResultat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkFlux_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void btnRechercheCompte_Click(object sender, EventArgs e)
        {
            
        }
        long valeur = 0;
        private void txtNumCompte_TextChanged(object sender, EventArgs e)
        {
               
        }

        private void cboMotifGL_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboBalance_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboDebitCredit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboAfficher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {

        }
    }
}
