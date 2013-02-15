using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using TryOut.Properties;
namespace TryOut.Grid
{
    
    class WallCell : GridCell
    {
        Rectangle rect, imageRectangle;
        Bitmap texture;
       TextureBrush textureBrush ;

       int size;

        public WallCell(int side, int x, int y, int locationX, int locationY) : base(side, x, y, locationX, locationY)
        {
            base.X = locationX;
            base.Y = locationY;


            base.isWall = true;
            base.isDestination = false;
            size = side;
            texture = new Bitmap(Resources.wall);
            textureBrush = new TextureBrush(texture);

            rect = new Rectangle(x, y, size+1, size);
            imageRectangle = new Rectangle(x, y , size +1, size +1);
        }

        public WallCell(GridCell gridCell) : base(gridCell.rectangle.Width, gridCell.rectangle.X, gridCell.rectangle.Y, gridCell.X, gridCell.Y)
        {
            base.X = gridCell.X;
            base.Y = gridCell.Y;
            base.isWall = true;
            size = gridCell.rectangle.Width;
            texture = new Bitmap(Resources.wall);
            textureBrush = new TextureBrush(texture);

            rect = new Rectangle(gridCell.rectangle.X, gridCell.rectangle.Y, size + 1, size);
            imageRectangle = new Rectangle(gridCell.rectangle.X, gridCell.rectangle.Y, size + 1, size + 1);
        }        

        public override void DrawCell(Graphics g)
        {
                g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), base.rectangle);
                g.FillRectangle(textureBrush, imageRectangle);
        }
    }


}
