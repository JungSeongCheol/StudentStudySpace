using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfElseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("숫자를 입력하세요. : ");

            string input = Console.ReadLine();
            int number;

            if (int.TryParse(input, out number))
            {
                if (number > 0)
                {
                    Console.WriteLine("양수");
                    if (number % 2 == 0)
                        Console.WriteLine("짝수");
                    else
                        Console.WriteLine("홀수");
                }

                else
                    Console.WriteLine("양수만 계산가능합니다.");
            }
            else
            {
                Console.WriteLine("입력값이 숫자가 아닙니다.");
                return;
            }
        }
    }
}
