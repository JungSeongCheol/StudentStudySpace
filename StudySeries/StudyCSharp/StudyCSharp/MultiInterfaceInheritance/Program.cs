using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiInterfaceInheritance
{
    interface Irunnable
    {
        void Run();
    }

    interface IFlyable
    {
        void Fly();
    }

    public class Vehicle
    {
        public string Year;
        public string Company;
        public float HorsePower;
    }
    class FlyingCar : Vehicle, Irunnable, IFlyable
    {
        public void Run()
        {
            Console.WriteLine("Run! Run!");
        }

        public void Fly()
        {
            Console.WriteLine("Fly! Fly!");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            FlyingCar car = new FlyingCar();
            car.Run();
            car.Fly();
            car.Company = "현대";

            Irunnable runnable = car as Irunnable;
            runnable.Run();

            IFlyable flyable = car as IFlyable;
            flyable.Fly();
        }
    }
}
