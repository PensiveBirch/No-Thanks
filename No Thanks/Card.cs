using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No_Thanks
{
    class Card
    {
        int value; //value on the card

        public int Value { get { return value; } }

        public Card(int v)
        {
            value = v;
        }
    }
}
