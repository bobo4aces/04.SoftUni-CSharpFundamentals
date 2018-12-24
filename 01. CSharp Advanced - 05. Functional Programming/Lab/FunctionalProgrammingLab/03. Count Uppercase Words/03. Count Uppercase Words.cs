using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(String.Join(Environment.NewLine, Console.ReadLine()
            //    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
            //    .Where(w=>Char.IsUpper(w[0]))));

            Func<string, bool> isUpper = w => Char.IsUpper(w[0]);
            Console.WriteLine(String.Join(Environment.NewLine, Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(isUpper)));
        }
    }
}
