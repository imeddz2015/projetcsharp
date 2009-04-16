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
            //Panel pan = new Panel();
            Graphics g = tableLayoutPanel1.CreateGraphics();
            //pan.CreateGraphics();
            paintCircle(6, 6, g);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void paintCircle(int x, int y, Graphics gr)
        {
            gr.FillEllipse(Brushes.MediumSlateBlue, x, y, 20, 20);
        }

    }
}