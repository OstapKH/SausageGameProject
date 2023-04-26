using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SausageGame
{
    public class Game
    {
        static private Deck deck;
        private List<Player> players;
        private int currentPlayerIndex;
        private List<Card> cardsOnTable;

        public Game(List<Player> gamePlayers, uint amountOfCards = 52)
        {
            deck = new Deck(amountOfCards);
            deck.Shuffle();

            players = new List<Player>();
            foreach (Player player in gamePlayers)
            {
                players.Add(player);
            }

            currentPlayerIndex = 0;
            cardsOnTable = new List<Card>();
        }

        public List<Player> Players
        {
            get => players;
            set => players = value ?? throw new ArgumentNullException(nameof(value));
        }

        public void DealCards(int numCards)
        {
            for (int i = 0; i < numCards; i++)
            {
                foreach (Player player in players)
                {
                    Card card = deck.Deal();
                    if (card != null && player.Hand.Count < (numCards / players.Count) + 1)
                    {
                        player.AddCardToHand(card);
                    }
                }
            }
        }

        public bool PlayRound()
        {
            bool roundOver = false;
            int maxCards = 0;
            Player winner = null;

            for (int i = 0; i < players.Count; ++i)
            {
                Player player = players[(currentPlayerIndex + i) % players.Count];
                Card cardToTable = player.Hand[0];
                cardsOnTable.Add(cardToTable);
                player.RemoveCardFromHand(cardToTable);
                Console.WriteLine($"{player.Name} played {cardToTable}");

                if (cardsOnTable.Any(card => card.Value == cardToTable.Value && card.Suit != cardToTable.Suit))
                {
                    int index = cardsOnTable.FindIndex(card => card.Value == cardToTable.Value);
                    List<Card> takenCards = cardsOnTable.GetRange(index, cardsOnTable.Count - index);
                    player.Hand.AddRange(takenCards);
                    cardsOnTable.RemoveRange(index, takenCards.Count);
                    Console.WriteLine($"{player.Name} took {takenCards.Count} cards from the table");
                }

                if (player.Hand.Count == 0)
                {
                    Console.WriteLine($"Player {player.Name} has no more cards and loses the game.");
                    players.Remove(player);
                    roundOver = true;
                    break;
                }
            }

            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;

            return roundOver;
        }
        
        private bool CheckWinner()
        {
            foreach (Player player in players)
            {
                if (players.Count == 1)
                {
                    Console.WriteLine($"Player {player.Name} has won the game!");
                    return true;
                }
            }
            return false;
        }
    
        public void StartGame()
        {
            while (true)
            {
                bool roundOver = PlayRound();
                if (CheckWinner())
                {
                    Console.WriteLine("Game over.");
                    break;
                }
                if (roundOver)
                {
                    Thread.Sleep(3000);
                }
            }
        }
    }
}