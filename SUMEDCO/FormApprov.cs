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
    public partial class FormApprov : Form
    {
        public FormApprov()
        {
            InitializeComponent();
            for (int i = 0; i < dgvAppro.ColumnCount; i++)
            {
                dgvAppro.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassStock cs = new ClassStock();
        ClassCompta cc = new ClassCompta();
        public int idexercice = 0,
            idoperation = 0,
            idAppro = 0;
        public string caisse = "",
            compteFournis = "",
            poste = "",
            categorie_produit = "";
        public double prixvente = 0, 
            prix_achat = 0,
            taux = 0;
        public bool lotvalide;
        private void cboFournisseur_DropDown(object sender, EventArgs e)
        {
            cc.ChargerFournisseur(this);
        }

        private void FormApprov_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                taux = cc.ChangerDate(this, new DateTaux());
            }
            else
                taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cc.Approvisionner(this);
        }

        private void dgvAppro_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            cc.CalculLigne(this);            
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                if(dgvAppro.RowCount != 0)
                {
                    dgvAppro.CurrentRow.Cells[2].ReadOnly = false;
                    dgvAppro.CurrentRow.Cells[3].ReadOnly = false;
                    dgvAppro.CurrentRow.Cells[14].Value = "OUI";
                }
                
            }
            else
            {
                if (dgvAppro.RowCount != 0)
                {
                    dgvAppro.CurrentRow.Cells[2].Value = "";
                    dgvAppro.CurrentRow.Cells[3].Value = "";
                    dgvAppro.CurrentRow.Cells[14].Value = "NON";
                    dgvAppro.CurrentRow.Cells[2].ReadOnly = true;
                    dgvAppro.CurrentRow.Cells[3].ReadOnly = true;
                }
            }
        }

        private void cboFournisseur_SelectedIndexChanged(object sender, EventArgs e)
        {
            compteFournis = cc.TrouverId("numcompte", cboFournisseur.Text).ToString();
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if (dgvAppro.RowCount != 0)
            {
                if (dgvAppro.CurrentRow.Index < dgvAppro.RowCount - 1)
                dgvAppro.Rows.RemoveAt(dgvAppro.CurrentRow.Index);
            }
        }
        ClassMalade cm = new ClassMalade();
        private void txtValeurMin_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtValeurMin);
        }       
    }
}
