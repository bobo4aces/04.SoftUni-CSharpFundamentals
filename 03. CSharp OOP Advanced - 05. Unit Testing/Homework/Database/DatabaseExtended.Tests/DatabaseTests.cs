using DatabaseExtended;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace Tests
{
    public class DatabaseExtendedTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(new Person(54321, "Gosho"));
        }

        [Test]
        public void CapacityMustBeExactly16Persons()
        {
            Type type = typeof(Database);
            FieldInfo field = type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.Name == "array");
            Array array = (Array)field.GetValue(this.database);

            int actualResult = array.Length;
            int expectedResult = 16;
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldAddPersonInDatabase()
        {
            Person person = new Person(12345, "Pesho");
            this.database.Add(person);

            int actualLength = this.database.CurrentLength;
            int expectedLength = 2;
            Assert.That(actualLength, Is.EqualTo(expectedLength));

            Person actualLastPerson = this.database.Fetch()[expectedLength-1];
            Person expectedLastPerson = person;

            Assert.That(actualLastPerson, Is.SameAs(expectedLastPerson));
        }

        [Test]
        public void AddingPersonWithSameNameShouldThrowException()
        {
            Person person = new Person(12345, "Gosho");

            Assert.That(()=>this.database.Add(person), Throws.InvalidOperationException);
        }

        [Test]
        public void AddingPersonWithSameIdShouldThrowException()
        {
            Person person = new Person(54321, "Pesho");

            Assert.That(() => this.database.Add(person), Throws.InvalidOperationException);
        }

        [Test]
        public void ShouldRemovePersonInDatabase()
        {
            int lengthBeforeRemoving = this.database.CurrentLength;
            this.database.Remove();
            int lengthAfterRemoving = this.database.CurrentLength;
            int actualResult = lengthBeforeRemoving - lengthAfterRemoving;
            int expectedResult = 1;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void RemovePersonInEmptyDatabaseShouldThrowException()
        {
            this.database.Remove();

            Assert.That(()=>this.database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void ShouldFindPersonByUsername()
        {
            Person person = new Person(12345, "Pesho");
            this.database.Add(person);

            Person actualResult = this.database.FindByUsername("Pesho");
            Person expectedResult = person;

            Assert.That(actualResult, Is.SameAs(expectedResult));
        }

        [Test]
        public void FindingPersonByNameNotPresentInDatabaseShouldThrowException()
        {
            Assert.That(()=> this.database.FindByUsername("Pesho"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindingPersonByNameWithNullArgumentShouldThrowException()
        {
            Assert.That(() => this.database.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void FindingPersonByNameCaseSensitiveShouldThrowException()
        {
            Assert.That(() => this.database.FindByUsername("gesho"), Throws.InvalidOperationException);
        }

        [Test]
        public void ShouldFindPersonById()
        {
            Person person = new Person(12345, "Pesho");
            this.database.Add(person);

            Person actualResult = this.database.FindById(12345);
            Person expectedResult = person;

            Assert.That(actualResult, Is.SameAs(expectedResult));
        }

        [Test]
        public void FindingPersonByIdNotPresentInDatabaseShouldThrowException()
        {
            Assert.That(() => this.database.FindById(12345), Throws.InvalidOperationException);
        }

        [Test]
        public void FindingPersonByNegativeIdShouldThrowException()
        {
            Type exceptionType = typeof(ArgumentOutOfRangeException);
            Assert.That(() => this.database.FindById(-54321), Throws.TypeOf(exceptionType));
        }
    }
}