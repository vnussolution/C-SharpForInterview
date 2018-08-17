using System;

namespace MulticastDelegates
{

    ///  MULTI DELEGATE IS USED IN  OBSERVER DESIGN PATTERN  (PUBLISH/SUBSCRIBE PATTERN)
    public delegate int MultiDelegates(int value);
    class Program
    {
        static void Main(string[] args)
        {

            MultiDelegates del = new MultiDelegates(DeleMethod1); // ONE WAY TO REGISTER DELEGATE
            del += DeleMethod2; // ANOTHER WAY TO REGISTER
            del += DeleMethod3;

            int returnedValue = del(5);


            Console.WriteLine($" returned value of delegate =  {returnedValue}"); // it will return the last delegate DeleMethod3
            Console.ReadKey();
        }



        public static int DeleMethod1(int value)
        {
            return value + 1;
        }


        public static int DeleMethod2(int value)
        {
            return value + 2;
        }
        public static int DeleMethod3(int value)
        {
            return value + 3;
        }
    }
}
