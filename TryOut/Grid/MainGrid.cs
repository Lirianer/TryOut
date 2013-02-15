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
        private bool gridWon;
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
            Point emitterLocation = new Point(0,0);
            emitterLocation = EmitRandomEdge(tempEmitAmount, 0, emitterLocation);  // emit Creeper in random edge cell
            EmitRandomEdge(tempEmitAmount * -1, 8, emitterLocation);               // emit Anti-Creeper in different edge cell at minimum distance
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

        private Point EmitRandomEdge(double amount, double minDistance, Point compareLocation)
        {   // Emit an amount at the edge, or close to it. Also use a minimum distance compared to point parameter.
            Point emitter;
            double distance = 0;

            do
            {   // keep looking until a free spot at the edge is found
                emitter = GetRandomFreeCell();
                distance = GetDistance(emitter, compareLocation);
            }
            while (!((emitter.X <= 1  ||                             // (close to) left edge
                      emitter.X >= 8  ||                             // (close to) right edge
                      emitter.Y <= 1  ||                             // (close to) top edge
                      emitter.Y >= 8) &&                             // (close to) bottom edge
                      grid[emitter.X, emitter.Y].oldAmount == 0 &&   // no other Creeper
                     (minDistance == 0 ||                            // no minimal distance required
                      compareLocation.IsEmpty ||                     // no location to compare to
                      distance >= minDistance)));                    // located at minimal distance

            grid[emitter.X, emitter.Y].oldAmount = amount;

            return emitter; // return the location of the new emitter
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
            foreach (GridCell cell in grid)
            {
                cell.DrawCell(graphics);
            }

            // Indicate cell with highest density
            Point location = GetHighestDensity();
            grid[location.X, location.Y].DrawCircle(graphics);
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

            if (Math.Abs(grid[X, Y].oldAmount) != 0)
            {
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

       /* public bool GridWon
        {
            get { return gridWon; }
            set { gridWon = value; }
        }*/
        

        private double GetDistance(Point point1, Point point2)
        {
            // For now I just use Pythagoras, but Dijkstra's algorithm could also be implemented here.
            double distance = Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));

            return distance;
        }

        internal void SwitchDestination(Point mousePos)
        {
            foreach (GridCell cell in grid)
            {
                if ((cell.rectangle.X < mousePos.X && cell.rectangle.X + cell.rectangle.Width > mousePos.X) && (cell.rectangle.Y < mousePos.Y && cell.rectangle.Y + cell.rectangle.Width > mousePos.Y))
                {

                    if (grid[cell.X, cell.Y].isDestination)
                    {
                        grid[cell.X, cell.Y] = new GridCell(grid[cell.X, cell.Y]);
                    }
                    else if (!grid[cell.X, cell.Y].isDestination)
                    {
                        // moved all Creeper to neighbours
                        grid[cell.X, cell.Y] = new DestinationCell(grid[cell.X, cell.Y], -100);
                        
                    }
                }
            }
        }

        private Point GetHighestDensity()
        {
            double highestAmount = 0;
            Point cellLocation = new Point();

            foreach (GridCell cell in grid)
            {
                if (cell.oldAmount > highestAmount)
                {
                    highestAmount = cell.oldAmount;
                    cellLocation.X = cell.X;
                    cellLocation.Y = cell.Y;
                }
            }

            return cellLocation;
        }
    }
}


