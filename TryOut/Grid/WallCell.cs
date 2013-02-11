using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace TryOut.Grid
{
    
    class WallCell : GridCell
    {
        Rectangle rect;
        Image image;
        Bitmap texture;
        string location = "C:/Users/Gabriel/Documents/Visual Studio 2012/Projects/TryOut/TryOut/resources/wall.bmp";
       TextureBrush textureBrush ;

       int size;
        public WallCell(int side, int x, int y) : base(side, x, y)
        {
            base.isWall = true;
            size = side;
                texture = new Bitmap(location);
                textureBrush = new TextureBrush(texture);

            rect = new Rectangle(x, y, size, size);
        }
        

        public override void DrawCell(Graphics g, Color c)
        {
                g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rectangle);
                g.FillRectangle(textureBrush, rectangle);
        }
    }


}
