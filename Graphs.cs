using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsProjects
{
    public static  class Graph
    {
        public struct Node
        {
            internal int value;
            internal LinkedList<Node> adjacent;
            public Node(int value)
            {
                adjacent = new LinkedList<Node>();
                this.value = value;
            }
        }

        
     
        public static bool HasPathBreathFirstSearch(Node s, Node d) {
            HashSet<int> visited = new HashSet<int>();
            Queue<int> nexttovisit = new Queue<int>();

            nexttovisit.Enqueue(s.value);
            while(nexttovisit.Count > 0)
            {
                int v = nexttovisit.Dequeue();
                if (v == d.value)
                {
                    return true;
                }
                if (visited.Contains(s.value)) return false;

                foreach(var adj in s.adjacent)
                {
                    nexttovisit.Enqueue(adj.value);
                }
            }
            return false;
        } 
        public static bool HasPathDeptFirstSearch(Node source, Node destination)
        {
            //hashset of value visisted
            HashSet<int> visited = new HashSet<int>();
            // if the source is visited return false
            if (visited.Contains(source.value))
            {
                return false;
            }
            //add to visted and then check
            visited.Add(source.value);
            if (source.value == destination.value) return true;
            foreach(var node in source.adjacent)
            {
                if (HasPathDeptFirstSearch(node, destination)) return true;
            }
            return false;
        }


        public static bool canVisitAllRooms(List<List<int>> rooms)
        {
            bool[] seen = new bool[rooms.Count];
            seen[0] = true;
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            //At the beginning, we have a todo list "stack" of keys to use.
            //'seen' represents at some point we have entered this room.
            while (stack.Count !=0)
            { // While we have keys...
                int node = stack.Pop(); // Get the next key 'node'
                foreach (int nei in rooms[node]) // For every key in room # 'node'...
                    if (!seen[nei])
                    { // ...that hasn't been used yet
                        seen[nei] = true; // mark that we've entered the room
                        stack.Push(nei); // add the key to the todo list
                    }
            }

            foreach (bool v in seen)  // if any room hasn't been visited, return false
                if (!v) return false;
            return true;
        }
    }
}
