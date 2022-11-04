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
    public partial class FormMedecinHistoChat : Form
    {
        public FormMedecinHistoChat()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public int idmessage = 0,
            idexpediteur = 0,
            iddestinataire = 0; 
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMessage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvMessage.RowCount != 0)
            {
                if (dgvMessage.CurrentRow.Cells[1].Value.ToString() == "")
                {
                    dgvMessage.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Silver;
                    dgvMessage.CurrentRow.DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                    btnRepondre.Enabled = false;
                    btnModifier.Enabled = false;
                    iddestinataire = 0;
                    idmessage = 0;
				}
                else
                {
                    if (dgvMessage.CurrentRow.Cells[3].Value.ToString().StartsWith("Réponse")) 
                        btnRepondre.Enabled = false;
                    else
                        btnRepondre.Enabled = true;
                    btnModifier.Enabled = true;
                    iddestinataire = int.Parse(dgvMessage.CurrentRow.Cells[6].Value.ToString());
                    idmessage = int.Parse(dgvMessage.CurrentRow.Cells[0].Value.ToString());
                }
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            cm.NouveauMessage(this, new FormMedecinMessage());
        }

        private void btnRepondre_Click(object sender, EventArgs e)
        {
            cm.Repondre(this, new FormMedecinMessage());
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cm.Modifier(this, new FormMedecinMessage());
        }

        private void dgvMessage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMessage.RowCount != 0)
            {
                if (dgvMessage.CurrentRow.Cells[1].Value.ToString() != "")
                    cm.VoirMessage(this, new FormMedecinMessage());
            }
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.Afficher(this);
        }
    }
}
