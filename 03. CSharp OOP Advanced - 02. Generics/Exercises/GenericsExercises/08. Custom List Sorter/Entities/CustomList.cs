using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _08._Custom_List_Sorter.Entities
{
    public class CustomList<T> : ICustomList<T>, IEnumerable<T>
        where T: IComparable<T>
    {
        private T[] list;
        private uint capacity;

        public uint Size { get; private set; }

        public CustomList()
        {
            this.list = new T[2];
            this.capacity = 2;
            this.Size = 0;
        }

        public T this[uint index]
        {
            get
            {
                if (index >= this.Size || index < 0)
                {
                    throw new IndexOutOfRangeException("Index was out of range!");
                }
                return this.list[index];
            }
            set
            {
                if (index >= this.Size || index < 0)
                {
                    throw new IndexOutOfRangeException("Index was out of range!");
                }
                this.list[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.capacity <= this.Size)
            {
                T[] newList = new T[this.capacity];
                this.list.CopyTo(newList, 0);
                Enlarge();
                this.list = new T[this.capacity];
                newList.CopyTo(this.list, 0);
            }
            this.list[this.Size++] = element;
        }

        private void Enlarge()
        {
            this.capacity *= 2;
        }

        public bool Contains(T element)
        {
            for (uint i = 0; i < this.Size; i++)
            {
                if (this.list[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public uint CountGreaterThan(T element)
        {
            uint count = 0;
            for (uint i = 0; i < this.Size; i++)
            {
                if (list[i].CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }

        public T Max()
        {
            T maxElement = list[0];
            for (uint i = 1; i < this.Size; i++)
            {
                if (list[i].CompareTo(maxElement) > 0)
                {
                    maxElement = list[i];
                }
            }
            return maxElement;
        }

        public T Min()
        {
            T minElement = list[0];
            for (uint i = 0; i < this.Size; i++)
            {
                if (list[i].CompareTo(minElement) < 0)
                {
                    minElement = list[i];
                }
            }
            return minElement;
        }

        public T Remove(uint index)
        {
            ValidateRange(index);
            T elementToRemove = list[index];
            T[] newList = new T[this.Size - 1];
            uint newListCounter = 0;
            for (uint i = 0; i < this.Size; i++)
            {
                if (i == index)
                {
                    continue;
                }
                newList[newListCounter++] = list[i];
            }
            this.list = new T[this.capacity];
            newList.CopyTo(this.list, 0);
            this.Size--;
            //if (this.capacity <= this.Size / 3)
            //{
            //    Reduce();
            //}

            return elementToRemove;
        }

        private void ValidateRange(uint index)
        {
            if (index < 0 || index >= this.capacity)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
        }

        //private void Reduce()
        //{
        //    this.capacity /= 2;
        //
        //    T[] newList = new T[this.capacity];
        //    this.list.CopyTo(newList, 0);
        //    
        //    this.list = new T[this.capacity];
        //    newList.CopyTo(this.list, 0);
        //}

        public void Swap(uint index1, uint index2)
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

        public IEnumerator<T> GetEnumerator()
        {
            for (uint i = 0; i < this.Size; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (uint i = 0; i < this.Size; i++)
            {
                yield return list[i];
            }
        }
    }
}
