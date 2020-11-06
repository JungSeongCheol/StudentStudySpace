using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte a = sbyte.MaxValue;
            Console.WriteLine($"a = {a}");

            int b = a;
            Console.WriteLine($"b = {b}");

            int x = 128;
            Console.WriteLine($"x = {x}");

            sbyte y = (sbyte)x; //오버플로우 발생 조심
            Console.WriteLine($"y = {y}");

        }
    }
}

