using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool poradi = true;
        int poradi_cislo = 0;
        bool vyhra;
        private void zmacknuto(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (poradi)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            poradi = !poradi;

            b.Enabled = false;
            poradi_cislo++;
            vyhraCheck();
        }

        private void novaHraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            poradi = true;
            poradi_cislo = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Text = "";
                    b.Enabled = true;
                }
            }
            catch { }
        }

        private void jakHratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("klasické piškvorky, pospojuj 3  X/O vedle sebe horizontálně, diagonálně a křížem", "pravidla");

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void vyhraCheck()
        {
            vyhra = false;

            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                vyhra = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                vyhra = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                vyhra = true;
            }
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                vyhra = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                vyhra = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                vyhra = true;
            }

            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                vyhra = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
            {
                vyhra = true;
            }




            if (vyhra)
            {
                reset();

                string vitez;

                if (poradi)
                {
                    vitez = "O";
                }
                else
                {
                    vitez = "X";
                }

                MessageBox.Show(vitez + " vyhrava", "konec hry");
            }
            else
            {
                if (poradi_cislo == 9)
                {
                    MessageBox.Show("remiza", "konec hry");
                }
            }
        }


        private void reset()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { };
        }
    }
}
