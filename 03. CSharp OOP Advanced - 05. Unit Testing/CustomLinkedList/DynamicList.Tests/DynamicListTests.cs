using CustomLinkedList;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace CustomLinkedListTests
{
    public class DynamicListTests
    {

        private DynamicList<string> dynamicList;
        private Type type = typeof(DynamicList<string>);
        private FieldInfo[] fieldInfos = typeof(DynamicList<string>)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        [SetUp]
        public void SetUp()
        {
            this.dynamicList = new DynamicList<string>();
        }

        [Test]
        public void GettingElementByValidIndexShouldPass()
        {
            this.dynamicList.Add("C#");

            Assert.That(this.dynamicList[0], Is.EqualTo("C#"));
        }

        [Test]
        public void SettingByInvalidIndexShouldThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.dynamicList[1] = null, "Setting invalid indexer does Not throw exception!");
        }

        [Test]
        public void GettingByInvalidIndexShouldThrowArgumentOutOfRangeException()
        {
            PropertyInfo property = type
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .First(p => p.PropertyType == typeof(string));

            Assert.Throws<ArgumentOutOfRangeException>(() => property.SetValue(this.dynamicList[0], null), "Try Getting invalid index does Not throw Exception!");
        }

        [TestCase("C#")]
        public void AddingOneValidElementShouldPass(string value)
        {
            this.dynamicList.Add(value);

            Assert.That(this.dynamicList[0], Is.EqualTo(value));
        }

        [TestCase("C#")]
        public void AddingMultipleElementsShouldPass(string value)
        {
            this.dynamicList.Add(value);
            this.dynamicList.Add(value + ".NET");
            
            Assert.That(dynamicList[0], Is.EqualTo(value));
            Assert.That(dynamicList[1], Is.EqualTo(value + ".NET"));
            Assert.That(dynamicList.Count, Is.EqualTo(2));
            
            this.dynamicList.Add(value + value);
            Assert.That(dynamicList[2], Is.Not.EqualTo(null));
        }

        [Test]
        public void RemovingExistingItemShouldPass()
        {
            this.dynamicList.Add("C#");
            this.dynamicList.Add("Java");
            int countBeforeRemoval = this.dynamicList.Count;

            this.dynamicList.Remove("Java");

            int countAfterRemoval = this.dynamicList.Count;

            int actualValue = countBeforeRemoval - countAfterRemoval;
            int expectedValue = 1;

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void RemovingNonExistingItemShouldReturnNegativeInteger()
        {
            this.dynamicList.Add("C#");
            this.dynamicList.Add("Java");
            Assert.That(this.dynamicList.Remove("JS"), Is.EqualTo(-1));
        }

        public void RemoveAtExistingElementShouldPass()
        {
            this.dynamicList.Add("C#");
            this.dynamicList.Add("JS");
            this.dynamicList.Add("Python");

            var countField = fieldInfos.First(f => f.FieldType == typeof(int));

            Assert.That(countField.GetValue(this.dynamicList), Is.EqualTo(3));
            Assert.That(this.dynamicList.RemoveAt(1), Is.EqualTo("JS"));
            Assert.That(countField.GetValue(this.dynamicList), Is.EqualTo(2));
        }

        [Test]
        public void RemoveAtNonExistingIndexShouldThrow()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.dynamicList.RemoveAt(1));

            this.dynamicList.Add("C#");
            this.dynamicList.Add("JS");
            this.dynamicList.Add("Python");

            Assert.Throws<ArgumentOutOfRangeException>(() => this.dynamicList.RemoveAt(3));
        }
    }
}