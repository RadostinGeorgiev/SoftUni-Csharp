using NUnit.Framework;

namespace Tests
{
    using System;
    using System.Linq;
    using ExtendedDatabase;

    public class ExtendedDatabaseTests
    {
        private Person ELEMENT = new Person(1, $"Person");
        const int MAX_PERSON = 16;
        private ExtendedDatabase extendedDatabase;

        private Person[] persons;

        [SetUp]
        public void Setup()
        {
            persons = Enumerable.Range(1, MAX_PERSON).Select(n => new Person(n, $"Person{n}")).ToArray();
            extendedDatabase = new ExtendedDatabase(persons);
        }

        [Test]
        public void ExtendedDatabase_TestConstructor()
        {
            //Arrange
            var iD = 123456;
            var name = "PersonOne";
            var person = new Person(iD, name);
            this.extendedDatabase = new ExtendedDatabase(person);

            //Act
            int expectedCount = 1;
            int actualCount = this.extendedDatabase.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ExtendedDatabase_TestConstructor_MaxElements()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase(this.persons);

            //Act
            int expectedCount = this.persons.Length;
            int actualCount = this.extendedDatabase.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ExtendedDatabase_TestConstructor_ShouldThrowExceptionAtBiggerNumberThan16()
        {
            //Arrange
            var overCollectionNumbers = Enumerable.Range(1, MAX_PERSON + 1).Select(n => new Person(n, $"Person{n}")).ToArray();

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(overCollectionNumbers));

        }

        [Test]
        public void ExtendedDatabase_TestAdd_AddElementToDatabase()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase();

            //Act
            this.extendedDatabase.Add(this.ELEMENT);

            //Assert
            Assert.AreEqual(1, this.extendedDatabase.Count);
        }

        [Test]
        public void ExtendedDatabase_TestAdd_ShouldThrowExceptionWhenTryAddMoreNumbersThanCapacity()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase(persons);


            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.Add(ELEMENT),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void ExtendedDatabase_TestAdd_ShouldThrowExceptionWhenTryAddElementWithExistingName()
        {
            //Arrange
            var iD = 123456;
            var name = "PersonOne";
            var person = new Person(iD, name);
            this.extendedDatabase = new ExtendedDatabase(person);


            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.Add(new Person(111111, "PersonOne")),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void ExtendedDatabase_TestAdd_ShouldThrowExceptionWhenTryAddElementWithExistingID()
        {
            //Arrange
            var iD = 123456;
            var name = "PersonOne";
            var person = new Person(iD, name);
            this.extendedDatabase = new ExtendedDatabase(person);


            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.Add(new Person(123456, "SomePerson")),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void ExtendedDatabase_TestRemove_ShouldDecreaseCountWhenRemoveElement()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase(persons);

            //Act
            this.extendedDatabase.Remove();

            //Assert
            Assert.AreEqual(15,this.extendedDatabase.Count);
        }

        [Test]
        public void ExtendedDatabase_TestRemove_ShouldThrowExceptionWhenTryRemoveFromEmptyDatabase()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase(new Person[] { });

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Remove());
        }

        [Test]
        public void ExtendedDatabase_TestFindByUsername_ShouldThrowExceptionWhenTryFindMissingElement()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase(persons);

            //Act

            //Assert
            Assert.That(() => this.extendedDatabase.FindByUsername("SomePerson"),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ExtendedDatabase_TestFindByUsername_ShouldThrowExceptionWhenTryFindNullElement(string name)
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => this.extendedDatabase.FindByUsername(name));
        }

        [Test]
        public void ExtendedDatabase_TestFindByUsername_ShouldReturnElementWhenExists()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase(this.ELEMENT);

            //Act
            var person = this.extendedDatabase.FindByUsername("Person");

            //Assert
            Assert.AreEqual(person, ELEMENT);
        }

        [Test]
        [TestCase(-10)]
        public void ExtendedDatabase_TestFindById_ShouldThrowExceptionWhenTryFindWithNegativeID(int ID)
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.extendedDatabase.FindById(ID));
        }

        [Test]
        public void ExtendedDatabase_TestFindById_ShouldThrowExceptionWhenTryFindMissingElement()
        {
            //Assert
            Assert.That(() => this.extendedDatabase.FindById(123),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void ExtendedDatabase_TestFindById_ShouldReturnElementWhenExists()
        {
            //Arrange
            this.extendedDatabase = new ExtendedDatabase(this.ELEMENT);

            //Act
            var person = this.extendedDatabase.FindById(1);

            //Assert
            Assert.True(person.Equals(ELEMENT));
        }
    }
}