namespace StorageMaster
{
    public class Gpu : Product
    {
        private const double gpuWeigth = 0.7;

        public Gpu(double price) 
            : base(price, gpuWeigth)
        {
        }
    }
}
