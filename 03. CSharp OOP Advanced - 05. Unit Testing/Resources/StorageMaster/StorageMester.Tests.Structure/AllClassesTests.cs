using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class AllClassesTests
    {
        private static readonly string[] abstractClasses = new[]
        {
                "Vehicle",
                "Storage",
                "Product"
        };

        [Test]
        public void ValidateConcreteClassExistShouldAllBeTrue()
        {
            string[] factoryClasses = new[] {
                 "ProductFactory",
                 "StorageFactory",
                 "VehicleFactory"
            };

            string[] entityClasses = new[]
            {
                "Gpu",
                "HardDrive",
                "Ram",
                "SolidStateDrive",
                "Product",

                "Storage",
                "AutomatedWarehouse",
                "DistributionCenter",
                "Warehouse",

                "Vehicle",
                "Semi",
                "Truck",
                "Van"
            };

            string[] controllerClasses = new[]
            {
                "StorageMaster"
            };

            string[][] allClasses = new[]
            {
                factoryClasses,
                entityClasses,
                controllerClasses
            };

            foreach (var @class in allClasses)
            {
                foreach (var typeName in @class)
                {
                    Type type = typeof(StorageMaster.StartUp).Assembly.GetTypes().First(t => t.Name == typeName);
                    string message = $"{typeName} type does not exist!";

                    Assert.That(type, Is.Not.Null, message);
                }
            }
        }

        [Test]
        public void ValidateAbstractClassesShouldBeTrue()
        {
            foreach (var className in abstractClasses)
            {
                Type type = typeof(StorageMaster.StartUp).Assembly.GetTypes().First(t => t.Name == className);
                string message = $"{className} type is not abstract!";

                Assert.That(type.IsAbstract, Is.True, message);
            }
        }

        [Test]
        public void ValidateAbstractClassesHasProtectedConstructorShouldBeTrue()
        {
            foreach (var classType in abstractClasses)
            {
                Type type = typeof(StorageMaster.StartUp).Assembly.GetTypes().First(t => t.Name == classType);
                ConstructorInfo[] constructors = type.GetConstructors();

                string message = $"{classType} has public constructor.";
                Assert.That(constructors.Length, Is.EqualTo(0), message);

                constructors = type
                     .GetConstructors((BindingFlags.Instance | BindingFlags.NonPublic));

                foreach (var constructor in constructors)
                {
                    message = $"{classType} does not contain protected constructor!";
                    Assert.That(constructor.IsFamily, Is.True, message);
                }
            }
        }

        [TestCase(new object[] { "Van", "Truck", "Semi" }, "Vehicle")]
        [TestCase(new object[] { "Gpu", "HardDrive", "Ram", "SolidStateDrive" }, "Product")]
        [TestCase(new object[] { "AutomatedWarehouse", "DistributionCenter", "Warehouse" }, "Storage")]
        public void ValidateChildClassesInheritFromBaseTypeShouldBeEqual(object[] values, string baseType)
        {
            foreach (var typeName in values.Select(Convert.ToString).ToArray())
            {
                Type type = typeof(StorageMaster.StartUp).Assembly.GetTypes().First(t => t.Name == typeName); ;
                string message = $"{typeName} does not inherit from {baseType} class";

                Assert.That(type.BaseType.Name, Is.EqualTo(baseType), message);
            }
        }
    }
}
