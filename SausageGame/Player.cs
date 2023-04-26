using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SausageGame
{
    public class Player
    {
        public string Name { get; }
        public List<Card> Hand { get; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }

        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        public void RemoveCardFromHand(Card card)
        {
            Hand.Remove(card);
        }

        public Card getLowestCard()
        {
            Card lowestCard = Hand[0];
            for (int i = 1; i < Hand.Count; i++)
            {
                if (Hand[i].CompareTo(lowestCard) == 1)
                {
                    lowestCard = Hand[i];
                }
            }

            return lowestCard;
        }
    
        public Card getLowestTrumpCard(Suit trumpSuit)
        {
            var lowestTrumpCard = Hand.Where(card => card.Suit == trumpSuit)
                .OrderBy(card => card)
                .FirstOrDefault();

            return lowestTrumpCard;
        }
    
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Player name: {Name}");
            sb.AppendLine("Cards in hand:");
            foreach (Card card in Hand)
            {
                sb.Append(card.ToString() + " ");
            }
            return sb.ToString();
        }

    }
}