using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class StorageClassTests
    {
        private const BindingFlags publicFlags = BindingFlags.Public | BindingFlags.Instance;

        private Type type;
        private string message = string.Empty;

        [SetUp]
        public void GetTypeBeforeEachTest()
        {
            this.type = typeof(StorageMaster.StartUp).Assembly.GetTypes().First(t => t.Name == "Storage");
        }

        [Test]
        public void ValidateAllPropertiesExistAllShouldBeTrue()
        {
            string[] expectedProps = new[]
            {
                "Name",
                "Capacity",
                "GarageSlots",
                "IsFull",
                "Garage",
                "Products"
            };

            PropertyInfo[] actualProps = type.GetProperties(publicFlags);

            foreach (var expProp in expectedProps)
            {
                PropertyInfo property = actualProps.FirstOrDefault(x => x.Name == expProp);

                message = $"Type {this.type.Name} does not contain property {expProp}";
                Assert.That(property, Is.Not.Null, message);
            }
        }

        [TestCase("Name", typeof(String))]
        [TestCase("Capacity", typeof(Int32))]
        [TestCase("GarageSlots", typeof(Int32))]
        [TestCase("IsFull", typeof(Boolean))]
        [TestCase("Products", typeof(IReadOnlyCollection<Product>))]
        [TestCase("Garage", typeof(IReadOnlyCollection<Vehicle>))]
        public void ValidatePropertiesTypesAllShouldBeRight(string propName, Type expectedType)
        {
            PropertyInfo property = type.GetProperty(propName);

            message = $"{propName} is not from type {expectedType}";
            Assert.That(property.PropertyType, Is.EqualTo(expectedType), message);
        }

        [Test]
        public void ValidateMethodsExistShouldNotBeNull()
        {
            string[] expectedMethods = new[]
            {
                "GetVehicle",
                "UnloadVehicle",
                "SendVehicleTo",
            };

            MethodInfo[] methods = type.GetMethods(publicFlags);

            foreach (var expectedMethod in expectedMethods)
            {
                MethodInfo method = methods.FirstOrDefault(x => x.Name == expectedMethod);

                message = $"{expectedMethod} does not exist!";
                Assert.That(method, Is.Not.Null, message);
            }
        }
    }
}
