using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsProjects
{
    public class HashTableProblems
    {

        public static string twoStrings(string s1, string s2)
        {
            
            Dictionary<char, int> table = new Dictionary<char, int>();

            if (s1.Length <= s2.Length)
            {
                for(var i = 0; i< s2.Length; i++)
                {
                    if (table.ContainsKey(s2[i]))
                    {
                        table[s2[i]]++;
                    }
                    else
                    {
                        table.Add(s2[i], 1);
                    }
                }

                foreach(char c in s1)
                {
                    if (table.ContainsKey(c)) return "YES";
                }

            }
            else
            {
                for (var i = 0; i < s1.Length; i++)
                {
                    if (table.ContainsKey(s1[i]))
                    {
                        table[s1[i]]++;
                    }
                    else
                    {
                        table.Add(s1[i], 1);
                    }
                }

                foreach (char c in s2)
                {
                    if (table.ContainsKey(c)) return "YES";
                }
            }
            return "NO";
        }
    }
}
