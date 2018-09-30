using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Skip_List
{
    public class SkipList<T> : ICollection<T> where T : IComparable
    {
        class Node
        {
            public T Value;
            public int Height => Skips.Count;
            public List<Node> Skips; //Array

            public Node(int height, T value)
            {
                this.Value = value;
                Skips = new List<Node>(height);
                for (int i = 0; i < height; i++)
                {
                    Skips.Add(null);
                }
            }

        }



        public int Count { get; private set; }

        public bool IsReadOnly => false;

        private Node head;

        public int ChooseRandomHeight(int max)
        {
            Random gen = new Random();
            int height = 1;

            int coin = gen.Next(0, 2); // 0 is head, 1 is tail
            while (coin == 0 && height < max)
            {
                height++;
                coin = gen.Next(0, 2);
            }
            return height;
        }

        public void Add(T item)
        {
            Node temp = new Node(ChooseRandomHeight(head.Height + 1), item);

            int level = head.Height - 1;
            Node curr = head;
            while (level >= 0)
            {
                if (curr.Skips[level] == null || item.CompareTo(curr.Skips[level].Value) > 0)
                {
                    //if we can link the new node at this level
                    //link the new node in

                    //move down
                }
                else
                {
                    //move right
                }
            }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }



    }
}
