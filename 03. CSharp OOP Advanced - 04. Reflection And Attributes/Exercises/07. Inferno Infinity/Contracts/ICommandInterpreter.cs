using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Inferno_Infinity.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string[] data);
    }
}
