using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index;

        public ListyIterator(params T[] list)
        {
            this.list = list.ToList();
            this.index = 0;
        }

        public bool Move()
        {
            if (!this.IsInRange())
            {
                return false;
            }
            this.index++;

            return true;
        }

        public bool HasNext()
        {
            return this.IsInRange();
        }

        public void Print()
        {
            this.IsEmpty();
            Console.WriteLine(this.list[this.index]);
        }

        private void IsEmpty()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }

        private bool IsInRange()
        {
            if (this.index + 1 == this.list.Count)
            {
                return false;
            }
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            this.IsEmpty();

            for (int i = 0; i < this.list.Count; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            this.IsEmpty();
            return this.GetEnumerator();
        }
    }
}
