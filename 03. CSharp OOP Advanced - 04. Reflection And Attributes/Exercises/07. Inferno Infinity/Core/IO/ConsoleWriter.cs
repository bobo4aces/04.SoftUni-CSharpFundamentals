using _07._Inferno_Infinity.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Inferno_Infinity.Core.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
