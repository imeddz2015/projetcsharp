using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tacton
{
    public partial class tsize : Form
    {
        public bool valide = false;
        public int nbl;
        public int nbc;
        public tsize()
        {
            InitializeComponent();
        }

        public void charger()
        {
            this.nblb.Text=nbl.ToString();
            this.nbcb.Text= nbc.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.nbc = Convert.ToInt32(this.nbcb.Text);
            this.nbl = Convert.ToInt32(this.nblb.Text);
            if (nbc > 0 && nbl > 0)
            {
                this.valide = true;
                this.Close();
            }
            else
                MessageBox.Show("Nombre de lignes / colonnes non valide");
        }
    }
}