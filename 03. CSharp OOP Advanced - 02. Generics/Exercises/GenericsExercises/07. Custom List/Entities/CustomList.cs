using _07._Custom_List.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._Custom_List.Entities
{
    public class CustomList<T> : ICustomList<T> where T: IComparable<T>
    {
        private List<T> list;

        public CustomList()
        {
            list = new List<T>();
        }

        public void Add(T element)
        {
            list.Add(element);
        }

        public bool Contains(T element)
        {
            return list.Contains(element);
        }

        public int CountGreaterThan(T element)
        {
            int count = list.Where(e => e.CompareTo(element) > 0).Count();
            return count;
        }

        public T Max()
        {
            return list.Max();
        }

        public T Min()
        {
            return list.Min();
        }

        public T Remove(int index)
        {
            T removedElement = list.ElementAt(index);
            list.RemoveAt(index);
            return removedElement;
        }

        public void Swap(int index1, int index2)
        {
            T oldElement = list[index1];
            list[index1] = list[index2];
            list[index2] = oldElement;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var element in this.list)
            {
                stringBuilder.AppendLine($"{element}");
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
