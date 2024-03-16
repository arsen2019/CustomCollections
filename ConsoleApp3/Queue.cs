using System;
using System.Collections;


public class CQueue<T>: IEnumerable<T>
{
    private T[] items;
    private int front; 
    private int next; 
    private int size; 
    private int capacity;

   

    public CQueue() {}
    public CQueue(int capacity)
    {
        this.capacity = capacity;
        items = new T[capacity];
        front = 0;
        next = -1;
        size = 0;
    }


    public void Enqueue(T item)
    {
        if (size == capacity)
            Resize(size + 10);

        next++;
        items[next] = item;
        size++;
    }

 
    public T Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");

        T dequeuedItem = items[front];
        front++;
        size--;
        return dequeuedItem;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty");

        return items[front];
    }
    public void Print()
    {
        if (size == 0)
        {
            Console.WriteLine("Queue is empty");
            return;
        }

        Console.Write("Queue elements: ");
        int index = front;
        for (int i = 0; i < size; i++)
        {
            Console.Write(items[index] + " ");
            index = (index + 1);
        }
        Console.WriteLine();
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

   
    public int Size()
    {
        return size;
    }
    private void Resize(int newCapacity)
    {
        T[] newArray = new T[newCapacity];
        for (int i = 0; i < size; i++)
        {
            newArray[i] = items[front + i];
        }
        items = newArray;
        capacity = newCapacity;
        front = 0;
        next = size - 1;
    }


    public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                int index = front + i;
                yield return items[index];
            }
        }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return items.GetEnumerator();
    }
}