using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Tacton
{
    public class Tactons
    {
        public static int id = 0;
        public int idc;

        public Form p; //panel de référence
        private bool[,] matrice; //garde en mémoire l'état des tactons
        public Brush bordure = Brushes.White; // couleur de la bordure de la matrice
        public Brush tacton_off = Brushes.Beige; //couleur du tacton en position off
        public Brush tacton_on = Brushes.BlueViolet; //couleur du tactons en position on
        public int marge = 5; //marge entre les tactons

        public int tsize; //taille du tacton
        public int x=-1; //nombre de tactons en ligne
        public int y=-1; //nombre de tactons en colonne
        public int posx; //position left de la matrice
        public int posy; //position top de la matrice
        public int height; //hauteur  +2 pour le bord
        public int width; //largeur +2 pour le bord

        public int temps=1; //temps du tacton

        private Graphics getGraphics()
        { //renvoi le graphics du panel en cours
            return p.CreateGraphics();
        }
        public Tactons(Form p, int x, int y, int tsize, int posx, int posy)
        { //Constructeur avec marge
            this.buildTactons(p, x, y, tsize, posx, posy);
        }
        public Tactons(Form p, int x, int y, int tsize)
        { //constructeur sans marge
            this.buildTactons(p, x, y, tsize, 0, 0);
        }
        public void deplace(int x, int y)
        {
            //efface le vieu
            this.effacer();
            //maj
            this.posx = x;
            this.posy = y;
            //construit le nouveau
            this.repaint();
        }
        public void effacer()
        {
            this.getGraphics().FillRectangle((new Pen(this.p.BackColor)).Brush, posx, posy, width + 2, height + 2);
        }
        public void setOn(int pos)
        { //allume un tacton avec une position absolue
            int y = pos / this.x;
            int x = pos % this.x;
            this.setOn(x, y);
        }
        public void setOn(Point p)
        {
            this.setOn(p.X, p.Y);
        }
        public void setOn(int x, int y)
        { //allume le tacton avec des positions relatives
            if (x < this.x && y < this.y)
            {
                Rectangle r = new Rectangle(posx + (x * tsize) + marge + (marge * x), (marge * y) + posy + (y * tsize) + marge, tsize, tsize);//, posx + (i * tsize) + tsize, posy + (j * tsize) + tsize);
                this.getGraphics().FillEllipse(this.tacton_on, r);
                this.matrice[x, y] = true;
            }
            //else Console.WriteLine("hors limite");

        }
        public void setOff(int pos)
        {//éteint un tacton avec une position absolue
            int y = pos / this.x;
            int x = pos % this.x;
            this.setOff(x, y);
        }
        public void setOff(Point p)
        {
            this.setOff(p.X, p.Y);
        }
        public void setOff(int x, int y)
        { //éteint le tacton avec des positions relatives
            if (x < this.x && y < this.y)
            {
                Rectangle r = new Rectangle(posx + (x * tsize) + marge + (marge * x), (marge * y) + posy + (y * tsize) + marge, tsize, tsize);//, posx + (i * tsize) + tsize, posy + (j * tsize) + tsize);
                this.getGraphics().FillEllipse(this.tacton_off, r);
                this.matrice[x, y] = false;
            }
           // else Console.WriteLine("hors limite");

        }
        public Point getCoordonnee(int sx, int sy)
        { //Renvoie les coordonnée relative du tacton en fonction des coordonnées en pixel sur l'écran
            Point p=new Point();
            //p.X = sx / (this.tsize+this.marge);
            //p.Y = sy / (this.tsize+this.marge);
            p.X = (sx-this.posx) / (this.tsize + this.marge);
            p.Y = (sy-this.posy) / (this.tsize + this.marge);
            
            return p;
        }
        public bool isIn(int sx, int sy)
        {
            Point p = getCoordonnee(sx, sy);
            return p.X >= 0 && p.Y >= 0 && p.X < this.x && p.Y < this.y;
        }
        public void chargerMatriceDepuisFichier(string mat)
        { //charge la matrice a partir d'une séquence
            Xml x = new Xml();
            x.setNom(mat);
            x.open();       
            {
                string s = x.readStatic();
                string[] list = s.Split('#');
                this.y = Convert.ToInt32(list[0]);
                this.x = Convert.ToInt32(list[1]);
                chargerMatrice(list[2]);
            }
          x.free();
          //this.repaint();
        }
        public void chargerMatrice(string s)
        {
            int taille = Convert.ToInt32(Math.Sqrt(s.Length));
            if (this.x == -1) //si on ne sait pas, on considere un tacton carre donc de largeur sqrt()
                this.x = taille;
            if (this.y==-1)
                this.y = taille;
            this.matrice = new bool[this.x, this.y];
            int i, j;
            for (i = 0; i < this.x; i++)
                for (j = 0; j < this.y; j++)
                    if (s[(j*this.x) + i] == '1')
                        this.matrice[i, j] = true;
                    else
                        this.matrice[i, j] = false;
            //this.width = this.x * tsize + marge * this.x + marge;
            //this.height = this.y * tsize + marge * this.y + marge;
            this.calculSize();
        }
        public void sauverMatriceDansUnFichier(string fichier)
        { //sauve la matrice dans le fichier en parametre
            Xml x = new Xml();
            x.setNom(fichier);
            string bin = sauverMatrice();
            //MessageBox.Show(bin);
            x.writeStatic(bin);
            x.free();
        }
        public string sauverMatrice()
        { //renvoie le binaire statique
            string ret = "";
            int i, j;
            for (i = 0; i < this.y; i++)
            {
                for (j = 0; j < this.x; j++)
                    ret += this.matrice[j, i] ? "1" : "0";
                ret += ',';
            }
            return ret.Substring(0, ret.Length - 1);
        }
        public bool isOn(int x, int y)
        {
            if (x < 0 || y < 0 || x >= this.x || y >= this.y)
                return false;
            return this.matrice[x, y];
        }
        public bool isOn(Point p)
        {
            return isOn(p.X, p.Y);
        }
        public void repaint()
        { //repaind les tactons en fonction de la matrice de sauvegarde
            //pourtour
            if (this.p is Form1)
            {
                Form1 f = this.p as Form1;
                this.tacton_off = f.deftacton_off;
                this.tacton_on = f.deftacton_on;
                this.bordure = f.defbordure;
            }
            else
            {
                Form5 f = this.p as Form5;
                this.tacton_off = f.deftacton_off;
                this.tacton_on = f.deftacton_on;
                this.bordure = f.defbordure;
            }
           


            this.getGraphics().DrawRectangle(new Pen(this.bordure), posx, posy, width, height);
            //points
            int i, j;
            for (i = 0; i < this.x; i++)
                for (j = 0; j < this.y; j++)
                {
                    if (this.matrice[i, j])
                        this.setOn(i, j);
                    else
                        this.setOff(i, j);
                }
        }
        public void calculSize()
        {
            this.width = x * tsize + marge * x + marge;
            this.height = y * tsize + marge * y + marge;
        }
        private void buildTactons(Form f, int x, int y, int tsize, int posx, int posy)
        { // extension du constructeur, on assigne les variables par défaut et on construit notre classe
            //
            //this.p = new Panel();
            //this.p.Parent = f;
            this.idc = id++;
            this.p = f;
            this.x = x;
            this.y = y;
            this.tsize = tsize;
            this.posy = posy;
            this.posx = posx;
            //this.p.Left = this.posx;
            //this.p.Top = this.posy;
            this.matrice=new bool[x,y];
            //
            this.calculSize();
            //p.Width = width+posx+marge; p.Height = height+posy+marge;

            //Graphics g = this.getGraphics();
            //g.DrawRectangle(new Pen(this.bordure), posx, posy, width, height);
            int i, j;
            //int ligne=0;

            for (i = 0; i < x; i++)
                for (j = 0; j < y; j++)
                {
                    this.matrice[i, j] = false;
                    //this.setOff(i, j); //par défaut les tactons sont éteint
                }
        }
        public override string ToString()
        {
            return "OK ok reste cool";
        }
    }
}
