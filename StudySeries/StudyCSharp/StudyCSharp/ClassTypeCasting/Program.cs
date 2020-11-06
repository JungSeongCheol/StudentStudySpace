using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTypeCasting
{
    class Program
    {
        class Mammal    //포유류
        {
            public void Nurse()
            {
                Console.WriteLine("Nurse()");
            }
        }

        class Dog : Mammal
        {
            public void Bark()
            {
                Console.WriteLine("Bark()");
            }
        }

        class Cat : Mammal
        {
            public void Meow()
            {
                Console.WriteLine("Meow()");
            }
        }

        static void Main(string[] args)
        {
            Mammal mammal = new Dog();
            Dog dog;

            if(mammal is Dog)
            {
                dog = mammal as Dog;
                dog.Bark();
            }

            Mammal mammal2 = new Cat();

            Cat cat = mammal2 as Cat;
            if (cat != null)
                cat.Meow();

            Cat cat2 = mammal as Cat;
            if (cat != null)
                cat.Meow();
            else
                Console.WriteLine("cat2 is not a Cat");
        }
    }
}
