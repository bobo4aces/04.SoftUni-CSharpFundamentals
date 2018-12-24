using System;

namespace Person
{
    public class Child : Person
    {
        public override int Age
        {
            get => base.Age;
            set
            {
                if (15 < value)
                {
                    throw new ArgumentException("Child's age must be less than 15!");
                }
                base.Age = value;
            }
        }

        public Child(string name, int age) : base(name, age)
        {
        }
    }
}
