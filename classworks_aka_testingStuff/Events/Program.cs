using System;

namespace Events
{
    delegate void D1(object sender, EventArgs e);

    class SomeClass
    {
        
        private D1 _d1;
        public event D1 d1
        {
            add {
                _d1 += value;
                Console.WriteLine($"Metdod {value} added");
            }
            remove
            {
                _d1 -= value;
                Console.WriteLine($"Method {value} removed");
            }
        }
        
        public void EventInvoke()
        {
             _d1?.Invoke(this, new MyArgs("asd asd"));
            
        }
    }
    class MyArgs : EventArgs
    {
        public readonly string str;
        public MyArgs(string str)
        {
            this.str = str;
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            SomeClass sc = new SomeClass();

            sc.d1 += ShitHandler;
            sc.EventInvoke();
            sc.d1 -= ShitHandler;
            sc.EventInvoke();
        }
        static void ShitHandler(object sender, EventArgs e)
        {
            if (e != EventArgs.Empty)
            {
                Console.WriteLine((e as MyArgs).str);
            }
        }
    }
}
