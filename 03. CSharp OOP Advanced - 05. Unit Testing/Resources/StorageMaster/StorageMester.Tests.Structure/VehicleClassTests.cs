using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class VehicleClassTests
    {
        private const BindingFlags publicFlags = BindingFlags.Public | BindingFlags.Instance;

        private Type type;
        private string message = string.Empty;

        [SetUp]
        public void GetTypeBeforeEachTest()
        {
            this.type = typeof(StorageMaster.StartUp).Assembly.GetTypes().First(t => t.Name == "Vehicle");
        }

        [Test]
        public void ValidatePropertiesExistAllShouldNotBeNull()
        {
            string[] expectedProps = new[]
            {
                "Capacity",
                "Trunk",
                "IsFull",
                "IsEmpty"
            };

            PropertyInfo[] actualProps = type.GetProperties(publicFlags);

            foreach (var expProp in expectedProps)
            {
                var property = actualProps.FirstOrDefault(p => p.Name == expProp);

                message = $"Type Vehicle does not contain {expProp} property!";
                Assert.That(property, Is.Not.Null, message);
            }
        }

        [TestCase("Capacity", typeof(Int32))]
        [TestCase("Trunk", typeof(IReadOnlyCollection<Product>))]
        [TestCase("IsFull", typeof(Boolean))]
        [TestCase("IsEmpty", typeof(Boolean))]
        public void ValidatePropertiesTypesAllShouldBeTrue(string propName, Type expectedType)
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
                "Unload",
                "LoadProduct",
            };

            MethodInfo[] methods = type.GetMethods(publicFlags);

            foreach (var expectedMethod in expectedMethods)
            {
                MethodInfo method = methods.FirstOrDefault(x => x.Name == expectedMethod);

                message = $"{expectedMethod} does not exist!";
                Assert.That(method, Is.Not.Null, message);
            }
        }

        [TestCase("Unload", typeof(Product))]
        [TestCase("LoadProduct", typeof(void))]
        public void ValidateMethodsReturnTypesAllShouldBeTrue(string methodName, Type expectedType)
        {
            MethodInfo method = type.GetMethod(methodName);

            message = $"{methodName} does not return correct type!";
            Assert.That(method.ReturnType, Is.EqualTo(expectedType), message);
        }

        [TestCase("LoadProduct", typeof(Product))]
        public void ValidateLoadProductMethodParamsShouldBeTypeProduct(string methodName, Type expectedType)
        {
            MethodInfo method = type.GetMethod(methodName);
            ParameterInfo[] @params = method.GetParameters();

            foreach (var param in @params)
            {
                string paramType = param.ParameterType.Name;

                message = $"{methodName} parameter is not from type {expectedType}";
                Assert.That(paramType, Is.EqualTo(expectedType.Name), message);
            }
        }
    }
}
