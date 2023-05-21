using System;
using System.Collections.Generic;

namespace SausageGame
{
    // Class representing a deck of cards
    public class Deck
    {
        private List<Card> cards;  // List to store the cards in the deck

        // Default constructor to create a standard 52-card deck
        public Deck()
        {
            cards = new List<Card>();

            // Generate cards for each suit and value combination
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    cards.Add(new Card(suit, value));
                }
            }
        }

        // Constructor to create a deck with a specific number of cards
        public Deck(uint amountOfCards)
        {
            cards = new List<Card>();

            // Generate cards based on the specified amount
            if (amountOfCards == 52)
            {
                // Create a standard 52-card deck
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                    {
                        cards.Add(new Card(suit, value));
                    }
                }
            }
            else if (amountOfCards == 36)
            {
                // Create a 36-card deck (removing cards below Six)
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    for (int i = (int)CardValue.Six; i <= (int)CardValue.Ace; i++)
                    {
                        cards.Add(new Card(suit, (CardValue)i));
                    }
                }
            }
        }

        // Method to shuffle the deck using the Fisher-Yates algorithm
        public void Shuffle()
        {
            Random rng = new Random();

            // Iterate over each card in the deck from the last to the first
            for (int i = cards.Count - 1; i > 0; i--)
            {
                // Generate a random index to swap with the current card
                int j = rng.Next(i + 1);

                // Swap the current card with the randomly selected card
                (cards[i], cards[j]) = (cards[j], cards[i]);
            }
        }

        // Method to deal a card from the deck
        public Card Deal()
        {
            if (cards.Count == 0)
            {
                // If the deck is empty, return null indicating no more cards
                return null;
            }

            // Remove the first card from the deck and return it
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
}
