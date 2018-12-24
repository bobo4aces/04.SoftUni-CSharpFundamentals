namespace StorageMaster
{
    public class Ram : Product
    {
        private const double ramWeigth = 0.1;

        public Ram(double price) 
            : base(price, ramWeigth)
        {
        }
    }
}
