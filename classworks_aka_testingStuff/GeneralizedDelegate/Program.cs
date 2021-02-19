using System;

namespace GeneralizedDelegate
{
    class Person
    {
        public string Name { get; set; }
        public virtual void Display()
        => Console.WriteLine($"Person {Name}");
    }
    class Client : Person
    {
        public override void Display()
        => Console.WriteLine($"Client {Name}");
    }
    delegate T Builder<out T>(string name);

    delegate void GetInfo<in T>(T item);

    class Program
    {
        static Client GetClient(string name) => new Client() { Name = name };

        private static void PersonInfo(Person p) => p.Display();

        static void Main(string[] args)
        {
            Builder<Person> b1 = GetClient;

            Person p1 = b1("Bob");
            p1.Display();

            GetInfo<Client> clientInfo = PersonInfo;

            clientInfo(new Client() { Name = "Carl" });
            
        }
    }
}
