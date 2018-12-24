using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public virtual string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }
            private set
            {
                if (value.Length < 5 || 10 < value.Length)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                if (!Regex.IsMatch(value, @"^[A-Za-z0-9]+$"))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNumber = value;
            }
        }

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            FacultyNumber = facultyNumber;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine($"Faculty number: {this.FacultyNumber}");
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
