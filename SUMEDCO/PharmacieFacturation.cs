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
    public partial class PharmacieFacturation : Form
    {
        public PharmacieFacturation()
        {
            InitializeComponent();
        }
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
        private void PharmacieFactureProduit_Load(object sender, EventArgs e)
        {
            
        }
    }
}
