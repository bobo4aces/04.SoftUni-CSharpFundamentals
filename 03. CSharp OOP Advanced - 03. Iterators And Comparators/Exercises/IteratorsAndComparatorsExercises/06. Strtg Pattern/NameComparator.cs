using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Strtg_Pattern
{
    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            int result = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);
            if (result == 0)
            {
                char firstPersonLetter = firstPerson.Name.ToLower()[0];
                char secondPersonLetter = secondPerson.Name.ToLower()[0];

                return firstPersonLetter.CompareTo(secondPersonLetter);
            }
            return result;
        }
    }
}
