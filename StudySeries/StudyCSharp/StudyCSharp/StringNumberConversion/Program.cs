using System;

namespace StringNumberConversion
{
    class Program
    {
        enum z { YES, NO, CANCEL }
        static void Main(string[] args)
        {
            int a = 12345;
            string b = a.ToString();
            Console.WriteLine($"b= {b}");
            float c = 3.141592f;
            string d = c.ToString();
            Console.WriteLine($"d = {d}");

            string e = "123456*";
            int f;
            if(int.TryParse(e, out f)) // out f의 의미 : TryParse의 결과값을 f변수에 저장하라는 의미이다.(성공했으면) TryParse는 변환 성공시 True를 변환 실패시 False를 반환한다.
            //Call by Reference 의 의미를 가진다.
            {
                Console.WriteLine($"f = {f}");
            }
            else
            {
                Console.WriteLine("f 변환시 에러발생, 문자열 확인요망");
            }
            //  bool result = int.TryParse(e, out f);
            //  Console.WriteLine($"result = {result}");

            string g = "3:141592";
            float h;
            if(float.TryParse(g, out h))    // 마찬가지로 out h의 의미 : TryParse의 결과 값을 h에 저장하라는 의미이다.
            {
                Console.WriteLine($"h = {h}");
            }
            else
            {
                Console.WriteLine("g 변환시 에러발생, 문자열 확인요망");
            }
        }
    }
}
