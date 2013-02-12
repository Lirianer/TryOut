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
        int randomCellX;
        int randomCellY;

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

            randomCellX = 0;
            randomCellY = 0;

            bool isWallCreated = false;
            for (int i = 0; i < xCells; i++)
            {
                isWallCreated = false;

                for (int j = 0; j < yCells; j++)
                {

                    if (!isWallCreated && randomCellY < j)
                    {
                        randomCellY = random.Next(j, yCells - 1);

                        
                    }
                    if (j == randomCellY)
                    {
                        grid[i, j] = new WallCell(gridCellSide, gridCellX + 2, gridCellY + 2);
                        randomCellY = -1;
                        isWallCreated = true;
                    }
                    else
                    {
                        grid[i, j] = new GridCell(gridCellSide, gridCellX + 2, gridCellY + 2);
                    }
                    
                    /*if ((i == 1 && j != 0) && (i == 1 && j != 9) || (j == 1 && i != 0) && (j == 1 && i != 9) || (j == 8 && i != 0) && (j == 8 && i != 9))
                    {
                        grid[i, j] = new WallCell(gridCellSide, gridCellX + 2, gridCellY + 2);
                    }
                    else if ((i == 8 && j != 0) && (i == 8 && j != 9) && (i == 8 && j != yCells / 2))
                    {
                        grid[i, j] = new WallCell(gridCellSide, gridCellX + 2, gridCellY + 2);
                    }
                    else if ((i == xCells / 2) && (j == xCells / 2))
                    {
                        grid[i, j] = new GridCell(gridCellSide, gridCellX + 2, gridCellY + 2, 1000F);
                    }
                    else
                    {
                        grid[i, j] = new GridCell(gridCellSide, gridCellX + 2, gridCellY + 2);
                    }*/






                   /* if (randomCellX == i && randomCellY == j)
                    {
                        grid[i, j] = new GridCell(gridCellSide, gridCellX + 2, gridCellY + 2, 100.0F);
                    }
                    /*else
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

            CreateRandomCell();
        }

        private void CreateRandomCell()
        {
            randomCellX = random.Next(0, 9);
            randomCellY = random.Next(0, 9);

            if (!grid[randomCellX, randomCellY].isWall)
            {
                grid[randomCellX, randomCellY].oldAmount = 1000F;
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

            for (int x = 0; x < xCells; x++)
            {
                for (int y = 0; y < yCells; y++)
                {
                    int neighbourCounter = 0;
                    if (!grid[x, y].isWall)
                    {

                        for (int neighBourX = x - 1; neighBourX < x + 2; neighBourX++)
                        {
                            if (neighBourX >= 0 && neighBourX < xCells)
                            {
                                for (int neighBourY = y - 1; neighBourY < y + 2; neighBourY++)
                                {
                                    if (neighBourY >= 0 && neighBourY < yCells && !grid[neighBourX, neighBourY].isWall) 
                                    {
                                        tempFloat += grid[neighBourX, neighBourY].oldAmount;
                                        neighbourCounter++;
                                    }
                                }
                            }

                        }

                        newAverage = tempFloat / neighbourCounter;
                        grid[x, y].newAmount = newAverage;
                        tempFloat = 0F;
                    }
                }
            }

            foreach (GridCell cell in grid)
                    {
                        cell.oldAmount = cell.newAmount; 
                        tempFloat += cell.newAmount;
                    }      Console.WriteLine(tempFloat.ToString("0.###"));     
            }


        }


    }


