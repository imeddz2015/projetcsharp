using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tacton
{
    public class MonEventArgs : MouseEventArgs
    {
        private int up_x, up_y, down_x, down_y;
        private DateTime down_t, up_t;
        private TimeSpan t;

        public MonEventArgs(MouseEventArgs e): base(e.Button, e.Clicks, e.X, e.Y, e.Delta)
        {
        }

        public TimeSpan temps_appuie
        {
            get { return t; }
            set { t = up_t - down_t;}
        }

        public int position_up_x
        {
            get { return up_x; }
            set { up_x = value; }
        }

        public int position_up_y
        {
            get { return up_y; }
            set { up_y = value; }
        }

        public int position_down_x
        {
            get { return down_x; }
            set { down_x = value; }
        }

        public int position_down_y
        {
            get { return down_y; }
            set { down_y = value; }
        }

        public DateTime temps_down_t
        {
            get { return down_t; }
            set { down_t = value; }
        }

        public DateTime temps_up_t
        {
            get { return up_t; }
            set { up_t = value; }
        }
    }
}
