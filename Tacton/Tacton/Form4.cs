using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tacton
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ()
            {
                this.Close();
            }
            else 
                MessageBox.Show("Boucle / vitesse de l'animation non valide");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}