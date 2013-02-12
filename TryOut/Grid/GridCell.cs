using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryOut.Grid
{
    class GridCell
    {
       public Rectangle rectangle;
       private RectangleF rectangleF;
       private int amount;
       public bool isWall; 

        public GridCell(int side,int x, int y)
        {
            amount = 0;
            rectangle = new Rectangle(x, y, side, side);
        }

        public GridCell(int side, int x, int y, int amount)
        {
            this.amount = amount;
            rectangle = new Rectangle(x, y, side, side);
            rectangleF = rectangle;
        }

        public virtual void DrawCell(Graphics g, Color c)
        {


            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;      // Horizontal Alignment
            stringFormat.LineAlignment = StringAlignment.Near;  // Vertical Alignment

            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rectangle);
            g.DrawString(amount.ToString(), new Font("Arial", 16), new SolidBrush(Color.Blue), rectangleF.X,rectangleF.Y, stringFormat);
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public int X
        {
            get { return rectangle.X; }
        }

        public int Y
        {
            get { return rectangle.Y; }
        }

        public int SideSize
        {
            get { return rectangle.Width; }
        }
        
    }
}
