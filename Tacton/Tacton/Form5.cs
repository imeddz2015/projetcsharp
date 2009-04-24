using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tacton
{
    public partial class Form5 : Form
    {
        public Form1 f;
        public Brush deftacton_off;
        public Brush deftacton_on;
        public Brush defbordure;
        public EnsembleTactons e = new EnsembleTactons();
        public int pos = 0;
        public int boucle = 0;
        LRClickManager lr;
        bool infini = false;


        public Form5()
        {
            InitializeComponent();
            lr = new LRClickManager(this);
            lr += new LRMouseDownEventHandler(MajStatus);
        }

        public void afficher(Tactons temp)
        {
            e.vider();
            Tactons t = new Tactons(this, temp.x, temp.y, temp.tsize, 0, 0);
            t.chargerMatrice(temp.sauverMatrice().Replace(",", ""));
            e.ajouter(t);
            e.replacer();
        }
        public void MajStatus(object sender, MonEventArgs arg)
        {
            int ecart;
            int marge_pixel = 100;
            int marge_millisec = 300;
            TimeSpan t;
            t = arg.temps_up_t - arg.temps_down_t;
            ecart = arg.position_up_x - arg.position_down_x;
            if (ecart < -marge_pixel)
            {
                Console.WriteLine(
                    "désactivation de l'animation\n" +
                    "x:" + arg.position_down_x +
                    " y:" + arg.position_down_y +
                    " t:" + t.TotalMilliseconds +
                    "\nx:" + arg.position_up_x +
                    " y:" + arg.position_up_y +
                    " t:" + t.TotalMilliseconds
                    );
                tim.Enabled = false;
                this.Close();
            }
        }
        public void Affichage()
        {
            this.infini = this.f.vitesse_animation == 0;
           
            this.e.xd = 2; this.e.yd = 2;
            this.e.unite_temps=this.f.ens.unite_temps;
            this.defbordure = f.defbordure;
            this.deftacton_off = f.deftacton_off;
            this.deftacton_on = f.deftacton_on;
            this.boucle = this.f.boucle_animation-1;
            if (f.ens.items.Count < 1)
                return;
            Tactons temp = f.ens.items[pos++];
            this.Width = temp.width + 25;
            this.Height = temp.height + 50;
            /*if (this.Width < 100)
                this.Width = 120;
             */
            afficher(temp);
            //tim.Interval = Convert.ToInt32( Math.Round(1000.0 * Convert.ToDouble(temp.temps) * Convert.ToDouble(e.unite_temps) * (Convert.ToDouble(this.f.vitesse_animation) / 100.0)));
            if (this.f.vitesse_animation == 0)
                tim.Interval = Convert.ToInt32(Math.Round(1000.0 * Convert.ToDouble(temp.temps) * Convert.ToDouble(e.unite_temps)));
            else
                tim.Interval = Convert.ToInt32(Math.Round((this.f.vitesse_animation * 1000.0) / (this.f.ens.items.Count)));
                    
            tim.Enabled=true;
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
            Affichage();
            
        }

        private void Form5_Shown(object sender, EventArgs e)
        {
            
        }

        private void Form5_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Form5_Paint(object sender, PaintEventArgs e)
        {
            this.e.repaint();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tim.Enabled = false;
            if (pos < this.f.ens.items.Count)
            {
                afficher(this.f.ens.items[this.pos]);
                //tim.Interval = Convert.ToInt32(Math.Round(1000.0 * Convert.ToDouble(this.f.ens.items[this.pos++].temps) * Convert.ToDouble(this.e.unite_temps) * (Convert.ToDouble(this.f.vitesse_animation) / 100.0)));
                if (this.f.vitesse_animation == 0)
                    tim.Interval = Convert.ToInt32(Math.Round(1000.0 * Convert.ToDouble(this.f.ens.items[this.pos++].temps) * Convert.ToDouble(this.e.unite_temps)));
                else 
                {
                    tim.Interval = Convert.ToInt32(Math.Round((this.f.vitesse_animation*1000.0)/(this.f.ens.items.Count)));
                    pos++;
                }
                tim.Enabled = true;
            }
            else
                if (!infini && this.boucle ==0)
                    ;//MessageBox.Show("fini");
                else
                    {
                       this.boucle--;
                        this.pos = 0;
                        this.timer1_Tick(this, null);
                    }
        }

    }
}