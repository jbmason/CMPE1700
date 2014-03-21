using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamesMason_ICA7
{
    class Program
    {
        enum Suit { Hearts, Diamonds, Clubs, Spades };
        enum Value { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };

        struct Cards
        {
            public Suit suit;
            public Value value;

            public Cards(Suit cardsuit, Value cardvalue)
            {
                suit = cardsuit;
                value = cardvalue;
            }

            public override string  ToString()
            {
 	            return string.Format("{0} of {1}", value, suit);
            }
        }

        static void Main(string[] args)
        {
            Stack<Cards> tempA = new Stack<Cards> { };
            Stack<Cards> tempB = new Stack<Cards> { };
            Stack<Cards> main = new Stack<Cards> { };

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                foreach (Value value in Enum.GetValues(typeof(Value)))
                    main.Push(new Cards(suit, value));

            Random generator = new Random();
            int i = 0;

            for (int x = 0; x < 10000; x++)
            {
                while (main.Count > 0)
                {                  
                    i = generator.Next(1, 3);
                    if (i == 1)
                        tempA.Push(main.Pop());                    
                    else                    
                        tempB.Push(main.Pop());                  
                }

                while (main.Count < 52)
                {     
                    i = generator.Next(1, 3);
                    if (i == 1 && tempA.Count != 0)
                        main.Push(tempA.Pop());
                    else if (tempB.Count != 0)
                        main.Push(tempB.Pop());   
                }
            }

            foreach (Cards card in main)
                Console.WriteLine(card);

            Console.ReadKey();
        }
    }
}
