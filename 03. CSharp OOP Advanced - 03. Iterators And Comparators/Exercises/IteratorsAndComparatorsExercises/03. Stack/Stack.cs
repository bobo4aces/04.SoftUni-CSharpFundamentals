using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> list;

        public Stack()
        {
            this.list = new List<T>();
        }

        public void Push(params T[] element)
        {
            foreach (var item in element)
            {
                this.list.Add(item);
            }
            
        }

        public void Pop()
        {
            if (this.list.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            this.list.RemoveAt(this.list.Count - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.list.Count - 1; i >= 0; i--)
            {
                yield return this.list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
