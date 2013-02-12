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
       private float amount;
       public bool isWall; 

        public GridCell(int side,int x, int y)
        {
            amount = 0;
            rectangle = new Rectangle(x, y, side, side);
        }

        public GridCell(int side, int x, int y, float amount)
        {
            this.amount = amount;
            rectangle = new Rectangle(x, y, side, side);
        }

        public virtual void DrawCell(Graphics g)
        {


            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;      // Horizontal Alignment
            stringFormat.LineAlignment = StringAlignment.Center;  // Vertical Alignment

            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rectangle);
            g.DrawString(this.Amount.ToString(".#"), new Font("Arial", 12), new SolidBrush(Color.Blue), rectangle, stringFormat);
        }

        public float Amount
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
