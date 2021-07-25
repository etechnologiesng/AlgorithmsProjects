using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsProjects
{
   public static class NumberofIslands
    {

        public static int NumberofIslandsExample(char[][] grid)
        {
            int count = 0;

            for(var i=0; i<grid.Length; i++)
            {

                for(var j=0; j<grid[i].Length; j++)
                {
                    if (grid[i][j] == '1') { count++;
                        CallBFS(grid, i, j);
                    }
                }
            }
            return count;
        }


        private static void CallBFS(char[][] grid , int i, int j)
        {

 
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || grid[i][j] == '0') return;

            grid[i][j] = '0';

            CallBFS(grid, i+1, j);
            CallBFS(grid, i-1, j);
            CallBFS(grid, i, j-1);
            CallBFS(grid, i, j+1);
        }
    }


}
