using System;
using System.Collections.Generic;

namespace List
{
    class Program
    {
        static List<Employee> list = new List<Employee>();

        static List<int> listInt = new List<int>() { 1, 112, 3, 45, 3, 4, 6, 76, 7, 8, 65, 33 };
        static List<string> listString = new List<string>() { "a", "o", "l", "k", "j", "h", "f", "d", "e", "t" };

        static void Main(string[] args)
        {
            Employee e1 = new Employee() { Id = 1, Name = "John", Salary = 1000 };
            Employee e2 = new Employee() { Id = 2, Name = "Jane", Salary = 21000 };
            Employee e3 = new Employee() { Id = 3, Name = "Jully", Salary = 31000 };
            Employee e4 = new Employee() { Id = 4, Name = "Frank", Salary = 231000 };
            Employee e5 = new Employee() { Id = 5, Name = "Dave", Salary = 131000 };


            list.Add(e1);
            list.Add(e2);
            list.Add(e3);
            list.Add(e4);
            list.Add(e5);


            /////////Contains///////////////////////////
            Console.WriteLine(list.Contains(e3) ? "Customer3 exists in the list" :
                " customer 3 does not exist in the list");

            ///////////////Exists/////////////////////////////////
            Console.WriteLine(list.Exists(e => e.Salary > 9000) ?
                "There is more one than 1 employee with salary > 9000"
                : "There is none  employee with salary > 9000");

            /////////////Find///////////////////////////////////
            Employee emp = list.Find(em => em.Name.EndsWith("y"));
            Console.Write($" employee with y at the end:  {emp.Name}");


            ////////////////FindAll////////////////////////////////
            List<Employee> empList = list.FindAll(empl => empl.Salary > 2000);
            foreach (var em in empList)
            {
                Console.WriteLine($" employee:  {emp.Name}");
            }





            PrintList("Before sorting");
            listInt.Sort();
            listString.Sort();
            PrintList("After sorting");


            listInt.Reverse();
            listString.Reverse();
            PrintList("After reverse");


            /////implement IComparer - sort by name////
            SortByName sbn = new SortByName();
            list.Sort(sbn);
            Console.WriteLine();
            foreach (var em in list)
            {
                Console.Write($" {em.Name} ");
            }




            //// sort by id////
            Console.WriteLine();

            Comparison<Employee> employeeComparer = new Comparison<Employee>(CompareEmployee);
            list.Sort(employeeComparer);

            // use delegate for sorting
            list.Sort(delegate (Employee x, Employee y) { return x.Id.CompareTo(y.Id); });

            // use lambda for sorting, the best way
            list.Sort((x, y) => x.Id.CompareTo(y.Id));


            Console.ReadKey();
        }

        public static int CompareEmployee(Employee x, Employee y)
        {
            return x.Id.CompareTo(y.Id);
        }



        public static void PrintList(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            foreach (int item in listInt)
            {
                Console.Write(+item + " ");
            }
            Console.WriteLine();
            foreach (string item in listString)
            {
                Console.Write($"  {item} ");
            }
            Console.WriteLine();
            foreach (Employee em in list)
            {
                Console.Write($"  {em.Salary} ");
            }
            Console.WriteLine();
        }



    }

    public class Employee : IComparable<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }


        /// <summary>
        /// /Compare on salary by default
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Employee other)
        {
            return this.Salary.CompareTo(other.Salary);
        }
    }

    public class SortByName : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return String.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }
}
