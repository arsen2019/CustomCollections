using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class DoublyLinkedList<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
                Previous = null;
            }
        }

        private Node head;
        private Node tail;
        private int count;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void AddFirst(T data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }

            count++;
        }

        public void AddLast(T data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }

            count++;
        }

        public bool Remove(T data)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        tail = current.Previous;
                    }

                    count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void PrintForward()
        {
            Node current = head;

            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }

            Console.WriteLine();
        }

        public void PrintBackward()
        {
            Node current = tail;

            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Previous;
            }

            Console.WriteLine();
        }

        public int Count
        {
            get { return count; }
        }
    }

}
