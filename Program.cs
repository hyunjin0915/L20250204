using System;

namespace L20250204
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] deck = new int[52];

            for (int i = 0; i < deck.Length; i++)
            {
                deck[i] = i + 1;
            }

            Random random = new Random();
            random.Next(0, 1000);
            for (int i = 0; i < 10; i++)
            {
                int firstCardIndex = random.Next(0, deck.Length);
                int secondCardIndex = random.Next(0, deck.Length);
                (deck[firstCardIndex], deck[secondCardIndex]) = (deck[secondCardIndex], deck[firstCardIndex]);
            }

            for (int i = 0; i < 8; i++)
            {
                int deckNum = deck[i];
                //Console.WriteLine( deckNum);
                switch ((deckNum-1)/13)
                {
                    case 0:
                        Console.Write("Heart ");
                        break;
                    case 1:
                        Console.Write("Diamond ");
                        break;
                    case 2:
                        Console.Write("Clover ");
                        break;
                    case 3:
                        Console.Write("Spade ");
                        break;
                }

                int num = deckNum % 13;
                if(num == 1)
                {
                    Console.Write("A");
                    Console.WriteLine();
                }
                else if (num == 11)
                {
                    Console.Write("J");
                    Console.WriteLine();
                }
                else if(num == 12)
                {
                    Console.Write("Q");
                    Console.WriteLine();
                }
                else if(num == 13)
                {
                    Console.Write("K");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(num);
                    Console.WriteLine();
                }
            }
        }
    }
}