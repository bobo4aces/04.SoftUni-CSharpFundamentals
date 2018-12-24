namespace StorageMaster
{
    public class SolidStateDrive : Product
    {
        private const double solidStateDriveWeigth = 0.2;

        public SolidStateDrive(double price) 
            : base(price, solidStateDriveWeigth)
        {
        }
    }
}
