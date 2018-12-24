using P03.Detail_Printer.Contacts;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Employee employee = new Employee("Pesho");
            List<string> documents = new List<string>();
            documents.Add("Document 1");
            documents.Add("Document 2");
            documents.Add("Document 3");
            Employee manager = new Manager("Gosho", documents);
            List<Employee> employees = new List<Employee>();
            employees.Add(employee);
            employees.Add(manager);
            DetailsPrinter detailsPrinter = new DetailsPrinter(employees);
            detailsPrinter.PrintDetails();
        }
    }
}
