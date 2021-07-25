using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsProjects
{
    public class PascalsTriangle
    {

        public List<List<int>> GeneratePascals(int noRows)
        {
            List<List<int>> pascalsTriangle = new List<List<int>>();

            if (noRows == 0) return pascalsTriangle;

            List<int> firstRow = new List<int> { 1 };

            pascalsTriangle.Add(firstRow);

            for( var i=1; i< noRows; i++)
            {
                List<int> prevRow = pascalsTriangle[i - 1];
                List<int> row = new List<int>();
                row.Add(1);
                for(var j =0; j<i; j++)
                {
                    row.Add(prevRow[j - 1] + prevRow[j]);
                    row.Add(1);
                    pascalsTriangle.Add(row);
                }
            }

            return pascalsTriangle;
        }

        
    }
}
