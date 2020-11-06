using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace MyExtension
{
    public static class IntegerExtension
    {
        public static int Square(this int Int)
        {
            return Int * Int;
        }

        public static int Power(this int Int, int exponent)
        {
            int result = Int;
            for (int i = 1; i < exponent; i++)
                result = result * Int;

            return result;
        }

        public static string Adda(this string A)
        {
            string result = A;
            return result + "a";
        }
    }
}
