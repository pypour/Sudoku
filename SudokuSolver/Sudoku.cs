using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace SudokuSolver
{
    public class Sudoku
    {
        public bool Solve(Dictionary<int, Dictionary<int, int>> values, out string message)
        {
            message = string.Empty;
            if (values.Any(x => x.Value.Where(y => y.Value != 0).Select(y => y.Value)
                .GroupBy(y => y).Any(y => y.Count() > 1)))
            {
                message = "There are some duplicate values in same row!";
                return false;
            }

            for (int i = 0; i < values[0].Count; i++)
            {
                if (values.Select(x => x.Value[i]).Where(x => x != 0).GroupBy(x => x).Any(x => x.Count() > 1))
                {
                    message = "There are some duplicate values in same column!";
                    return false;
                }
            }

            return Solve(values);
        }

        private bool Solve(Dictionary<int, Dictionary<int, int>> values)
        {
            for (var i = 0; i < values.Count; i++)
            {
                var row = values[i];
                for (var j = 0; j < row.Count; j++)
                {
                    if (row[j] == 0)
                    {
                        for (var c = 1; c <= 9; c++)
                        {
                            if (isValid(values, i, j, c))
                            {
                                row[j] = c;

                                if (Solve(values))
                                    return true;
                                else
                                    row[j] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool isValid(Dictionary<int, Dictionary<int, int>> board,
            int row, int col, int value)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i][col] != 0 && board[i][col] == value)
                    return false;
                if (board[row][i] != 0 && board[row][i] == value)
                    return false;
                if (board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] != 0 &&
                    board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] == value)
                    return false;
            }
            return true;
        }
    }
}