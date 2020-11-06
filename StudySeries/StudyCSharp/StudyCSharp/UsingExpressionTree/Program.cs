using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace UsingExpressionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression const1 = Expression.Constant(1);
            Expression const2 = Expression.Constant(2);

            Expression leftExp = Expression.Multiply(const1, const2); //곱하기 연산을 나타내는 BinaryExpression

            Expression param1 = Expression.Parameter(typeof(int)); //x를 위한 변수
            Expression param2 = Expression.Parameter(typeof(int)); // y를 위한 변수

            Expression rightExp = Expression.Subtract(param1, param2);  // 산술 빼기 연산

            Expression exp = Expression.Add(leftExp, rightExp); // 산술 더하기연산

            Expression<Func<int, int, int>> expression = Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>(
                exp, new ParameterExpression[] { (ParameterExpression)param1, (ParameterExpression)param2 });

            Func<int, int, int> func = expression.Compile();    //컴파일

            Console.WriteLine($"1*2+({7}-{8}) = {func(7, 8)}");
        }
    }
}
