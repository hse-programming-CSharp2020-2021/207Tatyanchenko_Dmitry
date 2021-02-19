using System;
using System.Collections.Generic;
using System.Linq;

namespace Enclosure
{
    class Program
    {
        static Action CreateAction()
        {
            int count = 0;
            Action action = () =>
            {
                count++;
                Console.WriteLine(count);
            };
            return action;
        }

        static List<Action> GetListOfActions()
        {
            List<Action> list = new List<Action>();
            for (int i = 0; i < 3; i++)
            {
                int temp = i;
                list.Add(() => Console.WriteLine(temp));
            }
            //foreach(int i in Enumerable.Range(0, 3))
            //{
            //    list.Add(() => Console.WriteLine(i));
            //}
            return list;
        }
        static void Main(string[] args)
        {
            //var action = CreateAction();
            //action();
            //action();
            //var action1 = CreateAction();
            //action1();
            var ActionList = GetListOfActions();
            foreach (var action in ActionList) action();
            //for (int i = 0; i < ActionList.Count; i++) ActionList[i]();
        }

    }
}
