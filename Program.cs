using System;

namespace L20250204
{
    //1 - 13 -> Heart , 1 -> A, 11 -> J, 12 -> Q , 13 -> K
    //14 - 26 -> Diamond
    //27 - 39 -> Clover
    //40 - 52 -> Spade 
    internal class Program
    {
        enum CardType
        {
            None = -1,
            Heart = 0,
            Diamond = 1,
            Clover = 2,
            Spade = 3
        }

        static void Initialize(int [] _deck)
        {
            for (int i = 0; i < _deck.Length; i++)
            {
                _deck[i] = i + 1;
            }
        }
        static void Shuffle(int[] _deck)
        {
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                int firstCardIndex = random.Next(0, _deck.Length);
                int secondCardIndex = random.Next(0, _deck.Length);
                (_deck[firstCardIndex], _deck[secondCardIndex]) = (_deck[secondCardIndex], _deck[firstCardIndex]);
            }
        }

        static void PrintCard(int _deckNum)
        {
            switch ((_deckNum - 1) / 13)
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

            int num = _deckNum % 13;
            if (num == 1)
            {
                Console.Write("A");
                Console.WriteLine();
            }
            else if (num == 11)
            {
                Console.Write("J");
                Console.WriteLine();
            }
            else if (num == 12)
            {
                Console.Write("Q");
                Console.WriteLine();
            }
            else if (num == 13)
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

        static CardType CheckCardType(int cardNumber)
        {
            int valueType = (cardNumber - 1) / 13;
            //CardType returnCardType = CardType.None;
            return (CardType)valueType;
            /*switch ((CardType)valueType)
            {
                case CardType.Heart:
                    returnCardType = CardType.Heart;
                    break;
                case CardType.Diamond:
                    returnCardType = CardType.Diamond;
                    break;
                case CardType.Clover:
                    returnCardType = CardType.Clover;
                    break;
                case CardType.Spade:
                    returnCardType = CardType.Spade;
                    break;
                default:
                    break;
            }
            return returnCardType;
             */

        }

        static string CheckCardName(int cardNumber)
        {
            int cardValue = ((cardNumber - 1) % 13) + 1;
            //나중에 작업할 때 cardValue가 1-13이게 하기 위해 값 조정
            string cardName = string.Empty;
            switch(cardValue)
            {
                case 1:
                    cardName = "A";
                    break;
                case 11: 
                    cardName = "J";
                    break;
                case 12:
                    cardName = "Q";
                    break;
                case 13:
                    cardName = "K";
                    break;
                default:
                    cardName = cardValue.ToString();
                    break;
            }
            return cardName;
        }

        static void Print(int[] deck)
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(CheckCardType(deck[i]).ToString() + " " + CheckCardName(deck[i]));
            }
        }

        /*static string CountScore(int[] deck)
        {
            int computerScore, playerScore;

            for (int i = 0; i < 6; i++)
            {
                int getScoreNum;
                string getScoreStr = CheckCardName(deck[i]);
                if (getScoreStr.Equals("A"))
                {
                    getScoreNum = 1;
                }
                else if ((getScoreStr.Equals("J")) || (getScoreStr.Equals("Q")) || (getScoreStr.Equals("K")))
                {
                    getScoreNum = 10;
                }
                else
                {
                    getScoreNum = ((deck[i] - 1) % 13) + 1;
                }
            }
        }*/
        static int  CheckScore(int cardNumber)
        {
            int cardValue = ((cardNumber - 1) % 13) + 1;
            int score;
            string cardName = string.Empty;
            switch (cardValue)
            {
                case 1:
                    score = 1;
                    break;
                case 11:
                case 12:
                case 13:
                    score = 10;
                    break;
                default:
                    score = cardValue;
                    break;
            }
            return score;
        }

        static void Winner(int _computerScore, int _playerScore)
        {
            string winner = "";
            if (_computerScore == 21 || _playerScore == 21)
            {
                Console.WriteLine("블랙잭");
                return;
            }
            else if(_computerScore>21)
            {
                winner = "Player";
            }
            else if(_playerScore > 21)
            {
                winner = "Computer";
            }
            else
            {
                winner = _computerScore > _playerScore ? "Computer" : "Player";
            }
            Console.WriteLine(winner + " Win");
        }

        static void Main(string[] args)
        {
            int[] deck = new int[52];

            Initialize(deck);
            Shuffle(deck);
            //Print(deck);

            /*for (int i = 0; i < 8; i++)
            {
                int deckNum = deck[i];
                //Console.WriteLine( deckNum);
                //PrintCard(deckNum);
            }*/
            int computerScore = 0;
            int playerScore = 0;

            for (int i = 0; i < 3; i++)
            {
                computerScore += CheckScore(deck[i]);
            }
            for (int i = 1; i < 6; i++)
            {
                playerScore += CheckScore(deck[i]);
            }
            Winner(computerScore, playerScore);
        }
    }
}