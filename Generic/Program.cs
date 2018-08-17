using System;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {


            Account accountA = new Account() { Id = 1, Balance = 100 };
            Account accountB = new Account() { Id = 2, Balance = 100 };
            bool equalInt = CompareInt.IsEqual(5, 6);
            bool equalString = CompareString.AreEqual("3", "3");

            string resultInt = equalInt ? " yes " : "no";
            string resultString = equalString ? " yes " : "no";


            Console.WriteLine($" are they equal ?    resultInt: {resultInt} -- resultString : {resultString}");
            Console.WriteLine($" Compare accountA and accountB : { CompareGeneric<Account>.Equal(accountA, accountB)} ");

            Console.ReadKey();
        }
    }

    public class CompareInt
    {
        // put type on the method
        public static bool IsEqual(int value1, int value2)
        {
            return value1.Equals(value2);
        }
    }


    // put type on the class
    public class CompareString
    {
        public static bool AreEqual(string value1, string value2)
        {
            return value2.Equals(value1);
        }
    }

    public class CompareGeneric<T>
    {
        public static bool Equal<T>(T value1, T value2) where T : Account
        {
            return value1.Balance == value2.Balance;
        }

        public static bool Equals<T>(T value1, T value2)
        {
            return value1.Equals(value2);
        }
    }

    public class Account
    {
        public int Id { get; set; }
        public int Balance { get; set; }

    }


}
