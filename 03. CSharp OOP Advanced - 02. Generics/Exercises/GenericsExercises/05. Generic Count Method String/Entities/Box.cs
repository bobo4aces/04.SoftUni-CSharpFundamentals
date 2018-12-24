using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Generic_Count_Method_String.Entities
{
    public class Box<T> where T : IComparable<T>
    {
        public T Value { get; set; }

        public Box(T value)
        {
            this.Value = value;
        }

        public static IList<Box<T>> Swap(IList<Box<T>> list,int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= list.Count ||
                secondIndex < 0 || secondIndex >= list.Count)
            {
                throw new ArgumentException("Invalid Indexes");
            }
            Box<T> oldValue = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = oldValue;

            return list;
        }
        public override string ToString()
        {
            return $"{this.Value.GetType()}: {this.Value}";
        }

        public static int GetGreaterElementsCount(IList<Box<T>> list, Box<T> element)
        {
            int count = list
                        .Where(e => e.Value.CompareTo(element.Value) > 0)
                        .Count();
            return count;
        }
    }
}
