using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsProjects
{
    public static class StringProblems
    {

        public static long repeatedString(string s, long n)
        {

            if (s.Length == 1 && s[0] == 'a') return n;
            int nooftimes = int.Parse(n.ToString()) / s.Length;
            int rem = int.Parse(n.ToString()) % s.Length;

            int count = (nooftimes * countNoofAs(s, s.Length)) + (countNoofAs(s, (rem == 0) ? 0 : rem));

            return count;
        }

        private static int countNoofAs(string s, long n)
        {
            int noofas = 0;
            for (var i = 0; i < n; i++)
            {
                if (s[i] == 'a')
                {
                    noofas++;
                }
                // if (i == n) break;
            }

            return noofas;
        }
        public static string twoStrings(string s1, string s2)
        {
            HashSet<char> store = new HashSet<char>();
            var dd = new int[4];
          //  dd.ToList().AddRange();

            if (s1.Length >= s2.Length)
            {
                
                for (var i = 0; i < s1.Length; i++)
                {
                    store.Add(s1[i]);
                 //   if (s1.IndexOf(s2[i]) != -1) return "YES";
                }
                foreach(char c in s2.ToCharArray())
                if(store.Contains(c)) return "YES";

            }
            else
            {
                for (var i = 0; i < s2.Length; i++)
                {
                    store.Add(s2[i]);
                    //   if (s1.IndexOf(s2[i]) != -1) return "YES";
                }
                foreach (char c in s1.ToCharArray())
                    if (store.Contains(c)) return "YES";
            }

            return "NO";
        }


        public static string[] GetAllSubstring(string str)
        {
            int n = str.Length;
            List<string> strArray = new List<string>();

            for(var i=0; i <= str.Length; i++)
            {
                for(var j=i+1; j<= str.Length; j++)
                {
                    strArray.Add(str.Substring(i, j-i));
                }
            }
            return strArray.ToArray();
        }

        public static bool CheckAnagram(string s1, string s2)
        {
            if(s1.Length!=s2.Length) return false;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach(char c in s1)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }
            foreach (char c in s2)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]--;
                }
                else
                {
                    return false;
                }
            }
         


            return true;
        }

        public static int CountAnagram(int currentindex, string[] str)
        {
            int count = 0;
            bool[] visited = new bool[str.Length];
            for (var i = 0; i < str.Length; i++)
            {
                if (currentindex == i || visited[i]) continue;
                if (CheckAnagram(str[currentindex], str[i])) {

                    count++;
                    visited[i] = true;
                }
            }


            return count;

        }


        public static int alternatingCharacters(string s)
        {
            //abbbab
            int count = 0;
            int rightpointer = 0;
            int leftpointer = 1;
            while(rightpointer< s.Length)
            {
                if(s[rightpointer] != s[leftpointer])
                {
                    rightpointer++;
                    leftpointer++;
                }
                else
                {
                    count++;
                    rightpointer++;
                    leftpointer++;
                }

            }
            return count;
        }

        public static string isValid(string s)
        {
            Dictionary<char, int> store = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (store.ContainsKey(c))
                {
                    store[c]++;
                }
                else
                {
                    store.Add(c, 1);
                }
            }

            var storeArray = store.Values.ToArray();
            for(var i=0; i<store.Values.Count; i++)
            {
                if(storeArray[i] != storeArray[i + 1])
                {

                }
            }

            return "YES";
        }

        public static int sherlockAndAnagrams(string s)
        {
            var substr = GetAllSubstring(s);
            int count = 0;
            for (var i = 0; i < substr.Length; i++)
            {

                count += CountAnagram(i, substr);
            }
            return count;
        }
    }
}
