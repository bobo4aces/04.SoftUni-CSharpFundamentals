using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace StorageMester.BusinessLogic.Tests
{
    [TestFixture]
    public class BusnessLogicTests
    {
        private const BindingFlags nonPublicFlags = BindingFlags.NonPublic | BindingFlags.Instance;

        private StorageMaster.Core.StorageMaster storageMaster;
        private Type type;
        private string message = string.Empty;

        [SetUp]
        public void InitializeBeforeEachTest()
        {
            this.type = typeof(StorageMaster.StartUp).Assembly.GetTypes().First(t=>t.Name == "StorageMaster");
            this.storageMaster = (StorageMaster.Core.StorageMaster)Activator.CreateInstance(this.type, new object[] { });
        }

        [Test]
        public void AddProductToStorageMasterShouldReturnCorrectString()
        {
            string methodName = "AddProduct";
            MethodInfo method = this.type.GetMethod(methodName);

            string productType = "Ram";
            double price = 2.0;

            string expectedResult = $"Added { productType } to pool";
            object actualResult = method.Invoke(this.storageMaster, new object[] { productType, price });

            message = $"Invalid return message!";
            Assert.That(actualResult, Is.EqualTo(expectedResult), message);

            Dictionary<string, Stack<Product>>.ValueCollection productPool = GetPoolField().Values;

            int expectedSize = 1;
            message = $"Invalid collection size!";
            Assert.That(productPool.Count, Is.EqualTo(expectedSize), message);
        }

        [Test]
        public void RegisterStorageShouldReturnCorrectString()
        {
            string methodName = "RegisterStorage";
            MethodInfo method = this.type.GetMethod(methodName);

            string storageType = "Warehouse";
            string storageName = "Softuni";

            string expectedResult = $"Registered {storageName}";
            object actualResult = method.Invoke(this.storageMaster, new object[] { storageType, storageName });

            message = $"Invalid return message!";
            Assert.That(actualResult, Is.EqualTo(expectedResult), message);

            Dictionary<string,Storage>.ValueCollection storageRegistry = GetStorageField().Values;

            int expectedSize = 1;
            message = $"Invalid return message!";
            Assert.That(storageRegistry.Count, Is.EqualTo(expectedSize), message);
        }

        [Test]
        public void SelectVehicleShouldReturnCorrectVehicle()
        {
            string methodName = "SelectVehicle";
            MethodInfo method = this.type.GetMethod(methodName);

            Dictionary<string, Storage> storageRegistry = GetStorageField();
            storageRegistry.Add("Softuni", new Warehouse("Softuni"));
            storageRegistry.Add("C#", new DistributionCenter("C#"));

            FieldInfo selectedVehicle = this.type
                                       .GetFields(nonPublicFlags)
                                       .First(x => x.FieldType.Name == typeof(Vehicle).Name);

            Assert.That(selectedVehicle.GetValue(this.storageMaster), Is.Null);

            string storageName = "Softuni";
            int garageSlot = 1;
            object actualResult = method.Invoke(this.storageMaster, new object[] { storageName, garageSlot });
            string expectedResult = $"Selected {typeof(Semi).Name}";

            message = $"Invalid vehicle returned!";
            Assert.That(actualResult, Is.EqualTo(expectedResult), message);

            Assert.That(selectedVehicle.GetValue(this.storageMaster), Is.Not.Null);
        }

        [Test]
        public void LoadVehicleWithEmptyPoolShouldThrowInvalidOperationException()
        {
            string methodName = "LoadVehicle";
            MethodInfo method = this.type.GetMethod(methodName);
            List<string> methodParams = new List<string> { "Gpu", "HardDrive" };
            object[] @params = new object[] { methodParams };
            this.type
              .GetFields(nonPublicFlags)
              .First(x => x.FieldType.Name == typeof(Vehicle).Name)
              .SetValue(this.storageMaster, new Truck());

            Assert.That(() => method.Invoke(this.storageMaster, @params),
            Throws.InnerException.InstanceOf(typeof(InvalidOperationException)));
        }

        [Test]
        public void LoadVehicleWithValidPoolShouldWorkCorrect()
        {
            string methodName = "LoadVehicle";
            MethodInfo method = this.type.GetMethod(methodName);
            List<string> methodParams = new List<string> { "Gpu", "HardDrive" };
            object[] @params = new object[] { methodParams };

            Dictionary<string, Stack<Product>> productPool = GetPoolField();
            Stack<Product> gpu = new Stack<Product>();
            gpu.Push(new Gpu(10));
            productPool.Add("Gpu", gpu);
            Stack<Product> hardDrive = new Stack<Product>();
            hardDrive.Push(new HardDrive(17));
            productPool.Add("HardDrive", hardDrive);

            this.type
              .GetFields(nonPublicFlags)
              .First(x => x.FieldType.Name == typeof(Vehicle).Name)
              .SetValue(this.storageMaster, new Truck());

            string expectedResult = $"Loaded {methodParams.Count}/{methodParams.Count} products into {typeof(Truck).Name}";

            object actualResult = method.Invoke(this.storageMaster, @params);

            message = "Invalid message returned!";
            Assert.That(actualResult, Is.EqualTo(expectedResult), message);

            int expectedPoolSize = 0;
            message = "Invalid Pool size";
            Assert.That(productPool.Values.Sum(v=>v.Count), Is.EqualTo(expectedPoolSize), message);
        }

        [Test]
        public void SendVehicleToShouldWorkCorrect()
        {
            string methodName = "SendVehicleTo";
            MethodInfo method = this.type.GetMethod(methodName);
            string sourceName = "Kaufland";
            string destination = "Fantastiko";
            int garageSlot = 1;

            Dictionary<string,Storage> storageRegistry = GetStorageField();
            storageRegistry.Add(sourceName, new Warehouse(sourceName));
            storageRegistry.Add(destination, new AutomatedWarehouse(destination));

            string expectedResult = $"Sent {typeof(Semi).Name} to {destination} (slot {garageSlot})";
            object actualResult = method.Invoke(this.storageMaster, new object[] { sourceName, garageSlot, destination });

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        private Dictionary<string, Stack<Product>> GetPoolField()
        {
            return (Dictionary<string, Stack<Product>>)this.type
                 .GetFields(nonPublicFlags)
                 .First(x => x.FieldType == typeof(Dictionary<string, Stack<Product>>))
                 .GetValue(this.storageMaster);
        }

        private Dictionary<string, Storage> GetStorageField()
        {
            return (Dictionary<string, Storage>)this.type
                  .GetFields(nonPublicFlags)
                  .First(x => x.FieldType == typeof(Dictionary<string, Storage>))
                  .GetValue(this.storageMaster);
        }

    }
}
