using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tacton
{
    public delegate void LRMouseDownEventHandler(object sender, MonEventArgs e);
    class LRClickManager
    {
        private bool estGaucheClicke;
        private bool estDroiteClicke;
        private int down_x, down_y;
        private int up_x, up_y;
        private DateTime down_t, up_t;
        private System.Windows.Forms.Control f;
        private int marge_pixel, marge_millisec, ecart;
        public event LRMouseDownEventHandler evenement;

        public LRClickManager(System.Windows.Forms.Control f)
        {
            estGaucheClicke = estDroiteClicke = false;
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
            marge_pixel = 50;
            marge_millisec = 300;
            TimeSpan t;
            MonEventArgs em = new MonEventArgs(e);
            if (e.Button == MouseButtons.Right)
            {
                estDroiteClicke = true;
                em.position_x = e.X;
                this.up_x = e.X;
                this.up_y = e.Y;
                this.up_t = DateTime.Now;
                em.position_y = e.Y;
                em.temps_appuie = DateTime.Now.Millisecond.ToString();
                Onevenement(em);
                t = this.up_t - this.down_t;
                ecart = this.up_x - this.down_x;
                if (t.TotalMilliseconds >= marge_millisec)
                {
                    if (ecart > marge_pixel)
                    {
                        {
                            Console.WriteLine(
                                "activation de l'animation\n" +
                                "x:" + this.down_x +
                                " y:" + this.down_y +
                                " t:" + t.TotalMilliseconds +
                                "\nx:" + this.up_x +
                                " y:" + this.up_y +
                                " t:" + t.TotalMilliseconds
                                );
                        }
                    }
                    if (ecart < -marge_pixel)
                    {
                        Console.WriteLine(
                                "désactivation de l'animation\n" +
                                "x:" + this.down_x +
                                " y:" + this.down_y +
                                " t:" + t.TotalMilliseconds +
                                "\nx:" + this.up_x +
                                " y:" + this.up_y +
                                " t:" + t.TotalMilliseconds
                                );
                    }
                }
                else
                {
                    if ((ecart < marge_pixel )&& (ecart>=0))
                    {
                        {
                            Console.WriteLine(
                                "affichage des paramètres\n" +
                                "x:" + this.down_x +
                                " y:" + this.down_y +
                                " t:" + t.TotalMilliseconds +
                                "\nx:" + this.up_x +
                                " y:" + this.up_y +
                                " t:" + t.TotalMilliseconds
                                );
                        }
                    }
                    if ((ecart > -marge_pixel) && (ecart < -1))
                    {
                        Console.WriteLine(
                                "masquage des paramètres\n" +
                                "x:" + this.down_x +
                                " y:" + this.down_y +
                                " t:" + t.TotalMilliseconds +
                                "\nx:" + this.up_x +
                                " y:" + this.up_y +
                                " t:" + t.TotalMilliseconds
                                );
                    }
                }
            }
        }   

        private void OnMouseDown(object sender,  MouseEventArgs e)
        {
            MonEventArgs em = new MonEventArgs(e);
            if (e.Button == MouseButtons.Right)
            {
                estDroiteClicke = true;
                em.position_x = e.X;
                this.down_x = e.X;
                this.down_y = e.Y;
                this.down_t = DateTime.Now;
                em.position_y = e.Y;
                em.temps_appuie = DateTime.Now.Millisecond.ToString();
                Onevenement(em);
            }
        }
        public void Onevenement(MonEventArgs em)
        {
            if (em!=null)
                evenement(f, em);
        }
    }
}