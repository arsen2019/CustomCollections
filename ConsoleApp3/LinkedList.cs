using System;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Collections;

public class CLinkedList<T>: IEnumerable<T>
{
    protected class Node
    {
        public T Data { get; set; }
        public Node Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    protected Node head;
    protected int count;

    public CLinkedList()
    {
        head = null;
        count = 0;
    }

    public virtual void AddFirst(T data)
    {
        Node newNode = new Node(data);
        newNode.Next = head;
        head = newNode;
        count++;
    }

    public virtual void AddLast(T data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
        count++;
    }

    public bool Remove(T data)
    {
        Node current = head;
        Node previous = null;

        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                if (previous == null)
                {
                    head = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }
                count--;
                return true;
            }
            previous = current;
            current = current.Next;
        }
        return false;
    }

    public bool Contains(T data)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public virtual void Print()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }
        Node current = head;
        Console.Write("Linked List elems: ");
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public int Count
    {
        get { return count; }
    }
    private void Resize()
    {
        int newCapacity = count * 2;
        Node[] newArray = new Node[newCapacity];

        int i = 0;
        Node current = head;
        while (current != null)
        {
            newArray[i] = current;
            current = current.Next;
            i++;
        }

        head = newArray[0];
        for (int j = 0; j < count - 1; j++)
        {
            newArray[j].Next = newArray[j + 1];
        }
        newArray[count - 1].Next = null;
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

