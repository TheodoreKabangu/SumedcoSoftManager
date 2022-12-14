using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp;
namespace SUMEDCO
{
    public partial class FormAdminStatService : Form
    {
        public FormAdminStatService()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public int nbjours,
            nbcolonne,
            sommeligne;
        public string colonne;
        private void FormRapportTrim_Shown(object sender, EventArgs e)
        {
            cc.RubriqueStatService(this);
            //colonne = "01/2022";
            //nbjours = DateTime.DaysInMonth(int.Parse(colonne.Substring(3)), int.Parse(colonne.Substring(0, 2)));
            //MessageBox.Show("" + nbjours);
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.AjouterColonneMois(this);
            if (dgvRapport.ColumnCount > 3)
            {
                cc.AfficherCasConsultation(this);
                cc.AfficherCas(this);
            }
        }

        private void dgvRapport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRapport.CurrentRow.DefaultCellStyle.ForeColor == Color.MediumBlue)
                dgvRapport.CurrentRow.DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            if (dgvRapport.RowCount != 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = string.Format("Rapport du {0} au {1}", dtpDateDe.Text.Replace("/", "_"), dtpDateA.Text.Replace("/", "_"));
                bool error_msg = false;
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (Exception ex)
                        {
                            error_msg = true;
                            MessageBox.Show("Unable to write data in the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if(!error_msg)
                    {
                        try
                        {
                            //PdfPTable pTable = new PdfPTable();

                        }
                        catch (Exception ex)
                        {
                            error_msg = true;
                            MessageBox.Show("Unable to write data in the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
