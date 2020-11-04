using System;

namespace task1
{
    class BirthdayClass
    {
        public string Name
        {
            get;
        }
        public DateTime Birthday
        {
            get;
        }
        public BirthdayClass()
        {
            Name = "The Internet";
            Birthday = DateTime.Parse("01.01.1970");
        }
        public BirthdayClass(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public int NextBD()
        { 
        int current = DateTime.Today.DayOfYear;
            int birthday = Birthday.DayOfYear;
            if (birthday < current) return 366 - current + birthday;
            else return birthday - current;
        }
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter birthday date:");
            string date = Console.ReadLine();
            DateTime birthday = new DateTime();
            if (DateTime.TryParse(date, out birthday))
            {
                BirthdayClass bd = new BirthdayClass(name, birthday);
                Console.WriteLine($"Next {name}'s birthday is in {bd.NextBD()} days.");
            }
            else
            {
                Console.WriteLine("Error while parsing birthday date.");
            }
       
        }
    }
}
