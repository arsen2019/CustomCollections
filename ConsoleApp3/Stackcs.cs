using System;
using System.Collections;

namespace CustomCollection
{
    public interface ICustomMethods<T>
    {
         void Push(T value);
         T Pop();
         T Peek();
    }
    public class CustomArray<T> : IEnumerable<T>
    {
        protected T[] data;
        protected int count;

        public CustomArray()
        {
            data = new T[10];
        }
        public CustomArray(int length)
        {
            data = new T[length];
        }

        public int Length
        {
            get { return data.Length; }
        }

        public int Count
        {
            get { return count; }
        }

        public T this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; count++; }
        }
        public bool IsEmpty
        {
            get { return count == 0; }
        }
        protected void Resize(int max)
        {
            T[] tempItems = new T[max];
            for (int i = 0; i < count; i++)
                tempItems[i] = data[i];
            data = tempItems;
        }

       
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
       
    }
    public class CStack<T> : CustomArray<T>
    {
        public CStack() : base()
        {
            Console.WriteLine();
        }

        public void Push(T item)
        {

            if (count == data.Length)
                Resize(data.Length + 10);

            data[count++] = item;
        }
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is Empty");
            T item = data[--count];
            data[count] = default;

            if (count > 0 && count < data.Length - 10)
                Resize(data.Length - 10);

            return item;
        }
        public T Peek()
        {
            return data[count - 1];
        }
        public void Print()
        {
            Console.Write("Stack elems: ");
            for (int i = count-1; i >= 0; i--)
            {
                Console.Write(data[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = count; i >= 0; i--)
            {
                yield return data[i];
            }
        }

    }
}