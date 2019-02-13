using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedraft.Core
{
    public abstract class Command : ICommand
    {
        public IList<string> Arguments { get; private set; }
        protected Command(List<string> arguments)
        {
            this.Arguments = arguments;
        }
        public abstract string Execute();
    }
}
