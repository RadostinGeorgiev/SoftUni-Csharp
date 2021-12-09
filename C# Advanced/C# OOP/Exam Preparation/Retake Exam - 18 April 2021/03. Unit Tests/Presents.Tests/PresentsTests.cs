namespace Presents.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        [TestCase("Present", 1.5)]
        [TestCase("", 1.5)]
        [TestCase(null, 1.5)]
        [TestCase("Present", 0)]
        [TestCase("Present", -1)]
        public void Present_TestConstructor(string name, double magic)
        {
            //Arrange
            Present present = new Present(name, magic);

            //Act
            var expectedName = name;
            var expectedMagic = magic;

            //Assert 
            Assert.AreEqual(expectedName, present.Name);
            Assert.AreEqual(expectedMagic, present.Magic);
        }

        [Test]
        public void Bag_TestConstructor()
        {
            //Arrange
            this.bag = new Bag();

            //Assert
            Assert.IsNotNull(bag);
        }

        [Test]
        [TestCase(null)]
        public void Bag_TestCreate_ShouldThrowExceptionWhenTryToAddNullPresent(Present present)
        {
            //Arrange
            this.bag = new Bag();

            //Assert
            Assert.Throws<ArgumentNullException>(() => bag.Create(present));
        }

        [Test]
        public void Bag_TestCreate_ShouldThrowExceptionWhenTryToAddExistingPresent()
        {
            //Arrange
            this.bag = new Bag();

            var name = "Present";
            var magic = 1.5;
            var present = new Present(name, magic);
            this.bag.Create(present);

            //Assert
            Assert.That(() => bag.Create(present),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("This present already exists!"));
        }

        [Test]
        public void Bag_TestRemove_ShouldDecreasePresentCount()
        {
            //Arrange
            this.bag = new Bag();

            var name = "New Present";
            var magic = 1.5;
            var presentOne = new Present(name, magic);
            this.bag.Create(presentOne);

            name = "Christmas Present";
            magic = 2;
            var presentTwo = new Present(name, magic);
            this.bag.Create(presentTwo);

            //Act
            this.bag.Remove(presentOne);
            var expectedCount = 1;
            var actualCount = this.bag.GetPresents().Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase("New Present")]
        public void Bag_TestGetPresent_ShouldReturnPresent(string name)
        {
            //Arrange
            this.bag = new Bag();

            var presentName = "New Present";
            var magic = 1.5;
            var presentOne = new Present(presentName, magic);
            this.bag.Create(presentOne);

            //Act
            var expectedPresent = presentOne;
            var actualPresent = this.bag.GetPresent(name);

            //Assert
            Assert.AreEqual(expectedPresent, actualPresent);
        }

        [Test]
        public void Bag_TestGetPresentWithLeastMagic()
        {
            //Arrange
            this.bag = new Bag();

            var name = "New Present";
            var magic = 1.5;
            var presentOne = new Present(name, magic);
            this.bag.Create(presentOne);

            name = "Christmas Present";
            magic = 2;
            var presentTwo = new Present(name, magic);
            this.bag.Create(presentTwo);

            //Act
            var expectedPresentName = "New Present";
            var actualPresentName = this.bag.GetPresentWithLeastMagic().Name;

            //Assert
            Assert.AreEqual(expectedPresentName, actualPresentName);
        }

    }
}
