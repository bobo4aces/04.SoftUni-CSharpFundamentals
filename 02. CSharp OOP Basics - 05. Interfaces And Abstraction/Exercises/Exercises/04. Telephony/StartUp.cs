using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main()
        {
            string[] phoneNumbers = Console.ReadLine()
                                            .Split(" ")
                                            .ToArray();
            string[] sites = Console.ReadLine()
                                            .Split(" ")
                                            .ToArray();

            foreach (var phoneNumber in phoneNumbers)
            {
                Smartphone smartphone = new Smartphone();

                try
                {
                    smartphone.Phone = phoneNumber;
                    Console.WriteLine(smartphone.Calling(phoneNumber));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            foreach (var site in sites)
            {
                Smartphone smartphone = new Smartphone();

                try
                {
                    smartphone.Site = site;
                    Console.WriteLine(smartphone.Browsing(site));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
