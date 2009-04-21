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
        

        public void MajStatus(object sender, MonEventArgs arg)
        {
        }

  

 

 


        



        //OK OK

        public Form1()
        {
            ens = new EnsembleTactons();
            InitializeComponent();
            lr = new LRClickManager(this);
            lr += new LRMouseDownEventHandler(MajStatus);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.ens.repaint();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Tactons t = this.ens.getByMouse(e.X, e.Y);
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

        public void enableOpen()
        {
            editionToolStripMenuItem.Enabled = true;
            affichageToolStripMenuItem.Enabled = true;
            toolStripMenuItem2.Enabled = true;
        }

        public void disableOpen()
        {
            editionToolStripMenuItem.Enabled = false;
            affichageToolStripMenuItem.Enabled = false;
            toolStripMenuItem2.Enabled = false; //enregistrer
        }

        private void chargerUnTactonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                
                Tactons t = new Tactons(this, this.defx, this.defy, this.deftactonsize);
                try
                {
                    t.chargerMatriceDepuisFichier(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Impossible d'ouvrir le tacton :\n" + ex.Message);
                    return;
                }
                ens.vider();
                this.ens.ajouter(t);
                enableOpen();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disableOpen();
        }

        private void chargerUneanimationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {

                try
                {
                    this.ens.chargerDynamiqueDepuisFichier(openFileDialog1.FileName, this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Impossible de charger l'animation :\n" + ex.Message);
                    return;
                }
                ens.vider();
                enableOpen();
            }
        }

        private void nouveauTactonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //demander nombre de point
            tsize t = new tsize();
            t.nbc = this.defy;
            t.nbl = this.defx;
            t.charger();
            t.ShowDialog();
            if (t.valide)
            {
                this.defx = t.nbl;
                this.defy = t.nbc;
                ens.vider();
                ajouterTactonToolStripMenuItem_Click(this, null);
                enableOpen();
                ens.repaint();
            }
        }

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ens.vider();
            disableOpen();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (ens.items.Count == 0)
            {
                MessageBox.Show("Aucun tacton a enregistrer");
                return;
            }
            if (ens.items.Count > 1)
            { //enregistrement animation
                MessageBox.Show("Vous allez proc�der a l'enregistrement d'une s�quence");
                saveFileDialog1.FileName = "";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                    {
                     ens.sauveDynamiqueDansFichier(saveFileDialog1.FileName);
                    }
            }
            else
            { //enregistrement tacton
                MessageBox.Show("Vous allez proc�der a l'enregistrement d'un tacton seul");
                saveFileDialog1.FileName = "";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                    {
                    Tactons t = ens.items[0];
                    t.sauverMatriceDansUnFichier(saveFileDialog1.FileName);
                    }
            }
        }

        private void menuStrip1_Paint(object sender, PaintEventArgs e)
        {
            this.ens.repaint();
        }

        private void parametresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*public int deftactonsize = 20;
        public Brush defbordure = Brushes.White; // couleur de la bordure de la matrice
        public Brush deftacton_off = Brushes.Beige; //couleur du tacton en position off
        public Brush deftacton_on = Brushes.BlueViolet;
            */
            Form3 f = new Form3();
            Color toff, ton, bor;
            bool changement = false;
            Pen p = new Pen(this.deftacton_off);
            toff = p.Color;
            f.te = toff;
            p = new Pen(this.deftacton_on);
            ton = p.Color;
            f.ta = ton;
            p = new Pen(this.defbordure);
            bor = p.Color;
            f.bor = bor;
            f.tt = this.deftactonsize;
            f.charger();
            f.ShowDialog();
            //MessageBox.Show(f.te.ToString());
            if (f.te.ToArgb() != toff.ToArgb())
            {
                //MessageBox.Show("off dif");
                changement = true;
                this.deftacton_off = (new Pen(f.te)).Brush;
            }
            if (f.ta.ToArgb() != ton.ToArgb())
            {
                //MessageBox.Show("on dif");
                changement = true;
                this.deftacton_on = (new Pen(f.ta)).Brush;
            }
            if (f.bor.ToArgb() != bor.ToArgb())
            {
                //MessageBox.Show("bord dif");
                changement = true;
                this.defbordure = (new Pen(f.bor)).Brush;
            }
            if (this.deftactonsize != f.tt)
            {
                //MessageBox.Show("size dif");
                changement = true;
                this.deftactonsize = f.tt;
                this.ens.setTactonSize(this.deftactonsize);
            }
            if (changement)
                this.ens.repaint();
        }

    }
}