using _07._Inferno_Infinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Inferno_Infinity.Core.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
