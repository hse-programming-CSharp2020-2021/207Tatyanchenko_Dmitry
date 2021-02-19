using System;

namespace Action_Function_Predicate_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int, int> op = Add;
            op(3, 5);
            op -= Add;
            op += Sub;
            op(3, 5);

            Predicate<int> pr = IsEven;
            Console.WriteLine(pr(3));
            pr += MultipleOf3;
            Console.WriteLine(pr(3));

            Func<int, int> f1 = x => 2 * x;
            Console.WriteLine(f1(1));
        }
        static void Add(int x1, int x2) => Console.WriteLine(x1 + x2);
        static void Sub(int x1, int x2) => Console.WriteLine(x1 - x2);

        static bool IsEven(int x) => x % 2 == 0;
        static bool MultipleOf3(int x) => x % 3 == 0;

    }
}
