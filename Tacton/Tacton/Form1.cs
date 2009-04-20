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
                ens.vider();
                Tactons t = new Tactons(this, this.defx, this.defy, this.deftactonsize);
                t.chargerMatriceDepuisFichier(openFileDialog1.FileName);
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
                ens.vider();
                this.ens.chargerDynamiqueDepuisFichier(openFileDialog1.FileName, this);
                enableOpen();
            }
        }

        private void nouveauTactonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ens.vider();
            //demander nombre de point
            ajouterTactonToolStripMenuItem_Click(this,null);
            enableOpen();
            ens.repaint();
        }

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ens.vider();
            disableOpen();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (ens.items.Count > 1)
            { //enregistrement animation
                MessageBox.Show("Vous allez procéder a l'enregistrement d'une séquence");
                saveFileDialog1.FileName = "";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                    {
                     ens.sauveDynamiqueDansFichier(saveFileDialog1.FileName);
                    }
            }
            else
            { //enregistrement tacton
                MessageBox.Show("Vous allez procéder a l'enregistrement d'un tacton seul");
                saveFileDialog1.FileName = "";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                    {
                    Tactons t = ens.items[0];
                    t.sauverMatriceDansUnFichier(saveFileDialog1.FileName);
                    }
            }
        }

    }
}