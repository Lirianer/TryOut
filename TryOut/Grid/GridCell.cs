using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using TryOut.Properties;

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

        private bool isDestination;
        public bool IsDestination
        {
            get { return isDestination; }
            set { isDestination = value; }
        }

        public GridCell(int xCoord, int yCoord)
        {
            x = xCoord;
            y = yCoord;

            isWall = false;
            isDestination = false;

            oldAmount = 0;
            newAmount = 0;
        }

        public Rectangle Rect(int cellWidth)
        {
            Rectangle rect;
            int xPos = x * cellWidth;
            int yPos = y * cellWidth;

            rect = new Rectangle(xPos, yPos, cellWidth - 1, cellWidth - 1);

            return rect;
        }

        public Rectangle ImageRect(int cellWidth)
        {
            Rectangle rect;
            int xPos = x * cellWidth;
            int yPos = y * cellWidth;

            rect = new Rectangle(xPos, yPos, cellWidth, cellWidth);

            return rect;
        }

        public void DrawCircle(Graphics g, int cellWidth)
        {
            if (oldAmount >= 0.05)
            {
                Rectangle circleRect = Rectangle.Inflate(Rect(cellWidth), -2, -2); // slightly smaller than the cell
                Color orangeRed = Color.FromArgb(192, Color.OrangeRed);            // 25% transparent
                g.DrawEllipse(new Pen(new SolidBrush(orangeRed), 3), circleRect);  // Circle with line width 3
            }
        }

        private void DrawFluid(Graphics graphics, int cellWidth, bool displayDensity = true)
        {
            const int maxColor = 255;
            const int transparency = 25; // percentage
            int alpha = maxColor * (100 - transparency) / 100;
            int shade = 0;
            Color color = new Color();

            bool isAC = oldAmount < 0;
            double absAmount = Math.Abs(oldAmount);

            Rectangle rect = ImageRect(cellWidth);

            if (absAmount >= 0.05) // display blank cell for very tiny amounts
            {
                shade = maxColor - (int)((Math.Log10(absAmount) + 1) / 3 * maxColor);
                shade = Math.Min(shade, maxColor);
                shade = Math.Max(shade, 0);

                if (isAC)
                {   // green
                    color = Color.FromArgb(alpha, (int)shade, maxColor, (int)shade);
                }
                else
                {   // blue
                    color = Color.FromArgb(alpha, (int)shade, (int)shade, maxColor);
                }

                graphics.FillRectangle(new SolidBrush(color), rect);

                if (displayDensity)
                {
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;      // Horizontal Alignment
                    stringFormat.LineAlignment = StringAlignment.Center;  // Vertical Alignment
                    int fontSize = (int) Math.Max((cellWidth)/6, 6);      // Scaling fontsize, minimum = 6 pt

                    graphics.DrawString(absAmount.ToString("0.#"), new Font("Arial", fontSize), new SolidBrush(Color.Black), rect, stringFormat);
                }
            }
        }

        private void DrawDestination(Graphics graphics, int cellWidth)
        {
            Bitmap texture = new Bitmap(Resources.destination);
            TextureBrush textureBrush = new TextureBrush(texture);

            graphics.FillRectangle(textureBrush, ImageRect(cellWidth));
        }

        private void DrawWall(Graphics graphics, int cellWidth)
        {
            Bitmap texture = new Bitmap(Resources.wall);
            TextureBrush textureBrush = new TextureBrush(texture);

            graphics.FillRectangle(textureBrush, ImageRect(cellWidth));
        }

        public void Draw(Graphics graphics, int cellWidth, bool displayGrid = true, bool displayDensity = true)
        {

            if (isWall)
            {
                DrawWall(graphics, cellWidth);
            }
            else
            {
                if (isDestination)
                {
                    DrawDestination(graphics, cellWidth);
                }

                DrawFluid(graphics, cellWidth, displayDensity);
            }

            if (displayGrid)
            {
                graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)), Rect(cellWidth));
            }
        }

        public double DistanceTo(GridCell gridCell)
        {
            // For now I just use Pythagoras, but Dijkstra's algorithm could also be implemented here.
            double distance = Math.Sqrt(Math.Pow(x - gridCell.x, 2) + Math.Pow(y - gridCell.y, 2));

            return distance;
        }
    }
}
