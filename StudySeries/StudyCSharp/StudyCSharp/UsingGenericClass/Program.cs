using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingGenericClass
{
    class MyList<T>
    {
        private T[] array;

        public MyList()
        {
            array = new T[3];
        }
        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if (index >= array.Length)
                {
                    Array.Resize<T>(ref array, index + 1);
                    Console.WriteLine($"Array resized : {array.Length}");
                }
                array[index] = value;
            }
        }

        public int Length
        {
            get { return array.Length; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return (array[i]);
            }
        }

        //public IEnumerator GetEnumerator()
        //{
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        yield return (array[i]);
        //    }
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> str_list = new MyList<string>();
            str_list[0] = "abc";
            str_list[1] = "def";
            str_list[2] = "ghi";
            str_list[3] = "jkl";
            str_list[4] = "mno";

            //for (int i = 0; i < str_list.Length; i++)
            //{
            //    Console.WriteLine(str_list[i]);
            //}

            foreach (var e in str_list)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();

            MyList<float> float_list = new MyList<float>();
            float_list[0] = 12.4f;
            float_list[1] = 3.141592f;
            float_list[1] = 3.141592f;

            for (int i = 0; i < float_list.Length; i++)
            {
                Console.WriteLine(float_list[i]);
            }
        }
    }
}
