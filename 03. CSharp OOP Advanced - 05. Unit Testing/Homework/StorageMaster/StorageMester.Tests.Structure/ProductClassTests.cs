using NUnit.Framework;
using System;
using System.Reflection;
using System.Linq;

namespace StorageMester.Tests.Structure
{

    [TestFixture]
    public class ProductClassTests
    {
        private const BindingFlags nonPublicFlags = BindingFlags.NonPublic | BindingFlags.Instance;
        private const BindingFlags publicFlags = BindingFlags.Public | BindingFlags.Instance;

        private const string priceProperty = "Price";
        private const string weightProperty = "Weight";

        private static readonly Assembly ProjectAssembly = typeof(StorageMaster.StartUp).Assembly;
        private string message = string.Empty;

        private Type type = typeof(StorageMaster.StartUp).Assembly.GetTypes().First(t => t.Name == "Product");

        [Test]
        public void ValidateClassProductContainsPropertiesShouldBeTrue()
        {
            var properties = this.type
                .GetProperties(publicFlags)
                .Select(p => p.Name);

            this.message = $"Product type does not contain Price property";
            Assert.That(properties.Contains(priceProperty), Is.True, this.message);

            this.message = $"Product type does not contain Weight property";
            Assert.That(properties.Contains(weightProperty), Is.True, this.message);
        }

        [Test]
        public void ValidateClassProductGettersReturnTypeAllShouldBeDouble()
        {
            MethodInfo[] getMethods = this.type
                .GetMethods(publicFlags);

            foreach (var method in getMethods.Where(x => x.Name.StartsWith("get")))
            {
                this.message = $"{method.Name} does not return value of type double!";
                Assert.That(method.ReturnType, Is.EqualTo(typeof(Double)), message);
            }
        }

        [Test]
        public void ValidateClassProductPrivateSettersAllShouldBeTrue()
        {
            MethodInfo[] methods = this.type
                .GetMethods(nonPublicFlags);

            foreach (var method in methods.Where(x => x.Name.StartsWith("set")))
            {
                this.message = $"{method.Name} does not contain private setter";
                Assert.That(method.IsPrivate, Is.True, message);
            }
        }
    }

}
