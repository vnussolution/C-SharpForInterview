using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Delegate
{
    class Program
    {
        // Defines a method that returns an int, and has one int as an input
        // Delegate defines the signature (return type and parameters)
        public delegate int Manipulate(int a);

        // Action is just a delegate
        public delegate void MyAction();

        // Func is just a delegate with a return type
        public delegate int MyFunc();

        static void Main(string[] args)
        {


            List<Student> students = new List<Student>
            {
                new Student() {Id = 1, Name = "John", Grade = 7, Credits = 5},
                new Student() {Id = 2, Name = "Jelly", Grade = 9, Credits = 45},
                new Student() {Id = 3, Name = "Jannie", Grade = 7, Credits = 25},
                new Student() {Id = 4, Name = "Jolly", Grade = 8, Credits = 15}
            };



            IsPromotable delegatePromotable = new IsPromotable(Condition);
            Student.PromoteStudent(students, delegatePromotable);

            // CAN BE REDUCED INTO 1 LINE USING LAMPDA
            //Student.PromoteStudent(students, s=>s.Grade > 8);








            // Invoking a normal method
            var normalMethodInvokeResult = NormalMethod(2);

            // Create an instance of the delegate
            var normalMethodDelegate = new Manipulate(NormalMethod);
            var normalResult = normalMethodDelegate(3);

            // Anonymous method is a a delegate() { } and it returns a delegate
            Manipulate anonymousMethodDelegate = delegate (int a) { return a * 2; };
            var anonymousResult = anonymousMethodDelegate(3);

            // Lambda expressions are anything with => and a left/right value
            // They can return a delegate (so a method that can be invoked)
            // or an Expression of a delegate (so it can be compiled and then executed)
            Manipulate lambaDelegate = a => a * 2;
            var lambaResult = lambaDelegate(5);

            // Nicer way to write a lamba
            Manipulate nicerLambaDelegate = (a) => { return a * 2; };
            var nicerLambaResult = nicerLambaDelegate(6);

            // Lamba can return an Expression
            Expression<Manipulate> expressionLambda = a => a * 2;

            // An Action is just a delegate with no return type and optional input
            Action actionDelegate = () => { lambaDelegate(2); };
            Action<int> action2Delegate = (a) => { var b = a * 2; };

            // A Func is just a delegate with a return type
            Func<int> myFunc = () => 2;

            // Replace Manipulate with a Func
            Func<int, int> funcDelegate = a => a * 2;
            var funcResult = funcDelegate(5);

            // Mimic the FirstOrDefault Linq expression
            var items = new List<string>(new[] { "a", "b", "c", "d", "e", "f", "g" });
            var itemInts = Enumerable.Range(1, 10).ToList();

            // Calling the nuilt in Linq FirstOrDefault
            var foundItem = items.FirstOrDefault(item => item == "c");

            // Calling our version
            var foundItem2 = items.GetFirstOrDefaultCustom(item => item == "c");
            var foundItem3 = itemInts.GetFirstOrDefaultCustom(item => item > 4);
            Console.ReadKey();

        }


        //////////THE CONDITION IS DYNAMICALLY PASSED IN NOT HARD CODED//////////////
        static bool Condition(Student student)
        {
            return student.Grade > 8 ? true : false;
        }


        /// <summary>
        /// A normal looking method
        /// </summary>
        /// <param name="a">The input value</param>
        /// <returns>Returns twice the input value</returns>
        public static int NormalMethod(int a)
        {
            return a * 2;
        }


    }

    /// DELEGATE IS TYPE SAFE FUNCTION POINTER ////////////////
    delegate bool IsPromotable(Student student);

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public int Credits { get; set; }

        /// FLEXIBLE CONDITION IS PASSED IN USING DELEGATE
        public static void PromoteStudent(List<Student> students, IsPromotable condition)
        {
            foreach (Student student in students)
            {
                if (condition(student))
                {
                    Console.WriteLine(student.Name + " is promoted");

                }
            }
        }
    }


    /// <summary>
    /// Helpers classes, extension method
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Mimic the behaviour of the FirstOrDefault Linq expression
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="items"></param>
        /// <param name="findMatch"></param>
        /// <returns></returns>
        public static TResult GetFirstOrDefaultCustom<TResult>(this List<TResult> items, Func<TResult, bool> findMatch)
        {
            // Loop each item
            foreach (var item in items)
            {
                // See if caller method has found a match
                if (findMatch(item))
                    // If so return it
                    return item;
            }

            // If there was no match, return default value of return type
            return default(TResult);
        }
    }
}
