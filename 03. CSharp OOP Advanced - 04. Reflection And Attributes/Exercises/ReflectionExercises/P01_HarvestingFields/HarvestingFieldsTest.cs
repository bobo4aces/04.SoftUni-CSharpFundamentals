 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string command = Console.ReadLine();

            Type type = typeof(HarvestingFields);
            FieldInfo[] allFields = 
                type.GetFields(BindingFlags.Static|BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance);
            while (command.ToLower() != "harvest")
            {
                FieldInfo[] result = null;
                switch (command.ToLower())
                {
                    case "private":
                        result = allFields.Where(f => f.IsPrivate).ToArray();
                        break;
                    case "protected":
                        result = allFields.Where(f => f.IsFamily).ToArray();
                        break;
                    case "public":
                        result = allFields.Where(f => f.IsPublic).ToArray();
                        break;
                    case "all":
                        result = allFields;
                        break;
                    default:
                        break;
                }
                foreach (var field in result)
                {
                    if (!field.IsFamily)
                    {
                        Console.WriteLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                    }
                    
                }
                command = Console.ReadLine();
            }
        }
    }
}
