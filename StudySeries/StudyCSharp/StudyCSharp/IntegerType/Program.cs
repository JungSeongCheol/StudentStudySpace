using System;

namespace IntegerType
{
    class Program
    {
        static void Main(string[] args)
        {
            //sbyte a = sbyte.MinValue;
            //byte b = byte.MaxValue;

            //Console.WriteLine($"a = {a}, b = {b}");

            //short c = short.MinValue;
            //ushort d = ushort.MaxValue;

            //Console.WriteLine($"c = {c}, d = {d}");

            //int e = int.MinValue;
            //uint f = uint.MaxValue;

            //Console.WriteLine($"e = {e}, f = {f}");

            //long g = long.MinValue;
            //ulong h = 2_000_000_000_000_000_000;

            //Console.WriteLine($"g= {g}, h = {h}");

            //byte a = 255;

            //Console.WriteLine($"a = {a}");

            //byte b = 0b1111_1111;
            //Console.WriteLine($"b = {b}");

            //byte c = 0xff;
            //Console.WriteLine($"c = {c}");

            //uint d = 0x1234_abcd;
            //Console.WriteLine($"d = {d}");


            byte d = byte.MaxValue;
            Console.WriteLine($"d = {d}");
            d++;
            Console.WriteLine($"d = {d}");
            d++;
            Console.WriteLine($"d = {d}");

            float f = float.MaxValue;
//            double g = double.MaxValue;

            Console.WriteLine($"f = {f}");
        }
    }
}
