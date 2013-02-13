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
       double shade = 0;//(255 - color.R) * this.oldAmount + color.R;
       double blue = 255;//(255 - color.R) * this.oldAmount + color.B;
       public int X, Y;
       public bool displayAmount = true;

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


        public virtual void DrawCell(Graphics g)
        {
            if (oldAmount >= 0.1)
            {
                shade = 255 - ((Math.Log10(oldAmount)+1)/4 * 255);
                if (shade > 255)
                {
                    shade = 255;
                }
                if (shade < 0)
                {
                    shade = 0;
                }

                color = Color.FromArgb((int)shade, (int)shade, (int)blue);

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;      // Horizontal Alignment
                stringFormat.LineAlignment = StringAlignment.Center;  // Vertical Alignment

                g.FillRectangle(new SolidBrush(color), rectangle);

                if (displayAmount)
                {
                    g.DrawString(this.oldAmount.ToString("0.#"), new Font("Arial", 7), new SolidBrush(Color.Black), rectangle, stringFormat);
                }
            }

            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rectangle);
        }
    }
}
