using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    using Database = Database.Database;

    public class DatabaseTests
    {
        private const int ELEMENT = 111;
        private const int NEXT_ELEMENT = 11;
        private Database database;
        private static readonly int[] initData = Enumerable.Range(1, 10).ToArray();

        [SetUp]
        public void Setup()
        {
            this.database = new Database(initData);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { })]
        public void Database_TestConstructor(int[] initData)
        {
            //Arrange
            this.database = new Database(initData);

            //Act
            int expectedCount = initData.Length;
            int actualCount = database.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Database_TestConstructor_ShouldThrowExceptionAtBiggerNumberThan16()
        {
            //Arrange
            int[] overCollectionNumbers = Enumerable.Range(1, 17).ToArray();

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => new Database(overCollectionNumbers));

        }

        [Test]
        public void Database_TestAdd_AddElementToDatabase()
        {
            //Arrange

            //Act
            this.database.Add(ELEMENT);
            var itemsDatabase = this.database.Fetch();

            //Assert
            Assert.True(itemsDatabase.Contains(ELEMENT));
        }

        [Test]
        public void Database_TestAdd_IncreaseCountWhenAddValidLastElement()
        {
            //Arrange

            //Act
            this.database.Add(NEXT_ELEMENT);

            //Assert
            Assert.AreEqual(initData.Length + 1, this.database.Count);
        }

        [Test]
        public void Database_TestAdd_ShouldThrowExceptionWhenTryAddMoreNumbersThanCapacity()
        {
            //Arrange
            int[] maxCollectionNumbers = Enumerable.Range(1, 16).ToArray();
            this.database = new Database(maxCollectionNumbers);


            //Act

            //Assert
            Assert.That(() => this.database.Add(NEXT_ELEMENT),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Database_TestRemove_RemoveElementFromDatabase()
        {
            //Arrange

            //Act
            this.database.Add(ELEMENT);
            this.database.Remove();
            var itemsDatabase = this.database.Fetch();

            //Assert
            Assert.False(itemsDatabase.Contains(ELEMENT));
        }

        [Test]
        public void Database_TestRemove_ShouldDecreaseCountWhenRemoveLastElement()
        {
            //Arrange

            //Act
            this.database.Remove();

            //Assert
            Assert.AreEqual(initData.Length - 1, this.database.Count);

        }

        [Test]
        public void Database_TestRemove_ShouldThrowExceptionWhenTryRemoveFromEmptyDatabase()
        {
            //Arrange
            this.database = new Database(new int[] { });


            //Act

            //Assert
            Assert.That(() => this.database.Remove(),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { })]
        public void Database_TestFetch(int[] expectedData)
        {
            //Arrange
            this.database = new Database(expectedData);

            //Act
            var actualData = this.database.Fetch();

            //Assert
            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}