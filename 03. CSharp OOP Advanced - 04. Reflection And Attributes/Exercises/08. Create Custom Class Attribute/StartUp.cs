using System;
using System.Linq;
using System.Reflection;

namespace _08._Create_Custom_Class_Attribute
{
    class StartUp
    {
        static void Main()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly
                .GetTypes()
                .Where(x => x.GetCustomAttributes<DefaultAttribute>().Any())
                .ToArray();

            foreach (var type in types)
            {
                DefaultAttribute attribute = type.GetCustomAttribute<DefaultAttribute>();

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    switch (command)
                    {
                        case "Author":
                            Console.WriteLine($"Author: {attribute.Author}");
                            break;
                        case "Revision":
                            Console.WriteLine($"Revision: {attribute.Revision}");
                            break;
                        case "Description":
                            Console.WriteLine($"Class description: {attribute.Description}");
                            break;
                        case "Reviewers":
                            Console.WriteLine($"Reviewers: {String.Join(", ", attribute.Reviewers)}");
                            break;
                    }
                }
            }
        }
    }
}
