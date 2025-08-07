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
    public partial class AbonneMDI : Form
    {
        ClasseElements ce = new ClasseElements();
        public AbonneMDI()
        {
            InitializeComponent();
            ce.FigerColonne(dgvRapport);
            ce.AjouterCategorieRecette(dgvRapport);
        }
        AbonneTraceClasse atc = new AbonneTraceClasse();
        public Form activeForm = null;
        public string statut = "";
        public int idutilisateur;
        public bool infirmier_autorise;
        private void btnAbonne_Click(object sender, EventArgs e)
        {
            atc.SousForm(this, new ReceptionPatient());
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int progress;
        private void AbonneMDI_Shown(object sender, EventArgs e)
        {
            //atc.ConsommationTrace(dgvRapport);
            //timer1.Start();
            //progress = 0;
        }
        bool success;
        private async void timer1_Tick(object sender, EventArgs e)
        {
            progress += 1;
            if (progress == 60)
            {
                try
                {
                    success = await Task.Run(() => atc.ConsommationTrace(dgvRapport));
                    if(success)
                    {
                        lblSauvegarde.Text = "En cours ...";
                        dgvRapport.SelectAll();
                        DataObject copydata = dgvRapport.GetClipboardContent();
                        if (copydata != null) Clipboard.SetDataObject(copydata);
                        success = await Task.Run(() => atc.ExporterVersExcel(@"C:\Users\Public\Documents\AbonneTraces_.xlsx"));
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
        private void btnRapport_Click(object sender, EventArgs e)
        {
            atc.SousForm(this, new AbonneRapport());
        }
    }
}
