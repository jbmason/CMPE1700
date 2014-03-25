using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMPE1700JamesMason_ICA8
{
    class Program
    {
        public class Node
        {
            public int Value;
            public Node Next;
            public Node()
            {
                Value = 0;
                Next = null;
            }
            public Node(int val)
            {
                Value = val;
                Next = null;
            }
        }

        static public Node AddToTail(Node Head, int Value)
        {
            Node Fresh = new Node(Value);
            if (Head == null)
                return Fresh;

            Node Current = Head;
            while (Current.Next != null)
                Current = Current.Next;
            Current.Next = Fresh;

            return Head;
        }

        static public Node AddToHead(Node Head, int Value)
        {
            Node Fresh = new Node(Value);
            Fresh.Next = Head;
            return Fresh;
        }

        static void PrintList ( Node Head )
        {
            while ( Head != null )
            {
            Console . Write ( Head . Value + " ");
            Head = Head.Next;
            }
        }

        static void PrintListBackwards(Node Head)
        {
            if (Head != null)
            {
                PrintListBackwards(Head.Next);
                Console.Write(Head.Value + " ");
            }
            
        }



        static void Main(string[] args)
        {
            Random rand = new Random();
            Node Head = null;
            for (int i = 0; i < 10; ++i)
                Head = AddToHead(Head, i);
            PrintList(Head);
            Console.ReadLine();

            PrintListBackwards(Head);

            Console.ReadLine();
        }
    }
}
