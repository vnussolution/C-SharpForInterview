using System;
using System.Collections.Generic;

namespace GenericQueueStack
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


            // QUEUE = FIFO
            //dequeue is to remove the first item in the list 
            Employee deque = queueEmployee.Dequeue();

            Console.WriteLine($"dequeue item = {deque.Id} , total = {queueEmployee.Count}");

            Employee peekqueue = queueEmployee.Peek();
            Console.WriteLine($"peek queue =  {peekqueue.Id} ");




            //STACK = LIFO
            Stack<Employee> stackEmployee = new Stack<Employee>();
            stackEmployee.Push(e1);
            stackEmployee.Push(e2);
            stackEmployee.Push(e3);
            stackEmployee.Push(e4);
            stackEmployee.Push(e5);


            // POP is to remove from stack
            Employee popEmp = stackEmployee.Pop();

            Console.WriteLine($"POP from the stack {popEmp.Id} - total employee = {stackEmployee.Count}");

            //
            Employee peekStack = stackEmployee.Peek();

            Console.WriteLine($"POP from the stack {peekStack.Id} - total employee = {stackEmployee.Count}");



            Console.ReadKey();
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }
}
