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
        private int gridSize;       // dimension of grid (from 10x10 to 20x20)
        private int cellWidth;      // width of cell in pizels (gridRect/gridSize)

        private Rectangle gridRect; // rectangle of grid in pane
        public Rectangle GridRect
        {
            get { return gridRect; }
            set 
            { 
                gridRect = value;
                cellWidth = gridRect.Width / gridSize; 
            }
        }

        public double Total { get; set; }
        private bool hasDestination;
        
        public double emitAmount;
        double tempEmitAmount;

        private GridCell[,] grid;
        public GridCell[,] Grid
        {
            get { return grid; }
            set { grid = value; }
        }

        private double percentage = 5; // max: 100/max neighbors = 12.5
        public double Percentage
        {
            get { return percentage; }
            set { percentage = value; }
        }

        private decimal amountMultiplier = 1;
        public decimal AmountMultiplier
        {
            get { return amountMultiplier; }
            set { amountMultiplier = value; }
        }

        private bool gridWon;
        public bool GridWon
        {
            get { return gridWon; }
        }

        public MainGrid(int size)
        {
            emitAmount = 100;

            // Create grid
            gridSize = size;
            cellWidth = gridRect.Width / gridSize; 
            grid = new GridCell[gridSize, gridSize];

            // Create cells
            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    grid[x, y] = new GridCell(x, y);
                }
            }

            /*  Move later
            {   // Create 10 random walls

                Point wall;

                for (int i = 0; i < 25; i++)
                {
                    wall = GetRandomFreeCell();
                    grid[wall.X, wall.Y] = new WallCell(grid[wall.X, wall.Y]); // convert gridCell into wallcell
                }
            }
            */


            /*  MapGrid now obsolete because of flexible grid size. Commented for reference.
             
                for (int i = 0; i < xCells; i++)
                {
                    for (int j = 0; j < yCells; j++)
                    {
                        if ((i == 1 && j != 0) && (i == 1 && j != 9) || (j == 1 && i != 0) && (j == 1 && i != 9) || (j == 8 && i != 0) && (j == 8 && i != 9))
                        {
                            grid[i, j] = new WallCell(cellWidth, gridCellX + 2, gridCellY + 2, i, j);
                        }
                        else if ((i == 8 && j != 0) && (i == 8 && j != 9) && (i == 8 && j != yCells / 2))
                        {
                            grid[i, j] = new WallCell(cellWidth, gridCellX + 2, gridCellY + 2, i, j);
                        }
                        else
                        {
                            grid[i, j] = new GridCell(cellWidth, gridCellX + 2, gridCellY + 2, i, j);
                        }
                        gridCellY += cellWidth + 1;
                    }
                    gridCellX += cellWidth + 1;
                    gridCellY = 0;

               }
               emitAmount = 73; 
            */

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
            grid[x, y].OldAmount += tempEmitAmount;
        }

        private void EmitRandom(double amount)
        {
            Point emitter = GetRandomFreeCell();

            grid[emitter.X, emitter.Y].OldAmount += amount;
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
                      emitter.X >= gridSize-2  ||                    // (close to) right edge
                      emitter.Y <= 1  ||                             // (close to) top edge
                      emitter.Y >= gridSize-2) &&                    // (close to) bottom edge
                      grid[emitter.X, emitter.Y].OldAmount == 0 &&   // no other Creeper
                     (minDistance == 0 ||                            // no minimal distance required
                      compareLocation.IsEmpty ||                     // no location to compare to
                      distance >= minDistance)));                    // located at minimal distance

            grid[emitter.X, emitter.Y].OldAmount = amount;

            return emitter; // return the location of the new emitter
        }

        private Point GetRandomFreeCell()
        {
            Point freeCell = new Point();
            Random random = new Random();

            do
            {
                freeCell.X = random.Next(0, gridSize-1);
                freeCell.Y = random.Next(0, gridSize-1);
            }
            while (grid[freeCell.X, freeCell.Y].IsWall);

            return freeCell;
        }

        public void SwitchWall(Point mousePos)
        {
            GridCell cell = CellAtMousePos(mousePos);

            if (cell.IsWall)
            {
                cell.IsWall = false;
            }
            else
            {
                if (ProcessNeighbours(cell.X, cell.Y, true))
                {  // moved all Creeper to neighbours
                    cell.IsWall = true;
                }
            }
        }

        public void Emit(Point mousePos)
        {
            GridCell cell = CellAtMousePos(mousePos);

            if (!cell.IsWall)
            {
                Emit(cell.X, cell.Y);
            }
        }

        public GridCell CellAtMousePos(Point mousePos)
        {
            int x = (int) mousePos.X / cellWidth;
            int y = (int) mousePos.Y / cellWidth;

            GridCell cell = grid[x, y];

            return cell;
        }

        public void Draw(Graphics graphics)
        {
            foreach (GridCell cell in grid)
            {
                cell.Draw(graphics, cellWidth);
            }

            // Indicate cell with highest density
            Point location = GetHighestDensity();
            grid[location.X, location.Y].DrawCircle(graphics, cellWidth);
        }

        public void ProcessFlow()
        {
            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    if (!grid[x, y].IsWall && grid[x,y].OldAmount != 0)
                    {
                        ProcessNeighbours(x, y, false);
                    }
                }
            }

            Total = 0;
            foreach (GridCell cell in grid)
                    {
                        if (cell.IsDestination)
                        {
                            hasDestination = true;
                        }
                        cell.OldAmount = cell.NewAmount; 
                        Total+= cell.NewAmount;
                        cell.NewAmount = 0;
                    }
            if (hasDestination)
            {
                CheckForGridWon();
            }
            Console.WriteLine(Total.ToString("0.##"));     
        }

        private void CheckForGridWon()
        {
            List<bool> destinationCells = new List<bool>();

            foreach (GridCell cell in grid)
            {
                if (cell.IsDestination)
                {
                    destinationCells.Add(cell.CellCompleted);
                }
            }
            if (destinationCells.TrueForAll(isTrue))
            {
                gridWon = true;
            }
            else
            {
                gridWon = false;    
            }


            Console.WriteLine("\nTrueForAll (isTrue): {0}", destinationCells.TrueForAll(isTrue));
        }

        private bool isTrue(bool obj)
        {
            return obj;
        }

        private List<GridCell> GetNeighbours(int X, int Y)
        {
            List<GridCell> neighbours = new List<GridCell>();

            for (int neighBourX = X - 1; neighBourX <= X + 1; neighBourX++)
            {
                if (neighBourX >= 0 && neighBourX < gridSize)
                {
                    for (int neighBourY = Y - 1; neighBourY <= Y + 1; neighBourY++)
                    {
                        if (neighBourY >= 0 &&
                            neighBourY < gridSize &&
                            !grid[neighBourX, neighBourY].IsWall &&
                            !((neighBourX == X) && (neighBourY == Y))) // Don't add itself
                        {
                            neighbours.Add(grid[neighBourX, neighBourY]);
                        }
                    }
                }
            }

            return neighbours;
        }

        public bool ProcessNeighbours(int X, int Y, bool moveAll)
        {
            bool hasMoved = true;
            List<GridCell> neighbours = GetNeighbours(X, Y);

            if (Math.Abs(grid[X, Y].OldAmount) != 0)
            {
                int neighbourCount = neighbours.Count;

                if (moveAll)
                {
                    if (neighbourCount > 0)
                    {
                        double amount = grid[X, Y].OldAmount / neighbours.Count; // give each neighbour their full share

                        foreach (GridCell neighbour in neighbours)
                        {
                            neighbour.OldAmount += amount;
                        }

                        grid[X, Y].OldAmount = 0; // Empty this cell
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
                        neighbour.NewAmount += grid[X, Y].OldAmount * percentage / 100;
                    }
                    // give remainder back to center cell
                    grid[X, Y].NewAmount += grid[X, Y].OldAmount * (100 - neighbourCount * percentage) / 100;
                }
            }

            return hasMoved;
        }

        internal void UpdateEmitAmount()
        {
            tempEmitAmount = (emitAmount * (double) amountMultiplier);
        }

        private double GetDistance(Point point1, Point point2)
        {
            // For now I just use Pythagoras, but Dijkstra's algorithm could also be implemented here.
            double distance = Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));

            return distance;
        }

        public void SwitchDestination(Point mousePos)
        {
            GridCell cell = CellAtMousePos(mousePos);

            cell.IsDestination = !cell.IsDestination;
        }

        private Point GetHighestDensity()
        {
            double highestAmount = 0;
            Point cellLocation = new Point();

            foreach (GridCell cell in grid)
            {
                if (cell.OldAmount > highestAmount)
                {
                    highestAmount = cell.OldAmount;
                    cellLocation.X = cell.X;
                    cellLocation.Y = cell.Y;
                }
            }

            return cellLocation;
        }
    }
}


