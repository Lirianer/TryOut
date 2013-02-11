using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace TryOut.Grid
{
    
    class WallCell : GridCell
    {
        public WallCell(int side, int x, int y) : base(side, x, y)
        {
            base.isWall = true;
            base.rectangle = new Rectangle(x, y, side, side);
        }
        

        public override void DrawCell(Graphics g, Color c)
        {
            g.FillRectangle(new SolidBrush(c), base.rectangle);
        }
    }


}
