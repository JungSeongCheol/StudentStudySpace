using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingCallback
{
    delegate int Compare<T>(T a, T b);
    class Program
    {
        static int AscendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b);
        }

        static int DescendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) * -1;
        }

        static void BubbleSort<T>(T[] Dataset, Compare<T> Comparer)
        {
            T temp;

            for (int i = 0; i < Dataset.Length - 1; i++)
            {
                for (int j = 0; j < Dataset.Length - (i+1); j++)
                {
                    if(Comparer(Dataset[j] , Dataset[j + 1]) > 0)
                    {
                        temp = Dataset[j + 1];
                        Dataset[j+1] = Dataset[j];
                        Dataset[j] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int[] array = { 3, 7, 4, 2, 10 };

            Console.WriteLine("Sorting ascending...");
            BubbleSort<int>(array, new Compare<int>(AscendCompare));

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }

            int[] array2 = { 7, 2, 8, 10, 11 };
            Console.WriteLine("\nSorting descending...");
            BubbleSort<int>(array2, new Compare<int>(DescendCompare));

            foreach (var item in array2)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
