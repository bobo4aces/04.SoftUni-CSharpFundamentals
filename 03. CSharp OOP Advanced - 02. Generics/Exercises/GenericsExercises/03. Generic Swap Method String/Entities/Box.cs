using System;
using System.Collections.Generic;

namespace _03._Generic_Swap_Method_String.Entities
{
    public class Box<T>
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
    }
}
