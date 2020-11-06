using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunction
{
    class Program
    {
        static string ToLowerString(string input)
        {
            var arr = input.ToCharArray();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = ToLowerChar(i);
            }

            char ToLowerChar(int i)
            {
                if (arr[i] < 65 || arr[i] > 90)
                    return arr[i];
                else
                    return (char)(arr[i] + 32);
            }

            return new string(arr);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ToLowerString("hello!"));
            Console.WriteLine(ToLowerString("Good MORING."));   // 대문자 만들기 ctrl+shift+u 소문자 만들기 ctrl+u
            Console.WriteLine(ToLowerString("This is C#"));
        }
    }
}
