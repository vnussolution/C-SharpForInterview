using System;

namespace AbstractClass
{
    class Program
    {
        static void Main(string[] args)
        {

            SavingCustomer sc = new SavingCustomer();
            Console.WriteLine($"ID= {sc.ID}");

            CorpCustomer cc = new CorpCustomer();
            Console.WriteLine($"ID= {cc.ID}");

            Console.ReadKey();

        }

    }

    public abstract class Customer
    {

        private Guid _id;

        public Guid ID
        {
            get { return this._id; }
        }

        // abstract class can have constructor
        protected Customer()
        {
            // child class will call this automatically
            // call abstract class
            Print();
            Console.WriteLine("calling from abstract class");

            this._id = Guid.NewGuid();
        }

        public abstract void Print();

        public virtual void VirtualMethod()
        {
            Console.WriteLine($" base class virtual method");
        }
    }

    class SavingCustomer : Customer
    {
        public override void Print()
        {
            Console.WriteLine($" calling Print() from SavingCustomer ");
        }
    }

    class CorpCustomer : Customer, ICustomer
    {
        public override void Print()
        {
            Console.WriteLine($" calling Print() from Corp Customer ");
        }

        public void SayHello()
        {
            Console.WriteLine($" hello there..");
        }

        public override void VirtualMethod()
        {
            Console.WriteLine($" override abstract class virtual method");
        }
    }


    interface ICustomer
    {
        void SayHello();
    }
}
