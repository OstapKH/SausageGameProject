using System;
using System.Collections.Generic;

namespace SausageGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game(new List<Player> { new Player("Petro"), new Player("Mariyka"), new Player("Vitaliy"),  new Player("Serhiy") },
                52);
            game.DealCards(52);

            List<Player> players = game.Players;

            foreach (Player player in players)
            {
                Console.WriteLine(player);
            }
            
            game.StartGame();
        }
    }
}