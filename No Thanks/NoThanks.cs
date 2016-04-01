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

        int numOfPlayers = 0;
        Player[] players;
        List<Card> deck = new List<Card>();
        Card faceupCard;
        int tokensOnCurrentCard = 0;

        public NoThanks(int plrs)
        {
            numOfPlayers = plrs;
            players = new Player[plrs];
            getNames();
        }

        public NoThanks()
        {
            Console.WriteLine("How many players are playing?");
            int numberOfPlrs = Convert.ToInt32(Console.ReadLine());
            numOfPlayers = numberOfPlrs;
            players = new Player[numberOfPlrs];
            getNames();
        }

        public void getNames()
        {
            for (int i = 0; i < numOfPlayers; i++)
            {
                Console.WriteLine("Enter in your name: ");
                string plrName = Console.ReadLine();
                players[i] = new Player(plrName);
            }
        }

        public void populateDeck()
        {
            //for loop to create every card from 3 to 35
        }

        public void shuffleDeck()
        {
            //shuffles current deck
        }

        public void setUpDeck()
        {
            //calls populateDeck() and takes 9 out and calls shuffle()
        }

        public void DisplayPlayers()
        {
            for (int i = 0; i < numOfPlayers; i++)
            {
                Console.WriteLine("Player{0}: {1}\nTokens: {2}\n", i + 1, players[i].Name, players[i].Tokens);
            }
        }


        //First player and player order
        //Set up the deck
        //Max number of players and deck size dependant on num of players
        //Set up a choice method to pick between taking the card and placing a token
        //Figure out if the tokens in the pot should be stored on the card itself or in the "NoThanks" object
    }
}
