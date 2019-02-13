using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedraft.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public IHarvesterController HarvesterController { get; private set; }

        public IProviderController ProviderController { get; private set; }

        public string ProcessCommand(IList<string> args)
        {
            throw new NotImplementedException();
        }
    }
}
