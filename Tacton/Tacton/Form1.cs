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
        EnsembleTactons ens;//=new EnsembleTactons();
        public Form1()
        {
            ens = new EnsembleTactons();
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = panel1.CreateGraphics();
            
            //t.setOn(21);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }
 
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }  
 
        private void nouveauTactonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            //t.setOn(t.getCoordonnee(e.X, e.Y));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //t.repaint();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tactons t = new Tactons(this, 10, 10, 20, 100, 50);
           ens.ajouter(t);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //t.deplace(200, 100);
        }
    }
}