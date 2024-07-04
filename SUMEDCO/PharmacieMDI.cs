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
    public partial class PharmacieMDI : Form
    {
        public PharmacieMDI()
        {
            InitializeComponent();
        }
        public Form activeForm = null;
        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();
        PharmacieFacturationClasse ph = new PharmacieFacturationClasse();
        public int idutilisateur, idpharma;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnEncaisser_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormPhamaVente());
        }

        private void btnStockPh_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormStockProduit());
        }

        private void btnCommande_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormHistoCommande());
        }
        private void btnUtilisation_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormUtilisation());
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormStockInventaire());
        }

        private void btnFacturePorduit_Click(object sender, EventArgs e)
        {
            ph.FactureProduit(this, new PharmacieFacturation());
        }

    }
}