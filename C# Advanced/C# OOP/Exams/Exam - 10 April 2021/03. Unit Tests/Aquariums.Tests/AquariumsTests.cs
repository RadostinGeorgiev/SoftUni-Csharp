namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        [TestCase("Fish")]
        [TestCase("")]
        [TestCase(null)]
        public void Fish_TestConstructor(string name)
        {
            //Arrange
            Fish fish = new Fish(name);

            //Act
            var expectedName = name;
            var actualName = fish.Name;
            var expectedAvailable = true;
            var actualAvailable = fish.Available;

            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedAvailable, actualAvailable);
        }

        [Test]
        [TestCase("Aquarium", 10)]
        public void Aquarium_TestConstructor(string name, int capacity)
        {
            //Arrange
            Aquarium aquarium = new Aquarium(name, capacity);

            //Act
            var expectedName = name;
            var actualName = aquarium.Name;
            var expectedCapacity = capacity;
            var actualCapacity = aquarium.Capacity;

            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        [TestCase("", 10)]
        [TestCase(null, 10)]
        public void Aquarium_TestName_ShouldThrowsExceptionAtNullValue(string name, int capacity)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, capacity), "Invalid aquarium name!");
        }

        [Test]
        [TestCase("Aquarium", -10)]
        public void Aquarium_TestCapacity_ShouldThrowsExceptionAtNegativeValue(string name, int capacity)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => new Aquarium(name, capacity), "Invalid aquarium capacity!");
            Assert.That(() => new Aquarium(name, capacity),
                Throws.ArgumentException
                    .With.Message.EqualTo("Invalid aquarium capacity!"));
        }

        [Test]
        [TestCase("Aquarium", 10, "Betty")]
        public void Aquarium_TestCount(string name, int capacity, string fishName)
        {
            //Arrange
            Aquarium aquarium = new Aquarium(name, capacity);
            Fish fish = new Fish(fishName);

            //Act
            aquarium.Add(fish);
            var expectedCount = 1;
            var actualCount = aquarium.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase("Aquarium", 1, "Betty")]
        public void Aquarium_TestAdd_ShouldThrowExceptionAtFullAquarium(string name, int capacity, string fishName)
        {
            //Arrange
            Aquarium aquarium = new Aquarium(name, capacity);
            Fish fish = new Fish(fishName);

            //Act
            aquarium.Add(fish);

            //Assert
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish), "Aquarium is full!");
            Assert.That(() => aquarium.Add(fish), 
                Throws.InvalidOperationException
                    .With.Message.EqualTo("Aquarium is full!"));
        }

        [Test]
        [TestCase("Betty")]
        public void Aquarium_TestRemove_ShouldThrowExceptionAtMissingFish(string fishName)
        {
            //Arrange
            Aquarium aquarium = new Aquarium("Aquarium", 10);
            Fish fishR = new Fish("Red");
            Fish fishB = new Fish("Black");

            aquarium.Add(fishR);
            aquarium.Add(fishB);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish(fishName), $"Fish with the name {fishName} doesn't exist!");
            Assert.That(() => aquarium.RemoveFish(fishName), 
                Throws.InvalidOperationException
                    .With.Message.EqualTo($"Fish with the name {fishName} doesn't exist!"));
        }

        [Test]
        [TestCase("Red")]
        public void Aquarium_TestRemove_ShouldDecreaseCount(string fishName)
        {
            //Arrange
            Aquarium aquarium = new Aquarium("Aquarium", 10);
            Fish fishR = new Fish("Red");
            Fish fishB = new Fish("Black");

            aquarium.Add(fishR);
            aquarium.Add(fishB);

            //Act
            aquarium.RemoveFish(fishName);
            var expectedCount = 1;
            var actualCount = aquarium.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

    }
}
