using System;
using System.Reflection;

namespace LateBindingReflection
{
    class Program
    {
        static void Main(string[] args)
        {

            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            Type customerType = executingAssembly.GetType("LateBindingReflection.Customer");

            object customerInstance = Activator.CreateInstance(customerType);

            MethodInfo getFullNameMethod = customerType.GetMethod("GetFullName");

            string[] parameters = new[] { "frankie", "nguyen" };

            string fullName = (string)getFullNameMethod.Invoke(customerInstance, parameters);

            Console.WriteLine($"my fullname : {fullName}");
            Console.ReadKey();

            //Customer c1 = new Customer();
            //string fullName = c1.GetFullName("frank", "ng");
            //Console.WriteLine($"Full name = {fullName}");

        }
    }


    public class Customer
    {
        public string GetFullName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }
    }
}
