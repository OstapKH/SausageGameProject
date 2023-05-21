using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SausageGame
{
    // Class representing a player in the game
    public class Player
    {
        public string Name { get; }  // The name of the player
        public List<Card> Hand { get; }  // The player's hand (list of cards)

        // Constructor to initialize the player with a name and an empty hand
        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }

        // Method to add a card to the player's hand
        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        // Method to remove a card from the player's hand
        public void RemoveCardFromHand(Card card)
        {
            Hand.Remove(card);
        }

        // Method to get the lowest value card in the player's hand
        public Card GetLowestCard()
        {
            Card lowestCard = Hand[0];

            // Iterate over each card in the hand and find the lowest value card
            for (int i = 1; i < Hand.Count; i++)
            {
                if (Hand[i].CompareTo(lowestCard) == -1)
                {
                    lowestCard = Hand[i];
                }
            }

            return lowestCard;
        }

        // Method to get the lowest value trump card in the player's hand
        public Card GetLowestTrumpCard(Suit trumpSuit)
        {
            var lowestTrumpCard = Hand.Where(card => card.Suit == trumpSuit)
                .OrderBy(card => card)
                .FirstOrDefault();

            return lowestTrumpCard;
        }

        // Override of the ToString() method to provide a string representation of the player
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Player name: {Name}");
            sb.AppendLine("Cards in hand:");

            // Iterate over each card in the hand and append its string representation to the StringBuilder
            foreach (Card card in Hand)
            {
                sb.Append(card.ToString() + " ");
            }

            return sb.ToString();
        }
    }
}
