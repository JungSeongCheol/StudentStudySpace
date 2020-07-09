using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateChain
{
    delegate void Notify(string message);

    class Notifier
    {
        public Notify EventOccured;
    }

    class EventListener
    {
        private string name;
        public EventListener(string name)
        {
            this.name = name;
        }

        public void SomethingHappen(string message)
        {
            Console.WriteLine($"{name}.SomethingHappened : {message}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            EventListener listener1 = new EventListener("Listener1");
            EventListener listener2 = new EventListener("Listener2");
            EventListener listener3 = new EventListener("Listener3");

            notifier.EventOccured += listener1.SomethingHappen;
            notifier.EventOccured += listener2.SomethingHappen;
            notifier.EventOccured += listener3.SomethingHappen;
            notifier.EventOccured("You've got mail");

            Console.WriteLine();

            notifier.EventOccured -= listener2.SomethingHappen;
            notifier.EventOccured("Download complete");

            Console.WriteLine();

        }
    }
}
