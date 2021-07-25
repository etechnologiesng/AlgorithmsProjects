using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsProjects
{
    public class LinkedList
    {
        private Node head;
        public class Node
        {
            public int value;
            public Node next;
            public Node(int value)
            {
                this.value = value;
            }
        }
       public void Append(int value)
        {
            Node current = this.head;
            if (head == null) { head = new Node(value);  return; }
            while(current.next != null)
            {
                current = current.next;
            }
            current.next = new Node(value);
        }

        public void Prepend(int value)
        {
            var newHead = new Node(value);
            newHead.next = head;
            head = newHead;
        }

        public void DeleteWithValue(int value)
        {
            if (head == null) return;
            if(head.value == value)
            {
                head = head.next;
                return;
            }
            var current = head;
            while(current.next != null)
            {
                if(current.next.value == value)
                {
                    current.next = current.next.next;
                    return;
                }

                current = current.next;
            }

        }


        public Node ReverseLinkedList(Node head)
        {
            Node previousNode = null;
            while(head != null)
            {
                Node nextNode = head.next;
                head.next = previousNode;
                previousNode = head;
                head = nextNode;
            }
            return previousNode;

        }
        public bool IsPalidromeLinkedList(Node head)
        {
            Node fast = head;
            Node slow = head;

            while (fast != null && fast.next != null)
            {
                slow=slow.next;
                fast = fast.next.next;
            }

            slow = ReverseLinkedList(slow);
            fast = head;

            while(slow!= null)
            {
                
                if(slow.value != fast.value)
                {
                    return false;
                }

                slow = slow.next;
                fast = fast.next;
            }

            return true;
        }
        




    }
}
