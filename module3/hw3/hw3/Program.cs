using System;

namespace LinkedList
{

    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node(int data)
        {
            Data = data;
        }
        public override string ToString()
        {
            return $"{Data}";
        }
    }

    class LinkedList
    {
        Node head;
        Node tail;

        public int Count { get; private set; }

        public void Add(int data)
        {
            Node node = new Node(data);
            if (head == null)
            {
                head = node;
                Count = 0;
            }
            else
            {
                tail.Next = node;
            }
            tail = node;
            Count++;
        }
        //public void AddFirst(int data)
        //{
        //    Node node = new Node(data);

        //    node.Next = head;
        //    head = node;

        //    if (Count == 0)
        //        tail = head;

        //    Count++;
        //}
        public void Clear()
        {
            Count = 0;
            head = null;
            tail = null;
        }
        public bool Contains(int data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data == data)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        public void Print()
        {
            Node current = head;
            int i = 1;
            while (current != null)
            {
                Console.WriteLine($"{i} - {current}");
                current = current.Next;
                i++;
            }
        }

        public Node Max()
        {
            Node max = new Node(int.MinValue);
            Node current = head;
            while (current != null)
            {
                if (current.Data > max.Data) max = current;
                current = current.Next;
            }
            if (max.Data == int.MinValue) return null;
            else return max;
        }

        public Node Min()
        {
            Node min = new Node(int.MaxValue);
            Node current = head;
            while (current != null)
            {
                if (current.Data < min.Data) min = current;
                current = current.Next;
            }
            if (min.Data == int.MaxValue) return null;
            else return min;
        }

        public Node Middle()
        {
            if (Count != 0)
            {
                int currentLevel = 0;
                Node current = head;
                while (currentLevel < Count / 2)
                {
                    current = current.Next;
                    currentLevel++;
                }

                return current;
            }
            else return null;
        }

        // true if item with required data was removed
        // false if wasnt
        public bool Remove(int data)
        {
            // 1 2 3 4 5 6 7 8 5, 5 -> 1 2 3 4 6 7 8 5
            // если список пуст, если список из 1 элемента, если удаляемый элемент стоит в середине, в конце, в начале
            if (Count == 0)
            {
                return false;
            }
            Node current = head;
            if (current.Data == data)
            {
                head = current.Next;
                return true;
            }
            while (current.Next != null)
            {
                if (current.Next.Data == data)
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }
            
            return false;
        }
    }

    class MainClass
    {
        public static void Main()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.Add(1);
            linkedList.Add(2);
            //linkedList.AddFirst(3);
            linkedList.Add(4);
            linkedList.Add(22);
            linkedList.Print();
            Console.WriteLine(linkedList.Middle());
            linkedList.Remove(1);
            linkedList.Print();

        }
    }
}

