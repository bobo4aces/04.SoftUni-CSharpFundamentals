using StorageMaster.Core;
using System;

namespace StorageMaster
{
    public class StartUp
    {
        public static void Main()
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
