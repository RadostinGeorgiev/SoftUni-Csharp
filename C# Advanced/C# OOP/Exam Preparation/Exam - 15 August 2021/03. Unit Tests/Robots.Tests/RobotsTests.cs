namespace Robots.Tests
{
    using System;
    using Microsoft.VisualBasic;
    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        private RobotManager robotManager;

        [Test]
        [TestCase("Robot", 100)]
        [TestCase("", 100)]
        [TestCase(null, 100)]
        [TestCase("Robot", 0)]
        [TestCase("Robot", -100)]
        public void Robot_TestConstructor(string name, int maximumBattery)
        {
            //Arrange
            Robot robot = new Robot(name, maximumBattery);

            //Act
            var expectedName = name;
            var actualName = robot.Name;
            var expectedMaximumBattery = maximumBattery;
            var actualMaximumBattery = robot.MaximumBattery;
            var expectedBattery = maximumBattery;
            var actualBattery = robot.Battery;

            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedBattery, actualBattery);
            Assert.AreEqual(expectedMaximumBattery, actualMaximumBattery);
        }

        [Test]
        [TestCase(10)]
        [TestCase(0)]
        public void RobotManager_TestConstructor(int capacity)
        {
            //Arrange
            this.robotManager = new RobotManager(capacity);

            //Act
            var expectedCount = 0;
            var actualCount = robotManager.Count;
            var expectedCapaciry = capacity;
            var actualCapacity = robotManager.Capacity;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedCapaciry, actualCapacity);
        }

        [Test]
        [TestCase(-10)]
        public void RobotManager_TestCapacity_ShouldThrowArgumentExceptionAtNegativeCapacity(int capacity)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => new RobotManager(capacity));
            Assert.That(() => new RobotManager(capacity),
                Throws.ArgumentException
                    .With.Message.EqualTo("Invalid capacity!"));
        }

        [Test]
        public void RobotManager_TestAdd_ShouldThrowExceptionWhenTryAddExistingRobot()
        {
            //Arrange
            this.robotManager = new RobotManager(100);
            var name = "R2";
            var maximumBattery = 20;
            var robotR2 = new Robot(name, maximumBattery);

            //Act
            this.robotManager.Add(robotR2);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Add(robotR2));
            Assert.That(() => this.robotManager.Add(robotR2),
                Throws.InvalidOperationException
                    .With.Message.EqualTo($"There is already a robot with name {robotR2.Name}!"));
        }

        [Test]
        public void RobotManager_TestRemove()
        {
            //Arrange
            this.robotManager = new RobotManager(10);
            var name = "R2";
            var maximumBattery = 20;
            var robotR2 = new Robot(name, maximumBattery);

            name = "Trip";
            maximumBattery = 20;
            var robotTrip = new Robot(name, maximumBattery);

            this.robotManager.Add(robotR2);
            this.robotManager.Add(robotTrip);

            //Act
            this.robotManager.Remove("R2");
            var expectedCount = 1;
            var actualCount = this.robotManager.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.That(robotManager.Count, Is.EqualTo(1));
        }

        [Test]
        [TestCase("R4")]
        public void RobotManager_TestRemove_ShouldThrowExceptionWhenTryRemoveMissingRobot(string name)
        {
            //Arrange
            this.robotManager = new RobotManager(10);
            var robotName = "R2";
            var maximumBattery = 20;
            var robotR2 = new Robot(robotName, maximumBattery);

            robotName = "Trip";
            maximumBattery = 20;
            var robotTrip = new Robot(robotName, maximumBattery);

            this.robotManager.Add(robotR2);
            this.robotManager.Add(robotTrip);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Remove(name));
            Assert.That(() => this.robotManager.Remove(name),
                Throws.InvalidOperationException
                    .With.Message.EqualTo($"Robot with the name {name} doesn't exist!"));
        }

        [Test]
        [TestCase("R4", "", 10)]
        public void RobotManager_TestWork_ShouldThrowExceptionWhenAtMissingRobot(string robotName, string job, int batteryUsage)
        {
            //Arrange
            this.robotManager = new RobotManager(10);
            var name = "R2";
            var maximumBattery = 20;
            var robotR2 = new Robot(name, maximumBattery);

            name = "Trip";
            maximumBattery = 20;
            var robotTrip = new Robot(name, maximumBattery);

            this.robotManager.Add(robotR2);
            this.robotManager.Add(robotTrip);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work(robotName, job, batteryUsage));
            Assert.That(() => this.robotManager.Work(robotName, job, batteryUsage),
                Throws.InvalidOperationException
                    .With.Message.EqualTo($"Robot with the name {robotName} doesn't exist!"));
        }

        [Test]
        [TestCase("R2", "", 50)]
        public void RobotManager_TestWork_ShouldThrowExceptionAtLowBatteryLevel(string robotName, string job, int batteryUsage)
        {
            //Arrange
            this.robotManager = new RobotManager(10);
            var name = "R2";
            var maximumBattery = 20;
            var robotR2 = new Robot(name, maximumBattery);

            name = "Trip";
            maximumBattery = 20;
            var robotTrip = new Robot(name, maximumBattery);

            this.robotManager.Add(robotR2);
            this.robotManager.Add(robotTrip);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work(robotName, job, batteryUsage));
            Assert.That(() => this.robotManager.Work(robotName, job, batteryUsage),
                Throws.InvalidOperationException
                    .With.Message.EqualTo($"{robotName} doesn't have enough battery!"));
        }

        [Test]
        [TestCase("R2", "", 10)]
        public void RobotManager_TestWork_ShouldDecreaseBatteryLevel(string robotName, string job, int batteryUsage)
        {
            //Arrange
            this.robotManager = new RobotManager(10);
            var name = "R2";
            var maximumBattery = 20;
            var robotR2 = new Robot(name, maximumBattery);

            name = "Trip";
            maximumBattery = 20;
            var robotTrip = new Robot(name, maximumBattery);

            this.robotManager.Add(robotR2);
            this.robotManager.Add(robotTrip);

            //Act
            var expectedBattery = 10;
            var actualBattery = robotR2.Battery - batteryUsage;
            this.robotManager.Work(robotName, job, batteryUsage);

            //Assert
            Assert.AreEqual(expectedBattery, actualBattery);
            Assert.That(robotR2.Battery, Is.EqualTo(10));

        }

        [Test]
        [TestCase("R4")]
        public void RobotManager_TestCharge_ShouldThrowExceptionWhenAtMissingRobot(string robotName)
        {
            //Arrange
            this.robotManager = new RobotManager(10);
            var name = "R2";
            var maximumBattery = 20;
            var robotR2 = new Robot(name, maximumBattery);

            name = "Trip";
            maximumBattery = 20;
            var robotTrip = new Robot(name, maximumBattery);

            this.robotManager.Add(robotR2);
            this.robotManager.Add(robotTrip);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Charge(robotName));
            Assert.That(() => this.robotManager.Charge(robotName),
                Throws.InvalidOperationException
                    .With.Message.EqualTo($"Robot with the name {robotName} doesn't exist!"));
        }

        [Test]
        [TestCase("R2")]
        public void RobotManager_TestCharge_ShouldIncreaseBatteryLevel(string robotName)
        {
            //Arrange
            this.robotManager = new RobotManager(10);
            var name = "R2";
            var maximumBattery = 20;
            var robotR2 = new Robot(name, maximumBattery);

            name = "Trip";
            maximumBattery = 20;
            var robotTrip = new Robot(name, maximumBattery);

            this.robotManager.Add(robotR2);
            this.robotManager.Work("R2", "clean", 10);
            this.robotManager.Add(robotTrip);
            this.robotManager.Work("Trip", "translate", 5);


            //Act
            this.robotManager.Charge(robotName);
            var expectedBattery = 20;
            var actualBattery = robotR2.MaximumBattery;

            //Assert
            Assert.AreEqual(expectedBattery, actualBattery);
            Assert.That(robotR2.Battery, Is.EqualTo(20));
        }

    }
}
