using System;

namespace StorageMaster
{
    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            switch (type.ToLower())
            {
                case "gpu":
                    return new Gpu(price);
                case "harddrive":
                    return new HardDrive(price);
                case "ram":
                    return new Ram(price);
                case "solidstatedrive":
                    return new SolidStateDrive(price);
                default:
                    throw new FormatException("Invalid product type!");
            }
        }
    }
}
