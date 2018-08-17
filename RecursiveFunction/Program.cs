using System;
using System.IO;

namespace RecursiveFunction
{
    class Program
    {

        /// <summary>
        /// https://www.youtube.com/watch?v=ozmE8G6YKww&t=629s
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a number");
                var input = Console.ReadLine();

                int number;
                bool isNumber = int.TryParse(input, out number);


                if (isNumber)
                {
                    Console.WriteLine($" result = {Factorial(number)}");
                }
                else
                {
                    FindFiles(input);
                }


                Console.ReadKey();
            }

        }


        public static int Factorial(int number)
        {

            if (number == 0) return 1;

            int fact = 1;

            for (int i = number; i > 0; i--)
            {
                fact = fact * i;
            }
            return fact;

        }

        public static int RecursiveFactorial(int number)
        {
            // 1- write if
            if (number == 0) //2 - handle the simplest case
                return 1;
            else
            {
                int result = RecursiveFactorial(number - 1) * number; // write the recursive call

                return result;

            }

        }


        public static void FindFiles(string path)
        {

            foreach (var fileName in Directory.GetFiles(path))
            {
                Console.WriteLine($" file - {fileName}");
            }

            foreach (var folder in Directory.GetDirectories(path))
            {
                Console.WriteLine($" folder - { folder}");
                FindFiles(folder);
            }

        }

    }
}
