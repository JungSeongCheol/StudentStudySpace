using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericParameters
{
    class StructArray<T> where T : struct //값형식 <int>같은것 만 가능
    {
        public T[] Array { get; set; }

        public StructArray(int size)
        {
            Array = new T[size];
        }
    }

    class RefArray<T> where T : class  //참조형식 (class같은것) 만 가능
    {
        public T[] Array { get; set; }

        public RefArray(int size)
        {
            Array = new T[size];
        }
    }

    class Base { }

    class Derived : Base { }

    class BaseArray<U> where U : Base   //매개변수 U로부터 상속받은 클래스여야만 가능
    {
        public U[] Array { get; set; }

        public BaseArray(int size)
        {
            Array = new U[size];
        }

        public void CopyArray<T>(T[] source) where T : U
        {
            source.CopyTo(Array, 0);
        }
    }

    class Program
    {
        public static T CreateInstance<T>() where T : new()
        {
            return new T();
        }

        static void Main(string[] args)
        {
            StructArray<int> a = new StructArray<int>(3);
            a.Array[0] = 0;

            RefArray<Base> b = new RefArray<Base>(3);
            a.Array[0] = 3;

            BaseArray<Base> c = new BaseArray<Base>(3);
            c.Array[0] = new Base();
            c.Array[1] = new Derived();
            c.Array[2] = CreateInstance<Base>();

            BaseArray<Derived> d = new BaseArray<Derived>(3);
        }
    }
}
