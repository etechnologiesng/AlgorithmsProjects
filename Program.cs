using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsProjects
{
    class Program
    {
        static void Main(string[] args)
        {
           // StringProblems.CheckAnagram("om", "mo");
            StringProblems.sherlockAndAnagrams("mom");
            StringProblems.GetAllSubstring("mom");
            var ar = new int[] { 10, 20, 20, 10, 10, 30, 50, 10, 20 };
            Console.WriteLine(StringProblems.repeatedString("afcfffaged", 10));

            //int[][] li = { new int[] { 1 }, new int[] { 2 }, new int[] { 3 }, new int[] { } };
            //li.ToList();


            //Console.WriteLine(Graph.canVisitAllRooms(li.ToList<List<int>>()));
    Console.WriteLine(DynamicPrograming.LongestPalidroneSubstring("racecar"));
            Console.WriteLine(Stacks.ProperlyNestedBracket("{[()()]}"));
            // NumberProblems.BinaryGap(2147483648);
            ArrayProblems.TapeEquilibrium(new int[] { 3, 1, 2, 4, 3 });
            char[][] jagged_arr = new char[][]
{
    new char[] {'0', '1', '0', '1'},
    new char[] {'1', '0', '0', '1'},
    new char[] {'0', '1', '0', '1'},
    new char[] {'0', '1', '0', '1'},
};


            //Console.WriteLine(ArrayProblems.TwoSum(new int[] { 2, 5, 6, 9, 10, 15 }, 11)[0]+" , "+ ArrayProblems.TwoSum(new int[] { 2, 5, 6, 9, 10, 15 }, 11)[1] );
            int[] arr = new int[] { 230, 863, 916, 585, 981, 404, 316, 785, 88, 12, 70, 435, 384, 778, 887, 755, 740, 337, 86, 92, 325, 422, 815, 650, 920, 125, 277, 336, 221, 847, 168, 23, 677, 61, 400, 136, 874, 363, 394, 199, 863, 997, 794, 587, 124, 321, 212, 957, 764, 173, 314, 422, 927, 783, 930, 282, 306, 506, 44, 926, 691, 568, 68, 730, 933, 737, 531, 180, 414, 751, 28, 546, 60, 371, 493, 370, 527, 387, 43, 541, 13, 457, 328, 227, 652, 365, 430, 803, 59, 858, 538, 427, 583, 368, 375, 173, 809, 896, 370, 789 };
            ArrayProblems.TwoSumHashTable(arr, 542);
        Tree tree = new Tree();
            tree.Root = new Tree.Node(1);
            tree.Root.left = new Tree.Node(2);
            tree.Root.right = new Tree.Node(3);
            tree.Root.left.left = new Tree.Node(4);
            tree.Root.left.right = new Tree.Node(5);
            Tree.PrintPostOrder(tree.Root);

            Console.WriteLine(Tree.PathSum(tree.Root, 4));
            Console.WriteLine(TwoPointerProblems.TrapUsingLoop(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
           //foreach(var node in Tree.PrintPostOrderLeetCode590(tree.Root))
           // {
           //     Console.WriteLine(node);
           // }
            Console.ReadKey();
        }
    }
}
