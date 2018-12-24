namespace StorageMaster
{
    public class HardDrive : Product
    {
        private const double hardDriveWeigth = 1;

        public HardDrive(double price) 
            : base(price, hardDriveWeigth)
        {
        }
    }
}
