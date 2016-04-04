using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No_Thanks
{
    class Program
    {
        public static void Test1()
        {
            //testing player creation, adding cards to a player's hand, and calculating a player's score
            Player tyler = new Player("Tyler");
            for (int i = 5; i < 10; i++)
            {
                tyler.AddCard(new Card(i));
            }
            tyler.AddCard(new Card(25));
            tyler.AddCard(new Card(30));
            tyler.AddCard(new Card(31));
            /*
                Tyler's Cards:
                5, 6, 7, 8, 9, 25, 30, 31
                Tyler's Tokens:
                11

                Score: 5 + 25 + 30 - 11 = 49
            */
            tyler.CalculateScore();
            Console.WriteLine(tyler.Score);
        }

        public static void Test2()
        {
            //Testing new NoThanks() constructor and DisplayPlayers()
            NoThanks game1 = new NoThanks();
            game1.DisplayPlayers();
        }

        public static void Test3()
        {
            //Testing shuffle method in No Thanks class
            List <Card> testDeck = new List<Card>();
            for(int i = 3; i < 12; i++)
            {
                testDeck.Add(new Card(i));
            }
            Methods.Display<Card>(testDeck);
            Methods.Shuffle(testDeck);
            Methods.Display<Card>(testDeck);
        }

        public static void Test4()
        {
            //Simple game setup
            NoThanks newGame = new NoThanks();
            //newGame.setUpDeck();
            newGame.displayDeck();
        }
        static void Main(string[] args)
        {
            //Test1();
            //Test2();
            //Test3();
            Test4();
            Console.ReadLine();
        }
    }
}
