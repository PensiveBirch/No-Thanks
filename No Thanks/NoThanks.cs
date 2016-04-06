using System;
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

        //Constructors
        public NoThanks(int plrs)
        {
            numOfPlayers = plrs;
            players = new Player[plrs];
            getNames();
            setUpDeck();
        }

        public NoThanks()
        {
            Console.WriteLine("How many players are playing?");
            int numberOfPlrs = Convert.ToInt32(Console.ReadLine());
            numOfPlayers = numberOfPlrs;
            players = new Player[numberOfPlrs];
            getNames();
            setUpDeck();
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
                drawNewCard();
            }
            else
            {
                endGame();
            }
        }

        //Handles what happens when a player chooses to say "No thanks" to the faceupcard and put one
        //token on it instead. If the player chooses this without any tokens, they are forced to instead take the card
        public void pass(Player p)
        {
            if(p.Tokens == 0)
            {
                takeCard(p);
            }
            else
            {
                p.Tokens -= 1;
                nextTurn();
            }
        }

        //Draws a new card from the deck and makes it the new faceup card
        public void drawNewCard()
        {
            faceupCard = deck[0];
            deck.RemoveAt(0);
        }

        public void endGame()
        {
            //End the game
        }

        public void nextTurn()
        {
            //Sets the currentplayer to the next player in the turn sequence
        }

        


        //First player and player order
        //Set up the deck
        //Max number of players and deck size dependant on num of players
        //Set up a choice method to pick between taking the card and placing a token
        //Figure out if the tokens in the pot should be stored on the card itself or in the "NoThanks" object
    }
}
