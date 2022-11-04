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
    public partial class Accueil : Form
    {
        public Accueil()
        {
            InitializeComponent();
        }

        int nbfois = 0, counter = 0;
        int len = 0, progress = 0;
        string txt, txt2;
        private void Form1_Load(object sender, EventArgs e)
        {
            txt = "abcdefghijklmnopqrstuvwxyz";
            label2.Text = label2.Text + " " + DateTime.Now.ToShortDateString();
            len = txt.Length;
            timer1.Start();
            timer2.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter > len)
            {
                counter = 0;
                txt2 = "";
                nbfois++;
                if (nbfois == 1)
                {
                    panel1.BackColor = Color.LightSteelBlue;
                    panel2.BackColor = Color.LightSteelBlue;
                }
                if (nbfois == 2)
                {
                    panel1.BackColor = Color.FromArgb(180, 200, 255);
                    panel2.BackColor = Color.FromArgb(180, 200, 255);
                }
                if (nbfois == 3)
                {
                    panel1.BackColor = Color.LightSteelBlue;
                    panel2.BackColor = Color.LightSteelBlue;
                }
                if (nbfois == 4)
                {
                    panel1.BackColor = Color.FromArgb(180, 200, 255);
                    panel2.BackColor = Color.FromArgb(180, 200, 255);
                }
                if (nbfois == 5)
                {
                    timer1.Stop();
                    panel1.BackColor = Color.LightSteelBlue;
                    panel2.BackColor = Color.LightSteelBlue;
                }
            }
            else
            {
                txt2 = txt.Substring(0, counter);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progress += 1;
            if (progress >= 100)
            {
                progressBar1.Value = progressBar1.Maximum;
                lblpercent.Text = "Chargement à 100 %";
            }
            else
            {
                progressBar1.Value = progress;
                lblpercent.Text = "Chargement à " + progress.ToString() + " %";
            }
            if (progress == 110)
            {
                timer2.Stop();
                new FormAccueil().Show();
                this.Hide();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
