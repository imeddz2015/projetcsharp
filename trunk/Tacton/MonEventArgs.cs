using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tacton
{
    class MonEventArgs : MouseEventArgs
    {
        private string _bouton1;
        private string _bouton2;
        private string _temps;
        private int x, y;
        private string t;

        public MonEventArgs(MouseEventArgs e): base(e.Button, e.Clicks, e.X, e.Y, e.Delta)
        {
            _bouton1 = _bouton2 = _temps = t = "";
            x = y = 0;
        }
        public string bouton1
        {
            get { return _bouton1; }
            set { _bouton1 = value; }
        }
        public string bouton2
        {
            get { return _bouton2; }
            set { _bouton2 = value ; }
        }
        public string temps
        {
            get { return _temps; }
            set { _temps = value; }
        }
        public int position_x
        {
            get { return x; }
            set { x = value; }
        }

        public int position_y
        {
            get { return y; }
            set { y = value; }
        }
        public string temps_appuie
        {
            get { return t; }
            set { t = value; }
        }
    }
}
