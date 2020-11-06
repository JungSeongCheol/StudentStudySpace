using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UsingLock
{
    class Counter
    {
        const int LOOP_COUNT = 1_000;

        readonly object thisLock;

        public int count{ get; set; }

        public Counter()
        {
            thisLock = new object();
            count = 0;
        }

        public void Increase()
        {
            int loopCount = LOOP_COUNT;
            while(loopCount-- > 0)
            {
                lock (thisLock)
                {
                    count++;
                    Console.WriteLine(count);
                }
                Thread.Sleep(1);
            }
        }

        public void Decrease()
        {
            int loopCount = LOOP_COUNT;
            while(loopCount-- > 0)
            {
                lock (thisLock)
                {
                    count--;
                    Console.WriteLine(count);
                }
                Thread.Sleep(1);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();

            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            Console.WriteLine(counter.count);
        }
    }
}
