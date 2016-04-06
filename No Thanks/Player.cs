using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No_Thanks
{
    //This class includes all the attributes of a Player in No Thanks including
    //number of tokens, cards, the player's name, and their score

    class Player
    {
        string name;
        int tokens;                          //Worth negative points
        List<Card> cards = new List<Card>(); //Cards taken from deck
        int score;                           //Caculated at the end (or as the game progresses)

        //Properties
        public string Name { get { return name; } }
        public int Tokens { get { return tokens; } set { tokens = value; } }
        public List<Card> Cards { get { return cards; } }
        public int Score { get { return score; } set { score = value; } }

        //Constructor
        public Player(string n)
        {
            name = n;
            tokens = 11; //Start the game with 11 tokens
            score = 0;
        }

        //Adds a card to the hand of the player
        public void AddCard(Card c)
        {
            cards.Add(c);
        }

        //Calculates a player's score
        public void CalculateScore()
        {
            /*Score = card points - number of tokens
              card points are all of the card values added together, but any consecutive
              runs of values are valued as the lowest value card
              ex: cards{3, 4, 6, 8, 9, 10} = 3 + 6 + 9 = 18 card points */
            int cardPoints = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                cardPoints += cards.ElementAt(i).Value;
                if (i != 0 && cards.ElementAt(i - 1).Value + 1 == cards.ElementAt(i).Value)
                {
                    cardPoints -= cards.ElementAt(i).Value;
                }
            }
            score = cardPoints - tokens;
        }
    }
}
