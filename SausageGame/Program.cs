using System;
using System.Collections.Generic;

namespace SausageGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Create a new game with a list of players and an amount of cards
            Game game = new Game(new List<Player> { new Player("Petro"), new Player("Mariyka"), new Player("Vitaliy"), new Player("Serhiy") }, 52);
            
            // Deal cards to the players
            game.DealCards(52);

            // Get the list of players from the game
            List<Player> players = game.Players;

            // Print the cards in each player's hand
            foreach (Player player in players)
            {
                Console.WriteLine(player);
            }
            
            // Start the game
            game.StartGame();
        }
    }
}