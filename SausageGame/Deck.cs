using System;
using System.Collections.Generic;

namespace SausageGame
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    cards.Add(new Card(suit, value));
                }
            }
        }

        public Deck(uint amountOfCards)
        {
            cards = new List<Card>();
            if (amountOfCards == 52)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                    {
                        cards.Add(new Card(suit, value));
                    }
                }
            }

            if (amountOfCards == 36)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    for (int i = (int)CardValue.Six; i <= (int)CardValue.Ace; i++)
                    {
                        cards.Add(new Card(suit, (CardValue)i));
                    }
                } 
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();

            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (cards[i], cards[j]) = (cards[j], cards[i]);
            }
        }

        public Card Deal()
        {
            if (cards.Count == 0)
            {
                return null;
            }

            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
}