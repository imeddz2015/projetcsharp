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
        Tactons t;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = tableLayoutPanel1.CreateGraphics();
            paintCircle(6, 6, g);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void paintCircle(int x, int y, Graphics gr)
        {
            gr.FillEllipse(Brushes.MediumSlateBlue, x, y, 20, 20);
        }

        private void createTablePanel(string nom)
        {
            TableLayoutPanel s = new TableLayoutPanel();
            s.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            s.ColumnCount = 4;
            s.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            s.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            s.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            s.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            s.Cursor = System.Windows.Forms.Cursors.Hand;
            s.Location = new System.Drawing.Point(16, 48);
            s.Name = nom;
            s.RowCount = 4;
            s.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            s.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            s.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            s.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            s.Size = new System.Drawing.Size(120, 120);
            s.TabIndex = 1;
            Graphics g = s.CreateGraphics();
            //this.s.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            
        }

        private void nouveauTactonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createTablePanel("panel1");
           // Graphics g = .CreateGraphics();
           // paintCircle(6, 6, g);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            //this.dessiner(panel1,g,10, 10, 20, 0, 0);
            t = new Tactons(panel1, 10, 10, 20, 0, 0);
            t.setOn(10, 10);
            /*Point[] po = new Point[] { new Point(0, 0), new Point(120, 0), new Point(120, 120), new Point(0, 120), new Point(0, 0) };
            Pen col = Pens.White;
            g.DrawLines(col, po);
            g.DrawLine(col, 0, 0, 120, 0);
            g.DrawLine(col, 0, 120, 120, 120);
            g.DrawLine(col, 0, 30, 120, 30);
            g.DrawLine(col, 0, 60, 120, 60);
            g.DrawLine(col, 0, 90, 120, 90);
            g.DrawLine(col, 30, 0, 30, 120);
            g.DrawLine(col, 60, 0, 60, 120);
            g.DrawLine(col, 90, 0, 90, 120);
             */
        }
        

    }
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
            this.buildTactons(p,x,y,tsize,posx,posy);
        }
        public Tactons(Panel p, int x, int y, int tsize)
        { 
            this.buildTactons(p,x,y,tsize,0,0);
        }

        public void setOn(int pos)
        {
            int x=pos/this.x;
            int y=pos%this.x;
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
            int width = x * tsize+marge*x+marge;
            int height = y * tsize+marge*y+marge;
            p.Width = width+2; p.Height = height+2;
            Graphics g=this.getGraphics();
            g.DrawRectangle(new Pen(this.bordure), posx, posy, width, height);
            int i, j;
            //int ligne=0;
            
            for (i = 0; i < x; i++)
                for (j = 0; j < y; j++)
                {
                    Rectangle r = new Rectangle(posx + (i * tsize)+marge+(marge*i),(marge*j)+ posy + (j * tsize)+marge, tsize, tsize);//, posx + (i * tsize) + tsize, posy + (j * tsize) + tsize);
                    //Console.WriteLine(r.ToString());
                    g.FillEllipse(this.tacton_off, r);
                    
                }
        }
        
    }
}