using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cities
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continentCountryCity = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!continentCountryCity.ContainsKey(continent))
                {
                    continentCountryCity.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!continentCountryCity[continent].ContainsKey(country))
                {
                    continentCountryCity[continent].Add(country, new List<string>());
                }
                continentCountryCity[continent][country].Add(city);

            }

            foreach (var continent in continentCountryCity)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ",country.Value)}");
                }
            }
        }
    }
}
