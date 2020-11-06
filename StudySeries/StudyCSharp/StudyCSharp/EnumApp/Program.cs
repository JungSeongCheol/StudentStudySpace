using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumApp
{
    class Program
    {
        enum DialogResult
        {
            YES = 10,
            NO = 20,
            CANCEL = 30,
            CONFRIM = 40,
            OK
        }

        static void Main(string[] args)
        {
            //Console.WriteLine((int)DialogResult.YES);
            //Console.WriteLine((int)DialogResult.NO);
            DialogResult result = DialogResult.YES;
            Console.WriteLine((int)DialogResult.CANCEL);
            Console.WriteLine((int)DialogResult.CONFRIM);
            Console.WriteLine((int)DialogResult.OK);
            if (result == DialogResult.YES)
            {
                Console.WriteLine("YES를 선택했습니다.");
            }
        }
    }
}
