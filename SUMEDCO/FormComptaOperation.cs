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
    public partial class FormComptaOperation : Form
    {
        public FormComptaOperation()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public int idtypejournal = 0;
        public double sommeDebit = 0, sommeCredit = 0;
        private void cboTypeJournal_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("typejournal", cboTypeJournal, 0);
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.Afficher(this);
        }

        private void cboTypeJournal_SelectedIndexChanged(object sender, EventArgs e)
        {
            idtypejournal = cc.TrouverId("typejournal", cboTypeJournal.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche2_Click(object sender, EventArgs e)
        {
            //cc.AfficherGdLivre(this, txtRecherche.Text);
        }

        private void btnGdLivre_Click(object sender, EventArgs e)
        {
            cc.AfficherGdLivre(this);
        }
    }
}
