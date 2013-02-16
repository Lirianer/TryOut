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
       public bool isDestination, cellCompleted;

        public GridCell(int side,int x, int y, int locationX, int locationY)
        {
            X = locationX;
            Y = locationY;

            cellCompleted = false;
            isWall = false;
            isDestination = false;
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

        public GridCell(GridCell gridCell)
        {
            X = gridCell.X;
            Y = gridCell.Y;

            isWall = false;
            cellCompleted = false;
            oldAmount = 0;
            newAmount = 0;

            rectangle = gridCell.rectangle;
            color = new Color();
        }

        public virtual void DrawCircle(Graphics g)
        {
            if (oldAmount > 0.01)
            {
                Rectangle rect = Rectangle.Inflate(rectangle, -2, -2); // slightly smaller than the cell
                Color orangeRed = Color.FromArgb(192, Color.OrangeRed);    // 25% transparent
                g.DrawEllipse(new Pen(new SolidBrush(orangeRed), 3), rect); // Circle with line width 3
            }
        }

        public virtual void DrawCell(Graphics g)
        {
            const int maxColor = 255;
            bool isAC = oldAmount < 0;
            double absAmount = Math.Abs(oldAmount);

            if (absAmount > 0.01) // display blank cell for very tiny amounts
            {
                shade = maxColor - ((Math.Log10(absAmount) + 1) / 3 * maxColor);
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

        public virtual bool CellCompleted
        {
            get { return false; }
        }

        public double DistanceTo(GridCell gridCell)
        {
            // For now I just use Pythagoras, but Dijkstra's algorithm could also be implemented here.
            double distance = Math.Sqrt(Math.Pow(this.X - gridCell.X, 2) + Math.Pow(this.Y - gridCell.Y, 2));

            return distance;
        }
    }
}
