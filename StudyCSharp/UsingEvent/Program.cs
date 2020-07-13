using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingEvent
{
    delegate void EventHandler(string message);
    
    class MyNotifier
    {
        public event EventHandler SomethingHappend;
        public void DoSomething(int number)
        {
            int temp = number % 10; // 3 , 6, 9, (12일때 짝말고 13일때 짝을 하고싶다!!! 이런의미이다.)

            if ((temp != 0) && (temp % 3 == 0))
            {
                SomethingHappend(String.Format($"{number} : 짝"));
            }
        }
    }

    class Program
    {
        static public void MyHandler(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappend += new EventHandler(MyHandler);

            for (int i = 0; i < 30; i++)
            {
                notifier.DoSomething(i);
            }
        }
    }
}
