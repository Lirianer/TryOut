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
       public float oldAmount, newAmount;
       public bool isWall;
       private int counter = 0;
       float red = 0;//(255 - color.R) * this.oldAmount + color.R;
       float blue = 255F;//(255 - color.R) * this.oldAmount + color.B;

        public GridCell(int side,int x, int y)
        {
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
            red = 255-(this.oldAmount*2.55F);


            if (red > 255F) { red = 255F; }
            if (red < 0F) { red = 0F; }
            //if(green>255F){green = 255F;}
                
            color = Color.FromArgb((int)red, (int)red, (int)blue);

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;      // Horizontal Alignment
            stringFormat.LineAlignment = StringAlignment.Center;  // Vertical Alignment

            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rectangle);
            if (this.oldAmount > 0F)
            {
                
                g.FillRectangle(new SolidBrush(color), rectangle);
                
                /*if (this.oldAmount > 9)
                {
                    g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#08088A")), rectangle);
                }
                else if (8 < this.oldAmount && this.oldAmount < 9)
                {
                    g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#0101DF")), rectangle);
                }
                else if (7 < this.oldAmount && this.oldAmount < 8)
                {
                    g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#0000FF")), rectangle);
                }
                else if (6 < this.oldAmount && this.oldAmount < 7)
                {
                    g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#2E2EFE")), rectangle);
                }
                else if (5 < this.oldAmount && this.oldAmount < 6)
                {
                    g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#5858FA")), rectangle);
                }
                else if (4 < this.oldAmount && this.oldAmount < 5)
                {
                    g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#8181F7")), rectangle);
                }
                else if (3 < this.oldAmount && this.oldAmount < 4)
                {
                    g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#A9A9F5")), rectangle);
                }
                else if (2 < this.oldAmount && this.oldAmount < 3)
                {
                    g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#CECEF6")), rectangle);
                }
                else if (1 < this.oldAmount && this.oldAmount < 2)
                {
                    g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#E0E0F8")), rectangle);
                }
                else if (0 < this.oldAmount && this.oldAmount < 1)
                {
                    g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#EFEFFB")), rectangle);
                }*/
                g.DrawString(this.oldAmount.ToString("0.#"), new Font("Arial", 8), new SolidBrush(Color.Black), rectangle, stringFormat);
            }
            else
            {
               // g.FillRectangle(new SolidBrush(Color.White), rectangle);
            }
        }
        
    }
}
