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
    public partial class FormRenseignement : Form
    {
        public FormRenseignement()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public int idligneagenda = 0, 
            idligne = 0,
            idsigne = 0,
            idconsultation = 0, 
            idmedecin= 0, 
            idpatient=0,
            nbligne_trouve = 0;
        public string motif = "", type_consultation ="";
        public bool ajoutvalide;
        private void btnValider_Click(object sender, EventArgs e)
        {
            cm.ValiderLigne(this);
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.RowCount != 0)
            {
                if (cboMotif.Text != "examen physique")
                {
                    txtLibelle.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
                    btnRetirer.Enabled = true;
                }
                else
                    txtLibelle.Text = dgv1.CurrentRow.Cells[2].Value.ToString();
                txtLibelle.Select();
            }            
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            dgv1.Rows.RemoveAt(dgv1.CurrentRow.Index);
            cm.Annuler(this);
            cm.RemplirNumLigne(dgv1, 0);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {

        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                txtRepondant.Enabled = true;
                cboLienRepondant.Enabled = true;
                txtRepondant.Select();
            }
            else
            {
                txtRepondant.Text = "";
                txtRepondant.Enabled = false;
                cboLienRepondant.DropDownStyle = ComboBoxStyle.DropDown;
                cboLienRepondant.SelectedText = "";
                cboLienRepondant.DropDownStyle = ComboBoxStyle.DropDownList;
                cboLienRepondant.Enabled = false;
            }
        }
    }
}
