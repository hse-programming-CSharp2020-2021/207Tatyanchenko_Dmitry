using System;
using System.Linq;
using System.Collections.Generic;

namespace ElectronicQueue
{
    struct Person
    {
        int Age { get; set; }
        string Name { get; set; }
        string Surname { get; set; }

        public Person(int age, string name, string surname)
        {
            this.Age = age;
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Age: {Age}.";
        }
    }

    class ElectronicQueue
    {
        public Queue<Person> elq = new Queue<Person>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            ElectronicQueue elq = new ElectronicQueue();
            Console.WriteLine("enqueueing:");
            for (int i = 0; i < 5; i++)
            {
                Person p = new Person(rnd.Next(0, 25), rnd.Next(0, 25).ToString(), rnd.Next(0, 25).ToString());
                elq.elq.Enqueue(p);
                Console.WriteLine(p);
            }
            Console.WriteLine("dequeueing:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(elq.elq.Dequeue());
            }
        }
    }
}
