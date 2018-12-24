using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                            .Split(new char[] { ';','=' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            List<Person> people = GetPeople(input);
            input = Console.ReadLine()
                            .Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
            List<Product> products = GetProducts(input);
            string[] command = Console.ReadLine()
                               .Split(" ")
                               .ToArray();
            while (command[0]?.ToLower() != "end")
            {
                string currentPersonName = command[0];
                string currentProductName = command[1];

                Person currentPerson = people.FirstOrDefault(n => n.Name == currentPersonName);
                Product currentProduct = products.FirstOrDefault(n => n.Name == currentProductName);
                if (currentPerson != null && currentProduct != null)
                {
                    Console.WriteLine(currentPerson.CanAfford(currentProduct));
                }

                command = Console.ReadLine()
                               .Split(" ")
                               .ToArray();
            }

            people.ForEach(p => Console.WriteLine(p));
        }

        private static List<Person> GetPeople(string[] input)
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < input.Length; i+=2)
            {
                try
                {
                    Person person = new Person(input[i], int.Parse(input[i+1]));
                    people.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return people;
        }

        private static List<Product> GetProducts(string[] input)
        {
            List<Product> products = new List<Product>();
            for (int i = 0; i < input.Length; i+=2)
            {
                try
                {
                    Product product = new Product(input[i], int.Parse(input[i+1]));
                    products.Add(product);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return products;
        }
    }
}
