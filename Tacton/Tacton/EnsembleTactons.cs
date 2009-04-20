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
    }
}
