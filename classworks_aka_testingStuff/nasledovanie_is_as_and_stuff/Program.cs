using System;

namespace nasledovanie_is_as_and_stuff
{
    class Base
    {
        public int x;
        public Base(int x) { Console.WriteLine(1); this.x = x; }

        public virtual void print()
        {
            Console.WriteLine(1);
        }
    }

    class Child : Base
    {
        public Child(int x) : base(x) { Console.WriteLine(2); }
        public sealed override void print()
        {
            Console.WriteLine(2);
        }
    }
    //class Child2 : Child
    //{
    //    public override void print()
    //    {
    //        Console.WriteLine(3);
    //    }
    //}

    //sealed class Child1 : Base
    //{
    //    public override void print()
    //    {
    //        Console.WriteLine(3);
    //    }
    //}

    //class Child3 : Child1
    //{
    //    public override void print()
    //    {
    //        Console.WriteLine(3);
    //    }
    //}
    delegate Base Test(int x);
    delegate int Test1(Child c);
     class Program
    {
        static int GetX(Base b)
        {
            return b.x;
        }

        static void Main(string[] args)
        {
            Test t1 = x => new Child(x);
            t1(5);
            Test1 t = GetX;
            Console.WriteLine(t(new Child(3)));
            //Base b = new Base(3);
            //Child c = b as Child;
            //Console.WriteLine(b is Base);
            //Child c1 = new Child(3);
            //Console.WriteLine(c1.x);
        }
    }
}
