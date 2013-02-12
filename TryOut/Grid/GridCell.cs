﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryOut.Grid
{
    class GridCell
    {
       public Rectangle rectangle;
       public float oldAmount, newAmount;
       public bool isWall;
       private int counter = 0;

        public GridCell(int side,int x, int y)
        {
            isWall = false;
            oldAmount = 0;
            newAmount = 0;
            rectangle = new Rectangle(x, y, side, side);
        }

        public GridCell(int side, int x, int y, float amount)
        {
            isWall = false;
            this.oldAmount = amount;
            newAmount = 0;
            rectangle = new Rectangle(x, y, side, side);
        }


        public virtual void DrawCell(Graphics g)
        {
            

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;      // Horizontal Alignment
            stringFormat.LineAlignment = StringAlignment.Center;  // Vertical Alignment

            g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rectangle);
            if (this.oldAmount > 0F)
            {
                if (counter % 2 == 0)
                {
                    g.FillRectangle(new SolidBrush(Color.Red), rectangle);
                    counter++;
                }
                else
                {
                    g.FillRectangle(new SolidBrush(Color.Green), rectangle);
                    counter++;
                }
                g.DrawString(this.oldAmount.ToString("0.#"), new Font("Arial", 8), new SolidBrush(Color.Blue), rectangle, stringFormat);
            }
        }
        
    }
}
