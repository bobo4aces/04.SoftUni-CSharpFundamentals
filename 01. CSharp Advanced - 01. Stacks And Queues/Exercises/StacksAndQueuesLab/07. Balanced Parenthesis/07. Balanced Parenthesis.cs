using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Dictionary<char, char> pairs = new Dictionary<char, char>();
            pairs.Add('{', '}');
            pairs.Add('(', ')');
            pairs.Add('[', ']');

            Stack<char> openBrackets = new Stack<char>(input);
            
            foreach (var bracket in input)
            {
                if (pairs.ContainsKey(bracket))
                {
                    openBrackets.Push(bracket);
                    continue;
                }
                char lastBracket = openBrackets.Pop();
                if (pairs[lastBracket] != bracket)
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES"); 
        }
    }
}
