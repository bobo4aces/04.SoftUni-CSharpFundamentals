using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedraft.Core
{
    public class HarvesterController : IHarvesterController
    {
        public double OreProduced { get; private set; }

        public string ChangeMode(string mode)
        {
            throw new NotImplementedException();
        }

        public string Produce()
        {
            throw new NotImplementedException();
        }

        public string Register(IList<string> args)
        {
            throw new NotImplementedException();
        }
    }
}
