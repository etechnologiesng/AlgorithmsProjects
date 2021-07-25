using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsProjects
{
    class SlidingWindowProblems
    {
        public static int LongestSubstringWithoutDuplicateLeetCode3(string s)
        {
            int leftPointer = 0;
            int rightPointer = 0;
            int maxlenght = 0;
            HashSet<char> characters = new HashSet<char>();
            while(rightPointer < s.Length-1)
            {
                if (!characters.Contains((char)s[rightPointer]))
                {
                    characters.Add(s[rightPointer]);
                    rightPointer++;
                    maxlenght = Math.Max(characters.Count, maxlenght);
                }
                else
                {
                    characters.Remove(s[leftPointer]);
                    leftPointer++;
                }
            }

            return maxlenght;
        }
    }
}
