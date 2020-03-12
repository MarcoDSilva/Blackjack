using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class GameManagement
    {
        private int numberOfDecks;
        private Deck deck = null;
        private Player player = null;

        public GameManagement()
        {
            numberOfDecks = 1;
            deck = new Deck();
            player = new Player();
            player.SetBank(10.00);
        }

        public void FillDeck()
        {
            for (int i = 0; i < numberOfDecks; i++)
            {
                deck.Fill("Diamonds", deck);
                deck.Fill("Spades", deck);
                deck.Fill("Clubs", deck);
                deck.Fill("Hearts", deck);
            }
        }

        /// <summary>
        /// returns the deck (list of) being used
        /// </summary>
        /// <returns></returns>
        public Deck GetDeckList()
        {
            return deck;
        }

        /// <summary>
        /// define the number of decks, in case we want to add more
        /// </summary>
        /// <param name="num"></param>
        public void SetNumberOfDecks(int num)
        {
            numberOfDecks = num;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Card GetCard()
        {
            Random rng = new Random();
            int cardCount = deck.GetCardCount();
            Card cardToReturn;

            //checks the count total to know if we return a random card, the last card or none
            if (cardCount > 2)
            {
                cardToReturn = deck.GetDeck()[rng.Next(1, cardCount)];
                deck.GetDeck().Remove(cardToReturn);
                return cardToReturn;
            }
            else if (cardCount == 1)
            {
                cardToReturn = deck.GetDeck()[1];
                deck.GetDeck().Remove(cardToReturn);
                return cardToReturn;
            }
            else
            {
                return null;
            }
        }

        public Player GetPlayer()
        {
            return player;
        }
    }
}
