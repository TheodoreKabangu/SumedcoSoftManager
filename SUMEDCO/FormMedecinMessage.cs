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
    public partial class FormMedecinMessage : Form
    {
        public FormMedecinMessage()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public int idmessage = 0,
            idexpediteur = 0,
            iddestinataire = 0;
        public bool modification, repondre;
        private void cboMedecin_DropDown(object sender, EventArgs e)
        {
            if(!modification)
                cm.ChargerDestinataire(cboMedecin, idexpediteur);
        }

        private void cboMedecin_SelectedIndexChanged(object sender, EventArgs e)
        {
            iddestinataire = cm.TrouverId("medecin", cboMedecin.Text);
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
