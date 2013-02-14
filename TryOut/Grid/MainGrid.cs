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
        public decimal amountMultiplier = 1;
        public double percentage = 5; // max: 100/max neighbors = 12.5
        public double Total;

        public GridCell[,] grid;

        Random random;
        public double emitAmount;
        double tempEmitAmount;

        public Graphics graphics;

        public MainGrid(Graphics g/*int width, int heigth*/, int selector)
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

            emitAmount = 0;

            switch (selector)
            {
                //BlankGrid
                case 1:
                case 3:
                    for (int i = 0; i < xCells; i++)
                    {
                        for (int j = 0; j < yCells; j++)
                        {
                            grid[i, j] = new GridCell(gridCellSide, gridCellX + 2, gridCellY + 2, i, j);

                            gridCellY += gridCellSide + 1;
                        }
                        gridCellX += gridCellSide + 1;
                        gridCellY = 0;
                    }

                    emitAmount = 100;

                    if (selector == 3)
                    {   // Create 10 random walls

                        Point wall;

                        for (int i = 0; i < 25; i++)
                        {
                            wall = GetRandomFreeCell();
                            grid[wall.X, wall.Y] = new WallCell(grid[wall.X, wall.Y]); // convert gridCell into wallcell
                        }

                        emitAmount = 75;
                    }

                    break;

                //MapGrid
                case 2:
                    for (int i = 0; i < xCells; i++)
                    {
                        for (int j = 0; j < yCells; j++)
                        {
                            if ((i == 1 && j != 0) && (i == 1 && j != 9) || (j == 1 && i != 0) && (j == 1 && i != 9) || (j == 8 && i != 0) && (j == 8 && i != 9))
                            {
                                grid[i, j] = new WallCell(gridCellSide, gridCellX + 2, gridCellY + 2, i, j);
                            }
                            else if ((i == 8 && j != 0) && (i == 8 && j != 9) && (i == 8 && j != yCells / 2))
                            {
                                grid[i, j] = new WallCell(gridCellSide, gridCellX + 2, gridCellY + 2, i, j);
                            }
                            else
                            {
                                grid[i, j] = new GridCell(gridCellSide, gridCellX + 2, gridCellY + 2, i, j);
                            }
                            gridCellY += gridCellSide + 1;
                        }
                        gridCellX += gridCellSide + 1;
                        gridCellY = 0;
                    }

                    emitAmount = 73;

                    break;
            }

            tempEmitAmount = (emitAmount * (double) amountMultiplier);
            Emit();
        }

        public void Emit()
        {
            EmitRandom(tempEmitAmount);
        }

        public void Emit(int x, int y)
        {
            UpdateEmitAmount();
            grid[x, y].oldAmount += tempEmitAmount;
        }

        private void EmitRandom(double amount)
        {
            Point emitter = GetRandomFreeCell();

            grid[emitter.X, emitter.Y].oldAmount += amount;
        }

        private Point GetRandomFreeCell()
        {
            Point freeCell = new Point();

            do
            {
                freeCell.X = random.Next(0, 9);
                freeCell.Y = random.Next(0, 9);
            }
            while (grid[freeCell.X, freeCell.Y].isWall);

            return freeCell;
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
            int neighBourCount;

            for (int x = 0; x < xCells; x++)
            {
                for (int y = 0; y < yCells; y++)
                {
                    if (!grid[x, y].isWall && grid[x,y].oldAmount != 0)
                    {
                        neighBourCount = 0;

                        for (int neighBourX = x - 1; neighBourX < x + 2; neighBourX++)
                        {
                            if (neighBourX >= 0 && neighBourX < xCells)
                            {
                                for (int neighBourY = y - 1; neighBourY < y + 2; neighBourY++)
                                {
                                    if (neighBourY >= 0 && 
                                        neighBourY < yCells &&
                                        !grid[neighBourX, neighBourY].isWall &&
                                        !((neighBourX == x ) && (neighBourY == y))) 
                                    {
                                        grid[neighBourX, neighBourY].newAmount += grid[x, y].oldAmount * percentage/100;
                                        neighBourCount++;
                                    }
                                }
                            }

                        }

                        grid[x, y].newAmount += grid[x, y].oldAmount * (100 - neighBourCount * percentage) / 100;
                    }
                }
            }

            Total = 0;
            foreach (GridCell cell in grid)
                    {
                        cell.oldAmount = cell.newAmount; 
                        Total+= cell.newAmount;
                        cell.newAmount = 0;
                    }     
            Console.WriteLine(Total.ToString("0.##"));     
            }

        internal void UpdateEmitAmount()
        {
            

            tempEmitAmount = (emitAmount * (double) amountMultiplier);
            

        }
    }
    }


