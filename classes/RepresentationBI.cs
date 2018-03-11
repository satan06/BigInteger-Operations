using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace std
{
    class RepresentationBI
    {
        public static void Write(BigInteger _uint)
        {
            for (int i = 3; i < _uint.items.Count; i += 4)
            {
                _uint.items.Insert(i, -1);
            }
            _uint.items.Reverse();

            if (_uint.is_negative)
            {
                Console.Write('-');
            }
            foreach (int i in _uint.items)
            {
                if (i == -1)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(i);
                }
            }
        }
        public static void Write(BigIntegerFraction _fraction)
        {
            Write(_fraction.numerator);
            Console.Write("/");
            Write(_fraction.denominator);
        }
    }
}
