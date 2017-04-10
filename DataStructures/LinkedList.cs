using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }

    public class Utilities
    {
        public static void PrintList(Node node)
        {
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }

        public static void PrintList(LinkedListNode linkedList)
        {
            if (linkedList.Count > 0)
            {
                PrintList(linkedList.Head);
            }
        }
    }

    public class LinkedListNode
    {
        public int Count { get; set; }
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public void AddFirst(Node node)
        {
            if (Count > 0)
            {
                node.Next = Head;
                Head = node;
            }
            else
            {
                Head = node;
                Tail = node;
            }

            Count++;
        }

        public void AddLast(Node node)
        {
            if (Count > 0)
            {
                Tail.Next = node;
                Tail = node;
            }
            else
            {
                Head = Tail = node;
            }

            Count++;
        }

        public void RemoveFirst()
        {
            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Node current = Head;
                while (current.Next != Tail)
                {
                    current = current.Next;
                }

                current.Next = null;
                Tail = current;
            }

            Count--;
        }

        public void RemoveLast()
        {
            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                if (Count > 1)
                {
                    Node current = Head;
                    while (current.Next != Tail)
                    {
                        current = current.Next;
                    }

                    current.Next = null;
                    Tail = current;
                }
            }

            Count--;
        }
    }
}
