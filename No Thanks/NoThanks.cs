﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No_Thanks
{
    class NoThanks
    {
        //This is the class that sets up all the Game's rules
        //In other words, an instance of the NoThanks class will be a game of No Thanks

        int numOfPlayers = 0;               //Number of players
        Player[] players;                   //Player array of all players, order is player order
        List<Card> deck = new List<Card>(); //Deck of shuffled cards waiting to be turned over
        Card faceupCard = null;             //current card that is showing to players
        int tokensOnFaceupCard = 0;         //Number of tokens on that faceupCard
        Player currentPlayer = null;        //The player whose turn it is
        int currentPlayerIndex = 0;
        bool gameOver = false;

        //Constructors
        public NoThanks(int plrs)
        {
            numOfPlayers = plrs;
            players = new Player[plrs];
            printRules();
            startGame();
        }

        public NoThanks()
        {
            printRules();
            while(numOfPlayers > 5 || numOfPlayers < 3)
            {
                Console.WriteLine("How many players are playing? (3-5 players)");
                
                try
                {
                    numOfPlayers = Convert.ToInt32(Console.ReadLine());
                    players = new Player[numOfPlayers];
                }
                catch
                {
                }
            }
            startGame();
        }

        //Asks for the names of the players playing
        public void getNames()
        {
            for (int i = 0; i < numOfPlayers; i++)
            {
                Console.WriteLine("Enter in your name: ");
                string plrName = Console.ReadLine();
                players[i] = new Player(plrName);
            }
        }

        //Creates all cards in the deck from 3 to 35
        public void populateDeck()
        {
            for (int i = 3; i < 36; i++)
            {
                deck.Add(new Card(i));
            }
        }
        
        //Shuffles current deck
        public void shuffleDeck()
        {
            Methods.Shuffle(deck);
        }

        //Populates, shuffles, and removes 9 random cards to prepare for the start of the game
        public void setUpDeck()
        {
            populateDeck();
            shuffleDeck();
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("I removed {0}", deck[0].Value);
                deck.RemoveAt(0);
            }
            shuffleDeck();
            drawNewCard();
        }

        //Prints out the cards in the deck
        public void displayDeck()
        {
            Methods.Display<Card>(deck);
        }

        //Prints out the names and tokens of the players
        public void DisplayPlayers()
        {
            for (int i = 0; i < numOfPlayers; i++)
            {
                Console.WriteLine("Player{0}: {1}\nTokens: {2}\n", i + 1, players[i].Name, players[i].Tokens);
            }
        }

        //Handles what happens when a player chooses (or is forced) to take the faceup card
        //Tokens on card go to the player, and the card is added to that players hand.
        //Then, if there are still cards in the deck, a new one is drawn. Else, the game ends
        public void takeCard(Player p)
        {
            p.Tokens += tokensOnFaceupCard;
            tokensOnFaceupCard = 0;
            p.AddCard(faceupCard);
            if (deck.Count > 0)
            {
                //Console.WriteLine("Drawing a new card. Deckcount = {0}", deck.Count);
                drawNewCard();
            }
            else
            {
                //Console.WriteLine("Alert! Can't draw anymore cards");
                endGame();
            }
        }

        //Handles what happens when a player chooses to say "No thanks" to the faceupcard and put one
        //token on it instead. If the player chooses this without any tokens, they are forced to instead take the card
        public void pass(Player p)
        {
            if(p.Tokens <= 0)
            {
                takeCard(p);
            }
            else
            {
                p.Tokens -= 1;
                tokensOnFaceupCard++;
                nextTurn();
            }
        }

        //Draws a new card from the deck and makes it the new faceup card
        public void drawNewCard()
        {
            faceupCard = deck[0];
            deck.RemoveAt(0);
        }

        public void startGame()
        {
            getNames();
            setUpDeck();
            currentPlayer = players[0];
            while (deck.Count >= 0 && !gameOver)
            {
                playerTurn();
            }
        }

        //Display the totals for every player: list of cards, number of tokens
        //Announce scores, with 1st place, 2nd place, etc
        //Stop the turns, tally up the scores, display the tallies and declare a winner
        //Then terminate the game or ask if you want to play again
        public void endGame()
        {
            gameOver = true;
            Console.WriteLine("\n\n\n\n\n" + Methods.largeBreak + "\nGAME OVER\n" + Methods.largeBreak + "\n\n\n");
            for (int i = 0; i < players.Length; i++)
            {
                players[i].CalculateScore();
            }
            endGameDisplay();
            Player winner = players[0];
            for(int i = 1; i < players.Length; i++)
            {
                if(players[i].Score < winner.Score)
                {
                    winner = players[i];
                }
            }
            Console.WriteLine(Methods.largeBreak + "\nThe winner is {0} with the lowest score of {1}!", winner.Name, winner.Score);
            Console.WriteLine("Do you want to play again? [Y/N]");
            bool valid = false;
            while (!valid)
            {
                string newGame = Console.ReadLine().ToLower();
                if (newGame.Equals("y"))
                {
                    valid = true;
                    Console.WriteLine("\n\n\n");
                    NoThanks game = new NoThanks();
                }
                else if (newGame.Equals("n"))
                {
                    Console.WriteLine("Thanks for playing!");
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Please enter [Y]es or [N]o.");
                }
            }
        }

        public void playerTurn()
        {
            //Ask the current player to either put a token on the card, or take it
            displayChoice();
            Console.WriteLine("\nDo you want to:\n[1] Pass by putting a token on the card (if you have one)");
            Console.WriteLine("[2] Take the card and the tokens on it");
            bool validChoice = false;
            while (!validChoice)
            {
                int choice = 0;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                }
                if (choice == 1)
                {
                    pass(currentPlayer);
                    validChoice = true;
                }
                else if (choice == 2)
                {
                    takeCard(currentPlayer);
                    validChoice = true;
                }
                else
                {
                    Console.WriteLine("Please enter 1 or 2");
                }
            }
        }

        public void nextTurn()
        {
            //Sets the currentplayer to the next player in the turn sequence
            if(currentPlayerIndex + 1 < players.Length)
            {
                currentPlayerIndex++;
            }
            else if (currentPlayerIndex + 1 == players.Length)
            {
                currentPlayerIndex = 0;
            }
            currentPlayer = players[currentPlayerIndex];
        }

        public void displayChoice()
        {
            //Faceup card, your cards, others cards, your tokens, number of tokens on card
            Console.WriteLine("\n\n\n\n\n\n\n" + Methods.smallBreak);
            Console.WriteLine("{0}'s Turn:\n", currentPlayer.Name);
            //Console.WriteLine("Faceup card: {0}\nTokens on card: {1}", faceupCard.Value, tokensOnFaceupCard);
            Methods.PrintFaceupCard(faceupCard, tokensOnFaceupCard);
            Console.WriteLine("Your tokens: {0}\n", currentPlayer.Tokens);
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i] != currentPlayer)
                {
                    players[i].displayPlayerInfo();
                }
            }
            currentPlayer.displayPlayerInfo();
        }

        public void printRules()
        {
            string rules = Methods.largeBreak +
@"
Welcome to No Thanks
Here are the rules:
";
            Console.WriteLine(rules);
        }

        public void endGameDisplay()
        {
            //Display the totals for every player: list of cards, number of tokens
            //Announce scores, with 1st place, 2nd place, etc
            //Stop the turns, tally up the scores, display the tallies and declare a winner
            for(int i = 0; i < players.Length; i++)
            {
                //Player:
                //Tokens: 
                //Cards: 
                Console.WriteLine(Methods.smallBreak);
                Console.WriteLine("{0}:\nTokens: {1}", players[i].Name, players[i].Tokens);
                players[i].displayPlayerInfo();
                Console.WriteLine("Score: {0}", players[i].Score);
            }
        }
    }
}
