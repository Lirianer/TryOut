﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryOut.Grid
{
    class MainGrid
    {
        int gridWidth, gridHeigth;
        int gridCellSide;
        int gridCellX, gridCellY;
        int xCells, yCells;
        GridCell[,] grid;

        public MainGrid(Graphics g/*int width, int heigth*/)
        {
            
            gridCellSide = 30;
            gridCellX = 0;
            gridCellY = 0;

            gridWidth = 300; //width;
            gridHeigth = 300; //heigth;

            xCells = gridWidth / gridCellSide;
            yCells = gridHeigth / gridCellSide;
            
            grid = new GridCell[xCells,yCells];

            for (int i = 0; i < xCells; i++)
            {
                for (int j = 0; j < yCells; j++)
                {
                    grid[i, j] = new GridCell(gridCellSide,gridCellX, gridCellY);
                    gridCellY += gridCellSide;
                }
                gridCellX += gridCellSide;
                gridCellY = 0;
            }

            foreach (GridCell cell in grid)
            {
                cell.DrawCell(g);
            }

        }

    }
}
