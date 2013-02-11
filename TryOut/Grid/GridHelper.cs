using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryOut.Grid
{
    class GridHelper
    {
        GridCell[,] grid, auxgrid;
        int amountAverage;
        private List<GridCell> cellList;


        public GridHelper(GridCell[,] gridCells)
        {
            grid = gridCells;
        }

        private void checkForAmounts (GridCell[,] gridCells)
        {
            cellList = new List<GridCell>();

            foreach(GridCell cell in grid)
            {
                if(cell.Amount > 0)
                {
                    cellList.Add(cell);
                }
            }

          // amountAverage = GetAverage();
        }


       /* private int GetAverage()
        {
            for(int i = 0; i < cellList.
        }*/

    }
}
