using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambda
{
    class Program
    {
        delegate int Calculate(int a, int b);
        delegate string Concatenate(string[] args);
        //static int Plus(int a, int b)
        //{
        //    return a + b;
        //}

        static string Join(string[] arr)
        {
            string result = string.Empty;
            foreach (string s in arr)
            {
                //Todo
                result += $"{s}";
            }
            return result;
        }

        static void Main(string[] args)
        {
            //Calculate calc = new Calculate(Plus);
            //Console.WriteLine(calc(3, 4));

            //Calculate calc1 = (a, b) => a + b;
            //Console.WriteLine(calc1(3, 4));

            #region ConCat람다식 (주석처리)
            //Concatenate concat = (arr) =>
            //{
            //    string result = string.Empty;
            //    foreach (string s in arr)
            //    {
            //        //Todo
            //        result += $"{s}";
            //    }
            //    return result;
            //};
            //Console.WriteLine(concat(args));
            #endregion

            #region 일반 delegate식(ConCat2)
            Concatenate concat2 = new Concatenate(Join);
            Console.WriteLine(concat2(args));
            #endregion


        }
    }
}
