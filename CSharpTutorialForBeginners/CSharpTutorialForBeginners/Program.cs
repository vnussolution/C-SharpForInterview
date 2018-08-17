using System;

namespace CSharpTutorialForBeginners
{


    class Program
    {


        public static void Hello(string strMessage)
        {
            Console.WriteLine(strMessage);
        }

        static void Main(string[] args)
        {


            // By default value types are non nullable : int, float,doube enums etc
            // to make them nullable use '?' : int? i = 0
            int? i = null;


            //Null coalescing Operator ??
            int tickets;
            int? ticketsOnSale = null;
            tickets = ticketsOnSale ?? 0;


            ////////////////////////New keyword to hide//////////////////////////////////////
            FullTimeEmployee FTE = new FullTimeEmployee();
            FTE.FirstName = "fulltime";
            FTE.LastName = "employee";
            FTE.PrintFullName();

            PartTimeEmployee PTE = new PartTimeEmployee();
            PTE.FirstName = "parttime";
            PTE.LastName = "employee";
            PTE.PrintFullName();




            Employee[] employees = new Employee[4];
            employees[0] = new Employee();
            employees[1] = new PartTimeEmployee();
            employees[2] = new FullTimeEmployee();
            employees[3] = new TempEmployee();


            foreach (Employee e in employees)
            {
                e.PrintFullName();
            }

            Console.ReadKey();

        }
    }


    public class Employee : TestProctedInternal
    {
        public string FirstName = "firstname";
        public string LastName = "lastname";
        private int myInt;

        public virtual void PrintFullName()
        {
            Console.WriteLine($"{FirstName} {LastName}");
            myInt = base.onlyInternal + 1;

        }
    }

    public class PartTimeEmployee : Employee
    {

        // new keyword will hide parent's method
        public override void PrintFullName()
        {
            Console.WriteLine($" new keyword -  child is hiding parent's method {FirstName}  {LastName} parttime");
        }
    }

    public class FullTimeEmployee : Employee
    {
        public override void PrintFullName()
        {
            Console.WriteLine($" new keyword -  child is hiding parent's method {FirstName}  {LastName} fulltime");
        }

    }

    public class TempEmployee : Employee
    {
        public override void PrintFullName()
        {
            Console.WriteLine($" new keyword -  child is hiding parent's method {FirstName}  {LastName} temp");
        }
    }


    public class TestProctedInternal
    {
        // protected internal type member can be accessed from another derived containing assembly
        protected internal int protectedInternal = 1;

        // internal access modifier can only be access with in containing assembly
        internal int onlyInternal = 2;


    }



}
