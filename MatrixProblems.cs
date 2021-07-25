using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsProjects
{
    public static class MatrixProblems
    {

        public static int UniquePaths(int m, int n)
        {
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for (int j = 0; j < n; j++)
            {

                dp[0, j] = 1;
            }
            for (var i = 1; i < m; i++)
            {
                for (var j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
            return dp[m - 1, n - 1];


        }

        public static int MinPathSum(int[][] grid)
        {

            int row = grid.Length;
            int col = grid[0].Length;
            int[,] dp = new int[row, col];
            dp[0, 0] = grid[0][0];


            for (var i = 1; i < row; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + grid[i][0];
            }
            for (var i = 1; i < col; i++)
            {
                dp[0, i] = grid[0][i] + dp[0, i - 1];
            }


            for (var i = 1; i < row; i++)
            {
                for (var j = 1; j < col; j++)
                {


                    dp[i, j] = grid[i][j] + Math.Min(dp[i - 1, j], dp[i, j - 1]);
                }


            }
            return dp[row - 1, col - 1];
        }
    }
}
