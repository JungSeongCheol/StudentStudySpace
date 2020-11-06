using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = ("슈퍼맨", 56, "크립톤");
            //Console.WriteLine($"{a.Item1}, {a.Item2}, {a.Item3}");
            //Console.WriteLine($"{a.Item1.GetType()}, {a.Item2.GetType()}, {a.Item3.GetType()}");

            //var b = (Name: "박상현", Age: 17, Home: "부산");
            //Console.WriteLine($"{ b.Age }, {b.Name}, {b.Home}");
            //b = a;
            //Console.WriteLine($"{ b.Age }, {b.Name}, {b.Home}");

            //var (name, age, home) = b;
            //Console.WriteLine($"{name}, {age}, {home}"); // 대소문자 구분하지 않는다.

            var (name, age, home) = GetInfo();
            Console.WriteLine($"{name}, {age}, {home}"); // 대소문자 구분하지 않는다.
        }


        static Tuple<string, int, string> GetInfo()
        {
            return new Tuple<string, int, string>("a", 12, "b");
        }
        
    }
}
