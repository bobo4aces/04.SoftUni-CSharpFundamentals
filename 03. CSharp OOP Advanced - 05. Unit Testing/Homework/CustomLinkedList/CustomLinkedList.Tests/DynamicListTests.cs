using CustomLinkedList;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace Tests
{
    public class DynamicListTests
    {
        private DynamicList<string> dynamicList;
        private Type type;
        private FieldInfo[] fieldInfos;

        [SetUp]
        public void Setup()
        {
            this.dynamicList = new DynamicList<string>();
            this.type = typeof(DynamicList<string>);
            this.fieldInfos = this.type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        }

        [Test]
        public void ShouldInitializeDynamicList()
        {
            DynamicList<string> head = (DynamicList<string>)this.fieldInfos
                .First(f => f.Name == "head")
                .GetValue(this.dynamicList);
            DynamicList<string> tail = (DynamicList<string>)this.fieldInfos
                .First(f => f.Name == "tail")
                .GetValue(this.dynamicList);
            int count = (int)this.fieldInfos
                .First(f => f.Name == "count")
                .GetValue(this.dynamicList);

            Assert.That(head,Is.Null);
            Assert.That(tail, Is.Null);
            Assert.That(count, Is.Zero);
        }

        [Test]
        public void ShouldAddItemInDynamicList()
        {
            int lenghtBeforeAdding = this.dynamicList.Count;
            this.dynamicList.Add("Pesho");
            int lenghtAfterAdding = this.dynamicList.Count;

            int actualResult = lenghtAfterAdding - lenghtBeforeAdding;
            int expectedResult = 1;
            Assert.That(actualResult, Is.EqualTo(expectedResult));

            Assert.That(this.dynamicList[0], Is.EqualTo("Pesho"));
        }

        [Test]
        public void ShouldRemoveItemInSpecifiedIndex()
        {
            this.dynamicList.Add("Pesho");
            int lenghtBeforeRemoving = this.dynamicList.Count;
            this.dynamicList.RemoveAt(0);
            int lenghtAfterRemoving = this.dynamicList.Count;

            int actualResult = lenghtBeforeRemoving - lenghtAfterRemoving;
            int expectedResult = 1;
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void RemoveAtShouldThrowException()
        {
            this.dynamicList.Add("Pesho");
            Type type = typeof(ArgumentOutOfRangeException);
            Assert.That(()=> this.dynamicList.RemoveAt(-1),Throws.TypeOf(type));
        }

        [Test]
        public void RemovingItemShouldReturnInteger()
        {
            this.dynamicList.Add("Pesho");
            int actualResult = this.dynamicList.Remove("Pesho");
            int expectedResult = 0;
            Assert.That(actualResult, Is.EqualTo(expectedResult));

            actualResult = this.dynamicList.Remove("Pesho");
            expectedResult = -1;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void IndexOfShouldReturnInteger()
        {
            this.dynamicList.Add("Pesho");
            int actualResult = this.dynamicList.IndexOf("Pesho");
            int expectedResult = 0;
            Assert.That(actualResult, Is.EqualTo(expectedResult));

            actualResult = this.dynamicList.IndexOf("Gosho");
            expectedResult = -1;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ContainsShouldReturnTrue()
        {
            this.dynamicList.Add("Pesho");
            bool actualResult = this.dynamicList.Contains("Pesho");
            bool expectedResult = true;
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ContainsShouldReturnFalse()
        {
            this.dynamicList.Add("Pesho");
            bool actualResult = this.dynamicList.Contains("Gosho");
            bool expectedResult = false;
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void RemoveListNodeShouldRemoveNode()
        {
            ConstructorInfo contructor = this.type.GetConstructor(new Type[] { this.type });

            this.dynamicList.Add("Pesho");
            this.dynamicList.Add("Gosho");
            int lengthBeforeRemovingListNode = this.dynamicList.Count;
            MethodInfo methodInfo = typeof(DynamicList<string>)
                .GetMethod("RemoveListNode",BindingFlags.NonPublic|BindingFlags.Instance);
            methodInfo.Invoke(string, new object[] { this.dynamicList[0], this.dynamicList[1] });
            int lengthAfterRemovingListNode = 2;
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}