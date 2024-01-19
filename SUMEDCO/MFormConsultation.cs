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
    public partial class MFormConsultation : Form
    {
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        public int idmedecin = 0, idutilisateur;
        public MFormConsultation()
        {
            InitializeComponent();
            //cc.ActualiserDesign(pnlSousMenu);
        }

        private void btnConsultation_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormConsulterPrise());            
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormMessageHisto());
        }

        private void btnRendezVous_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormConsultationStat());
        }

        private void btnDossier_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new FormConsultationDossier());
        }
    }
}
