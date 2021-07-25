using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsProjects
{
    public static class Stacks
    {

        public static char[][] TOKENS = new char[][] { new char[] { '{', '}' }, new char[] { '[', ']' }, new char[] { '(', ')' } };

        private static bool OpenTerm(char c)
        {
            for (var i = 0; i < TOKENS.Length; i++)
            {
                if (c == TOKENS[i][0]) return true;
            }
            return false;
        }

        private static bool IsMatch(char o, char c)
        {
            for (var i = 0; i < TOKENS.Length; i++)
            {
                if (o == TOKENS[i][0]) return c == TOKENS[i][1];
            }
            return false;

        }
        public static int ProperlyNestedBracket(string s)
        {
            if (s.Length % 2 != 0) return 0;

            Stack<char> stack = new Stack<char>();
            for (var i = 0; i < s.Length; i++)
            {
                if (OpenTerm(s[i]))
                {
                    stack.Push(s[i]);
                }
                else
                {
                    if (stack.Count <= 0 || !(IsMatch(stack.Pop(), s[i]))) return 0;
                }
            }



            return (stack.Count < 1) ? 1 : 0;
        }

        public static int LargestRectangleArea(int[] height)
        {
            var maxArea = 0;
            var mystack = new Stack<int>();

            for (var i = 0; i < height.Length; i++)
            {
                while (mystack.Count > 0 && height[i] <= height[mystack.Peek()])
                {
                    var top = mystack.Pop();
                    var prelessHeight = mystack.Count == 0 ? -1 : mystack.Peek();

                    maxArea = Math.Max(maxArea, height[top] * (i - prelessHeight - 1));
                }

                mystack.Push(i);
            }

            var lastIndex = mystack.Any() ? mystack.Peek() : -1;
            while (mystack.Any())
            {
                var top = mystack.Pop();
                var prelessHeight = mystack.Count == 0 ? -1 : mystack.Peek();

                maxArea = Math.Max(maxArea, height[top] * (lastIndex - prelessHeight));
            }

            return maxArea;


        }
    }
}
