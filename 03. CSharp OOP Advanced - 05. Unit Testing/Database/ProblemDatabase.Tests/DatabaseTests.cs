using NUnit.Framework;
using ProblemDatabase;
using System;
using System.Linq;
using System.Reflection;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { int.MinValue })]
        [TestCase(new int[] { int.MaxValue })]
        public void CapacityMustBeExactly16Integers(params int[] numbers)
        {
            this.database = new Database(numbers);
            Type type = typeof(Database);
            FieldInfo field = type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.Name == "array");
            Array array = (Array)field.GetValue(this.database);

            int actualResult = array.Length;
            int expectedResult = 16;
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { int.MinValue })]
        [TestCase(new int[] { int.MaxValue })]
        public void ShouldAddElementAtTheNextFreeCell(params int[] numbers)
        {
            this.database = new Database(numbers);
            int lengthBeforeAdding = this.database.CurrentLength;
            this.database.Add(5);
            int lengthAfterAdding = this.database.CurrentLength;

            int actualResult = lengthAfterAdding - lengthBeforeAdding;
            int expectedResult = 1;

            Assert.That(actualResult, Is.EqualTo(expectedResult));

            int lastCell = this.database.Fetch().Last();
            actualResult = lastCell;
            expectedResult = 5;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddingElementShouldThrowException(params int[] numbers)
        {
            this.database = new Database(numbers);

            Assert.That(() => this.database.Add(5), Throws.InvalidOperationException);
        }

        [TestCase(new int[] { 1, 2, 3, 5 })]
        [TestCase(new int[] { int.MinValue, 5 })]
        [TestCase(new int[] { int.MaxValue, 5 })]
        public void ShouldRemoveElementAtTheLastCell(params int[] numbers)
        {
            this.database = new Database(numbers);
            int lengthBeforeRemoving = this.database.CurrentLength;
            int lastCell = this.database.Fetch().Last();
            this.database.Remove();
            int lengthAfterRemoving = this.database.CurrentLength;

            int actualResult = lastCell;
            int expectedResult = 5;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase(new int[] { })]
        public void RemovingElementFromEmptyDatabaseShouldThrowException(params int[] numbers)
        {
            this.database = new Database(numbers);

            Assert.That(() => this.database.Remove(), Throws.InvalidOperationException);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { int.MinValue })]
        [TestCase(new int[] { int.MaxValue })]
        public void ShouldFetchArray(params int[] numbers)
        {
            this.database = new Database(numbers);

            Assert.That(this.database.Fetch(), Is.TypeOf<Int32[]>());
        }
    }
}