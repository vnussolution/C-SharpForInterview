using System;
using System.Collections.Generic;

namespace ListListGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<object>> list = new List<List<object>>();


            List<object> list1 = new List<object>() { 1, 2, 3, 4, 5, 6, 7 };
            List<object> list2 = new List<object>() { '2', '4', 'a', 'v', 'f', 'd', 's' };
            List<object> list3 = new List<object>() { "tyesy", "hello", "test" };

            list.Add(list1);
            list.Add(list2);
            list.Add(list3);


            foreach (var item in list)
            {
                Console.WriteLine($" outer list ====");
                foreach (var i in item)
                {
                    Console.WriteLine($" inner list--> {i.ToString()}");
                }
            }


            Console.Read();
        }
    }
}
