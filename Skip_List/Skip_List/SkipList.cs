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
        private Random gen = new Random();

        public SkipList()
        {
            Count = 0;
            head = new Node(1, default(T));
        }

        public int ChooseRandomHeight(int max)
        {
            int height = 1;
            while (gen.Next(0, 2) == 0 && height < max)
            {
                height++;
            }
            return height;
        }

        public void Add(T item)
        {
            Count++;
            Node temp = new Node(ChooseRandomHeight(head.Height + 1), item);

            if (temp.Height > head.Height)
            {
                head.Skips.Add(null);
            }

            int level = head.Height - 1;
            Node curr = head;
            while (level >= 0)
            {
                if (curr.Skips[level] == null || item.CompareTo(curr.Skips[level].Value) < 0)
                {
                    //if we can link the new node at this level
                    //link the new node in
                    if (temp.Height > level)
                    {
                        //linking in
                        temp.Skips[level] = curr.Skips[level];
                        curr.Skips[level] = temp;
                    }
                    //move down
                    level--;

                }
                else
                {
                    //move right
                    curr = curr.Skips[level];
                }
            }
        }

        public bool Remove(T item)
        {
            int level = head.Height - 1;
            Node curr = head;
            bool found = false;
            while (level >= 0)
            {
                if (curr.Skips[level] == null || item.CompareTo(curr.Skips[level].Value) <= 0)
                {
                    if (curr.Skips[level] != null && item.CompareTo(curr.Skips[level].Value) == 0)
                    {
                        found = true;
                        curr.Skips[level] = curr.Skips[level].Skips[level];
                    }
                    level--;
                }
                else
                {
                    curr = curr.Skips[level];
                }

            }
            if (found)
            {
                Count--;
            }
            return found;
        }

        public void Clear()
        {
            head.Skips = new List<Node>();
        }

        public bool Contains(T item)
        {
            Node curr = head;
            int level = head.Height - 1;
            while (level >= 0)
            {
                int comp = item.CompareTo(curr.Skips[level].Value);
                if (curr.Skips[level] == null || comp < 0)
                {
                    if (comp > 0)
                    {
                        level--;
                    }
                    if (comp < 0)
                    {
                        curr = curr.Skips[level];
                    }
                    if (comp == 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {

            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node curr = head;
            while (curr.Skips[0] != null)
            {
                yield return curr.Skips[0].Value;
                curr = curr.Skips[0];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



    }
}
