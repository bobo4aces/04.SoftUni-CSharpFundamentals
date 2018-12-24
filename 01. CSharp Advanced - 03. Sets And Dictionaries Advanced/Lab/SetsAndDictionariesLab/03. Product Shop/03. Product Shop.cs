using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            SortedDictionary<string, Dictionary<string, double>> shopProductPrice = new SortedDictionary<string, Dictionary<string, double>>();

            while (input[0]?.ToLower() != "revision")
            {
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!shopProductPrice.ContainsKey(shop))
                {
                    shopProductPrice.Add(shop, new Dictionary<string, double>());
                }
                if (!shopProductPrice[shop].ContainsKey(product))
                {
                    shopProductPrice[shop].Add(product, 0);
                }
                shopProductPrice[shop][product] = price;

                input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            foreach (var shop in shopProductPrice)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
