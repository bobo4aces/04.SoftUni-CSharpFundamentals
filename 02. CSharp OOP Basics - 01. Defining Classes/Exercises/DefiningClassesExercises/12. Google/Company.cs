using System;

namespace Google
{
    public class Company
    {
        public string CompanyName { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public Company()
        {

        }
        public Company(string companyName, string department, decimal salary)
        {
            CompanyName = companyName;
            Department = department;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{CompanyName} {Department} {Salary:f2}";
        }
    }
}
