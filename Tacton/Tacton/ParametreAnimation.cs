using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tacton
{
    public partial class ParametreAnimation : Form
    {
        public bool valide = false;
        public int v_anim, b_anim;
        LRClickManager lr;
        public void MajStatus(object sender, MonEventArgs arg)
        {
            int ecart;
            int marge_pixel = 100;
            int marge_millisec = 300;
            TimeSpan t;
            t = arg.temps_up_t - arg.temps_down_t;
            //t = em.temps_up_t - em.temps_down_t;

            ecart = arg.position_up_x - arg.position_down_x;
            //ecart = em.position_up_x - em.position_down_x;

            if ((ecart > -marge_pixel) && (ecart < -1))
            {
                /*
                Console.WriteLine(
                    "masquage des paramètres\n" +
                    "x:" + arg.position_down_x +
                    " y:" + arg.position_down_y +
                    " t:" + t.TotalMilliseconds +
                    "\nx:" + arg.position_up_x +
                    " y:" + arg.position_up_y +
                    " t:" + t.TotalMilliseconds
                    );
                 */ 
                button2_Click(this, null);
            }
            
        }
        public ParametreAnimation()
        {
            InitializeComponent();
            lr = new LRClickManager(this);
            lr += new LRMouseDownEventHandler(MajStatus);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.boucle_anim.Text)>=0)
            {
                b_anim = Convert.ToInt32(this.boucle_anim.Text);
                v_anim= Convert.ToInt32(this.vitesse_anim.Text);
                this.valide = true;
                this.Close();
            }
            else 
                MessageBox.Show("Boucle / vitesse de l'animation non valide");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void charger()
        {
            this.boucle_anim.Text = b_anim.ToString();
            this.vitesse_anim.Text = v_anim.ToString();
        }

    }
}