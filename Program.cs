using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Fill("Diamonds", deck);
            deck.Fill("Spades", deck);
            deck.Fill("Clubs", deck);
            deck.Fill("Hearts", deck);

            //foreach (Card c in deck.GetDeck())
            //{
            //    Console.WriteLine($"Card value : {c.GetCardValue()} , with the suit of {c.GetSuit()}");
            //}

            Random rng = new Random();

            Card toSpit = deck.GetDeck()[rng.Next(1, 53)];

            if (!toSpit.Equals(null))
            {
                Console.WriteLine($"Carta: {toSpit.GetCardValue()}, Naipe: {toSpit.GetSuit()}");

            }


            for (int i = 0; i < deck.GetDeck().Count; i++)
            {
                Card test = deck.GetDeck()[i];

                if(test.GetSuit().Equals("Diamonds") && test.GetCardValue().Equals("A"))
                {
                    Console.WriteLine($"Carta encontrada na iteração: {i}");
                } 
            }
        }
    }
}
