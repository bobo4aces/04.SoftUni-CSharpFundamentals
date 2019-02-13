using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _06._Traffic_Lights
{
    public class StartUp
    {
        public static void Main()
        {
            string[] inputArgs = Console.ReadLine()
                .Split(" ")
                .ToArray();
            TrafficLight[] trafficLights = new TrafficLight[inputArgs.Length];
            
            for (int i = 0; i < inputArgs.Length; i++)
            {
                Type type = typeof(TrafficLight);
                trafficLights[i] = (TrafficLight)Activator.CreateInstance(type, new object[] { inputArgs[i] });
            }

            int changesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < changesCount; i++)
            {
                List<string> result = new List<string>();
                foreach (var trafficLight in trafficLights)
                {
                    trafficLight.Update();
                    Type type = typeof(TrafficLight);
                    FieldInfo colorInfo = type.GetField("color", BindingFlags.NonPublic | BindingFlags.Instance);
                    string currentColor = colorInfo.GetValue(trafficLight).ToString();
                    result.Add(currentColor);
                }
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
