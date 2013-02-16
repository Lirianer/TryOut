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
        private int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        private double oldAmount;
        public double OldAmount
        {
            get { return oldAmount; }
            set { oldAmount = value; }
        }

        private double newAmount;
        public double NewAmount
        {
            get { return newAmount; }
            set { newAmount = value; }
        }

        private bool isWall;
        public bool IsWall
        {
            get { return isWall; }
            set { isWall = value; }
        }

        private bool isSelected = false;
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }

        private bool isDestination;
        public bool IsDestination
        {
            get { return isDestination; }
            set { isDestination = value; }
        }

        private bool isCompleted;
        public bool IsCompleted
        {
            get { return isCompleted; }
            set { isCompleted = value; }
        }

        public bool displayAmount = true;

        public GridCell(int xCoord, int yCoord)
        {
            x = xCoord;
            y = yCoord;

            isCompleted = false;
            isWall = false;
            isDestination = false;

            oldAmount = 0;
            newAmount = 0;
        }
/*
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
*/
        public Rectangle Rect(int cellWidth)
        {
            Rectangle rect;
            int xPos = x * cellWidth;
            int yPos = y * cellWidth;

            rect = new Rectangle(xPos, yPos, cellWidth - 1, cellWidth - 1);

            return rect;
        }

        public void DrawCircle(Graphics g, int cellWidth)
        {
            if (oldAmount > 0.01)
            {
                Rectangle circleRect = Rectangle.Inflate(Rect(cellWidth), -2, -2); // slightly smaller than the cell
                Color orangeRed = Color.FromArgb(192, Color.OrangeRed);            // 25% transparent
                g.DrawEllipse(new Pen(new SolidBrush(orangeRed), 3), circleRect);  // Circle with line width 3
            }
        }

        public void Draw(Graphics graphics, int cellWidth)
        {
            const int maxColor = 255;
            Color color = new Color();
            int shade = 0;

            bool isAC = oldAmount < 0;
            double absAmount = Math.Abs(oldAmount);

            Rectangle rect = Rect(cellWidth);

            if (absAmount > 0.01) // display blank cell for very tiny amounts
            {
                shade = maxColor - (int)((Math.Log10(absAmount) + 1) / 3 * maxColor);
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

                graphics.FillRectangle(new SolidBrush(color), rect);

                if (displayAmount)
                {
                    graphics.DrawString(absAmount.ToString("0.#"), new Font("Arial", 7), new SolidBrush(Color.Black), rect, stringFormat);
                }
            }
            if (!isSelected)
            {
                graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rect);
            }
            else if (isSelected)
            {
                graphics.DrawRectangle(new Pen(new SolidBrush(Color.Green)), rect);
            }
        }

        public bool CellCompleted
        { // ???
            get { return false; }
        }

        public double DistanceTo(GridCell gridCell)
        {
            // For now I just use Pythagoras, but Dijkstra's algorithm could also be implemented here.
            double distance = Math.Sqrt(Math.Pow(x - gridCell.x, 2) + Math.Pow(y - gridCell.y, 2));

            return distance;
        }
    }
}
