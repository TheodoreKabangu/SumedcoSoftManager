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
    public partial class RecetteMDI : Form
    {
        ClassCompta cc = new ClassCompta();
        ClasseElements ce = new ClasseElements();
        RecetteClasse rc = new RecetteClasse();
        AbonneTraceClasse atc = new AbonneTraceClasse();
        public Form activeForm = null;
        public int idutilisateur;
        public RecetteMDI()
        {
            InitializeComponent();
            ce.FigerColonne(dgvRapport);
            ce.AjouterCategorieRecette(dgvRapport);
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRecette_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new Recette());
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new RecetteJournal());
        }
        int progress;
        bool success;
        private void RecetteMDI_Shown(object sender, EventArgs e)
        {
            //rc.RecetteTrace(dgvRapport);
            //timer1.Start();
            //progress = 0;
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {
            progress += 1;
            if (progress == 30)
            {
                try
                {
                    success = await Task.Run(() => rc.RecetteTrace(dgvRapport));
                    if (success)
                    {
                        lblSauvegarde.Text = "En cours ...";
                        dgvRapport.SelectAll();
                        DataObject copydata = dgvRapport.GetClipboardContent();
                        if (copydata != null) Clipboard.SetDataObject(copydata);
                        success = await Task.Run(() => atc.ExporterVersExcel(@"C:\Users\Public\Documents\RecetteTraces.xlsx"));
                        progress = 0;
                        if (success) lblSauvegarde.Text = "Sauvegardé";
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}
