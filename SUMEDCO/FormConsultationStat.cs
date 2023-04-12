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
    public partial class FormConsultationStat : Form
    {
        public FormConsultationStat()
        {
            InitializeComponent();
        }
        public int idmedecin = 0,
            idservice=0;
        //SELECT nomservice, COUNT(Consultation.idconsultation) FROM Consultation, PriseSigneVitaux, Recette, RecetteService, Service WHERE Consultation.idprise = PriseSigneVitaux.idprise AND PriseSigneVitaux.idrecette = Recette.idrecette AND idmedecin = '"+s.idmedecin+"' AND Recette.idrecette = RecetteService.idrecette AND RecetteService.idservice = Service.idservice AND nomservice IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence') GROUP BY nomservice
        ClassMalade cm = new ClassMalade();
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.ResumeCas(this);
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRdv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvRdv.RowCount != 0)
            {
                btnEnregistrer.Enabled = true;
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cm.AjouterOBsRDV(this);
        }
    }
}
