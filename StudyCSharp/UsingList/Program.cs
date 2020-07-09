using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                int iresult = list.Add(i);    //리스트 가장 마지막에 값을 추가
                Console.WriteLine($"{iresult}번째에 데이터 {i}추가 완료");
            }

            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            list.RemoveAt(2);   //인덱스 위치값 삭제

            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            list.Insert(4, 4.5);    //인덱스 위치에 값을추가(원래 있던 인덱스위치의 값은 뒤로 밀려짐)
            //int형식이 아니라도 저장이가능(모든 값이 object로 저장이 되기떄문에)

            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            list.Clear();
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
