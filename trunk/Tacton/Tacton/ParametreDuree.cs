using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tacton
{
    public partial class Fduree : Form
    {
        public int duree = -1;
        public int unite = -1;
        public Fduree()
        {
            InitializeComponent();
        }
        public bool passed()
        {
            return duree != -1 && unite != -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.duree = Convert.ToInt32(tempsaff.Text);
            this.unite = Convert.ToInt32(unit.Text);
            this.Close();
        }

        public void maj()
        {
            //Console.WriteLine(this.unite.ToString() + " || " + this.duree.ToString());
            if (this.unite != -1)
                this.unit.Text = this.unite.ToString();
            if (this.duree != -1)
                this.tempsaff.Text = this.duree.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}