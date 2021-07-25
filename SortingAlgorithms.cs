using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsProjects
{
    public class SortingAlgorithms
    {
        //ON^2
        public void SelectionSort(int[] arr)
        {
            int len = arr.Length;

            for(var i=0; i<len-1; i++)
            {
                int minIndex = i;
                for(var j=i+1; j<len; j++)
                {
                    if(arr[j] < arr[minIndex])
                    {
                        minIndex = j;

                        int temp = arr[minIndex];
                        arr[minIndex] = arr[i];
                        arr[i] = temp;

                    }

                }
            }
        }

        private static int PartitionFunction(int[] arr, int left, int right)
        {
            int pivot = arr[right];

            int i = left - 1;

            for(var j=left; j < right; j++)
            {
                
                if(arr[j]< pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;

                }

            }
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[right];
            arr[left] = temp1;

            return i + 1;
        }
        static void quickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                /* pi is partitioning index, arr[pi] is  
                now at right place */
                int pi = PartitionFunction(arr, low, high);
                // Recursively sort elements before 
                // partition and after partition 
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
        }
    }
}
