namespace _07._Inferno_Infinity.Contracts
{
    public interface IGemFactory
    {
        IGem CreateGem(string gemRearity, string gemType);
    }
}
