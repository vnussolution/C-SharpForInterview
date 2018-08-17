namespace WhyAbstractClass
{
    class Program
    {
        static void Main(string[] args)
        {


            //abstract prevents you from create an instance 
            //abstract acts like interface by using abstract method stubs
            //abstract is a mix of interface and class


            FulltimeEmployee fte = new FulltimeEmployee() { Id = 1, AnnualSalary = 90000, FirstName = "Truc", LastName = "Nguyen" };

            ContractEmployee ce = new ContractEmployee() { Id = 2, HourlyPay = 40, TotalHoursPerMonth = 60, LastName = "Ng", FirstName = "Frankie" };

        }
    }

    abstract class BaseEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string GetFullName()
        {

            return $"{FirstName} {LastName}";
        }

        public abstract int GetMonthlySalary();
    }


    class FulltimeEmployee : BaseEmployee
    {

        public int AnnualSalary { get; set; }

        public override int GetMonthlySalary()
        {
            return this.AnnualSalary / 12;
        }
    }

    class ContractEmployee : BaseEmployee
    {

        public int HourlyPay { get; set; }
        public int TotalHoursPerMonth { get; set; }


        public override int GetMonthlySalary()
        {
            return HourlyPay * TotalHoursPerMonth;
        }
    }

}
