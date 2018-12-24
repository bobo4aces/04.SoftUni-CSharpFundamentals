using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Strtg_Pattern
{
    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            return firstPerson.Age.CompareTo(secondPerson.Age);
        }
    }
}
