using StorageMaster.Factories;
using StorageMaster.Vehicles;
using StorageMaster.Storages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private Dictionary<string,Product> products;
        private List<Product> productPool;
        private List<Storage> storageRegistry;
        private Vehicle currentVehicle = null;

        public StorageMaster()
        {
            productFactory = new ProductFactory();
            productPool = new List<Product>();
            storageFactory = new StorageFactory();
            storageRegistry = new List<Storage>();
            products = new Dictionary<string, Product>();
        }

        public string AddProduct(string type, double price)
        {
            Product product = productFactory.CreateProduct(type, price);
            productPool.Add(product);
            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = storageFactory.CreateStorage(type, name);
            storageRegistry.Add(storage);
            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            currentVehicle = storageRegistry.First(s => s.Name == storageName).GetVehicle(garageSlot);
            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;
            foreach (var productName in productNames)
            {
                Product product = productPool.LastOrDefault(p => p.GetType().Name == productName);
                if (currentVehicle.IsFull())
                {
                    break;
                }
                if (product == null)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }
                int lastIndex = productPool.LastIndexOf(product);
                productPool.RemoveAt(lastIndex);
                currentVehicle.LoadProduct(product);
                loadedProductsCount++;
            }
            return $"Loaded {loadedProductsCount}/{productNames.Count()} products into {currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            Storage source = storageRegistry.FirstOrDefault(s => s.Name == sourceName);
            Storage destination = storageRegistry.FirstOrDefault(s => s.Name == destinationName);
            if (source == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            if (destination == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }
            Vehicle vehicle = source.GetVehicle(sourceGarageSlot);
            int destinationGarageSlot = source.SendVehicleTo(sourceGarageSlot,destination);
            Vehicle[] garage = destination.Garage.ToArray();
            for (int i = 0; i < garage.Length; i++)
            {
                if (garage[i] == null)
                {
                    garage[i] = vehicle;
                    destination.Garage = garage;
                    return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {i})";
                }
            }
            return "";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = storageRegistry.FirstOrDefault(s=>s.Name == storageName);
            Vehicle vehicle = storage.GetVehicle(garageSlot);
            int productsCount = vehicle.Trunk.Count;
            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);
            return $"Unloaded {unloadedProductsCount}/{productsCount} products at {storage.Name}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = storageRegistry.FirstOrDefault(s => s.Name == storageName);
            List<string> garage = new List<string>();
            string output = string.Empty;
            double weight = 0;
            int capacity = storage.Capacity;
            List<string> productsAsList = new List<string>();

            if (storage != null)
            {
                
                if (storage.Products != null)
                {
                    int productsCount = storage.Products.Count;
                    var products = storage.Products
                        .GroupBy(s => s.GetType().Name)
                        .OrderByDescending(p => p.Key.Count())
                        .ThenBy(p => p.Key.GetType().Name);
                    weight = storage.Products.Sum(p => p.Weight);
                    productsAsList = new List<string>();
                    foreach (var product in products)
                    {
                        productsAsList.Add($"{product.Key} ({product.Count()})");
                    }
                }
                
            }
            output += $"Stock ({weight}/{capacity}): ";
            output += $"[{string.Join(", ", productsAsList)}]\n";

            foreach (var vehicle in storage.Garage)
            {
                if (vehicle == null)
                {
                    garage.Add("empty");
                }
                else
                {
                    garage.Add(vehicle.GetType().Name);
                }
            }
            output += $"Garage: [{string.Join("|", garage)}]";

            return output;
        }

        public string GetSummary()
        {
            string output = string.Empty;
            foreach (var storage in storageRegistry.OrderByDescending(s=>s.Products.Sum(p=>p.Price)))
            {
                string storageName = storage.Name;
                double totalMoney = 0;
                if (storage.Products != null)
                {
                    totalMoney = storage.Products.Sum(p => p.Price);
                }
                output += $"{storageName}:\nStorage worth: ${totalMoney:F2}\n";
            }
            return output.TrimEnd();
        }

    }
}
