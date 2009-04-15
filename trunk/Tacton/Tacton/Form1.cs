using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tacton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            Panel pan = new Panel();
            Graphics g = this.CreateGraphics();
            pan.CreateGraphics();
            g.FillEllipse(Brushes.MediumSlateBlue, 5, 10, 70, 70);
        }

    }
}