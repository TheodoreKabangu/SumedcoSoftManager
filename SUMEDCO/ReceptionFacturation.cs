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
    public partial class ReceptionFacturation : Form
    {
        public ReceptionFacturation()
        {
            InitializeComponent();
        }

        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public int idrecette = 0,
            idservice = 0,
            idpayeur = 0,
            idoperation = 0,
            idexercice = 0,
            idutilisateur;
        public bool ajoutvalide, recettePatientConsulte, fermeture_succes;
        public string poste = "", type_patient = "",
            numcompte = "",
            numcomptediffere = "4711";

        private void ReceptionFactureService_Shown(object sender, EventArgs e)
        {
            
            
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            
        }
    }
}
