using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingEnumerable
{
    class MyList : IEnumerable, IEnumerator
    {
        private int[] array;
        int position = -1;  //0이 되면 안되는 이유 : MoveNext 처음 실행시 if문을 뛰어넘어서 position++;를 실행하게되고, 이러면 position = 1이 되어 두번째 요소가 실행됨

        public MyList()
        {
            array = new int[3];
        }

        public int this[int index]
        {
            get
            {
                return array[index];
            }

            set
            {
                if (index >= array.Length)
                {
                    Array.Resize(ref array, index + 1);
                    Console.WriteLine($"Array Reisized : {array.Length}");
                }

                array[index] = value;
            }
        }

        public object Current
        {
            get
            {
                return array[position];
            }
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

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return (array[i]);
            }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();
            for (int i = 0; i < 5; i++)
            {
                list[i] = i;
            }

            foreach (int e in list)
            {
                Console.WriteLine(e);
            }
        }
    }
}
