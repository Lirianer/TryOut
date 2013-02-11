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
        }

        public virtual void DrawCell(Graphics g, Color c)
        {
            
            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rectangle);
            
        }
        
    }
}
