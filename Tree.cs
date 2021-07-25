using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsProjects
{
    //Binary Searc Tree;
    //PreOrder Traversal - Visit the root node first and the visit the left and the right node
    //inOrder Traversal  -  Visit the left node first and the root note and then the right node
    //postOrder Traversal - Vist the left node, right node and then the root node
    public class Tree
    {
        public Node Root;
        public class Node
        {

            public Node left, right;
            public int value;
            public List<Node> children;

            public Node(int value)
            {

                this.children = new List<Node> { left, right };
                this.value = value;
                left = right = null;
            }
        }

        public void InsertNode(Node root, int value)
        {
            if (root == null) Root = new Node(value);
            Node current = root;
            if (value <= current.value)
            {
                if (current.left == null)
                {
                    current.left = new Node(value);
                }
                else
                {
                    InsertNode(current.left, value);
                }

            }
            else if (value >= current.value)
            {
                if (current.right == null)
                {
                    current.right = new Node(value);
                }
                else
                {
                    InsertNode(current.right, value);
                }
            }
        }


        public bool Contains(Node root, int value)
        {
            if (root.value == value) return true;
            if (value <= root.left.value)
            {
                if (root.left.value == value)
                {
                    return true;
                }
                else
                {
                    return Contains(root.left, value);
                }
            }
            else
            {
                if (root.right.value == value) { return true; }
                else
                {
                    return Contains(root.right, value);
                }
            }
        }

        public static void PrintInOrder(Node root)
        {
            if (root == null) return;
            if (root.left != null)
            {
                PrintInOrder(root.left);
            }
            Console.Write(root.value + " ,");
            if (root.right != null)
            {
                PrintInOrder(root.right);
            }

        }

        public static void PrintPostOrder(Node root)
        {
            if (root == null) return;


            if (root.left != null)
            {
                PrintPostOrder(root.left);
            }
            if (root.right != null)
            {
                PrintPostOrder(root.right);
            }
            Console.Write(root.value + " ,");
        }


        public static IList<int> PrintPostOrderLeetCode590(Node root)
        {
            List<int> output_arr = new List<int>();
            Stack<Node> stack = new Stack<Node>();

            if (root == null) return output_arr;
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                output_arr.Insert(0, node.value);

                foreach (var connected_node in node.children)
                {
                    stack.Push(connected_node);
                }
            }

            return output_arr;

        }

        //This can be implemented iteratively
        public Node MergeTwoTree(Node t1, Node t2)
        {
            if (t1 == null) return t2;
            if (t2 == null) return t1;

            t1.value += t2.value;
            t1.left = MergeTwoTree(t1.left, t2.left);
            t1.right = MergeTwoTree(t1.right, t2.right);

            return t1;
        }

        public static Node InvertBinaryTree(Node root)
        {
            if (root == null)
            {
                return null;
            }

            Node left = InvertBinaryTree(root.left);
            Node right = InvertBinaryTree(root.right);
            root.right = left;
            root.left = right;
            PrintPostOrder(root);
            return root;
        }


        public int MaxDepth(Node root)
        {
            if (root == null)
                return 0;

            // Recursively find the depth of each subtree.
            int leftDepth = MaxDepth(root.left);
            int rightDepth = MaxDepth(root.right);

            // Get the larger depth and add 1 to it to
            // account for the root.
            if (leftDepth > rightDepth)
                return (leftDepth + 1);
            else
                return (rightDepth + 1);
        }

        private static bool isSymmetric(Node a, Node b)
        {
            if (a == null && b == null) return true;
            if (a == null || b == null) return false;
            return a.value == b.value && isSymmetric(a.left, b.right) && isSymmetric(a.right, b.left);
        }

        public bool HasPathSum(Node root, int sum)
        {
            if (root == null) return false;


            int diff = sum - root.value;
            if (root.left == null && root.right == null && root.value == sum) return true;

            return HasPathSum(root.left, diff) || HasPathSum(root.right, diff);


        }

        //    public void LookForPathSum(Node n, List<int> branch, int sum)
        //    {
        //        if (n == null) return;
        //        var diff = sum - n.value;
        //        branch.Add(n.value);
        //        if (n.left == null && n.right == null && diff == 0)
        //        {
        //            lists.Add(l);
        //        }
        //        else
        //        {
        //            var branch_copy = branch.ToList();
        //            LookForPathSum(n.left, branch, diff);
        //            LookForPathSum(n.right, branch_copy, diff);
        //        }
        //    }

        //    IList<IList<int>> lists = new List<IList<int>>();
        //    public IList<IList<int>> PathSum(Node root, int sum)
        //    {
        //        LookForPathSum(root, new List<int>(), sum);
        //        return lists;
        //    }
        //}
        //Path sum
        public static IList<IList<int>> PathSum(Node root, int sum)
        {
            IList<IList<int>> res = new List<IList<int>>();


            ListSumPath(root, res, new List<int>(), sum);


            return res;
        }

        private static  void ListSumPath(Node root, IList<IList<int>> result, List<int> sumPath, int sum)
        {

            if (root == null) return;

            sumPath.Add(root.value);

            int diff = sum - root.value;
            if (root.left == null && root.right == null && diff == 0)
            {
                result.Add(sumPath);
                return;
            }
            var sumPathCopy = sumPath.ToList();
            ListSumPath(root.left, result, sumPath, diff);
            ListSumPath(root.right, result, sumPathCopy, diff);

        }



        public IList<string> BinaryTreePaths(Node root)
        {
            IList<string> result = new List<string>();
            BinaryTreePathsHelper(root);
            return result;

            void BinaryTreePathsHelper(Node node, string path = "")
            {
                if (node == null)
                    return;
                if (node.left == null && node.right == null)
                    result.Add($"{path}{node.value}");
                else
                {
                    BinaryTreePathsHelper(node.left, $"{path}{node.value}->");
                    BinaryTreePathsHelper(node.right, $"{path}{node.value}->");
                }
            }
        }
    }
}
