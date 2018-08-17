using System;
using System.Collections.Generic;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { Id = 1, Name = "John", Grade = 7, Credits = 5 });
            students.Add(new Student() { Id = 2, Name = "Jelly", Grade = 9, Credits = 45 });
            students.Add(new Student() { Id = 3, Name = "Jannie", Grade = 7, Credits = 25 });
            students.Add(new Student() { Id = 4, Name = "Jolly", Grade = 8, Credits = 15 });



            IsPromotable delegatePromotable = new IsPromotable(Condition);
            Student.PromoteStudent(students, delegatePromotable);

            // CAN BE REDUCED INTO 1 LINE USING LAMPDA
            //Student.PromoteStudent(students, s=>s.Grade > 8);

            Console.ReadKey();

        }


        //////////THE CONDITION IS DYNAMICALLY PASSED IN NOT HARD CODED//////////////
        static bool Condition(Student student)
        {
            return student.Grade > 8 ? true : false;
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
}
