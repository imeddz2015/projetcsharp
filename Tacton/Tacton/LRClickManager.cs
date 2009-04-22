using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tacton
{
    public delegate void LRMouseDownEventHandler(object sender, MonEventArgs e);
    class LRClickManager
    {
        private int down_x, down_y, up_x, up_y;
        private DateTime down_t, up_t;
        private System.Windows.Forms.Control f;
        private int marge_pixel, marge_millisec, ecart;
        public event LRMouseDownEventHandler evenement;

        public LRClickManager(System.Windows.Forms.Control f)
        {
            f.MouseDown+=new System.Windows.Forms.MouseEventHandler(OnMouseDown);
            f.MouseUp += new System.Windows.Forms.MouseEventHandler(OnMouseUp);
            this.f = f;
        }

        public static LRClickManager operator +(LRClickManager man, LRMouseDownEventHandler evnt)
        {
            man.evenement+=evnt;
            return man;
        }

        private void statusStrip1_MouseUp(object sender, MouseEventArgs e)
        {
           /* if (e.Button == MouseButtons.Right)
                estDroiteClicke = false;
            else if (e.Button == MouseButtons.Left)
                estGaucheClicke = false;*/
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            marge_pixel = 100;
            marge_millisec = 300;
            TimeSpan t;
            MonEventArgs em = new MonEventArgs(e);
            if (e.Button == MouseButtons.Right)
            {
                em.position_up_x = e.X;
                em.position_up_y = e.Y;
                em.position_down_x = this.down_x;
                em.position_down_y = this.down_y;
                em.temps_up_t = DateTime.Now;
                em.temps_down_t = this.down_t;

                this.up_x = e.X;
                this.up_y = e.Y;
                this.up_t = DateTime.Now;

                Onevenement(em);
                
                
            }
        }   

        private void OnMouseDown(object sender,  MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.down_x = e.X;
                this.down_y = e.Y;
                this.down_t = DateTime.Now;
            }
        }
        public void Onevenement(MonEventArgs em)
        {
            if (em != null)
            {
                evenement(f, em);
                em.initialiser();
            }
        }
    }
}