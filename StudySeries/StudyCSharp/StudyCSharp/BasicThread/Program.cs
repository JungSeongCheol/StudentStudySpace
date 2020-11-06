using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingBasicThread
{
    class Program
    {
        static void DoSomething()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"DoSomething : {i}");
                Thread.Sleep(1000);
            }
        }

        static void DoAnything()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"DoAnything : {i}");
                Thread.Sleep(300);
            }
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(DoSomething));
            Thread thread2 = new Thread(new ThreadStart(DoAnything));

            Console.WriteLine("Starting thread...");
            thread.Start(); // 시작하면서 DoSomething 호출
            thread2.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Main : {i}");
                Thread.Sleep(500);
            }

            Console.WriteLine("Wating until thread stops...");
            thread.Join();
            thread2.Join();

            Console.WriteLine("Finished");
        }
    }
}
