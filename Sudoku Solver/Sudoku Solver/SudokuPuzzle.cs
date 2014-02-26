using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku0Solver
{
    class SudokuPuzzle
    {
        private int[][] puzzle = {    
                                    new int[9] {4, 8, 0, 0, 0, 6, 9, 0, 2}, 
                                    new int[9] {0, 0, 2, 0, 0, 8, 0, 0, 1}, 
                                    new int[9] {9, 0, 0, 3, 7, 0, 0, 6, 0}, 
                                    new int[9] {8, 4, 0, 0, 1, 0, 2, 0, 0}, 
                                    new int[9] {0, 0, 3, 7, 0, 4, 1, 0, 0}, 
                                    new int[9] {0, 0, 1, 0, 6, 0, 0, 4, 9}, 
                                    new int[9] {0, 2, 0, 0, 8, 5, 0, 0, 7}, 
                                    new int[9] {7, 0, 0, 9, 0, 0, 6, 0, 0}, 
                                    new int[9] {6, 0, 9, 2, 0, 0, 0, 1, 8} 
                                };

        public int[][] Puzzle
        {
            get { return puzzle; }
            set { puzzle = value; }
        }
    }
}
