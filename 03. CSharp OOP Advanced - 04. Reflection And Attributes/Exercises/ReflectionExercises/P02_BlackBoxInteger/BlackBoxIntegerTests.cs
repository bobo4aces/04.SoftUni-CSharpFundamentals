namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            ConstructorInfo constructor = type.GetConstructor(flags,null,new Type[] { typeof(int) }, null);
            BlackBoxInteger instance = (BlackBoxInteger)constructor.Invoke(new object[] { 0 });
            FieldInfo innerField = type.GetField("innerValue", flags);

            string[] inputArgs = Console.ReadLine()
                                    .Split("_")
                                    .ToArray();

            while (inputArgs[0]?.ToLower() != "end")
            {
                string methodName = inputArgs[0];
                int number = int.Parse(inputArgs[1]);
                MethodInfo method = type.GetMethod(methodName, flags);
                method.Invoke(instance, new object[] { number });
                Console.WriteLine(innerField.GetValue(instance));

                inputArgs = Console.ReadLine()
                                    .Split("_")
                                    .ToArray();
            }
        }
    }
}
