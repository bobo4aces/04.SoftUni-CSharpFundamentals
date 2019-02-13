public abstract class Provider : IProvider
{
    private const int InitialDurability = 1000;
    public int ID { get; private set; }
    public double EnergyOutput { get; protected set; }
    public double Durability { get; protected set; }
    public Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }
    public void Broke()
    {
        this.Durability -= 100;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }
}