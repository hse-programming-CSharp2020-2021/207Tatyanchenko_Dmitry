using System;
using System.Collections.Generic;
namespace delegates
{
    class Program
    {
        //delegate void Mdel(int x);
        //delegate void PrintDel(int[] digits);
        //delegate int[] GetDel(int x);

        //public static void Print(int[] digits)
        //{
        //    foreach (int i in digits) Console.Write($"{i} ");
        //}

        //public static int[] GetDigits(int x)
        //{
        //    string str = x.ToString();
        //    int[] digits = new int[str.Length];
        //    for (int i = 0; i < str.Length; i++) digits[i] = Convert.ToInt32(str[i].ToString());
        //    return digits;
        //}

        //public delegate int Cast(double x);

        //public delegate string SomeDelegate<T>(T a,int b);


        //public static void Test(Cast meth)
        //{
        //    Console.WriteLine(meth?.Invoke(5.6));
        //}

        //public delegate void Message();

        //public static void M1()
        //{
        //    Console.WriteLine("m1");
        //}

        //public static void M2()
        //{
        //    Console.WriteLine("m2");
        //}

        public delegate T DOut<out T>();
        public delegate C1 DIn<in T>(T c);

        public class C1
        {
            public virtual int GetClass()
            {
                return 1;
            }
        }
        public class C2 : C1
        {
            public override int GetClass()
            {
                return 2;
            }
        }

        public static C1 GetC1(C1 c) { return c; }
        public static C2 GetC2() { return new C2(); }

        static void Main(string[] args)
        {
            //DOut<C1> d = GetC2; // Ковариативность
            //Console.WriteLine(d().GetClass());


            //DIn<C2> d1 = GetC1;
            C2 c = new C2();
            //Console.WriteLine(d1(c).GetClass());

            Console.WriteLine((c).GetClass());

            //static string M1<T,K>(T a,string b) {
            //    return a.ToString() + b.ToString() ;
            //}
            //SomeDelegate<string> sd = M1;
            //Console.Write(sd("3",6.9));
            //Message msg = M1;
            //msg += M2;
            //int i = Sum();
            //Cast delegate1 = delegate (double x) { return (int)Math.Round(x, MidpointRounding.ToEven); };
            //Cast delegate2 = delegate (double x) { return (int)Math.Log10(x) + 1; };
            //Cast lambda1 = x => (int)Math.Round(x, MidpointRounding.ToEven);
            //Cast lambda2 = (double x) => (int)Math.Log10(x) + 1;
            //Cast Multicast = lambda1 + lambda2;
            //List<Cast> list = new List<Cast>() {delegate1,delegate2,lambda1,lambda2,Multicast };
            //Console.WriteLine(msg.Method);
            //foreach (Cast meth in list) Test(meth);

            //GetDel get = GetDigits;
            //PrintDel print = Print;

            //print(get(678268));

            //Console.WriteLine();

            //Console.WriteLine(print.Method);
            //Console.WriteLine(print.Target);
            //Console.WriteLine(get.Method);
            //Console.WriteLine(get.Target);

            //Mdel Ndel = SomeMeth;
            //Ndel += OtherMeth;
            //Ndel(2222);
            //Ndel += SomeMeth;
            //Ndel(2);
            //Ndel -= SomeMeth;
            //Ndel -= OtherMeth;

            //Ndel?.Invoke(5);
        }
        //static void OtherMeth(int x)
        //{
        //Console.WriteLine(x);
        //}
        //static void SomeMeth(int x)
        //{
        //Console.WriteLine( 5);
        //}
    }
}
