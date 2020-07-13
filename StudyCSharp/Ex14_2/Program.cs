using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex14_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 11, 22, 33, 44, 55 };

            foreach (int a in array)
            {
                Action action = () =>
                {
                    Console.WriteLine(a * a);
                };
                action();

                //Action action = new Action(
                //    delegate ()
                //    {
                //        Console.WriteLine(a * a);
                //    }
                //);

                //action();
            }
        }
    }
}
