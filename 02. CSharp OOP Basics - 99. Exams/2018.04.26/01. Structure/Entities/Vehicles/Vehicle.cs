using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Vehicles
{
    public abstract class Vehicle
    {
        private List<Product> products;

        public int Capacity { get; private set; }
        public IReadOnlyCollection<Product> Trunk { get=>this.products.AsReadOnly();}

        protected Vehicle(int capacity)
        {
            Capacity = capacity;
            products = new List<Product>();
        }

        public bool IsFull()
        {
            return Trunk.Sum(p => p.Weight) >= Capacity;
        }

        public bool IsEmpty()
        {
            return Trunk.Count == 0;
        }

        public void LoadProduct(Product product)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Vehicle is full!");
            }
            products.Add(product);
        }

        public Product Unload()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }
            Product lastProduct = products.Last();
            products = products.SkipLast(1).ToList();
            return lastProduct;
        }
    }
}
