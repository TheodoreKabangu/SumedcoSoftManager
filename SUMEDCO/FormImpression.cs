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
    public partial class FormImpression : Form
    {
        public FormImpression()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public int numbon=0,
            idmedecin = 0,
            idconsultation = 0;
        public string patient = "",
            medecin = "",
            numfiche= "",
            beneficiaire,
            montantlettre,
            montantchiffre,
            monnaie,
            motif,
            bonrequisition,
            date_jour,
            
            payeur;

        private void FormImpression_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }  
}
