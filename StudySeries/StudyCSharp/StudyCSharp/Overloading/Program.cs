using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading
{
    class Program
    {
        /// <summary>
        /// int 형에 대해서 저장됩니다.
        /// </summary>
        /// <param name="a">int a</param>
        /// <param name="b">int b</param>
        /// <returns>int 리턴</returns>
        static int Plus(int a, int b)
        {
            return a + b;
        }

        static int Plus(int a, int b, int c)
        {
            return a + b + c;
        }

        /// <summary>
        /// 덧셈 double형 두 수를 더한다.
        /// </summary>
        /// <param name="a">double a</param>
        /// <param name="b">double b</param>
        /// <returns>double return</returns>
        static double Plus(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// 덧셈 double형 세수를 더한다.
        /// <param name="a">double a</param>
        /// <param name="b">double b</param>
        /// <param name="c">double c</param>
        /// <returns>double return</returns>
        static double Plus(double a, double b, double c)
        {
            return a + b + c;
        }

        static float Plus(float a, float b)
        {
            return a + b;
        }

        static double Plus(float a, int b)
        {
            return a + b;
        }

        static int Sum(params int[] args)
        {
            int sum = 0;

            for (int i = 0; i < args.Length; i++)
            {
                sum += args[i];
            }

            return sum;
        }

        static void MyMethod(string arg1 = "", string arg2 = "")
        {
            Console.WriteLine("MyMethod A");
        }

        static void MyMethod()
        {
            Console.WriteLine("MyMethod B");
        }


        static void Main(string[] args)
        {
            //Console.WriteLine(Plus(3.14f, 2.56f));
            //Console.WriteLine(Plus(3,2));

            int sum = Sum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);

            Console.WriteLine($"Sum : {sum}");
            MyMethod("", "");
        }
    }
}
