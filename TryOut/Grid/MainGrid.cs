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
        public double Total { get; set; }

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

        public void SwitchWall(Point mousePos)
        {
            foreach (GridCell cell in grid)
            {
                if ((cell.rectangle.X < mousePos.X && cell.rectangle.X + cell.rectangle.Width > mousePos.X) && (cell.rectangle.Y < mousePos.Y && cell.rectangle.Y + cell.rectangle.Width > mousePos.Y))
                {

                    if (grid[cell.X, cell.Y].isWall)
                    {
                        grid[cell.X, cell.Y] = new GridCell(grid[cell.X, cell.Y]);
                    }
                    else if (!grid[cell.X, cell.Y].isWall)
                    {
                        if (ProcessNeighbours(cell.X, cell.Y, true))
                        {  // moved all Creeper to neighbours
                            grid[cell.X, cell.Y] = new WallCell(grid[cell.X, cell.Y]);
                        }
                    }
                }
            }
        }

        public void Emit(Point mousePos)
        {

            foreach (GridCell cell in grid)
            {
                if ((cell.rectangle.X < mousePos.X && cell.rectangle.X + cell.rectangle.Width > mousePos.X) && (cell.rectangle.Y < mousePos.Y && cell.rectangle.Y + cell.rectangle.Width > mousePos.Y))
                {
                    if (!grid[cell.X, cell.Y].isWall)
                    {
                        Emit(cell.X, cell.Y);
                    }
                }
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
            for (int x = 0; x < xCells; x++)
            {
                for (int y = 0; y < yCells; y++)
                {
                    if (!grid[x, y].isWall && grid[x,y].oldAmount != 0)
                    {
                        ProcessNeighbours(x, y, false);
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

        public bool ProcessNeighbours(int X, int Y, bool moveAll)
        {
            bool hasMoved = true;
            List<GridCell> neighbours = new List<GridCell>();

            for (int neighBourX = X - 1; neighBourX <= X + 1; neighBourX++)
            {
                if (neighBourX >= 0 && neighBourX < xCells)
                {
                    for (int neighBourY = Y - 1; neighBourY <= Y + 1; neighBourY++)
                    {
                        if (neighBourY >= 0 &&
                            neighBourY < yCells &&
                            !grid[neighBourX, neighBourY].isWall &&
                            !((neighBourX == X) && (neighBourY == Y)))
                        {
                                neighbours.Add(grid[neighBourX, neighBourY]);
                        }
                    }
                }
            }

           int neighbourCount = neighbours.Count;

           if (moveAll)
           {
               if (neighbourCount > 0)
               {
                   double amount = grid[X, Y].oldAmount / neighbours.Count; // give each neighbour their full share

                   foreach (GridCell neighbour in neighbours)
                   {
                       neighbour.oldAmount += amount;
                   }

                   grid[X, Y].oldAmount = 0; // Empty this cell
               }
               else
               {   // No neighbours!!!
                   hasMoved = false;
               }
            }
            else
            {   
                foreach (GridCell neighbour in neighbours)
                {   // move a percentage to the neighbours
                    neighbour.newAmount += grid[X, Y].oldAmount * percentage / 100;
                }
                // give remainder back to center cell
                grid[X, Y].newAmount += grid[X, Y].oldAmount * (100 - neighbourCount * percentage) / 100;
            }

            return hasMoved;
        }

        internal void UpdateEmitAmount()
        {
            tempEmitAmount = (emitAmount * (double) amountMultiplier);
        }

        //Properties!
        public double Percentage
        {
            get { return percentage; }
            set { percentage = value; }
        }

        public decimal AmountMultiplier
        {
            get { return amountMultiplier; }
            set { amountMultiplier = value; }
        }

    }
}


