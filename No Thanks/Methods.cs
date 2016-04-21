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

        public static string smallBreak = "-------------------------------------------------";
        public static string largeBreak = "============================================================================";

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

        public static void PrintFaceupCard(Card c, int tokens)
        {
            string output = "";
            int number = c.Value;
            while(number > 0)
            {
                int digit = number % 10;
                switch(digit)
                {
                    case 1:
                        output = one + output;
                        break;
                    case 2:
                        output = two + output;
                        break;
                    case 3:
                        output = three + output;
                        break;
                    case 4:
                        output = four + output;
                        break;
                    case 5:
                        output = five + output;
                        break;
                    case 6:
                        output = six + output;
                        break;
                    case 7:
                        output = seven + output;
                        break;
                    case 8:
                        output = eight + output;
                        break;
                    case 9:
                        output = nine + output;
                        break;
                    case 0:
                        output = zero + output;
                        break;
                    default:
                        output = zero + output;
                        break;
                }
                number /= 10;
            }
            Console.WriteLine(output);
            for(int i = 0; i < tokens; i++)
            {
                Console.Write("O ");
            }
            Console.WriteLine();
        }
        public static string one =
@"
 __  
/_ | 
 | | 
 | | 
 | | 
 |_|";
        public static string two =
@"
 ___   
|__ \  
   ) | 
  / /  
 / /_  
|____|";
        public static string three =
@"
 ____   
|___ \  
  __) | 
 |__ <  
 ___) | 
|____/  
";
        public static string four =
@"
 _  _    
| || |   
| || |_  
|__   _| 
   | |   
   |_|   
";
        public static string five =
@"
 _____  
| ____| 
| |__   
|___ \  
 ___) | 
|____/ 
";
        public static string six =
@"
   __   
  / /   
 / /_   
| '_ \  
| (_) | 
 \___/  
";
        public static string seven =
@"
 ______  
|____  | 
    / /  
   / /   
  / /    
 /_/ 
";
        public static string eight =
@"
  ___   
 / _ \  
| (_) | 
 > _ <  
| (_) | 
 \___/ 
";
        public static string nine =
@"
  ___   
 / _ \  
| (_) | 
 \__, | 
   / /  
  /_/   
";
        public static string zero =
@"
  ___   
 / _ \  
| | | | 
| | | | 
| |_| | 
 \___/  
";
    }
}
