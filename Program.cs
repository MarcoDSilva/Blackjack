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

            //List<Card> playerCards = new List<Card>();
            Hand playerHand = new Hand();
            Hand dealerHand = new Hand();

            bool start = true;
            ConsoleKey answer;


            //GameLogic();
            Console.WriteLine("Dealer Limit is 18\nYour 2 cards are: ");
            playerHand.AddCard(game.GetCard());
            playerHand.AddCard(game.GetCard());

            //color for the foreground to match the card types and printing it
            Console.ForegroundColor = GetForeColor(playerHand.GetCard(0));
            Console.WriteLine($"Value : {playerHand.GetCard(0).GetCardValue().PadRight(10)} Suit: {playerHand.GetCard(0).GetSuit().PadRight(10)}");

            Console.ForegroundColor = GetForeColor(playerHand.GetCard(1));
            Console.WriteLine($"Value : {playerHand.GetCard(1).GetCardValue().PadRight(10)} Suit: {playerHand.GetCard(1).GetSuit().PadRight(10)}");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Hand value: {GetValue(playerHand.GetHand())}");
            
            //DEALER TEST
            Console.WriteLine("Dealer Has: ");          
            dealerHand.AddCard(game.GetCard());

            //color for the foreground to match the card types and printing it
            Console.ForegroundColor = GetForeColor(dealerHand.GetCard(0));              
            Console.WriteLine($"Value : {dealerHand.GetCard(0).GetCardValue().PadRight(10)} Suit: {dealerHand.GetCard(0).GetSuit().PadRight(10)}");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Dealer Hand value: {GetValue(dealerHand.GetHand())}");

            Console.WriteLine("Do you want more cards? \nH for hit, S to stop, Esc to end");

            //game loop
            while (start)
            {
                do
                {
                    answer = Console.ReadKey(true).Key; //to not show the key in the console                

                } while (!answer.Equals(ConsoleKey.H) && !answer.Equals(ConsoleKey.Escape) && !answer.Equals(ConsoleKey.S));

                //conditional for the Hit key and the respective values
                if (answer.Equals(ConsoleKey.H))
                {
                    playerHand.AddCard(game.GetCard());

                    Console.ForegroundColor = GetForeColor(playerHand.GetCard(playerHand.GetHandSize() - 1));

                    Console.WriteLine($"Value : {playerHand.GetCard(playerHand.GetHandSize() - 1).GetCardValue().PadRight(10)}" +
                        $" Suit: {playerHand.GetCard(playerHand.GetHandSize() - 1).GetSuit().PadRight(10)}");



                    Console.ForegroundColor = ConsoleColor.White;
                    if (GetValue(playerHand.GetHand()) < 21)
                    {
                        Console.WriteLine($"Hand value: {GetValue(playerHand.GetHand())}");
                    }
                    else if (GetValue(playerHand.GetHand()) == 21 && playerHand.GetHandSize() > 2)
                    {
                        Console.Write("Hand value is 21! Maximum Value!");
                    }
                    else if (GetValue(playerHand.GetHand()) == 21 && playerHand.GetHandSize() == 2)
                    {
                        Console.Write("Hand value is 21! Blackjack!");
                    }
                    else
                    {
                        Console.WriteLine($"You blew up with: {GetValue(playerHand.GetHand())}");
                        start = false;
                    }
                }
                else if (answer.Equals(ConsoleKey.S)) //player turn ended, activate dealer turn
                {
                    Console.WriteLine("Dealer turn.");
                }
                else if (answer.Equals(ConsoleKey.Escape)) //gameEnd
                {
                    Console.WriteLine("Thank you for not playing!");
                    start = false;
                }
            }

        }

        /// <summary>
        /// Used to get the hand value numerically
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public static int GetValue(List<Card> cards)
        {
            int value = 0;
            int outValue = 0;
            int valueConverted;

            //we loop to get the value from the cards (values are string)
            //so we parse the ones we can extract an integer number 2 to 10 and use those
            //if it's a figure we verify Aces to get the right value and all others get the value 10
            foreach (Card c in cards)
            {
                if (int.TryParse(c.GetCardValue(), out outValue))
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

            //we verify the total cards in the hand, if there is an Ace and the total hand value is higher than 10 (ex: a figure)
            //the aces drop to value 1
            foreach (Card c in cards)
            {
                if (value >= 11 && c.GetCardValue().Equals("A"))
                {
                    value -= 10;
                }
            }
            return value;
        }

        public static ConsoleColor GetForeColor(Card card)
        {
            if (card.GetSuit().Equals("Hearts"))
            {
                return ConsoleColor.Red;
            }
            else if (card.GetSuit().Equals("Clubs"))
            {
                return ConsoleColor.Green;
            }
            else if (card.GetSuit().Equals("Spades"))
            {
                return ConsoleColor.White;
            }
            else
            {
                return ConsoleColor.Blue;
            }
        }

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

