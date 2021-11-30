using NUnit.Framework;

namespace Tests
{
    using System;
    using CarManager;

    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            string make = "BMW";
            string model = "X6";
            double fuelConsumption = 12.5;
            double fuelCapacity = 82.5;

            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        [TestCase("", "Model", 10, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -10, 100)]
        [TestCase("Make", "Model", 10, 0)]
        [TestCase("Make", "Model", 10, -100)]
        public void Car_TestConstructor_ShouldThrowExeptionWhenPropertyIsInvalid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase("Make", "Model", 10, 100)]
        public void Car_TestConstructor_ShouldSetPropertyWhenAreValid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act
            var expectedMake = make;
            var expectedModel = model;
            var expectedFuelConsumption = fuelConsumption;
            double expectedFuelCapacity = fuelCapacity;
            double expectedFuelAmount = 0;

            //Assert
            Assert.AreEqual(expectedMake, this.car.Make);
            Assert.AreEqual(expectedModel, this.car.Model);
            Assert.AreEqual(expectedFuelConsumption, this.car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, this.car.FuelCapacity);
            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void Car_TestRefuel_ShouldThrowArgumentExceptionWhenTryFuelWithNegativeOrZeroFuel(double fuel)
        {
            //Assert
            Assert.That(() => this.car.Refuel(fuel), 
                Throws.ArgumentException
                    .With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        [TestCase(50)]
        public void Car_TestRefuel_ShouldIncreaseFuelAmountAtValidFuel(double fuel)
        {
            //Act
            this.car.Refuel(fuel);

            double expectedFuel = fuel;
            double actualFuel = this.car.FuelAmount;

            //Assert
            Assert.AreEqual(expectedFuel, actualFuel);
        }

        [Test]
        [TestCase(100)]
        public void Car_TestRefuel_ShouldIncreaseFuelAmountToFuelCapacity(double fuel)
        {
            //Act
            this.car.Refuel(fuel);

            double expectedFuel = this.car.FuelCapacity;
            double actualFuel = this.car.FuelAmount;

            //Assert
            Assert.AreEqual(expectedFuel, actualFuel);
        }

        [Test]
        [TestCase(1000)]
        public void Car_TestDrive_ShouldThrowInvalidOperationExceptionWhenNoEnoughFuel(double distance)
        {
            //Act
            this.car.Refuel(this.car.FuelCapacity);

            //Assert
            Assert.That(() => this.car.Drive(distance),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        [TestCase(100)]
        public void Car_TestDrive_ShouldDereaseFuelAmountToFuelCapacity(double distance)
        {
            //Act
            this.car.Refuel(this.car.FuelCapacity);
            this.car.Drive(distance);

            double expectedFuel = this.car.FuelCapacity - this.car.FuelConsumption;
            double actualFuel = this.car.FuelAmount;

            //Assert
            Assert.AreEqual(expectedFuel, actualFuel);
        }
    }
}