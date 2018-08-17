using System;
using System.Threading;

namespace Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread workerThread1 = new Thread(PrintNumber);
            Thread workerThread2 = new Thread(PrintString);
            workerThread1.Start();
            workerThread2.Start();

            Console.ReadKey();


        }

        public static void PrintNumber()
        {
            int i = 0;
            while (true)
            {

                Thread.Sleep(500);
                Console.WriteLine(i++);
            }
        }
        public static void PrintString()
        {
            int i = 0;
            string str = "";
            while (true)
            {
                str += i++;
                Thread.Sleep(500);
                Console.WriteLine(str);
            }
        }
    }
}
