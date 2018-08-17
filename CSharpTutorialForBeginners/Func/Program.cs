using System;
using System.Collections.Generic;
using System.Linq;

namespace Func
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee e1 = new Employee() { Id = 1, Name = "John", Salary = 1000 };
            Employee e2 = new Employee() { Id = 2, Name = "Jane", Salary = 21000 };
            Employee e3 = new Employee() { Id = 3, Name = "Jully", Salary = 31000 };
            Employee e4 = new Employee() { Id = 4, Name = "Frank", Salary = 231000 };
            Employee e5 = new Employee() { Id = 5, Name = "Dave", Salary = 131000 };



            Queue<Employee> queueEmployee = new Queue<Employee>();
            queueEmployee.Enqueue(e1);
            queueEmployee.Enqueue(e2);
            queueEmployee.Enqueue(e3);
            queueEmployee.Enqueue(e4);
            queueEmployee.Enqueue(e5);


            Func<Employee, string> selector = emp => "Name" + emp.Name;

            // func way
            IEnumerable<string> names = queueEmployee.Select(selector);

            //lambda way 
            IEnumerable<string> names1 = queueEmployee.Select(emp => "Name" + emp.Name);

        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }
}
