using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepCopy
{
    class MyClass
    {
        public int MyField1;
        public int MyField2;

        public MyClass DeepCopy()
        {
            MyClass newcopy = new MyClass
            {
                MyField1 = MyField1,
                MyField2 = MyField2
            };
            return newcopy;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shallow Copy");
            //Shallow Copy하는 현상({}없어도 됨) 그냥 구분 블럭이다.
            {
                MyClass source = new MyClass();
                source.MyField1 = 10;
                source.MyField2 = 20;

                //MyClass source = new MyClass
                //{
                //    source.MyField1 = 10,
                //    source.MyField2 = 20
                //} 이것과 같음(위에 있는 MyClass source와)

                MyClass target = source;
                target.MyField2 = 30;

                Console.WriteLine($"{source.MyField1} {source.MyField2}");
                Console.WriteLine($"{target.MyField1} {target.MyField2}");
            }

            Console.WriteLine("Deep Copy");
            //Deep Copy하는 현상({}없어도 됨) 그냥 구분 블럭이다.
            {
                MyClass source = new MyClass();
                source.MyField1 = 10;
                source.MyField2 = 20;

                //MyClass source = new MyClass
                //{
                //    source.MyField1 = 10,
                //    source.MyField2 = 20
                //} 이것과 같음(위에 있는 MyClass source와)

                MyClass target = source.DeepCopy();
                target.MyField2 = 30;

                Console.WriteLine($"{source.MyField1} {source.MyField2}");
                Console.WriteLine($"{target.MyField1} {target.MyField2}");
            }
        }
    }
}
