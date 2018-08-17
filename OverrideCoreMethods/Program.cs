using System;

namespace OverrideCoreMethods
{
    class Program
    {
        static void Main(string[] args)
        {


            int number = 11;
            Console.WriteLine(number.ToString());



            Customer c1 = new Customer();

            c1.Firstname = "frankie";
            c1.Lastname = "nguyen";

            Customer c2 = new Customer();

            c2.Firstname = "frankie";
            c2.Lastname = "nguyen";

            Customer c3 = c2;


            Console.WriteLine(" Tostring :" + c1.ToString());

            Console.WriteLine($" c1 equals c2 ?: {c1.Equals(c2)}");//true
            Console.WriteLine($" c2 equals c3 ?: {c2.Equals(c3)}");//true
            Console.WriteLine($" c2 == c3 ?: {c2 == c3}");//true
            Console.WriteLine($" # {c2.GetHashCode()}");//true
            Console.ReadKey();

        }
    }


    public class Customer
    {

        public string Firstname { get; set; }
        public string Lastname { get; set; }



        public override string ToString()
        {
            return this.Firstname + "  " + this.Lastname;
        }

        public override bool Equals(object obj)
        {

            if (obj == null) return false;

            if (!(obj is Customer)) return false;

            return this.Firstname == ((Customer)obj).Firstname && this.Lastname == ((Customer)obj).Lastname;



        }

        public override int GetHashCode()
        {
            var hashCode = this.Firstname.GetHashCode() ^ this.Lastname.GetHashCode();
            Console.WriteLine($" Hash code = {hashCode}");
            return hashCode;
        }
    }
}
