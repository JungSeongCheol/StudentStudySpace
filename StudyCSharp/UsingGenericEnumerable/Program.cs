using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingGenericEnumerable
{
    class MyList<T> : IEnumerable<T>, IEnumerator<T>
    {
        private T[] array;
        int position = -1;

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
                if(index >= array.Length)
                {
                    Array.Resize<T>(ref array, index + 1);
                    Console.WriteLine($"Array Resized : {array.Length}");
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return (array[i]);
            }
        }

        public T Current
        {
            get { return array[position]; }
        }

        object IEnumerator.Current
        {
            get { return array[position]; }
        }

        public bool MoveNext()
        {
            if (position == array.Length - 1)
            {
                Reset();
                return false;
            }

            position++;
            return (position < array.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> strlist = new MyList<string>();
            strlist[0] = "abc";
            strlist[1] = "cde";
            strlist[2] = "def";
            strlist[3] = "efg";

            foreach (var item in strlist)
            {
                Console.Write($"'{item}' ,");
            }
            Console.WriteLine();
        }
    }
}
