using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    internal static class Extensions
    {
        internal static void Initialize(this Dictionary<int, Dictionary<int, int>> values, int size)
        {
            for (int row = 0; row < size; row++)
            {
                values.Add(row, new Dictionary<int, int>());
                for (int col = 0; col < size; col++)
                {
                    values[row].Add(col, 0);
                }
            }
        }

        internal static void Initialize(this Dictionary<int, Dictionary<int, List<int>>> values, int rowCount, int size)
        {
            for (int i = 0; i < rowCount; i++)
            {
                values.Add(i, new Dictionary<int, List<int>>());
                for (int j = 0; j < rowCount; j++)
                {
                    values[i].Add(j, new int[size].ToList());
                }
            }
        }
    }
}
