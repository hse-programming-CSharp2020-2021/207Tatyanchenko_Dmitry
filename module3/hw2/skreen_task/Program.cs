using System;
using class_library_screen;

namespace skreen_task
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            VetoCommision commision = new VetoCommision();
            VetoVoter[] voters = new VetoVoter[5];

            for (int i = 0; i < 5; i++)
            {
                voters[i] = new VetoVoter(rnd.Next().ToString());
                commision.OnVote += voters[i].VetoHandler;
            }

            Console.WriteLine(commision.Vote(rnd.Next().ToString()).ToString());
        }
    }
}
