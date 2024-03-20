using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StackAndQueue
{
    public class Pair
    {
        public double X;
        public double Y;

        public Pair(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public class Node
    {
        public Pair Data;
        public Node Next;

        public Node(Pair data)
        {
            Data = data;
            Next = null;
        }
    }

    public class Stack
    {
        private Node top;

        public void Push(double x, double y)
        {
            Pair pair = new Pair(x, y);
            Node newNode = new Node(pair);
            newNode.Next = top;
            top = newNode;
        }

        public Pair Pop()
        {
            if (top == null)
            {
               throw new InvalidOperationException("Stack is empty");
            }

            Pair pair = top.Data;
            top = top.Next;
            return pair;
        }

        public Pair Peek()
        {
            if (top == null)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return top.Data;
        }

        public bool IsEmpty()
        {
            return top == null;
        }
    }

    public class Queue
    {
        private int maxSize;
        private int front;
        private int rear;
        private string[] names;
        private string[] surnames;

        public Queue(int size)
        {
            maxSize = size;
            names = new string[maxSize];
            surnames = new string[maxSize];
            front = 0;
            rear = -1;
        }

        public void Enqueue(string name, string surname)
        {
            if (rear == maxSize - 1)
            {
                throw new InvalidOperationException("Queue is full");
            }

            names[++rear] = name;
            surnames[rear] = surname;
        }

        public bool IsEmpty()
        {
            return rear == front - 1;
        }

        public (string, string) Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            string name = names[front];
            string surname = surnames[front++];
            return (name, surname);
        }

        public (string, string) Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return (names[front], surnames[front]);
        }

        public bool IsFull()
        {
            return rear == maxSize - 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            stack.Push(1, 2);
            stack.Push(3, 4);
            stack.Push(5, 6);

            Console.WriteLine("Stack contents:");
            while (!stack.IsEmpty())
            {
                Pair pair = stack.Pop();
                Console.WriteLine($"({pair.X}, {pair.Y})");
            }

            Queue queue = new Queue(5);
            queue.Enqueue("John", "Marston");
            queue.Enqueue("Dutch", "Vanderlinde");
            queue.Enqueue("Dante", "Sparda");

            Console.WriteLine("\nQueue contents:");
            while (!queue.IsEmpty())
            {
                var (name, surname) = queue.Dequeue();
                Console.WriteLine($"Name: {name}, Surname: {surname}");
            }
        }
    }
}
