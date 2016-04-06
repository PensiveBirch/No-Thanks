using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No_Thanks
{
    static class Methods
    {
        //This is a class for static methods

        //Shuffles a List of Cards
        public static void Shuffle<Card>(this IList<Card> list)
        {
            //Fisher-Yates Shuffle
            Random rng = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                //get random number from i to Count-1
                int rand = rng.Next(i, list.Count);
                //swap i-th element and the random numbered element
                Card card1 = list[i];
                list[i] = list[rand];
                list[rand] = card1;
            }
        }

        //Prints out the value and count of a List of Cards
        public static void Display<Card>(this IList<No_Thanks.Card> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Card{0} value: {1}", i + 1, list[i].Value);
            }
            Console.WriteLine();
        }
    }
}
