using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsProjects
{
    public static class DynamicPrograming
    {

        public static int DPLongestCommonSubstring(string s1, string s2, int s1_index, int s2_index, int count)
        {
            //base case;
            int[,,] dp = new int[s1.Length, s2.Length, Math.Max(s1.Length, s2.Length)];


            if (s1_index == s1.Length || s2_index == s2.Length)
            {
                return count;
            }

            if (dp[s1_index, s2_index, count] == 0)
            {
                int c1 = count;

                if (s1[s1_index] == s2[s2_index])
                {
                    c1 = DPLongestCommonSubstring(s1, s2, s1_index + 1, s2_index + 1, count + 1);
                }

                int c2 = DPLongestCommonSubstring(s1, s2, s1_index, s2_index + 1, 0);
                int c3 = DPLongestCommonSubstring(s1, s2, s1_index + 1, s2_index, 0);

                dp[s1_index, s2_index, count] = Math.Max(count, Math.Max(c2, c3));
            }
            return dp[s1_index, s2_index, count];

        }

        //Now using a Bottom Up approach

        public static int KnapSackProblem(int[] profits, int[] weights, int currentindex, int capacity)
        {
            if (currentindex >= profits.Length || capacity <= 0 || currentindex < 0 || weights.Length != profits.Length) return 0;

            int profit1 = 0;
            if (weights[currentindex] <= capacity)
            {
                profit1 = profits[currentindex] + KnapSackProblem(profits, weights, currentindex, capacity - weights[currentindex]);
            }

            int profit2 = KnapSackProblem(profits, weights, currentindex + 1, capacity);


            return (Math.Max(profit1, profit2));


        }

        public static int KnapSackProblemDP(int[] profits, int[] weights, int currentindex, int capacity)
        {
            if (currentindex >= profits.Length || capacity <= 0 || currentindex < 0 || weights.Length != profits.Length) return 0;


            int[,] dp = new int[weights.Length, capacity + 1];


            if (dp[currentindex, capacity] != 0) return dp[currentindex, capacity];
            int profit1 = 0;
            if (weights[currentindex] <= capacity)
            {
                profit1 = profits[currentindex] + KnapSackProblem(profits, weights, currentindex, capacity - weights[currentindex]);
            }

            int profit2 = KnapSackProblem(profits, weights, currentindex + 1, capacity);


            dp[currentindex, capacity] = (Math.Max(profit1, profit2));

            return dp[currentindex, capacity];


        }

        public static int knapsackRecursive(int[] profits, int[] weights, int capacity,
int currentIndex)
        {

            int[,] dp = new int[profits.Length, capacity + 1];
            // base checks
            if (capacity <= 0 || currentIndex < 0 || currentIndex >= profits.Length)
                return 0;
            // if we have already processed similar problem, return the result from memory
            if (dp[currentIndex, capacity] != 0)
                return dp[currentIndex, capacity];
            // recursive call after choosing the element at the currentIndex
            // if the weight of the element at currentIndex exceeds the capacity, we shouldn’t process this
            int profit1 = 0;
            if (weights[currentIndex] <= capacity)
                profit1 = profits[currentIndex] + knapsackRecursive(profits, weights,
                capacity - weights[currentIndex], currentIndex);
            // recursive call after excluding the element at the currentIndex
            int profit2 = knapsackRecursive(profits, weights, capacity, currentIndex + 1);
            dp[currentIndex, capacity] = Math.Max(profit1, profit2);
            return dp[currentIndex, capacity];
        }


        private static int LongestPalindromeSubsequence(string s1, int startIndex, int endIndex)
        {
            if (startIndex > endIndex) return 0;
            if (startIndex == endIndex) return 1;
            if (s1[startIndex] == s1[endIndex])
            {
                return 2 + LongestPalindromeSubsequence(s1, startIndex + 1, endIndex + 1);
            }

            int c1 = LongestPalindromeSubsequence(s1, startIndex + 1, endIndex);
            int c2 = LongestPalindromeSubsequence(s1, startIndex, endIndex + 1);

            return Math.Max(c1, c2);
        }




        private static int LongestPalindromeSubsequenceDP(string s1, int startIndex, int endIndex)
        {

            int[,] Dp = new int[s1.Length, s1.Length];


            if (startIndex > endIndex) return 0;
            if (startIndex == endIndex) return 1;

            if (Dp[startIndex, endIndex] != 0) return Dp[startIndex, endIndex];

            if (s1[startIndex] == s1[endIndex])
            {
                Dp[startIndex, endIndex] = 2 + LongestPalindromeSubsequence(s1, startIndex + 1, endIndex + 1);
            }
            else
            {
                int c1 = LongestPalindromeSubsequence(s1, startIndex + 1, endIndex);
                int c2 = LongestPalindromeSubsequence(s1, startIndex, endIndex - 1);
                Dp[startIndex, endIndex] = Math.Max(c1, c2);
            }
            return Dp[startIndex, endIndex];
        }


        private static int CoinChangeProblem(int[] coins, int amount, int index, Dictionary<string, int> memo)
        {
            if (amount == 0) return 1;
            if (index >= coins.Length) return 0;

            int ways = 0;
            string key = amount + "-" + index;
            if (memo.ContainsKey(key))
            {
                return memo[key];
            }
            int amountwithCoins = 0;
            while (amountwithCoins <= amount)
            {
                int remaining = amount - amountwithCoins;

                ways += CoinChangeProblem(coins, remaining, index + 1, memo);
                amountwithCoins += coins[index];
            }
            memo.Add(key, ways);

            return ways;

        }


        public static int CountNumberOfStepsDP(int staircase)
        {

            int[] memo = new int[staircase + 1];

            memo[0] = 1;
            memo[1] = 1;
            memo[2] = 2;


            for (var i = 3; i <= staircase; i++)
            {

                memo[i] = memo[i - 1] + memo[i - 2] + memo[i - 3];
            }

            return memo[staircase];

        }



        //Longest Palidrome subsequence using expand around center

        public static string LongestPalidroneSubstring(string s)
        {
            int start = 0;
            int end = 0;
            for (var i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > (end - start))
                {
                    start = i - ((len - 1) / 2);
                    end = i + (len / 2);
                }

            }


            return s.Substring(start, end + 1);
        }


        private static int ExpandAroundCenter(string s, int left, int right)
        {
            if (left > right || s == null) return 0;

            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }



        //public static int LongestCommonSubsequence(string s1, string s2, int indexS1, int indexS2)
        //{

        //    int result = 0;
        //    if (indexS1 == 0 || indexS2 == 0)
        //    {
        //        result = 0;
        //    };

        //    int[,] dp = new int[s1.Length, s2.Length];

        //    if (s1[indexS1] == s2[indexS2])
        //    {
        //        result = 1 + LongestCommonSubsequence(s1, s2, indexS1 - 1, indexS2 - 1);
        //    }
        //    else
        //    {

        //        result = Math.Max(LongestCommonSubsequence(s1, s2, indexS1, indexS2 - 1), LongestCommonSubsequence(s1, s2, indexS1, indexS2 - 1));
        //    }

        //    dp[indexS1, indexS1] = result;

        //    return result;
        //}


        //public static int LongestCommonSubsequence(string s1, string s2, int indexS1, int indexS2)
        //{

        //    int result = 0;
        //    if (indexS1 == 0 || indexS2 == 0)
        //    {
        //        result = 0;
        //    };

        //    int[,] dp = new int[s1.Length, s2.Length];
            
        //    if (s1[indexS1] == s2[indexS2])
        //    {
        //        result = 1 + LongestCommonSubsequence(s1, s2, indexS1 - 1, indexS2 - 1);
        //    }
        //    else
        //    {

        //        result = Math.Max(LongestCommonSubsequence(s1, s2, indexS1, indexS2 - 1), LongestCommonSubsequence(s1, s2, indexS1, indexS2 - 1));
        //    }

        //    dp[indexS1, indexS1] = result;

        //    return result;
        //}
    }
}
