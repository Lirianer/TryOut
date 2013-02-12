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

        Random random;

        public Graphics graphics;

        public MainGrid(Graphics g/*int width, int heigth*/)
        {
            Console.WriteLine("Initializin Grid");
            random = new Random();

            graphics = g;

            gridCellSide = 30;
            gridCellX = 0;
            gridCellY = 0;

            //gridWidth = 311; //width;
            //gridHeigth = 3; //heigth;

            xCells = 10;
            yCells = 10;
            
            grid = new GridCell[xCells,yCells];

            int randomCellX = random.Next(1, 8);
            int randomCellY = random.Next(1, 8);

            for (int i = 0; i < xCells; i++)
            {
                for (int j = 0; j < yCells; j++)
                {

                    if (randomCellX == i && randomCellY == j)
                    {
                        grid[i, j] = new GridCell(gridCellSide, gridCellX + 2, gridCellY + 2, 64.0F);
                    }
                    else
                    {

                        grid[i, j] = new GridCell(gridCellSide, gridCellX + 2, gridCellY + 2);
                    }
                        /* if ((i >= 4 && j >= 4) && (i <= 5 && j <= 5))
                    {
                        grid[i, j] = new WallCell(gridCellSide, gridCellX + 2, gridCellY + 2);
                    }*/

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
                cell.DrawCell(graphics);
              //  i++;
            }
        }

        public void ProcessFlow()
        {
            GridCell[,] neighbourCells = new GridCell[3,3];
            float tempFloat = 0F;
            float newAverage = 0F;

            for (int x = 1; x < xCells-1; x++)
            {
                for (int y= 1; y < yCells-1; y++)
                {
                    int neighbourCounter = 0;

                        for(int neighBourX = x -1; neighBourX < x+2; neighBourX++)
                        {
                            for(int neighBourY = y-1; neighBourY < y+2; neighBourY++)
                            {
                                tempFloat += grid[neighBourX, neighBourY].oldAmount;
                                neighbourCounter++;
                            }
                            
                        }

                        newAverage = tempFloat/neighbourCounter;
                        grid[x, y].newAmount = newAverage;
                        tempFloat = 0F;
                }
            }

            foreach (GridCell cell in grid)
            { cell.oldAmount = cell.newAmount; }


        }


    }
}
