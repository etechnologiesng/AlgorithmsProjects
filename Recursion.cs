using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsProjects
{
   public static class Recursion
    {
        public static int FibanacciSequence(int n)
        {
            if (n <= 1) return n;

            return FibanacciSequence(n - 1) + FibanacciSequence(n - 2);

        }


        public static int CountNumberOfSteps(int staircase)
        {
          

            if (staircase == 0)
            {
                return 1;
            }
            else if(staircase <0 )
            {
                return 0;
            }
            return CountNumberOfSteps(staircase - 1) + CountNumberOfSteps(staircase - 3) + CountNumberOfSteps(staircase - 2);

        }


    }
}
