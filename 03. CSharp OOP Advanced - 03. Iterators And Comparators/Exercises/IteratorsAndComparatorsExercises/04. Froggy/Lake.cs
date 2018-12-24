using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04._Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> lake;

        public Lake(int[] numbers)
        {
            this.lake = new List<int>(numbers);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < lake.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return lake[i];
                }
            }
            for (int i = lake.Count - 1; i >= 0; i--)
            {
                if (i % 2 == 1)
                {
                    yield return lake[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
