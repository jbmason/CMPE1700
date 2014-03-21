using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamesMason_ICA2
{
    class Program
    {
        public enum CardSuit { Hearts = 1, Diamonds, Spades, Clubs };
        public enum CardValue { Deuce = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
        
        public struct Card
        {
            public CardSuit cardSuit;
            public CardValue cardValue;


            public Card(CardSuit Suit, CardValue Value)
            {
                cardSuit = Suit;
                cardValue = Value;
            }

            public override string ToString()
            {
                return string.Format("{0} of {1}", cardValue, cardSuit);
            }
        }
        static List<Card> cardList = new List<Card> {  };

        static void Main(string[] args)
        {
            

            foreach(CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    cardList.Add(new Card(suit, value));
                }

            Shuffle();

            foreach(Card card in cardList)
                Console.WriteLine(card);

            Console.ReadKey();
        }

        public static void Shuffle()
        {
            Random generator = new Random();
            int t = cardList.Count;
            while (t > 1)
            {
                t--;
                int r = generator.Next(t + 1);
                Card value = cardList[r];
                cardList[r] = cardList[t];
                cardList[t] = value;
                
            }

        }
    }
}
