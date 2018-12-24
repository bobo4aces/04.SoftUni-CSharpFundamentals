using System;

namespace DateModify
{
    public class StartUp
    {
        static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier(firstDate, secondDate);

            Console.WriteLine(dateModifier.GetDifference(dateModifier.FromDate,dateModifier.ToDate));
        }
    }
}
