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
        Tactons t;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void paintCircle(int x, int y, Graphics gr)
        {
            gr.FillEllipse(Brushes.MediumSlateBlue, x, y, 20, 20);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            t = new Tactons(panel1, 10, 10, 20, 0, 0);
            t.setOn(10, 10);
        }

        private void nouveauTactonToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)

        {
            Environment.Exit(-1);
        }
    }
}