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
        static void Main(string[] args)
        {
            Program program = new Program();
            SudokuPuzzle sudokuPuzzle = new SudokuPuzzle();

            program.start(sudokuPuzzle.Puzzle);
            program.start(sudokuPuzzle.Puzzle2);

            Console.ReadLine();
        }

        private void start(int[][] puzzle)
        {
            SudokuSolver solver = new SudokuSolver();

            Console.WriteLine("The unsolved puzzle:");
            solver.displayGrid(puzzle);

            solver.solve(puzzle, 0, 0);
        }
    }
}
