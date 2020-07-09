using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingHashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht["이름"] = "홍길동";
            ht["주소"] = "부산광역시 북구";
            ht["전화번호"] = "010-xxxx-xxxx";
            ht["키"] = 179.0;

            Console.WriteLine(ht["전화번호"]);

            int[] arr = { 123, 456, 789 };

            Queue queue = new Queue(arr);
            
        }
    }
}
