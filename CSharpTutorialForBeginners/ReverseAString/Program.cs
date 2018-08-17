using System;
using System.Linq;

namespace ReverseAString
{
    class Program
    {

        // one two three
        //-> eno owt eerht



        static void Main(string[] args)
        {

            Console.WriteLine($" please enter a string");
            var input = Console.ReadLine();

            ReverseString1(input);
            ReverseString2(input);


            Console.ReadKey();

        }



        static void ReverseString1(string input)
        {
            string[] arryString = input.Split(' ');

            foreach (var str in arryString)
            {
                var reversedArray = str.Reverse().ToArray();
                foreach (var c in reversedArray)
                {
                    Console.Write($"{c.ToString()}");
                }
                Console.Write(" ");
            }

            Console.WriteLine();
        }


        static void ReverseString2(string input)
        {
            string result1 = string.Join(" ", input.Split(' ').Select(x => new string(x.Reverse().ToArray())));
            string result2 = string.Join(" ", input.Split(' ').Select(x => String.Join("", x.Reverse())));

            Console.WriteLine($" {result1  }  - { result2}");
        }
    }
}
