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
       public bool isWall; 

        public GridCell(int side,int x, int y)
        {
            rectangle = new Rectangle(x, y, side, side);
        }

        public virtual void DrawCell(Graphics g, Color c)
        {
            
            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rectangle);
            
        }
        
    }
}
