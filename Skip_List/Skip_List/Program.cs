using System;

namespace Skip_List
{
    class Program
    {
        static void Main(string[] args)
        {
            SkipList<int> list = new SkipList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            foreach(int number in list)
            {
                Console.WriteLine(number);
            }
            list.Remove(1);
            list.Remove(2);
            list.Remove(3);
            list.Remove(4);
            list.Remove(5);
            //list.Remove(6);
            list.Remove(7);
            list.Remove(8);
            list.Remove(9);
            list.Remove(10);
            foreach (int number in list)
            {
                Console.WriteLine(number);
            }

            Console.ReadKey();
        }
    }
}
