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
            NoThanks game1 = new NoThanks();
            game1.DisplayPlayers();
        }

        static void Main(string[] args)
        {
            //Test1();
            Test2();
            Console.ReadLine();
        }
    }
}
