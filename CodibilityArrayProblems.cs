using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsProjects
{
    class CodibilityArrayProblems
    {

        public static int DistinctElements(int[] A)
        {
            if (A.Length < 1) return 0;
            HashSet<int> distinct = new HashSet<int>();
            for (var i=0; i< A.Length; i++)
            {
                if (!distinct.Contains(A[i]))
                {
                    distinct.Add(A[i]);
                }
            }
            return distinct.Count;
        }
    }
}
