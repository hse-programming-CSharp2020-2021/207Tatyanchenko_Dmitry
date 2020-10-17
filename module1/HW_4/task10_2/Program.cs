using System;
using System.Text;


namespace task10_1
{
    class MainClass
    {
        public static double Sr()
        {
            double Sr = 0;
            int i = 0;
            while (true)
            {
                int k;
                string inp = Console.ReadLine();
                if (int.TryParse(inp, out k))
                {
                    if (k < 0) { Sr = (double)(Sr * i + k) / (i + 1); i++; }

                }
                else if (inp == "q") break;
                else { Console.Write("err"); }
            }
            return Sr;
        }
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(Sr());
        }
    }
}
