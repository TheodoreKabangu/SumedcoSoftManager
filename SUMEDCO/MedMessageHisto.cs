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
    public partial class MedMessageHisto : Form
    {
        public MedMessageHisto()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public long idmessage = 0;
        public int idutilisateur = 0,
            iddestinataire = 0; 
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMessage_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            if(dgvMessage.RowCount != 0)
            {
                idmessage = Convert.ToInt64(dgvMessage.CurrentRow.Cells[0].Value);
                if (rbEnvoye.Checked && dgvMessage.CurrentRow.Cells[6].Value.ToString() == "Non lu")
                    btnModifier.Enabled = true;
                if (rbRecu.Checked)
                    btnRepondre.Enabled = true;
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            cm.NouveauMessage(this, new MedMessage());
        }

        private void btnRepondre_Click(object sender, EventArgs e)
        {
            cm.Repondre(this, new MedMessage());
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cm.Modifier(this, new MedMessage());
        }

        private void dgvMessage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMessage.RowCount != 0)
            {
                cm.VoirMessage(this, new MedMessage());
            }
        }
        private void rbEnvoye_Click(object sender, EventArgs e)
        {
            cm.MsgEnvoyés(this);
        }

        private void rbRecu_Click(object sender, EventArgs e)
        {
            cm.MsgReçus(this);
        }
    }
}
