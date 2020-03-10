using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Card
    {
        private string suit;
        private char suitAbreviation;
        private string cardValue;

        // ====== CONSTRUCTORS ======
        public Card()
        {
            SetSuit("");
            SetSuitAbreviation(' ');
            SetCardValue("");
        }

        public Card(string suit, char abb, string value)
        {
            SetSuit(suit);
            SetSuitAbreviation(abb);
            SetCardValue(value);
        }

        // ====== GETTERS/SETTERS ======

        public string GetSuit()
        {
            return suit;
        }

        public void SetSuit(string value)
        {
            suit = value;
        }


        public char GetSuitAbreviation()
        {
            return suitAbreviation;
        }

        public void SetSuitAbreviation(char value)
        {
            suitAbreviation = value;
        }

        public string GetCardValue()
        {
            return cardValue;
        }

        public void SetCardValue(string value)
        {
            cardValue = value;
        }

       
    }
}
