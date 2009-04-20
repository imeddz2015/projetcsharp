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
        Point MousePosition=new Point(0,0);
        LRClickManager lr;
        public int defx = 4;
        public int defy = 4;
        public int deftactonsize = 20;
        public Brush defbordure = Brushes.White; // couleur de la bordure de la matrice
        public Brush deftacton_off = Brushes.Beige; //couleur du tacton en position off
        public Brush deftacton_on = Brushes.BlueViolet;

        public bool clicked;
        public Form1()
        {
            ens = new EnsembleTactons();
            InitializeComponent();
            lr = new LRClickManager(this);
            lr += new LRMouseDownEventHandler(MajStatus);
        }

        public void MajStatus(object sender, MonEventArgs arg)
        {
        }

  
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }
 

 
    


        private void button1_Click(object sender, EventArgs e)
        {
            //t.repaint();.
            ens.repaint();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tactons t = new Tactons(this, 4, 4, 20, 100, 50);
           ens.ajouter(t);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //t.deplace(200, 100);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Tactons t=this.ens.getByMouse(e.X, e.Y);
            //MessageBox.Show(e.X.ToString() + ", " + e.Y.ToString());
            if (t != null)
            {
                //Console.WriteLine(t.idc.ToString());
                Point p = t.getCoordonnee(e.X, e.Y);
                if (t.isOn(p))
                    t.setOff(p);
                else
                    t.setOn(p);
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Tactons t = this.ens.getByMouse(e.X, e.Y);
            if (t != null)
            {
                this.ens.effacer(t);
                this.ens.replacer();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ens.replacer();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            /**/
            openFileDialog1.ShowDialog();
            this.ens.chargerDynamiqueDepuisFichier(openFileDialog1.FileName, this);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            saveFileDialog1.ShowDialog();
            /*
            Tactons t = ens.items[0];
            t.sauverMatriceDansUnFichier(saveFileDialog1.FileName);
             */
            ens.sauveDynamiqueDansFichier(saveFileDialog1.FileName);
        }

        

        private void button7_Click(object sender, EventArgs e)
        {
            this.ens.vider();
        }


        //OK OK

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.ens.repaint();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            //Console.WriteLine(this.MousePosition.ToString());
            Tactons t = this.ens.getByMouse(this.MousePosition.X,this.MousePosition.Y);
            if (t != null)
            {
                this.ens.effacer(t);
                this.ens.replacer();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.MousePosition.X = e.X;
            this.MousePosition.Y = e.Y;
        }

        private void ajusterLeTempsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tactons t = this.ens.getByMouse(this.MousePosition.X,this.MousePosition.Y);
            if (t != null)
            {
                Fduree f = new Fduree();
                if (t.temps != -1)
                    f.duree = t.temps;
                if (ens.unite_temps != -1)
                    f.unite = ens.unite_temps;
                //Console.WriteLine(t.temps.ToString()+" ,,,, "+ens.unite_temps.ToString());
                f.maj();
                f.ShowDialog();
                if (f.passed())
                {
                    //Console.WriteLine(f.duree.ToString()+" "+f.unite.ToString());
                    t.temps = f.duree;
                    ens.unite_temps = f.unite;
                }
            }
        }

        private void repeindreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ens.repaint();
        }

        private void ajouterTactonToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Tactons t = new Tactons(this, this.defx, this.defy,this.deftactonsize);
           ens.ajouter(t);
        }

        private void chargerUnTactonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.ShowDialog();
            if (openFileDialog1.
            Tactons t = new Tactons(this, this.defx, this.defy, this.deftactonsize);
            t.chargerMatriceDepuisFichier(openFileDialog1.FileName);
            this.ens.ajouter(t);
        }

    }
}