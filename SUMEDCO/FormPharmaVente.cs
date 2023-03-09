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
    public partial class FormPharmaVente : Form
    {
        public FormPharmaVente()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public int idpharma= 0,
            idrecette=0,
        idutilisateur=0;
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.AfficherRecetteProduit(this, "recherche");
        }

        private void FormPharmaVente_Shown(object sender, EventArgs e)
        {
            cc.AfficherRecetteProduit(this, "");
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                timer1.Start();
                progress = 0;
            }
            else
            {
                timer1.Stop();
            }
        }
        int progress = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            progress += 1;
            if (progress == 60)
            {
                cc.AfficherRecetteProduit(this, "");
                progress = 0;
            }
        }

        private void dgvRecette_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvRecette.RowCount != 0)
            {
                btnValider.Enabled = true;
                btnAnnuler.Enabled = false;
                idrecette = int.Parse(dgvRecette.CurrentRow.Cells[0].Value.ToString());
                cc.RecetteProduit(this);
            }
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvStock.RowCount != 0)
            {
                btnValider.Enabled = false;
                btnAnnuler.Enabled = true;
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            cc.ServirRecette(this, "OK");
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cc.ServirRecette(this, "");
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
