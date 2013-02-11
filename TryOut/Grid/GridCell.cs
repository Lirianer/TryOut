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
       private int side;
       private int x, y;

        public GridCell(int side,int x, int y)
        {
            this.side = side;
            this.x = x;
            this.y = y;
        }

        public virtual void DrawCell(Graphics g)
        {
            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), x,y,side,side);
        }

        public int getSide
        {
            get { return side; }
        }
        
    }
}
