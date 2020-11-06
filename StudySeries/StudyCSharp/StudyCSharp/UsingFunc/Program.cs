using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Func예제
            //Func<int> func1 = () => 10; // == {return 10;};
            //Console.WriteLine($"func1() : {func1()}");

            //Func<int, int> func2 = (x) => { return (x * 2); };
            //Console.WriteLine($"func2(4) : {func2(4)}");

            //Func<double, double, int> func3 = (x, y) => (int)(x / y);
            //Console.WriteLine($"func3(22, 7) : {func3(22, 7)}");
            #endregion

            Action act1 = () => Console.WriteLine("Action()");
            act1();

            int result = 0;
            Action<int> act2 = (x) => { result = x * x; };

            act2(3);
            Console.WriteLine(result);

            Action<double, double> act3 = (x, y) =>
            {
                double pi = x / y;
                Console.WriteLine($"Action<T1, T2>({x}, {y}) : {pi}");
            };

            act3(22, 7);
        }
    }
}
