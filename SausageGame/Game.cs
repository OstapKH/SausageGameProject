using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SausageGame
{
    // Class representing the game logic
    public class Game
    {
        static private Deck deck;  // Static deck instance shared among all game instances
        private List<Player> players;  // List of players in the game
        private int currentPlayerIndex;  // Index of the current player in the players list
        private List<Card> cardsOnTable;  // List of cards currently on the table

        // Constructor to initialize the game with players and an optional amount of cards
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

        // Getter and setter
        public List<Player> Players
        {
            get => players;
            set => players = value ?? throw new ArgumentNullException(nameof(value));
        }

        // Method to deal cards to players
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

        // Method to play a round of the game
        public bool PlayRound()
        {
            bool roundOver = false;
            int maxCards = 0;
            Player winner = null;

            // Each player plays a card from their hand
            for (int i = 0; i < players.Count; ++i)
            {
                // Get the current player based on the currentPlayerIndex
                Player player = players[(currentPlayerIndex + i) % players.Count];

                // Select the first card from the player's hand and add it to the table
                Card cardToTable = player.Hand[0];
                cardsOnTable.Add(cardToTable);
                player.RemoveCardFromHand(cardToTable);
                Console.WriteLine($"{player.Name} played {cardToTable}");

                // Check if any card on the table has the same value but a different suit
                if (cardsOnTable.Any(card => card.Value == cardToTable.Value && card.Suit != cardToTable.Suit))
                {
                    // Find the index of the first matching card on the table
                    int index = cardsOnTable.FindIndex(card => card.Value == cardToTable.Value);

                    // Take all the cards from the table with the same value but different suits
                    List<Card> takenCards = cardsOnTable.GetRange(index, cardsOnTable.Count - index);
                    player.Hand.AddRange(takenCards);
                    cardsOnTable.RemoveRange(index, takenCards.Count);
                    Console.WriteLine($"{player.Name} took {takenCards.Count} cards from the table");
                }

                // Check if the player has no more cards and remove them from the game
                if (player.Hand.Count == 0)
                {
                    Console.WriteLine($"Player {player.Name} has no more cards and loses the game.");
                    players.Remove(player);
                    roundOver = true;
                    break;
                }
            }

            // Move to the next player for the next round
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count; 
            // using "[(currentPlayerIndex + 1) % players.Count]" avoid receiving IndexOutOfBordersException

            return roundOver;
        }
        
        // Method that gives true when there is only one player left with all the cards - the winner
        private bool CheckWinner()
        {
            if (players.Count == 1)
            {
                Console.WriteLine($"Player {players.First().Name} has won the game!");
                return true;
            }
            return false;
        }
    
        // Method to start the game
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
