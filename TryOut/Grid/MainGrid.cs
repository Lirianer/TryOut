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

        private int wallPercentage; // percentage of random walls

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

        private double destinationAmount;
        public double DestinationAmount
        {
            get { return destinationAmount; }
            set { destinationAmount = value; }
        }

        private List<GridCell> destinationCells;

        private bool displayDensity = true;
        public bool DisplayDensity
        {
            get { return displayDensity; }
            set { displayDensity = value; }
        }

        private bool displayGrid = true;
        public bool DisplayGrid
        {
            get { return displayGrid; }
            set { displayGrid = value; }
        }
        
        private double total;
        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        private double emitBaseAmount;
        public double EmitBaseAmount
        {
            get { return emitBaseAmount; }
        }

        public MainGrid(int size)
        {
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
 
            destinationCells = new List<GridCell>();

            wallPercentage = 25;
            emitBaseAmount = 10 * gridSize * gridSize * (100 - wallPercentage) / 100;
        }

        public void CreateRandomWalls()
        {
            // Create random walls
            Point wall;
            int wallCount = gridSize * gridSize * wallPercentage / 100;

            for (int i = 0; i < wallCount; i++)
            {
                wall = GetRandomFreeCell();
                grid[wall.X, wall.Y].IsWall = true;
            }
        }

        private double GetEmitAmount()
        {
            return emitBaseAmount * (double)amountMultiplier;
        }

        public void CreateEmitters()
        {
            double emitAmount = GetEmitAmount();
            Point emitterLocation = new Point(0, 0);
            emitterLocation = EmitRandomEdge(emitAmount, 0, emitterLocation);  // emit Creeper in random edge cell
            EmitRandomEdge(emitAmount * -1, gridSize - 3, emitterLocation);    // emit Anti-Creeper in different edge cell at minimum distance
        }

        public void Emit()
        {
            EmitRandom(GetEmitAmount());
        }

        public void Emit(int x, int y)
        {
            grid[x, y].OldAmount += GetEmitAmount();
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
            int margin = (int)(gridSize / 5);

            do
            {   // keep looking until a free spot at the edge is found
                emitter = GetRandomFreeCell();
                distance = GetDistance(emitter, compareLocation);
            }
            while (!((emitter.X <= margin-1                     || // (close to) left edge
                      emitter.X >= gridSize-margin              || // (close to) right edge
                      emitter.Y <= margin-1                     || // (close to) top edge
                      emitter.Y >= gridSize-margin)             && // (close to) bottom edge
                      grid[emitter.X, emitter.Y].OldAmount == 0 && // no other Creeper
                     (minDistance == 0                          || // no minimal distance required
                      compareLocation.IsEmpty                   || // no location to compare to
                      distance >= minDistance)));                  // located at minimal distance

            grid[emitter.X, emitter.Y].OldAmount = amount;

            return emitter; // return the location of the new emitter
        }

        public void Emit(Point mousePos)
        {
            GridCell cell = CellAtMousePos(mousePos);

            if (!cell.IsWall)
            {
                Emit(cell.X, cell.Y);
            }
        }

        private Point GetRandomFreeCell()
        {
            GridCell cell;
            Point freeCell = new Point();
            Random random = new Random();

            do
            {
                freeCell.X = random.Next(0, gridSize-1);
                freeCell.Y = random.Next(0, gridSize-1);
                cell = grid[freeCell.X, freeCell.Y];
                
            }
            while (cell.IsWall || cell.OldAmount != 0);

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
                cell.Draw(graphics, cellWidth, displayGrid, displayDensity);
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
                cell.OldAmount = cell.NewAmount; 
                Total += cell.NewAmount;
                cell.NewAmount = 0;
            }
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

        private double GetDistance(Point point1, Point point2)
        {
            // For now I just use Pythagoras, but Dijkstra's algorithm could also be implemented here.
            double distance = Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));

            return distance;
        }

        public void SwitchDestination(Point mousePos)
        {
            GridCell cell = CellAtMousePos(mousePos);

            if (cell.IsDestination)
            {
                if (destinationCells.Remove(cell))
                {
                    cell.IsDestination = false;
                }
            }
            else
            {
                destinationCells.Add(cell);
                cell.IsDestination = true;
            }
        }

        public bool HasWon()
        {
            bool hasWon = (destinationCells.Count > 0);

            if (hasWon)
            {
                foreach (GridCell cell in destinationCells)
                {   // Check if amount in each destination cell is above required amount
                    hasWon = (Math.Abs(cell.OldAmount) >= destinationAmount) && hasWon;
                }
            }

            return hasWon;
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


