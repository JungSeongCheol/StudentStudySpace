using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicClass
{
    class Cat
    {
        public string Name;
        public Color Color;

        public Cat()
        {
            Name = "";
            Color = Color.Transparent;
        }

        /// <summary>
        /// 파라미터 생성자
        /// </summary>
        /// <param name="name">고양이 이름</param>
        /// <param name="color">고양이 털색</param>
        public Cat(string name, Color color)
        {
            Name = name;
            Color = color;
        }
        ~Cat()
        {
            Console.WriteLine("Distruct!");
        }

        public void Meow()
        {
            Console.WriteLine($"{Name}, 야옹~!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cat Kitty = new Cat(); // 인스턴스 화
            Kitty.Name = "키티";
            Kitty.Color = Color.White;
            Kitty.Meow();
            Console.WriteLine($"{Kitty.Name} : {Kitty.Color}");

            Cat nero = new Cat("네로", Color.Black);
            nero.Meow();
            Console.WriteLine($"{nero.Name} : {nero.Color}");

        }
    }
}
