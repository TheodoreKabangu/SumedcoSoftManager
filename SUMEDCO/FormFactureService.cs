﻿using System;
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
    public partial class FormFactureService : Form
    {
        public FormFactureService()
        {
            InitializeComponent();
            for (int i = 0; i < dgvFacture.ColumnCount; i++)
            {
                dgvFacture.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public int idrecette = 0,
            idservice = 0,
            idpayeur = 0,
            idoperation = 0,
            idexercice = 0,
            idutilisateur;
        public bool ajoutvalide, recettePatientConsulte, fermeture_succes;
        public string poste="", type_patient = "",
            numcompte = "",
            numcomptediffere = "4711";

        private void FormFacturation_Shown(object sender, EventArgs e)
        {
            if (!recettePatientConsulte)
            {
                if (poste == "abonné")
                {
                    cboTypeFacture.Items.Remove("immédiat");
                    cboPayeur.Items.Remove("passant");
                }
                cc.ChargerCategorie(this, "");
            }
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
                cboTypeFacture.Select();
            }
            else
            {
                lblDateOperation.Text = DateTime.Now.ToShortDateString();
                lblTaux.Text = cc.VerifierTaux(DateTime.Now.Date, "valeur").ToString() + " CDF";
                cboTypeFacture.Select();
            }
        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if(cboTypeFacture.Text != "" && cboPayeur.Text != "")
            {
                if (cboPayeur.Text == "passant")
                {
                   if(txtPayeur.Text != "" && txtContacts.Text != "")
                       cc.Enregistrer(this);
                   else
                       MessageBox.Show("Rassurez-vous que tous les champs ont des valeurs", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    cc.Enregistrer(this);
            }
            else
                MessageBox.Show("Rassurez-vous que tous les champs ont des valeurs", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if (dgvFacture.RowCount != 0)
            {
                dgvFacture.Rows.RemoveAt(dgvFacture.CurrentRow.Index);
                cc.CalculerTotal(dgvFacture, txtTotal);
            }
            btnRetirerTout.Enabled = false;
            btnRetirer.Enabled = false;
        }

        private void btnRetirerTout_Click(object sender, EventArgs e)
        {
            btnRetirerTout.Enabled = false;
            dgvFacture.Rows.Clear();
            txtTotal.Text = "0";
        }

        private void dgvFacture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvFacture.RowCount !=0)
            {
                btnRetirer.Enabled = true;
                btnRetirerTout.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cc.Annuler(this);
        }
        public string cas = "";

        private void txtPayeur_Enter(object sender, EventArgs e)
        {
            if (cboPayeur.Text == "")
            {
                MessageBox.Show("Aucun type de payeur n'a été sélectionné", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypeFacture.Select();
            }
        }

        private void cboTypeFacture_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPayeur.Select();
        }
        private void btnDate_Click(object sender, EventArgs e)
        {
            cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
            cboTypeFacture.Select();
        }
        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.RowCount != 0)
            {
                if (dgv1.CurrentRow.Cells[1].Selected)
                    cc.ChargerService(this, new FormFacture());
            }
        }

        private void cboPayeur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboPayeur.Text == "patient")
            {
                txtPayeur.Enabled = false ;
                txtContacts.Enabled = false;
                cm.TrouverPatient(this, new FormFacturePatient()); 
            }
            else
            {
                txtPayeur.Text = txtContacts.Text = "";
                txtPayeur.Enabled = true;
                txtContacts.Enabled = true;
            }
        }

        private void cboPayeur_Enter(object sender, EventArgs e)
        {
            if (cboTypeFacture.Text == "")
            {
                MessageBox.Show("Aucun type de facture n'a été sélectionné", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypeFacture.Select();
            }
        }

        private void txtContacts_Enter(object sender, EventArgs e)
        {
            if (txtPayeur.Text == "")
            {
                MessageBox.Show("Aucun payeur n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypeFacture.Select();
            }
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            if (txtRecherche.Text != "")
                cc.ChargerCategorie(this, "recherche");
            else
                cc.ChargerCategorie(this, "");
        }

        private void dgvFacture_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dgvFacture.CurrentRow.Cells[4].Value) > 1)
                {
                    dgvFacture.CurrentRow.Cells[5].Value = Convert.ToInt32(dgvFacture.CurrentRow.Cells[4].Value) * Convert.ToDouble(dgvFacture.CurrentRow.Cells[3].Value);
                    cc.CalculerTotal(dgvFacture, txtTotal);
                }
                else
                {
                    MessageBox.Show("Erreur! La valeur minimale doit être 1", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvFacture.CurrentRow.Cells[4].Value = 1;
                    cc.CalculerTotal(dgvFacture, txtTotal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur! Valeur interdite","Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvFacture.CurrentRow.Cells[4].Value = 1;
                cc.CalculerTotal(dgvFacture, txtTotal);
            }            
        }

    }
}
