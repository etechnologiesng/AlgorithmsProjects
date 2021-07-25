using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsProjects
{
    class TwoPointerProblems
    {

        public static int MaxAreaLeetCode11(int[] height)
        {
            int leftPointer = 0;
            int rightPointer = height.Length - 1;

            int maxArea = 0;
            while (leftPointer < rightPointer)
            {
                maxArea = Math.Max(maxArea, Math.Min(height[leftPointer], height[rightPointer]) * (rightPointer - leftPointer));

                if (height[rightPointer] > height[leftPointer]) 
                { leftPointer++; }
                else { rightPointer--; }
            }
            return maxArea;
        }


        public static int Trap(int[] height)
        {
            int left = 0, right = height.Length- 1;
            int ans = 0;
            int left_max = 0, right_max = 0;
            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (height[left] >= left_max)
                    { 
                        left_max = height[left] ;
                    } else { 
                        ans += (left_max - height[left]);
                    }
                    ++left;
                }
                else
                {
                    if (height[right] >= right_max)
                    {
                        right_max = height[right]; 
                    } 
                    else {
                        ans += (right_max - height[right]); 
                    }
                    --right;
                }
            }
            return ans;
        }


        //Same problem Looping
        // in this approach we get the max value by moving from left to right and right to left
        // thn we update sum by get the min

        public static  int TrapUsingLoop(int[] height)
        {
            int size = height.Length;
            int ans = 0;
            int[] leftMax = new int[size];
            int[] rightMax = new int[size];
           
            leftMax[0] = height[0];
            for (var i = 1; i < size; i++)
            {
                leftMax[i] = Math.Max(height[i], leftMax[i - 1]);
            }

            rightMax[height.Length - 1] = height[height.Length - 1];

            for (var i = size-2 ; i >=0 ; i--)
            {
                rightMax[i] = Math.Max(height[i], rightMax[i + 1]);
            }

            for (int i = 1; i < size - 1; i++)
            {
                ans += Math.Min(leftMax[i], rightMax[i]) - height[i];
            }

            return ans;
    }

    }
}
