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
        /**
        * Displays the grid in a shiny sudoku field.
        * @param grid the array that contains the row to be checked
        */
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

        /**
        * The main recursive method for solving the sudoku puzzle
        * @param puzzle the 2D array puzzle to be solved
        * @param row the row of the position to solve
        * @param col the column of the position to solve
        */
        public void solve(int[][] puzzle, int row, int col)
        {
            if (row > puzzle.Length - 1)
            {
                Console.WriteLine("Solution Found:");
                displayGrid(puzzle);
                return;
            }
            if (puzzle[row][col] != 0)
            {
                next(puzzle, row, col);
            }
            else
            {
                for (int num = 1; num < puzzle.Length + 1; num++)
                {
                    if (checkRow(puzzle, row, num) && checkCol(puzzle, col, num) && checkBox(puzzle, row, col, num))
                    {
                        puzzle[row][col] = num;
                        next(puzzle, row, col);
                    }
                }
                puzzle[row][col] = 0;
            }
        }

        /**
        * Invokes the solve() method on the next number in the 2D array
        * @param puzzle the array
        * @param row the row of the current place in the array  
        * @param col the column of the current place in the array
        */
        private void next(int[][] puzzle, int row, int col)
        {
            if (col <= puzzle.Length - 2)
            {
                solve(puzzle, row, col + 1);
            }
            else
            {
                solve(puzzle, row + 1, 0);
            }
        }

        /**
        * Displays the digit inside the grid.
        * @param grid the array that contains the row to be checked
        * @param row the row to check for the number
        * @param column the column to check for the number
        */
        private void displayDigits(int row, int column, int[][] grid)
        {
            if (grid[row][column] == 0)
            {
                Console.Write('0');
            }
            else
            {
                Console.Write(grid[row][column]);
            }
        }

        /**
        * Checks a row in the array to see if it contains a number
        * @param grid the array that contains the row to be checked
        * @param row the row to check for the number
        * @param num the number that is checked for
        * @return true if num not in row, false if it is.
        */
        private bool checkRow(int[][] grid, int row, int num)
        {
            for (int col = 0; col < grid.Length; col++)
            {
                if (grid[row][col] == num)
                {
                    return false;
                }
            }
            return true;
        }

        /**
        * Checks a column in the array to see if it contains a number 
        * @param grid the array that contains the column to be checked
        * @param col the column to check for the number
        * @param num the number that is checked for
        * @return true if num not in col, false if it is.
        */
        private bool checkCol(int[][] grid, int col, int num)
        {
            for (int row = 0; row < grid.Length; row++)
            {
                if (grid[row][col] == num)
                {
                    return false;
                }
            }
            return true;
        }

        /**
        * Checks a 3x3 "box" in the array to see if it contains a number
        * @param grid the array that contains the "box" to be checked
        * @param row the row of a number in the "box"
        * @param col the column of a number in the "box"
        * @param num the number that is checked for
        * @return true if num not in "box", false if it is.
        */
        private bool checkBox(int[][] grid, int row, int col, int num)
        {
            row = (row / (grid.Length / 3) * (grid.Length / 3));
            col = (col / 3) * 3;
            for (int r = 0; r < (grid.Length / 3); r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (grid[row + r][col + c] == num)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
