namespace StorageMaster.Vehicles
{
    public class Truck : Vehicle
    {
        private const int truckCapacity = 5;

        public Truck() 
            : base(truckCapacity)
        {
        }
    }
}
