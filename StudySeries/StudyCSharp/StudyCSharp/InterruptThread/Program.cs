using System;
using System.Threading;

namespace InterruptThread
{
    class SideTask
    {
        int count = 0;

        public SideTask(int count)
        {
            this.count = count;
        }

        public void KeepAlive()
        {
            try
            {
                Console.WriteLine("Running Thread isn't gonna be interrupted");
                //Thread.SpinWait(1_000_000_000);

                while (count > 0)
                {
                    Console.WriteLine($"{count--} left");

                    Console.WriteLine("Entering into WaitJoin State...");
                    Thread.Sleep(10);
                }
                Console.WriteLine("Count : 0");
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine(ex.Message);
                Thread.ResetAbort();
            }
            catch (ThreadInterruptedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Clearing resource...");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SideTask task = new SideTask(500);
            Thread th = new Thread(new ThreadStart(task.KeepAlive));
            th.IsBackground = false;

            Console.WriteLine("Starting thread...");
            th.Start();

            Thread.Sleep(100);

            //Console.WriteLine("Interrupting thread...");
            //th.Interrupt();
            //th.Suspend(); 이거 실행하고 Resume 실행해야함(아래에있는);

            Console.WriteLine("Waiting");
            Thread.Sleep(3000);

            //th.Resume();
            
            //Console.WriteLine("Waiting until thread stop");
            th.Join();

            Console.WriteLine("Done!!!");
        }
    }
}