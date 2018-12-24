using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._ListyIterator
{
    public class ListyIterator<T>
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
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.list[this.index]);
        }

        private bool IsInRange()
        {
            if (index + 1 == list.Count)
            {
                return false;
            }
            return true;
        }

    }
}
