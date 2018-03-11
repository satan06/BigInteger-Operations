using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace std
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                BigIntegerFraction n = new BigIntegerFraction(Console.ReadLine());
                BigIntegerFraction p = new BigIntegerFraction(Console.ReadLine());

                RepresentationBI.Write(n + p);
                Console.WriteLine();
            }
            while (true);
        }
    }
}
