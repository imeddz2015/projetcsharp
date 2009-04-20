using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tacton
{
    class EnsembleTactons
    {
        static int xd = 10;
        static int yd = 40;
        static int marge = 20;
        int xfree = xd-marge;
        int yfree = yd;
        int heighmax = 0;
        Form f;

        public List<Tactons> items=new List<Tactons>();
        public void ajouter(Tactons t)
        {
            if (t == null)
                return;
            if (xfree + t.width > t.p.Width)
            {
                yfree = yfree + heighmax + marge;
                xfree = xd-marge;
                heighmax = 0;
            }
            t.posx = xfree + marge;
            t.posy = yfree;
            //maj des espace libre
            xfree = xfree + marge + t.width;
            if (t.height > heighmax)
                heighmax = t.height;
            //yfree = yfree + marge + t.height;
            //Console.WriteLine(t);
            this.items.Add(t);
            t.repaint();
        }

        public void replacer()
        {
            xfree = xd - marge;
            yfree = yd;
            heighmax = 0;
            
            foreach (Tactons t in this.items)
            {
             if (xfree + t.width > t.p.Width)
                {
                    yfree = yfree + heighmax + marge;
                    xfree = xd - marge;
                    heighmax = 0;
                }
              t.deplace(xfree + marge, yfree);
              xfree = xfree + marge + t.width;
              if (t.height > heighmax)
                  heighmax = t.height;
              //Console.WriteLine(xfree.ToString() + " === " + yfree.ToString());
              
            }
        }

        public void effacer(Tactons t)
        {
            t.effacer();
            this.items.Remove(t);
        }
        public Tactons getByMouse(int x, int y)
        {
            //Tactons t=null;
            foreach (Tactons t in this.items)
            {
                if (t.isIn(x, y))
                    return t;
            }
            return null;
        }
        public void repaint()
        {
            foreach (Tactons t in this.items)
                t.repaint();
        }

        public void chargerDynamiqueDepuisFichier(string fic, Form f)
        {
            Xml x = new Xml();
            x.setNom(fic);
            x.open();
            string s = x.readDynamique();
            this.f = f;
            chargerDynamique(s);
            x.free();
        }
        public void chargerDynamique(string bin)
        {
            
            string[] t = bin.Split('#');
            string val=t[3];
            string[] ens = val.Split(' ');
            int i;
            MessageBox.Show(bin);
            for (i = 0; i < ens.Length; i = i + 2)
            {
                int taille=Convert.ToInt32(Math.Sqrt(ens[i+1].Length));
                Tactons ta = new Tactons(this.f, taille, taille, 20);
                ta.temps = Convert.ToInt32(ens[i]);
                ta.chargerMatrice(ens[i + 1]);
                this.ajouter(ta);
            }
        }
    }
}
