using System;

namespace SausageGame
{
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

    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public class Card : IComparable<Card>
    {
        public Suit Suit { get; }
        public CardValue Value { get; }

        public Card(Suit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        public int CompareTo(Card other)
        {
            return Value.CompareTo(other.Value);
        }

        public override string ToString()
        {
            string valueString;

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

            return $"{valueString}{suitString}";
        }

    }
}