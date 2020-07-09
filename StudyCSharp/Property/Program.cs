using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property
{
    class BirthdayInfo
    {
        private DateTime birthday;

        public string Name { get; set; } = "Unknown";

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                if (value.Year >= DateTime.Now.Year)
                {
                    birthday = DateTime.Now;
                }

                else
                    birthday = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BirthdayInfo info = new BirthdayInfo();
            info.Name = "박서현";
            info.Birthday = new DateTime(1991, 6, 28);
            Console.WriteLine($"{info.Name}, {info.Birthday} 출생");

            var myIns = new { name = "JSC", home = "부산"};
            Console.WriteLine($"{myIns.name}, {myIns.home}");

            var b = new { subject = "수학", scores = new int[] { 99, 88, 77 } };
            Console.WriteLine($"{b.subject}");
            foreach (var item in b.scores)
            {
                Console.WriteLine($"{item}");
            }
            //info.SetName("박서현");
            //info.SetBirthday(new DateTime(1991, 6, 28));

            //Console.WriteLine($"{info.getName()}, {info.GetBirthday()}출생");
        }
    }
}
