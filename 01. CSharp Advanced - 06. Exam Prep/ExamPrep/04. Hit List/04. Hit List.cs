using System;
using System.Collections.Generic;

namespace _04._Hit_List
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            var people = new Dictionary<string, SortedDictionary<string, string>>();

            while (input != "end transmissions")
            {
                string[] tokens = input.Split('=');
                string name = tokens[0];
                string[] kvps = tokens[1].Split(';');
                if (!people.ContainsKey(name))
                {
                    people.Add(name, new SortedDictionary<string, string>());
                }

                for (int i = 0; i < kvps.Length; i++)
                {
                    string[] kvp = kvps[i].Split(':');
                    string key = kvp[0];
                    string value = kvp[1];

                    if (!people[name].ContainsKey(key))
                    {
                        people[name].Add(key, value);
                    }
                    else
                    {
                        people[name][key] = value;
                    }
                }


                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            input = input.Remove(0, 5);

            int infoIndex = 0;

            Console.WriteLine($"Info on {input}:");
            foreach (var kvp in people[input])
            {
                infoIndex += kvp.Key.Length;
                infoIndex += kvp.Value.Length;
                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                int needed = targetInfoIndex - infoIndex;
                Console.WriteLine($"Need {needed} more info.");
            }
        }
    }
}
