using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedraft.Core.Commands
{
    public class RegisterCommand : Command
    {
        public RegisterCommand(List<string> arguments) 
            : base(arguments)
        {
        }

        public override string Execute()
        {
            string type = this.Arguments[0];
            if (type == "Harvester")
            {
                harvester
            }
        }
    }
}
