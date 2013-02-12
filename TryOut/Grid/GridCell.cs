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
                
                g.DrawString(this.oldAmount.ToString("0.#"), new Font("Arial", 8), new SolidBrush(Color.Black), rectangle, stringFormat);
            }
            else
            {
               // g.FillRectangle(new SolidBrush(Color.White), rectangle);
            }
        }
        
    }
}
