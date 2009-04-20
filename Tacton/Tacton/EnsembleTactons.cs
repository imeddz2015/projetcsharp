using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
