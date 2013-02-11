using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryOut.Grid
{
    class MainGrid
    {
        //int gridWidth, gridHeigth;
        int gridCellSide;
        int gridCellX, gridCellY;
        int xCells, yCells;
        GridCell[] grid;

        public Graphics graphics;

        public MainGrid(Graphics g, Form form/*int width, int heigth*/)
        {
            Console.WriteLine("Initializin Grid");

            graphics = g;

            gridCellSide = 30;
            gridCellX = 0;
            gridCellY = 0;

            //gridWidth = 311; //width;
            //gridHeigth = 3; //heigth;

            xCells = 10;
            yCells = 10;
            
            grid = new GridCell[xCells*yCells];

            for (int i = 0; i < grid.Length; i++)
            {
                if( gridCellX + gridCellSide + 1 > 10+gridCellSide*xCells)
                {
                    gridCellX = 0;
                    gridCellY += gridCellSide + 1;

                    if(gridCellY > gridCellY*yCells)
                    {
                        break;
                    }
                }

                grid[i] = new GridCell(gridCellSide, gridCellX + 2, gridCellY +2);

                if(i == 44 || i == 45 || i == 54 || i ==55)
                {
                    grid[i] = new WallCell(gridCellSide, gridCellX + 2, gridCellY + 2);
                }

                gridCellX += gridCellSide +1;
                //gridCellY = 0;

                
            }

            Console.WriteLine(grid.GetLowerBound(0));
            Console.WriteLine();

        }


        public void Draw()
        {
            //int i = 0;
            //Console.WriteLine("Drawing Grid");
            foreach (GridCell cell in grid)
            {
                //Console.WriteLine("Drawing Cell" + i);
                cell.DrawCell(graphics, Color.White);
              //  i++;
            }
        }

    }
}
