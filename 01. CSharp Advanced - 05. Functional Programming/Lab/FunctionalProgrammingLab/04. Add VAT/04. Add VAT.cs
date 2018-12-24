using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVat = p => p * 1.2;
            Func<double, string> formatNumber = n => n.ToString("0.00");
            Console.WriteLine(String.Join(Environment.NewLine, Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addVat)
                .Select(formatNumber)));
        }
    }
}
