using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Tacton
{
    class Tactons
    {
        private Panel p;
        public Brush bordure = Brushes.White;
        public Brush tacton_off = Brushes.Gray;
        public Brush tacton_on = Brushes.BlueViolet;
        public int marge = 5;

        public int tsize;
        public int x;
        public int y;
        public int posx;
        public int posy;
        private Graphics getGraphics()
        {
            return p.CreateGraphics();
        }
        public Tactons(Panel p, int x, int y, int tsize, int posx, int posy)
        {
            this.buildTactons(p, x, y, tsize, posx, posy);
        }
        public Tactons(Panel p, int x, int y, int tsize)
        {
            this.buildTactons(p, x, y, tsize, 0, 0);
        }

        public void setOn(int pos)
        {
            int x = pos / this.x;
            int y = pos % this.x;
            this.setOn(x, y);
        }
        public void setOn(int x, int y)
        {
            if (x < this.x && y < this.y)
            {
                Rectangle r = new Rectangle(posx + (x * tsize) + marge + (marge * x), (marge * y) + posy + (y * tsize) + marge, tsize, tsize);//, posx + (i * tsize) + tsize, posy + (j * tsize) + tsize);
                this.getGraphics().FillEllipse(this.tacton_on, r);
            }
            else Console.WriteLine("hors limite");

        }
        private void buildTactons(Panel p, int x, int y, int tsize, int posx, int posy)
        {
            //
            this.p = p;
            this.x = x;
            this.y = y;
            this.tsize = tsize;
            this.posy = posy;
            this.posx = posx;
            //
            int width = x * tsize + marge * x + marge;
            int height = y * tsize + marge * y + marge;
            p.Width = width + 2; p.Height = height + 2;
            Graphics g = this.getGraphics();
            g.DrawRectangle(new Pen(this.bordure), posx, posy, width, height);
            int i, j;
            //int ligne=0;

            for (i = 0; i < x; i++)
                for (j = 0; j < y; j++)
                {
                    Rectangle r = new Rectangle(posx + (i * tsize) + marge + (marge * i), (marge * j) + posy + (j * tsize) + marge, tsize, tsize);//, posx + (i * tsize) + tsize, posy + (j * tsize) + tsize);
                    //Console.WriteLine(r.ToString());
                    g.FillEllipse(this.tacton_off, r);

                }
        }

    }
}