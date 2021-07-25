using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsProjects
{
   public  static class ArrayProblems
    {
        //In this example the input array is sorted
        public static int[]  TwoSum(int[] numbers, int target)
        {
            int[] position = new int[2];
            //Using poniters

            int leftPointer = 0;
            int rightPointer = numbers.Length - 1;

            while(leftPointer <= rightPointer)
            {
                int sum = numbers[leftPointer] + numbers[rightPointer];
                if ( sum < target)
                {
                    leftPointer++;
                }
                else if(sum> target)
                {
                    rightPointer--;
                }
                else if(sum == target)
                {
                    position[0] = leftPointer;
                    position[1] = rightPointer;
                    return position;
                }
            }


            return position;
        }


        public static bool ArrayBinarySearchRecursion(int[] arr, int target, int left, int right)
        {
            if (left > right) return false;
            int mid = (left + right) / 2;
            if(arr[mid] == target)
            {
                return true;
            }else if(arr[mid]< target)
            {
                return ArrayBinarySearchRecursion(arr, target, left, mid - 1);
            }
            else
            {
                return ArrayBinarySearchRecursion(arr, target, mid + 1, right);
            }
           // return false;
        }

        public static bool ArrayBinarySearchIterative(int[] arr, int target, int left, int right)
        {
            Dictionary<int, int> table = new Dictionary<int, int>();
            
            if (left > right) return false;
            int mid = (left + right) / 2;
            if (arr[mid] == target)
            {
                return true;
            }
            else if (arr[mid] < target)
            {
                return ArrayBinarySearchRecursion(arr, target, left, mid - 1);
            }
            else
            {
                return ArrayBinarySearchRecursion(arr, target, mid + 1, right);
            }
            // return false;
        }

        public static int[] TwoSumHashTable(int[] nums, int target)
        {
             
            Dictionary<int, int> table = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {

                int compliment = target - nums[i];

                if (table.ContainsKey(compliment))
                {
                    return new int[2] { i, table[compliment] };
                }
                table.Add(nums[i], i);
            }


            return null;
        }
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            //HashSet<IList<int>> result = new HashSet<IList<int>>();
            //Array.Sort(nums);


            //for (int i = 0; i < nums.Length - 2; i++)
            //{
            //    int j = i + 1, k = nums.Length - 1;

            //    while (j < k)
            //    {
            //        int sum = nums[i] + nums[j] + nums[k];
            //        if (sum < 0)
            //        {
            //            j++;
            //        }
            //        else if (sum > 0)
            //        {
            //            k--;
            //        }
            //        else
            //        {
            //            result.add(Array.(nums[i], nums[j], nums[k]));
            //            j++;
            //            k--;
            //        }
            //    }
            //}
            //return new ArrayList<>(res);

            return null;
        }
        //Rotate and Array
        public static void RotateArray(int[] arr, int k)
        {
            k %= arr.Length;
            Rotate(arr, 0, arr.Length - 1);
            Rotate(arr, 0, k - 1);
            Rotate(arr, k, arr.Length - 1);

        }

        //Helper method for rotation
        private static void Rotate(int[] arr, int start, int end)
        {
            while(start< end)
            {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }
        public static int MaxSubArray(int[] nums)
        {

            int max = nums[0];
            int current = nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                current = Math.Max(nums[i], current + nums[i]);

                max = Math.Max(current, max);
            }

            return max;
        }

        public static int OddOccuranceinArray(int[] arr)
        {
            HashSet<int> dd = new HashSet<int>();
           
            if (arr.Length < 1) return 0;
            Dictionary<int,int> table = new Dictionary<int, int>();

            for (var i=0; i< arr.Length; i++)
            {
                if (!table.ContainsKey(arr[i]))
                {
                    table.Add(arr[i], 1);
                }
                else
                {
                    table[arr[i]] += 1;
                }


                
            }
            foreach(var key in table.Keys)
            {
                if (table[key] == 1) return key;
            }

            return 0;
        }



        public static int SucksMerchant(int[] ar, int n)
        {
            int pairs = 0;

            Dictionary<int, int> table = new Dictionary<int, int>();
            for(var i=0; i< n; i++)
            {
                if (table.ContainsKey(ar[i]))
                {
                    table[ar[i]]++;
                }
                else
                {
                    table.Add(ar[i], 1);
                }
            }
          foreach(var i in table.Values) { 
                if (i> 1)
                {
                    pairs += i / 2;
                }
            }




            return pairs;
        }
        public static  int FrogJump(int X, int[] A)
        {
            // write your code in Java SE 8


            Dictionary<int, int> table = new Dictionary<int, int>();


            for (var i = 0; i < A.Length; i++)
            {
                if (!table.ContainsKey(A[i]))
                {
                    table.Add(A[i], i);
                }
            }
            foreach (var key in table.Keys)
            {
                if (key == X) return table[key];

            }

            return -1;


    }

        public static int NumberOfJumps(int X, int Y, int D)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (X == Y) return 0;
            int noOfJumps = 0;
            while (X <Y)
            {
                X += D;
                noOfJumps++;

            }
            return noOfJumps ;
        }
        public static int NumberOfJumpsOptimized(int X, int Y, int D)
        {
            if (X == Y) return 0;
       

            int distanceToJump = Y - D;

            int jumpRequired = distanceToJump / D;

            if (distanceToJump % D != 0) jumpRequired += 1;


            return jumpRequired;
          
        }

        public static int MissingNumber(int[] A)
        {
            int max = A.Length + 1;
            HashSet<int> incomplete = new HashSet<int>();
            for (var i = 0; i < A.Length; i++)
            {
                incomplete.Add(A[i]);
            }
            for (var i = 0; i < max + 1; i++)
            {
                if (!incomplete.Contains(i))return i;
            }
            return 0;
        }


        public static int TapeEquilibrium(int[] A)
        {
            if (A.Length < 1 ) return 0;
           
            int totalArrSum = 0;
            int currentSum = 0;
            int secondPart = 0;
            int minDifference = int.MaxValue;
            for(var i=0; i< A.Length; i++)
            {
                totalArrSum += A[i];
            }
            for(var p = 0; p < A.Length; p++)
            {
                currentSum += A[p];
                secondPart = totalArrSum - currentSum;
                minDifference = Math.Min(minDifference, Math.Abs(currentSum - secondPart));

            }
            return minDifference;
        }
        public static void minimumBribes(int[] q)
        {
            int swaps = 0;
            for(var i = q.Length -1; i>=0; i--)
            {
                if (q[i] != i + 1)
                {
                    //check that the index and the element are the same on one step ahead
                    if (i - 1 >= 0 && q[i - 1] == i + 1)
                    {
                        int temp = q[i - 1];
                        q[i - 1] = q[i];
                        q[i] = temp;
                        swaps++;
                    }
                    else if (i - 2 >= 0 && q[i - 2] == i + 1)
                    {
                        q[i - 2] = q[i - 1];
                        q[i - 1] = q[i];
                        q[i] = q[i - 2];
                        swaps += 2;
                    }
                    else
                    {
                        Console.WriteLine("Too Chaotic");
                        return;
                    }
                }
            }

        }

        public static int[] rotLeft(int[] a, int d)
        {
            int rotateIndex = d;
            int[] rotatedArr = new int[a.Length];
            int i = 0;
            while(rotateIndex < a.Length)
            {
                rotatedArr[i] = a[rotateIndex];
                i++;
                rotateIndex++;
            }

            rotateIndex = 0;

            while (rotateIndex < d)
            {
                rotatedArr[i] = a[rotateIndex];
                i++;
                rotateIndex++;
            }


            return rotatedArr;
        }

        static int minimumSwaps(int[] arr)
        {

            Dictionary<int, int> store = new Dictionary<int,int>();
            for(var j=0; j< arr.Length; j++)
            {
                store[j] =j;
            }
            int count = 0;
            int i = 0;
            while (i < arr.Length)
            {
              //  int index = arr[i] - 1;
                if (arr[i] != i+1)
                {

                  //  arr[index] = arr[i];
                    count++;
                    int temp = arr[i];
                    arr[i] = i + 1;
                    store[arr[i + 1]] = temp;
                    store[temp] = store[i + 1];
                }
               
                    i++;
                
            }
            return count;
        }


    }


}
