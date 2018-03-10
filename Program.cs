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
                Console.Write("Enter first number: ");
                BigInteger n = new BigInteger(Console.ReadLine());
                Console.Write("Enter second number: ");
                BigInteger p = new BigInteger(Console.ReadLine());

                Console.WriteLine();
                Console.Write("Addition result: ");
                RepresentationBI.Write(n + p);

                Console.WriteLine();
                Console.Write("Substruction result: ");
                RepresentationBI.Write(n - p);

                Console.WriteLine();
                Console.Write("Multiplication result: ");
                RepresentationBI.Write(n * p);

                Console.WriteLine("\n");
            }
            while (true);
        }
    }
}
