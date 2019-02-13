using _07._Inferno_Infinity.Contracts;

namespace _07._Inferno_Infinity.Core.Commands
{
    public abstract class Command : IExecutable
    {
        public Command(string[] data)
        {
            this.Data = data;
        }
        public string[] Data { get; protected set; }
        public abstract void Execute();
    }
}
