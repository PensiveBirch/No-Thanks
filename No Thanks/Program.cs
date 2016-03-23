using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No_Thanks
{
    class Program
    {
        static void Main(string[] args)
        {
            Player tyler = new Player("Tyler");
            for (int i = 5; i < 10; i++)
            {
                tyler.AddCard(new Card(i));
            }
            tyler.AddCard(new Card(25));
            tyler.AddCard(new Card(30));
            tyler.CalculateScore();
            Console.WriteLine(tyler.Score);
            Console.ReadLine();            
        }
    }
}
