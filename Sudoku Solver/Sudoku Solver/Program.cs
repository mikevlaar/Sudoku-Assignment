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
        public Program()
        {

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

            Console.WriteLine("The unsolved puzzle:");
            solver.displayGrid(sudokuPuzzle.Puzzle);

            solver.solve(sudokuPuzzle.Puzzle, 0, 0);
            Console.ReadLine();
        }
    }
}
