using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryOut.Grid
{
    class MainGrid
    {
        //int gridWidth, gridHeigth;
        int gridCellSide;
        int gridCellX, gridCellY;
        int xCells, yCells;
        GridCell[,] grid;

        public Graphics graphics;

        public MainGrid(Graphics g/*int width, int heigth*/)
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
            
            grid = new GridCell[xCells,yCells];

            for (int i = 0; i < xCells; i++)
            {
                for (int j = 0; j < yCells; j++)
                {
                    grid[i, j] = new GridCell(gridCellSide, gridCellX + 2, gridCellY + 2);
                    if ((i >= 4 && j >= 4) && (i <= 5 && j <= 5))
                    {
                        grid[i, j] = new WallCell(gridCellSide, gridCellX + 2, gridCellY + 2);
                    }

                    gridCellY += gridCellSide +1;
                }
                gridCellX += gridCellSide +1;
                gridCellY = 0;
            }

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
