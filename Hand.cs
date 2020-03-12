using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Hand
    {
        List<Card> cards = null;

        public Hand()
        {
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public Card GetCard(int position)
        {
            return cards[position];
        }

        public List<Card> GetHand()
        {
            return cards;
        }

        public int GetHandSize()
        {
            return cards.Count;
        }
    }
}
