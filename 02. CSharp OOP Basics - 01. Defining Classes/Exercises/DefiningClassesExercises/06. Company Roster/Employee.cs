using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyRoster
{
    class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public Employee()
        {
            this.Email = "n/a";
            this.Age = -1;
        }

        public Employee(string name, decimal salary, string position, string department) : this()
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
        }

        public Employee(string name, decimal salary, string position, string department, string email) : this()
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = email;
        }

        public Employee(string name, decimal salary, string position, string department, int age) : this()
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Age = age;
        }

        public Employee(string name, decimal salary, string position, string department, string email, int age)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = email;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Salary:f2} {this.Email} {this.Age}";
        }
    }
}
