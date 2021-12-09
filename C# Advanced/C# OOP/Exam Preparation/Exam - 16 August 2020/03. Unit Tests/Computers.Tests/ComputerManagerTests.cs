using NUnit.Framework;

namespace Computers.Tests
{
    using System;
    using System.Linq;

    public class Tests
    {
        private ComputerManager computerManager;
        private Computer desktop;
        private Computer laptop;

        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
            desktop = new Computer("HP", "Elite", 1045.5m);
            laptop = new Computer("Lenovo", "Yoga", 2300m);
        }

        [Test]
        public void ComputerManager_TestConstructor()
        {
            Assert.IsNotNull(this.computerManager.Computers);
        }

        [Test]
        public void ComputerManager_TestAddComputer_SuccessAdd()
        {
            this.computerManager.AddComputer(desktop);
            this.computerManager.AddComputer(this.laptop);

            var expectedCount = 2;
            var actualCount = this.computerManager.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ComputerManager_TestAddComputer_SuccessCreateCollection()
        {
            this.computerManager.AddComputer(desktop);
            this.computerManager.AddComputer(this.laptop);

            var expectedCollection = new Computer[] { this.desktop , this.laptop};
            var actualCollection = this.computerManager.Computers;

            Assert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void ComputerManager_TestAddComputer_ShouldThrowExceptionAtNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.AddComputer(null),
                "Can not be null!");
        }

        [Test]
        public void ComputerManager_TestTestAddComputer_ShouldThrowExceptionAtExistingModelAndManufacturer()
        {
            this.computerManager.AddComputer(desktop);

            Assert.Throws<ArgumentException>(() => this.computerManager.AddComputer(new Computer("HP", "Elite", 1300m)),
                "This computer already exists.");
        }

        [Test]
        public void ComputerManager_TestRemoveComputer_()
        {
            this.computerManager.AddComputer(desktop);
            this.computerManager.AddComputer(this.laptop);

            var expectedComputer = this.desktop;
            var actualComputer = this.computerManager.RemoveComputer("HP", "Elite");
            var expectedCount = 1;
            var actualCount = this.computerManager.Computers.Count;

            Assert.AreEqual(expectedComputer, actualComputer);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ComputerManager_TestRemoveComputer_ShouldThrowExceptionAtMissingModelOrManufacturer()
        {
            this.computerManager.AddComputer(desktop);

            Assert.Throws<ArgumentException>(() => this.computerManager.RemoveComputer("HP", "ProBook"),
                "There is no computer with this manufacturer and model.");
            Assert.Throws<ArgumentException>(() => this.computerManager.RemoveComputer("Acer", "1370"),
                "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void ComputerManager_TestGetComputer()
        {
            this.computerManager.AddComputer(desktop);
            this.computerManager.AddComputer(this.laptop);

            var expectedComputer = this.desktop;
            var actualComputer = this.computerManager.GetComputer("HP", "Elite");

            Assert.AreEqual(expectedComputer, actualComputer);

        }

        [Test]
        public void ComputerManager_TestGetComputer_ShouldThrowExceptionAtNullModelOrManufacturer()
        {
            this.computerManager.AddComputer(desktop);

            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputer(null, "Elite"));
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputer("HP", null));
        }

        [Test]
        public void ComputerManager_TestGetComputer_ShouldThrowExceptionAtMissingModelOrManufacturer()
        {
            this.computerManager.AddComputer(desktop);

            Assert.Throws<ArgumentException>(() => this.computerManager.GetComputer("HP", "ProBook"),
                "There is no computer with this manufacturer and model.");
            Assert.Throws<ArgumentException>(() => this.computerManager.GetComputer("Acer", "1370"),
                "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void ComputerManager_TestGetComputerByManufacturer_ShouldThrowExceptionAtNullManufacturer()
        {
            this.computerManager.AddComputer(desktop);
            this.computerManager.AddComputer(this.laptop);

            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void ComputerManager_TestGetComputerByManufacturer()
        {
            this.computerManager.AddComputer(desktop);
            this.computerManager.AddComputer(this.laptop);

            var expectedCount = 1;
            var actualCount = this.computerManager.GetComputersByManufacturer("HP").Count;
            var expectedCollection = new[] {this.desktop};
            var actualCollection = this.computerManager.GetComputersByManufacturer("HP").ToArray();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void ComputerManager_TestGetComputerByManufacturer_ShouldReturnEmptyCollection()
        {
            this.computerManager.AddComputer(desktop);
            this.computerManager.AddComputer(this.laptop);

            var actualCollection = this.computerManager.GetComputersByManufacturer("Apple").ToArray();

            Assert.IsEmpty(actualCollection);
        }
    }
}