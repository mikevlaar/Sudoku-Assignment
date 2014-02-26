using Sudoku0Solver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver
{
    class Program
    {
        public int SIZE = 9;
        public int numEmptyCells = 0;

        public int[][] grid;
        public int[][] emptyCellsList;

        public Program()
        {
            grid = new int[SIZE][];
            emptyCellsList = new int[SIZE * SIZE][];

            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = new int[SIZE];
            }

            for (int i = 0; i < emptyCellsList.Length; i++)
            {
                emptyCellsList[i] = new int[SIZE];
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.start();
        }

        private void start()
        {
            SudokuPuzzle sudokuPuzzle = new SudokuPuzzle();
            SudokuSolver solver = new SudokuSolver();

            solver.initializeGrid(grid, sudokuPuzzle.puzzle);
            numEmptyCells = solver.getEmptyCells(grid, emptyCellsList);
            Console.WriteLine("The puzzle:");
            solver.displayGrid(sudokuPuzzle.puzzle);

            if (solver.solvePuzzle(grid, emptyCellsList, numEmptyCells))
            {
                Console.WriteLine("has been solved:");
                solver.displayGrid(grid);
            }
            else
            {
                Console.WriteLine("cannot be solved!");
            }
            Console.ReadLine();
        }
    }
}
