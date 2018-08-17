using CSharpTutorialForBeginners;
using System;

namespace AccessModifiers
{
    class Program  // default for type is internal. It can only access anywhere with in containing assembly 
    {
        static void Main(string[] args)
        {
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        string Name;
        protected string Title;

        internal int Age; // can access anywhere with in the containing assembly

        protected internal int Account; // can access anywhere with in the containing assembly, and from within a derived class in any another assembly

        int computers; // Default for type member is private

    }

    public class GoldCustomer : Customer
    {
        public void PrintId()
        {
            Customer cus = new Customer();
            Console.WriteLine($" Id = {cus.Id}");
            //Console.WriteLine($" Name = {cus.Name}"); // Name is private
            //Console.WriteLine($" Name = {cus.Title}"); // Name is private

            GoldCustomer gc = new GoldCustomer();
            base.Title = "yesss";
            Console.WriteLine($" Title =   {gc.Title}"); // Derived class is ok to access protected


            base.Age = 1;  // internal can only access within an assembly scope  (dll/exe)

        }
    }

    public class TestProtectedInternalClass : TestProctedInternal
    {
        private int myNewInt = 1;

        TestProtectedInternalClass t = new TestProtectedInternalClass();

        public void myNewMethod()
        {
            // protected internal type member can be accessed from another derived containing assembly
            this.myNewInt = base.protectedInternal;
        }
    }
}


// type  means class
// type member means properties

// Default access modifier for type member is private
// Default access modifier for type  is internal