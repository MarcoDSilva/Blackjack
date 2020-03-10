using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Deck
    {
        private short numberOfCards = 0;
            
        private List<Card> deckOfCards = null;

        public Deck()
        {
            numberOfCards = 52;
            deckOfCards = new List<Card>();
        }

        public Deck(short numOfCards)
        {
            numberOfCards = numOfCards;
            deckOfCards = new List<Card>();
        }


        // MANIPULATING THE DECK OF CARDS
        public void AddCard(Card card)
        {
            if(numberOfCards > 0)
            {
                deckOfCards.Add(card);
                numberOfCards -= 1;
            }
        }

        public void RemoveCard(Card card)
        {
            deckOfCards.Remove(card);          
        }

        public List<Card> GetDeck()
        {
            return this.deckOfCards;
        }

        public int GetCardCount()
        {
            return deckOfCards.Count;
        }

        /// <summary>
        /// Used to fill the deck with the cards corresponding to the respective suit
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="deck"></param>
        public void Fill(string suit, Deck deck)
        {
            char suitAbv = DefineSuit(suit);

            for(int i = 2; i < 11; i++)
            {
                deck.AddCard(new Card(suit, suitAbv, i.ToString()));
            }
          
            deck.AddCard(new Card(suit, suitAbv, "J"));
            deck.AddCard(new Card(suit, suitAbv, "Q"));
            deck.AddCard(new Card(suit, suitAbv, "K"));
            deck.AddCard(new Card(suit, suitAbv, "A"));
        }

        /// <summary>
        /// Returns the abbreviation of the suit
        /// </summary>
        /// <param name="suit"></param>
        /// <returns></returns>
        private char DefineSuit(string suit)
        {
            if (suit.Equals("Clubs"))
            {
                return 'C';
            }

            if (suit.Equals("Diamonds"))
            {
                return 'D';
            }

            if (suit.Equals("Spades"))
            {
                return 'S';
            }

            if (suit.Equals("Hearts"))
            {
                return 'H';
            }

            return ' ';
        }
    }
}
