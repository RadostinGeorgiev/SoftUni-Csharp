using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    using System;

    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver firstDriver;
        private UnitDriver secondDriver;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
            var ford = new UnitCar("Ford", 300, 1000);
            var mazda = new UnitCar("Mazda", 500, 2000);
            var bmw = new UnitCar("BMW", 600, 2500);
            this.firstDriver = new UnitDriver("First", ford);
            this.secondDriver = new UnitDriver("Second", mazda);

        }

        [Test]
        public void RaceEntry_TestConstructor()
        {
            Assert.IsNotNull(raceEntry);
        }

        [Test]
        public void RaceEntry_TestAddDriver_ShouldThrowExceptionAtNullDriver()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null), "Driver cannot be null.");
            Assert.That(() => raceEntry.AddDriver(null), 
                Throws.InvalidOperationException
                    .With.Message.EqualTo("Driver cannot be null."));
        }

        [Test]
        public void RaceEntry_TestAddDriver_ShouldThrowExceptionAtExistingDriver()
        {
            this.raceEntry.AddDriver(firstDriver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(this.firstDriver), $"Driver {this.firstDriver.Name} is already added.");
            Assert.That(() => raceEntry.AddDriver(this.firstDriver), 
                Throws.InvalidOperationException
                    .With.Message.EqualTo($"Driver {this.firstDriver.Name} is already added."));
        }

        [Test]
        public void RaceEntry_TestAddDriver_SuccessAddDriver()
        {
            this.raceEntry.AddDriver(firstDriver);

            var expectedCount = 1;
            var actualCount = this.raceEntry.Counter;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RaceEntry_TestCalculateAverageHorsePower_ShouldThrowExceptionAtLessParticipants()
        {
            this.raceEntry.AddDriver(firstDriver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower(), $"The race cannot start with less than 2 participants.");
            Assert.That(() => raceEntry.CalculateAverageHorsePower(), 
                Throws.InvalidOperationException
                    .With.Message.EqualTo($"The race cannot start with less than 2 participants."));
        }

        [Test]
        public void RaceEntry_TestCalculateAverageHorsePower_SuccessCalculation()
        {
            this.raceEntry.AddDriver(firstDriver);
            this.raceEntry.AddDriver(this.secondDriver);

            var expectedAverageHorsePower = 400;
            var actualAverageHorsePower = this.raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedAverageHorsePower, actualAverageHorsePower);
        }
    }
}