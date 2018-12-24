using System;
using System.Text;

namespace Animals.Animals
{
    public abstract class Animal
    {
        private string name;
        private int? age;
        private string gender;

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                name = value;
            }
        }
        public int? Age
        {
            get
            {
                return age;
            }
            private set
            {
                if (value <= 0 || value == null)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }
        public virtual string Gender
        {
            get
            {
                return gender;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;

            }
        }

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public virtual string ProduceSound()
        {
            return "Produce Sound";
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{this.GetType().Name}");
            stringBuilder.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            stringBuilder.AppendLine($"{this.ProduceSound()}");
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
