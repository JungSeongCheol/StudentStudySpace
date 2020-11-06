using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Parent
    {
        protected string Name;
        public Parent(string name)
        {
            Name = name;
            Console.WriteLine($"{Name}.Base()");
        }

        public void BaseMethod()
        {
            Console.WriteLine($"{Name}.BaseMethod()");
        }
    }

    class Child : Parent
    {
        public Child(string name) : base(name)
        {
            Console.WriteLine($"{Name}.Derived()");
        }

        public void DerivedMethod()
        {
            Console.WriteLine($"{Name}.DerivedMethod()");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Parent p = new Parent("P");
            p.BaseMethod();

            Child c = new Child("c");
            c.BaseMethod();
            Console.WriteLine("-------------------");
            c.DerivedMethod();

        }
    }
}
