using System;

namespace testing_stuff_new
{
    class Person
    {
        protected string FullName { get; set; }
        protected DateTime DateOfBirth { get; set; }
        protected bool IsMale { get; set; }

        public Person(string FullName, DateTime DateOfBirth, bool IsMale)
        {
            this.FullName = FullName;
            this.DateOfBirth = DateOfBirth;
            this.IsMale = IsMale;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"FullName:{FullName} DateOfBirth:{DateOfBirth} IsMale:{IsMale}");
        }

    }

    class Student : Person
    {
        string Institution { get; set; }
        string Speciality { get; set; }

        public Student(string FullName, DateTime DateOfBirth, bool IsMale, string Institution, string Speciality) : base(FullName, DateOfBirth, IsMale)
        {
            this.Speciality = Speciality;
            this.Institution = Institution;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"FullName:{FullName} DateOfBirth:{DateOfBirth} IsMale:{IsMale}  Institution:{Institution} Speciality:{Speciality}");
        }
    }

    class Employee : Person
    {
        string CompanyName { get; set; }
        string Post { get; set; }
        string Schedule { get; set; }
        decimal Salary { get; set; }

        public Employee(string FullName, DateTime DateOfBirth, bool IsMale,
                        string companyName, string post,string schedule, decimal salary) : base(FullName, DateOfBirth, IsMale)
        {
            CompanyName = companyName;
            Post = post;
            Schedule = schedule;
            Salary = salary;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"FullName:{FullName} DateOfBirth:{DateOfBirth} IsMale:{IsMale} " +
                              $"CompanyName:{CompanyName} Post:{Post} Schedule:{Schedule} " +
                              $"Salary:{Salary}$");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Person[] arr = new Person[3];
            arr[0] = new Person("asd", DateTime.Parse("01.01.2222"), true);
            arr[1] = new Student("asd1", DateTime.Parse("02.01.2222"), false, "Novosib", "Vodoprovodchik");
            arr[2] = new Employee("asd2", DateTime.Parse("01.01.-1234"), true, "RPC.inc", "TopManager","0 days a year",1123123123123.1234m);

            foreach (Person i in arr) i.ShowInfo();
        }
    }
}
