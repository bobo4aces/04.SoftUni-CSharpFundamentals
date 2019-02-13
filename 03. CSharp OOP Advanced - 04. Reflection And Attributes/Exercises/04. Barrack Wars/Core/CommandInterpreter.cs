using _03BarracksFactory.Contracts;
using P03_BarraksWars.Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {

        private IRepository repository;
        private IUnitFactory unitFactory;
        private CommandFactory commandFactory;
        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)    
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
            this.commandFactory = new CommandFactory();
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            return this.commandFactory.CreateCommand(data, this.repository, this.unitFactory);
        }
    }
}
