using Sudoku0Solver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver
{
    public class SudokuSolver
    {
        public void initializeGrid(int[][] grid, int[][] puzzle)
        {
            for (int r = 0; r < puzzle.Length; r++)
            {
                for (int c = 0; c < puzzle[0].Length; c++)
                {
                    grid[r][c] = puzzle[r][c];
                }
            }
        }

        public void displayDigits(int r, int c, int[][] grid)
        {
            if (grid[r][c] == 0)
            {
                Console.Write('0');
            }
            else
            {
                Console.Write(grid[r][c]);
            }
        }

        public void displayGrid(int[][] grid)
        {
            for (int r = 0; r < grid.Length; r++)
            {
                if (r % 3 == 0)
                {
                    Console.WriteLine("+---+---+---+");
                }
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (c % 3 == 0)
                    {
                        Console.Write("|");
                    }
                    displayDigits(r, c, grid);
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("+---+---+---+");
        }

        public int getEmptyCells(int[][] grid, int[][] emptyCells)
        {
            int i = 0;
            int numEmptyCells = 0;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] == 0)
                    {
                        emptyCells[i][0] = r;
                        emptyCells[i][1] = c;
                        numEmptyCells++;
                        i++;
                    }
                }
            }
            return numEmptyCells;
        }

        private bool hasNoDuplicates(int[] digitsList)
        {
            for (int j = 0; j < digitsList.Length; j++)
            {
                for (int k = j + 1; k < digitsList.Length; k++)
                {
                    if (digitsList[j] == digitsList[k] && digitsList[j] != 0)
                        return false;
                }
            }
            return true;
        }

        private bool checkCurrentRow(int[][] grid, int currentRow)
        {
            int[] digitsList = new int[grid.Length];
            for (int c = 0; c < digitsList.Length; c++)
            {
                digitsList[c] = grid[currentRow][c];
            }
            if (hasNoDuplicates(digitsList))
            {
                return true;
            }
            return false;
        }

        private bool checkCurrentCol(int[][] grid, int currentCol)
        {
            int[] digitsList = new int[grid.Length];
            for (int i = 0; i < digitsList.Length; i++)
            {
                digitsList[i] = grid[i][currentCol];
            }
            if (hasNoDuplicates(digitsList))
            {
                return true;
            }
            return false;
        }

        private bool checkCurrentRegion(int[][] grid, int currentRow, int currentCol)
        {
            int[] digitsList = new int[grid.Length];
            currentRow = (currentRow / 3) * 3;
            currentCol = (currentCol / 3) * 3;
            int i = 0;
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    digitsList[i] = grid[currentRow + r][currentCol + c];
                    i++;
                }
            }
            if (hasNoDuplicates(digitsList))
            {
                return true;
            }
            return false;
        }

        public bool isConsistent(int[][] grid, int currentRow, int currentCol)
        {
            bool checkRow = checkCurrentRow(grid, currentRow);
            bool checkCol = checkCurrentCol(grid, currentCol);
            bool checkReg = checkCurrentRegion(grid, currentRow, currentCol);

            if (checkRow && checkCol && checkReg)
            {
                return true;
            }
            return false;
        }

        public bool solvePuzzle(int[][] grid, int[][] emptyCells, int numEmptyCells)
        {
            int i = 0;
            int currentCellNum = 0;
            while (i < numEmptyCells)
            {
                currentCellNum = grid[emptyCells[i][0]][emptyCells[i][1]];
                if (currentCellNum != 9)
                {
                    currentCellNum++;
                    grid[emptyCells[i][0]][emptyCells[i][1]] = currentCellNum;
                    if (isConsistent(grid, emptyCells[i][0], emptyCells[i][1]))
                    {
                        i++;
                    }
                }
                else
                {
                    currentCellNum = 0;
                    grid[emptyCells[i][0]][emptyCells[i][1]] = currentCellNum;
                    i--;
                    if (i < 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
