using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsProjects
{
    class NumberProblems
    {

        public static int ReverseInteger(int x)
        {
            int reversed = 0;
            int pop = 0;

            while(x!=0)
            {
                pop = x % 10;
                x /= 10;
                if (reversed > int.MaxValue / 10 || reversed <= int.MinValue / 10) return 0;
                reversed = (reversed * 10) + pop;

            }

            return reversed;
        }
        public static bool NumberisPalidrome(int x)
        {
            if (x == 0) return false;
            if (x < 0 || x % 10 == 0) return false;


            int reversed = 0;

            while(x > reversed)
            {
                int pop = x % 10;
                x /= 10;
                reversed = (reversed * 10) + pop;
            }
            if (x == reversed || x == reversed / 10) return true;

            return false;
        }
        //trying to use two pinter;
        public static int BinaryGap(uint N)
        {
            int res = 0;

            int left = 0;
            int right = 0;
            int gap = 0;
            int currentGap = 0;
            int numberOfOnes = 0;
            string binary = ConvertToBinary(N);

            while(right< binary.Length)
            {
                if (binary[right] == '0') {
                    gap++;
                    
                  
                    right++;
                }
                else
                {
                    if (currentGap < gap) currentGap = gap;
                    numberOfOnes++;
                   
                    
                    gap = 0;
                 
                    right++;
                    left = right;
                }
               

            }

            if (numberOfOnes == 1 && binary[0] == '1') currentGap = 0;
                return currentGap;
        }

        public static string ConvertToBinary(uint N)
        {
            string res = "";
            while(N > 0)
            {
                res += (N % 2).ToString();
                N /= 2;
            }
            string revResult ="";
            for(var i = res.Length-1; i >=0; i--)
            {
                revResult += res[i].ToString();
            }
            return revResult;
        }
       
    }
}
