
namespace CustomCollection
{
    class Program
    {



        public static void Main(string[] args)
        {
            var myStack = new CStack<int>();
            var myQueue = new CQueue<int>();
            var myLinkedList = new CLinkedList<int>();

            List<int> list = new List<int>() {1,2,3,4,5,6 };

            foreach (int i in list)
            {
                myStack.Push(i);
                myQueue.Enqueue(i);
                myLinkedList.AddFirst(i);
            }

            myStack.Print();
            myQueue.Print();
            myLinkedList.Print();

            Console.WriteLine("______________MyStack______________");

            Console.WriteLine($"The Peek of myStack = {myStack.Peek()}");
            Console.WriteLine($"The Poped Value of myStack = {myStack.Pop()}");
            myStack.Push(11);
            Console.WriteLine($"Now Pushed the 11 to my Stack");
            myStack.Print();

            Console.WriteLine("______________Queue______________");

            Console.WriteLine($"The Peek of myQueue = {myQueue.Peek()}");
            Console.WriteLine($"The Dequeud Value of myQueue = {myQueue.Dequeue()}");
            myQueue.Enqueue(11);
            Console.WriteLine($"Now Pushed the 11 to myQueue");
            myQueue.Print();

            Console.WriteLine("______________MyLinkedList______________");

            myLinkedList.AddLast(11);
            Console.Write($"Aded 11 from the end");
            myLinkedList.Print();
            myLinkedList.Remove(4);
            Console.Write($"Removed 4 from myLinkedList");
            myLinkedList.Print();
         



        }
    }


}


