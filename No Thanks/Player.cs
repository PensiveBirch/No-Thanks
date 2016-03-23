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
        int tokens;
        List<Card> cards = new List<Card>();
        int score;

        public string Name { get { return name; } }
        public int Tokens { get { return tokens; } set { tokens = value; } }
        public List<Card> Cards { get { return cards; } }
        public int Score { get { return score; } set { score = value; } }

        public Player(string n)
        {
            name = n;
            tokens = 11;
            score = 0;
        }

        public Player()
        {
            name = "Bob";
            tokens = 11;
            score = 0;
        }

        public void AddTokens(int numOfTokens)
        {
            tokens += numOfTokens;
        }

        public void AddCard(Card c)
        {
            cards.Add(c);
        }

        public void CalculateScore()
        {
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
