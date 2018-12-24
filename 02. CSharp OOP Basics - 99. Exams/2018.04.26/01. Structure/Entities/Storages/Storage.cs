using StorageMaster.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Storages
{
    public abstract class Storage
    {
        private List<Product> products;
        private Vehicle[] garage;

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int GarageSlots { get; private set; }
        
        public IReadOnlyCollection<Product> Products { get=> products.AsReadOnly();}
        public IReadOnlyCollection<Vehicle> Garage { get=> Array.AsReadOnly(garage);}

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;
            garage = vehicles.ToArray();
            products = new List<Product>();
        }
        public IReadOnlyCollection<Vehicle> vehicles
        {
            get
            {
                return garage;
            }
            set
            {
                Vehicle[] currentGarage = new Vehicle[GarageSlots];
                int index = 0;
                foreach (var item in value)
                {
                    currentGarage[index] = item;
                    index++;
                }
                garage = currentGarage;
            }

        }
        public bool IsFull()
        {
            return products.Sum(p=>p.Weight) >= Capacity;
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            Vehicle vehicle = garage[garageSlot];
            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = GetVehicle(garageSlot);
            Vehicle[] garageTo = deliveryLocation.garage;
            if (garageTo.All(s=>s == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }
            int freeGarageSlot = AddVehicleToGarage(vehicle);
            return freeGarageSlot;
        }

        private int AddVehicleToGarage(Vehicle vehicle)
        {
            int freeGarageSlotIndex = Array.IndexOf(this.garage, null);
            if (freeGarageSlotIndex == -1)
            {
                throw new InvalidOperationException("");
            }
            this.garage[freeGarageSlotIndex] = vehicle;
            return freeGarageSlotIndex;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Storage is full!");
            }
            Vehicle vehicle = GetVehicle(garageSlot);
            int unloadedProductsCount = 0;
            List<Product> currentProducts = Products.ToList();
            while (true)
            {
                if (vehicle == null)
                {
                    break;
                }
                if (vehicle.IsEmpty())
                {
                    break;
                }
                if (IsFull())
                {
                    break;
                }
                currentProducts.Add(vehicle.Unload());
                unloadedProductsCount++;
            }
            products = currentProducts;
            return unloadedProductsCount;
        }
    }
}
