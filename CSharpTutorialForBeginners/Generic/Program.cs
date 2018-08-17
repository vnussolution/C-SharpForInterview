using System;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {


            bool equalInt = CompareInt.IsEqual<int>(5, 6);
            bool equalString = CompareString<string>.AreEqual("3", "3");

            string resultInt = equalInt ? " yes " : "no";
            string resultString = equalString ? " yes " : "no";

            Console.WriteLine($" resultInt: {resultInt} -- resultString : {resultString}");

            Console.ReadKey();
        }
    }

    public class CompareInt
    {
        // put type on the method
        public static bool IsEqual<T>(T value1, T value2)
        {
            return value1.Equals(value2);
        }
    }


    // put type on the class
    public class CompareString<T>
    {
        public static bool AreEqual(T value1, T value2)
        {
            return value2.Equals(value1);
        }
    }
}
