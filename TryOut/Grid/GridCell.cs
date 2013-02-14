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
        private Color color;
       public Rectangle rectangle;
       public double oldAmount, newAmount;
       public bool isWall;
       double shade = 0;
       public int X, Y;
       public bool displayAmount = true;
       public bool isSelected = false;

        public GridCell(int side,int x, int y, int locationX, int locationY)
        {
            X = locationX;
            Y = locationY;

            isWall = false;
            oldAmount = 0;
            newAmount = 0;
            rectangle = new Rectangle(x, y, side, side);
            color = new Color();
        }

        public GridCell(int side, int x, int y, float amount)
        {
            isWall = false;
            this.oldAmount = amount;
            newAmount = 0;
            rectangle = new Rectangle(x, y, side, side);
            color = new Color();
        }

        public GridCell(GridCell cell)
        {
            X = cell.X;
            Y = cell.Y;

            isWall = false;
            oldAmount = 0;
            newAmount = 0;
            rectangle = cell.rectangle;
            color = new Color();
            
        }

        public virtual void DrawCell(Graphics g)
        {
            const int maxColor = 255;
            bool isAC = oldAmount < 0;
            double absAmount = Math.Abs(oldAmount);

            if (absAmount > 0.001)
            {
                shade = maxColor - ((Math.Log10(absAmount) + 1) / 4 * maxColor);
                if (shade > maxColor)
                {
                    shade = maxColor;
                }
                if (shade < 0)
                {
                    shade = 0;
                }

                if (isAC)
                {   // green
                    color = Color.FromArgb((int)shade, maxColor, (int)shade);
                }
                else
                {   // blue
                    color = Color.FromArgb((int)shade, (int)shade, maxColor);
                }

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;      // Horizontal Alignment
                stringFormat.LineAlignment = StringAlignment.Center;  // Vertical Alignment

                g.FillRectangle(new SolidBrush(color), rectangle);

                if (displayAmount)
                {
                    g.DrawString(absAmount.ToString("0.#"), new Font("Arial", 7), new SolidBrush(Color.Black), rectangle, stringFormat);
                }
            }
            if (!isSelected)
            {
                g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rectangle);
            }
            else if (isSelected)
            {
                g.DrawRectangle(new Pen(new SolidBrush(Color.Green)), rectangle);
            }
        }
    }
}
