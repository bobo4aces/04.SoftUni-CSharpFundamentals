using System;
using System.Linq;

namespace ProblemDatabase
{
    public class Database
    {
        private const int capacity = 16;
        private int[] array;
        public int CurrentLength { get; private set; }

        public Database(params int[] numbers)
        {
            this.array = new int[capacity];
            this.SetArray(numbers);
        }

        private void SetArray(params int[] numbers)
        {
            numbers.CopyTo(this.array, 0);
            this.CurrentLength = numbers.Length;
        }

        public void Add(int number)
        {
            if (this.CurrentLength + 1 >= capacity)
            {
                throw new InvalidOperationException("The array must contains no more than 16 elements!");
            }
            this.array[this.CurrentLength++] = number;
        }

        public void Remove()
        {
            if (this.CurrentLength == 0)
            {
                throw new InvalidOperationException("The database is empty!");
            }
            this.array[this.CurrentLength--] = 0;
        }

        public int[] Fetch()
        {
            return this.array.Take(this.CurrentLength).ToArray();
        }
    }
}
