using System;
using System.Collections;

namespace ConsoleApp3
{

    public class CircularLinkedList<T>:CLinkedList<T>, IEnumerable<T>
    {
        private Node head;

        public CircularLinkedList()
        {
            head = null;
        }

        public virtual void AddLast(T data)
        {
            var newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                head.Next = head;
            }
            else
            {
                var temp = head;
                while (temp.Next != head)
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
                newNode.Next = head; 
            }
            count++;
        }

        public virtual void AddFirst(T data)
        {
            var newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                head.Next = head;
            }
            else
            {
                var temp = head;
                while (temp.Next != head)
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
                newNode.Next = head; 
                head = newNode; 
            }
            count++;
        }

        public override void Print()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            var temp = head;
            Console.Write("Circled LL elems:");
            do
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            } while (temp != head);
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var temp = head;
            do
            {
                yield return temp.Data;
                temp = temp.Next;
            } while (true);

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    

}
