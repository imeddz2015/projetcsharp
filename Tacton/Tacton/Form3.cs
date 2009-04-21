using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tacton
{
    public partial class Form3 : Form
    {
        public Color ta;
        public Color te;
        public Color bor;
        public int tt;

        public Form3()
        {
            InitializeComponent();
            this.tactal.Select(0, 0);
            this.tactb.Select(0, 0);
            this.tactet.Select(0, 0);
        }

        public void charger()
        {

            this.tactal.BackColor = this.ta;
            this.tactet.BackColor = this.te;
            this.tactb.BackColor = this.bor;
            this.taille.Text = this.tt.ToString();
        }


        private void textBox1_Click(object sender, EventArgs e)
        {
            colorbox.Color = ((sender) as TextBox).BackColor;
            colorbox.ShowDialog();
            if (!colorbox.Color.IsEmpty)
            {
                ((sender) as TextBox).BackColor = colorbox.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.ta = tactal.BackColor;
            this.te = tactet.BackColor;
            this.bor = tactb.BackColor;
            this.tt = Convert.ToInt32(taille.Text);
            this.Close();
        }
    }
}