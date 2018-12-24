using System;

namespace Ferrari
{
    public class StartUp
    {
        static void Main()
        {
            string driversName = Console.ReadLine();
            Ferrari ferrari = new Ferrari(driversName);
            Console.WriteLine(ferrari);
        }
    }
}
