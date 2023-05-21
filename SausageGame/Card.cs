using System;

namespace SausageGame
{
    // Enumeration for card values
    public enum CardValue
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14,
    }

    // Enumeration for card suits
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    // Class representing a playing card
    public class Card : IComparable<Card>
    {
        public Suit Suit { get; }  // The suit of the card
        public CardValue Value { get; }  // The value of the card

        // Constructor to initialize the card with a suit and value
        public Card(Suit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        // Implementation of the IComparable interface for card comparison
        public int CompareTo(Card other)
        {
            return Value.CompareTo(other.Value);
        }

        // Override of the ToString() method to provide a string representation of the card
        public override string ToString()
        {
            string valueString;

            // Convert the card value to string representation
            switch (Value)
            {
                case CardValue.Two:
                case CardValue.Three:
                case CardValue.Four:
                case CardValue.Five:
                case CardValue.Six:
                case CardValue.Seven:
                case CardValue.Eight:
                case CardValue.Nine:
                case CardValue.Ten:
                    valueString = ((int)Value).ToString();
                    break;
                case CardValue.Jack:
                    valueString = "J";
                    break;
                case CardValue.Queen:
                    valueString = "Q";
                    break;
                case CardValue.King:
                    valueString = "K";
                    break;
                case CardValue.Ace:
                    valueString = "A";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            string suitString;

            // Convert the card suit to string representation
            switch (Suit)
            {
                case Suit.Hearts:
                    suitString = "♥";
                    break;
                case Suit.Diamonds:
                    suitString = "♦";
                    break;
                case Suit.Clubs:
                    suitString = "♣";
                    break;
                case Suit.Spades:
                    suitString = "♠";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // Combine the value and suit strings and return the card representation
            return $"{valueString}{suitString}";
        }
    }
}
