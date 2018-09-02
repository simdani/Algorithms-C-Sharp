// question: write an algorithm such that if an element in an MxN matrix
// is 0, its entire row and column are set to 0

namespace Algorithms.CTCI.Arrays_and_Strings
{
    public static class ZeroMatrix
    {
        // solution #1
        public static void SetZeros(int[][] matrix)
        {
            bool[] row = new bool[matrix.Length];
            bool[] column = new bool[matrix[0].Length];

            // store the row and column index with value 0
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        row[i] = true;
                        column[j] = true;
                    }
                }
            }

            // nulify rows
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i])
                {
                    NulifyRow(matrix, i);
                }
            }

            // nulify columns
            for (int j = 0; j < column.Length; j++)
            {
                if (column[j])
                {
                    NulifyColumn(matrix, j);
                }
            }
        }

        private static void NulifyRow(int[][] matrix, int row)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                matrix[row][j] = 0;
            }
        }

        private static void NulifyColumn(int[][] matrix, int column)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i][column] = 0;
            }
        }


        // solution #2 optimized for space(1)
        public static void SetZerosOptimized(int[][] matrix)
        {
            bool rowHasZero = false;
            bool colHasZero = false;

            // check if first row has a zero
            for (int j = 0; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0)
                {
                    rowHasZero = true;
                    break;
                }
            }

            // check if first column has a zero
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    colHasZero = true;
                    break;
                }
            }
            // check for zeros in the of the array
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            // nulify rows based on values in first column
            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    NulifyRow(matrix, i);
                }
            }

            // nulify columns based on values in first row
            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0)
                {
                    NulifyColumn(matrix, j);
                }
            }

            // nulify first row
            if (rowHasZero)
            {
                NulifyRow(matrix, 0);
            }

            // nulify first column
            if (colHasZero)
            {
                NulifyColumn(matrix, 0);
            }
        }
    }
}
