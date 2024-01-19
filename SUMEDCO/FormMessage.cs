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
    public partial class FormMessage : Form
    {
        public FormMessage()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        ClassStock cs = new ClassStock();
        public long idmessage = 0;
        public int idexpediteur = 0,
            iddest = 0;
        public bool modification, repondre;
        private void cboMedecin_DropDown(object sender, EventArgs e)
        {
            cm.ChargerDestinataire(cboMedecin, idexpediteur);
        }

        private void cboMedecin_SelectedIndexChanged(object sender, EventArgs e)
        {
            iddest = cs.TrouverId("user", cboMedecin.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cm.Annuler(this);
        }

        private void btnEnvoyer_Click(object sender, EventArgs e)
        {
            cm.Enregistrer(this);
        }
    }
}
