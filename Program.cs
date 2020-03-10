using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Program
    {

        static void Main(string[] args)
        {
            GameManagement gameControl = new GameManagement();
            gameControl.FillDeck();

            GamePresentation(gameControl.GetPlayer(), gameControl);

            //foreach (Card c in gameControl.GetDeckList().GetDeck())
            //{
            //    if (c.GetSuit().Equals("Diamonds") || c.GetSuit().Equals("Hearts"))
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //    }
            //    else if (c.GetSuit().Equals("Clubs"))
            //    {
            //        Console.ForegroundColor = ConsoleColor.Green;
            //    }
            //    else
            //    {
            //        Console.ForegroundColor = ConsoleColor.White;
            //    }
            //    Console.WriteLine($"Value : {c.GetCardValue().PadRight(10)} Suit: {c.GetSuit().PadRight(10)}");
            //}


            // ===== RANDOM TO GEN THE CARDS ======
            //Random rng = new Random();


            //Card toSpit = deck.GetDeck()[rng.Next(1, 53)];

            //if (!toSpit.Equals(null))
            //{
            //    Console.WriteLine($"Carta: {toSpit.GetCardValue()}, Naipe: {toSpit.GetSuit()}");

            //}
            //Console.ForegroundColor = ConsoleColor.White;

            //for (int i = 0; i < deck.GetDeck().Count; i++)
            //{
            //    Card test = deck.GetDeck()[i];

            //    if(test.GetSuit().Equals("Diamonds") && test.GetCardValue().Equals("A"))
            //    {
            //        Console.WriteLine($"Carta encontrada na iteração: {i}");
            //    } 
            //}

        }


        public static void GamePresentation(Player player, GameManagement game)
        {
            ConsoleKey answer;

            Console.WriteLine("Welcome to BlackJack!");
            Console.Write("Player enter your name: ");

            player.SetName(Console.ReadLine());
            Console.WriteLine($"Welcome {player.GetName()}");

            //checks if the user wants to start the game right away or escape
            Console.WriteLine("Do you want to start the game? Y or Escape.");

            do
            {
                answer = Console.ReadKey(true).Key; //to not show the key in the console                

            } while (!answer.Equals(ConsoleKey.Y) && !answer.Equals(ConsoleKey.Escape));


            //verifies if the answer was to start/leave the game
            if (answer.Equals(ConsoleKey.Y))
            {
                Console.WriteLine("Game Started! Good luck.");
                //method to start the game
                GameStart(game);
            }
            else if (answer.Equals(ConsoleKey.Escape))
            {
                Console.WriteLine("Thank you for not playing!");
                //method to finish
            }

        }

        public static void GameStart(GameManagement game)
        {

            List<Card> playerCards = new List<Card>();

            bool start = true;            
            ConsoleKey answer;


            //GameLogic();
            Console.WriteLine("Your 2 cards are: ");
            playerCards.Add(game.GetCard());
            playerCards.Add(game.GetCard());

            Console.WriteLine($"Value : {playerCards[0].GetCardValue().PadRight(10)} Suit: {playerCards[0].GetSuit().PadRight(10)}");
            Console.WriteLine($"Value : {playerCards[1].GetCardValue().PadRight(10)} Suit: {playerCards[1].GetSuit().PadRight(10)}");
            Console.WriteLine($"Hand value: {GetValue(playerCards)}");
            Console.WriteLine("Do you want more cards? \nH for hit, S to stop, Esc to end");

            //loop to 
            while (start)
            {
                do
                {
                    answer = Console.ReadKey(true).Key; //to not show the key in the console                

                } while (!answer.Equals(ConsoleKey.H) && !answer.Equals(ConsoleKey.Escape) && !answer.Equals(ConsoleKey.S));

                if (answer.Equals(ConsoleKey.H))
                {
                    playerCards.Add(game.GetCard());
                    Console.WriteLine($"Value : {playerCards[playerCards.Count - 1].GetCardValue().PadRight(10)}" +
                        $" Suit: {playerCards[playerCards.Count - 1].GetSuit().PadRight(10)}");

                   

                    if(GetValue(playerCards) <= 21)
                    {
                        Console.WriteLine($"Hand value: {GetValue(playerCards)}");
                    } else
                    {
                        Console.WriteLine($"You blew up with: {GetValue(playerCards)}");
                    }

                }
                else if (answer.Equals(ConsoleKey.Escape) || answer.Equals(ConsoleKey.S))
                {
                    Console.WriteLine("Thank you for not playing!");
                    start = false;
                }

            }
            //foreach (Card c in gameControl.GetDeckList().GetDeck())
            //{
            //    if (c.GetSuit().Equals("Diamonds") || c.GetSuit().Equals("Hearts"))
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //    }
            //    else if (c.GetSuit().Equals("Clubs"))
            //    {
            //        Console.ForegroundColor = ConsoleColor.Green;
            //    }
            //    else
            //    {
            //        Console.ForegroundColor = ConsoleColor.White;
            //    }
            //    Console.WriteLine($"Value : {c.GetCardValue().PadRight(10)} Suit: {c.GetSuit().PadRight(10)}");
            //}

        }

        public static int GetValue(List<Card> cards)
        {
            int value = 0;
            int outrino = 0;
            int valueConverted;
            foreach (Card c in cards)
            {
                if (int.TryParse(c.GetCardValue(), out outrino))
                {
                    valueConverted = Convert.ToInt32(c.GetCardValue());

                    if (valueConverted >= 2 && valueConverted <= 10)
                    {
                        value += Convert.ToInt32(c.GetCardValue());
                    }
                }
                else
                {
                    if (c.GetCardValue().Equals("A"))
                    {
                        value += 11;
                    }
                    else
                    {
                        value += 10;
                    }
                }
            }

            foreach (Card c in cards)
            {
                if (value >= 11 && c.GetCardValue().Equals("A"))
                {
                    value -= 10;
                }
            }
            return value;
        }

        //public static void GameLogic()
        //{
        //    PlayerPlays();
        //    DealerPlays();
        //}

        //public static void PlayerPlays()
        //{

        //}

        //public static void DealerPlays()
        //{

        //}

        //public static void GameResult()
        //{

        //}

        //public static void Updates()
        //{

        //}

    }
}
