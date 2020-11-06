using System;
using System.IO;

namespace Interface
{
    class Program
    {
        interface ILogger   //인터페이스 ILogger 선언, 인터페이스의 특징으로 인터페이스 상속시 반드시, 안에있는 함수를 적어줄 필요성이 존재
        {
            void WriteLog(string message);
        }

        class ConsoleLogger : ILogger
        {
            public void WriteLog(string message)
            {
                DateTime now = DateTime.Now;
                Console.WriteLine($"[{now.ToLocalTime()}], {message}");
            }
        }

        class FileLogger : ILogger
        {
            private StreamWriter writer;

            public FileLogger(string path)
            {
                writer = File.CreateText(path);
                writer.AutoFlush = true;
            }

            public void WriteLog(string message)
            {
                DateTime now = DateTime.Now;
                writer.WriteLine($"[{now.ToLocalTime()}], {message}");
            }
        }

        class ClimateMonitor
        {
            private ILogger logger;
            public ClimateMonitor(ILogger logger)
            {
                this.logger = logger;
            }

            public void start()
            {
                while (true)
                {
                    Console.Write(" 온도를 입력해주세요: ");
                    string temperature = Console.ReadLine();
                    if (temperature == "") // 그냥 엔터 쳤을때 꺼짐
                        break;

                    logger.WriteLog(" 현재 온도 : " + temperature);
                }
            }
        }

        static void Main(string[] args)
        {
         //   ClimateMonitor monitor = new ClimateMonitor(new FileLogger("climate.log"));   //파일로 저장

            ClimateMonitor monitor = new ClimateMonitor(new ConsoleLogger());   // 콘솔에 띄움
            monitor.start();
        }
    }
}
