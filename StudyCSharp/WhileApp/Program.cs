using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhileApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>();
            strings.Add("Hello");
            strings.Add("Bye");
            strings.Add("Hey~~");
            List<string> subs = new List<string> { "Banana", "Straberry" };
            strings.AddRange(subs);
            int i = 0;
            foreach (var item in strings)
            {
                Console.WriteLine($"{++i} 번째 아이템 : {item}");
            }
        }
    }
}
