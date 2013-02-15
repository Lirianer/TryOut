using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TryOut.Properties;

namespace TryOut.Grid
{
    class DestinationCell : GridCell
    {
        int size;

        Rectangle rect, imageRectangle;
        Bitmap texture;
        TextureBrush textureBrush;
        double amountToWin;

        public DestinationCell (GridCell cell, double amountToWin) : base(cell)
        {
            base.X = cell.X;
            base.Y = cell.Y;
            this.amountToWin = amountToWin;

            base.cellCompleted = false;
            base.isWall = false;
            base.isDestination = true;
            size = cell.rectangle.Width;
            texture = new Bitmap(Resources.destination);
            textureBrush = new TextureBrush(texture);

            rect = new Rectangle(cell.rectangle.X, cell.rectangle.Y, size + 1, size);
            imageRectangle = new Rectangle(cell.rectangle.X, cell.rectangle.Y, size + 1, size + 1);
        }

        public override void DrawCell(Graphics g)
        {
            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), base.rectangle);
            g.FillRectangle(textureBrush, imageRectangle);
            if (this.oldAmount >= amountToWin)
            {
                cellCompleted = true;
            }
            
        }

        public override bool CellCompleted
        {
            get { return cellCompleted; }
        }

    }
}
