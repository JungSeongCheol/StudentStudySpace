using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingGenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            // List 일반화
            {
                //List<int> intList = new List<int>();
                //for (int i = 0; i < 5; i++)
                //{
                //    intList.Add(i);
                //}

                //foreach (int item in intList)
                //{
                //    Console.Write(item);
                //}
                //Console.WriteLine();
                //intList.RemoveAt(2);

                //foreach (int item in intList)
                //{
                //    Console.Write(item);
                //}
                //Console.WriteLine();
                //intList.Insert(2, 2);

                //foreach (int item in intList)
                //{
                //    Console.Write(item);
                //}
                //Console.WriteLine();
            }
            
            //Queue 일반화
            {
                //Queue<double> q = new Queue<double>();

                //q.Enqueue(1.2);
                //q.Enqueue(2.2);
                //q.Enqueue(3.3);
                //q.Enqueue(4.5);
                //q.Enqueue(5.4);

                //while (q.Count > 0)
                //    Console.WriteLine(q.Dequeue());
            }

            //Dictionary (HashTable 일반화) 일반화
            {
                Dictionary<string, int> dic = new Dictionary<string, int>();
                dic["하나"] = 100;
                dic["둘"] = 200;
                dic["셋"] = 300;
                dic["넷"] = 400;
                dic["다섯"] = 500;

                Console.WriteLine(dic["하나"]);
                Console.WriteLine(dic["둘"]);
                Console.WriteLine(dic["셋"]);
                Console.WriteLine(dic["넷"]);
                Console.WriteLine(dic["다섯"]);


            }
        }
    }
}
