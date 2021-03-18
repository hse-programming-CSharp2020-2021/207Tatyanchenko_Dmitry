using System;
using System.Linq;

namespace ClassLibrary
{
    public class Street
    {
        public string Name { get; private set; }
        public int[] Houses { get; private set; }

        public Street(string name, int[] houses)
        {
            this.Name = name;
            this.Houses = houses;
        }

        public static int operator ~(Street st) => st.Houses.Length;
        public static bool operator -(Street st) => st.Houses.Count(x => x.ToString().ToCharArray().Contains('7')) > 0;

        public override string ToString()
        {
            string str = String.Join(' ', Houses.Select(x => x.ToString()).ToArray());
            return $"{Name} {str}";
        }
    }
}
