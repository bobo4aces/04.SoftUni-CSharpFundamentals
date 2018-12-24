using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    class StartUp
    {
        static void Main()
        {
            int employeeCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<Employee>> employees = new Dictionary<string, List<Employee>>();

            for (int i = 0; i < employeeCount; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (info.Length == 4)
                {
                    Employee employee = new Employee(
                    info[0],
                    decimal.Parse(info[1]),
                    info[2],
                    info[3]);

                    AddToEmployees(employees, employee);
                }
                else if (info.Length == 5)
                {

                    if (info[4].Contains("@"))
                    {
                        Employee employee = new Employee(
                        info[0],
                        decimal.Parse(info[1]),
                        info[2],
                        info[3],
                        info[4]);

                        AddToEmployees(employees, employee);
                    }
                    else
                    {
                        Employee employee = new Employee(
                        info[0],
                        decimal.Parse(info[1]),
                        info[2],
                        info[3],
                        int.Parse(info[4]));

                        AddToEmployees(employees, employee);
                    }
                    
                }
                else
                {
                    Employee employee = new Employee(
                        info[0],
                        decimal.Parse(info[1]),
                        info[2],
                        info[3],
                        info[4],
                        int.Parse(info[5]));

                    AddToEmployees(employees, employee);
                }

            }

            string highestAverageSalaryDepartment = GetHighestAverageSalaryDepartment(employees);

            Console.WriteLine($"Highest Average Salary: {highestAverageSalaryDepartment}");

            foreach (var employee in employees[highestAverageSalaryDepartment].OrderByDescending(s => s.Salary))
            {
                Console.WriteLine(employee.ToString());
            }
        }

        private static string GetHighestAverageSalaryDepartment(Dictionary<string, List<Employee>> employees)
        {
            decimal highestAverageSalary = decimal.MinValue;
            string highestAverageSalaryDepartment = string.Empty;

            foreach (var department in employees)
            {
                decimal currentSalary = 0;
                int totalEmployees = department.Value.Count();
                foreach (var employee in department.Value)
                {
                    currentSalary += employee.Salary;
                }
                if (Decimal.Compare(highestAverageSalary,currentSalary / totalEmployees) == -1)
                {
                    highestAverageSalary = currentSalary / totalEmployees;
                    highestAverageSalaryDepartment = department.Key;
                }
            }

            return highestAverageSalaryDepartment;
        }

        private static void AddToEmployees(Dictionary<string, List<Employee>> employees, Employee employee)
        {
            if (!employees.ContainsKey(employee.Department))
            {
                employees.Add(employee.Department, new List<Employee>());
            }
            employees[employee.Department].Add(employee);
        }
    }
}
