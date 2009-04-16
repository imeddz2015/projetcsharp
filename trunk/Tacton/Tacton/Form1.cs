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
            Point[] po = new Point[] { new Point(0, 0), new Point(120, 0), new Point(120, 120), new Point(0, 120), new Point(0, 0) };
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
        }


    }
}