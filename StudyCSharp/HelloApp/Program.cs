using System;
using static System.Console;

namespace HelloApp
{
    /// <summary>
    /// 기본 클래스
    /// </summary>
     class Program
    {
         /// <summary>
         /// 엔트리포인트 메서드
         /// </summary>
         /// <param name="args"> </param>

        
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                WriteLine("ex: helloapp.exe <이름>");
                return;
            }

            else
                WriteLine($"Hello, {args[0]}!");
        }
    }
}