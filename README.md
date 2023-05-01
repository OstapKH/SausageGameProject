# Sausage Game

## How to play

The deck is shuffled, all cards are dealt equally to the players, and the players hold the cards face up. Players take turns placing the cards from the top of their pile face up on the table and checking if there is already a card of the same value (regardless of how long ago it was placed). If so, the player takes the part of the open pile that lies between the cards of the same value, including them, and places it under the bottom of his or her pile. The player who has lost all the cards loses. The one who has taken all the cards wins.

## Project Structure

### Card
The Card class represents a standard playing card with a suit (hearts, diamonds, spades, clubs) and a rank (2-10, jack, queen, king, ace). It has two properties, Suit and Rank, and a ToString() method that returns the rank and suit of the card.

### Deck
The Deck class represents a deck of playing cards. It has a list of Card objects as its field, which is initialized with a full deck of cards in the constructor. The Deck class has several methods, including Shuffle() which shuffles the deck, and DrawCard() which removes and returns the top card from the deck.

### Player
The Player class represents a player in the game. It has a Name field and a list of Card objects representing the player's hand. It also has several methods, including AddCardToHand() which adds a card to the player's hand, and ToString() which returns the player's name and the number of cards in their hand.

### Game
The Game class represents the game itself. It has a list of Player objects representing the players in the game, a Deck object representing the deck of cards, and a DealCards() method which deals a specified number of cards to each player. The Game class also has several methods related to playing the game, such as StartGame() which starts the game and PlayRound() which plays a round of the game.

### Program
The Program class is the entry point for the application. It creates a new Game object with a list of Player objects and a specified number of cards, deals the cards to the players, and then starts the game by calling the StartGame() method on the Game object.

## License

This project is licensed under the MIT License. 
