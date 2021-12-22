namespace Gyms.Tests
{
    using System;
    using NUnit.Framework;

    public class GymsTests
    {
        private Gym gym;

        [Test]
        [TestCase("Athletics", 10)]
        [TestCase("Athletics", 0)]
        public void Gym_TestConstructors(string name, int size)
        {
            this.gym = new Gym(name, size);
            Athlete athlete = new Athlete("First Athlete");
            var expectedName = name;
            var actualName = gym.Name;
            var expectedCapacity = size;
            var actualCapacity = gym.Capacity;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedCapacity, actualCapacity);
            Assert.IsNotNull(gym);
            Assert.IsNotNull(athlete);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        [TestCase(null, 10)]
        [TestCase("", 10)]
        public void Gym_TestConstructor_ShouldThrowExceptionAtInvalidName(string name, int size)
        {
            Assert.Throws<ArgumentNullException>(() => gym = new Gym(name, size));
        }

        [Test]
        [TestCase("Athletics", -10)]
        public void Gym_TestConstructor_ShouldThrowExceptionAtInvalidCapacity(string name, int size)
        {
            Assert.Throws<ArgumentException>(() => gym = new Gym(name, size));
        }

        [Test]
        public void Gym_TestAddAthlete_AddSuccess()
        {
            Gym gym = new Gym("Athletics", 1);
            Athlete firstAthlete = new Athlete("First Athlete");

            gym.AddAthlete(firstAthlete);
            var expectedCount = 1;
            var actualCount = gym.Count;

            Assert.AreEqual(expectedCount, actualCount);
            Assert.IsNotNull(gym);
        }

        [Test]
        public void Gym_TestAddAthlete_ShouldThrowExceptionAtFullGym()
        {
            Gym gym = new Gym("Athletics", 1);
            Athlete firstAthlete = new Athlete("First Athlet");
            Athlete secondAthlete = new Athlete("Second Athlet");

            gym.AddAthlete(firstAthlete);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(secondAthlete));
        }

        [Test]
        public void Gym_TestRemoveAthlete_RemoveSuccess()
        {
            Gym gym = new Gym("Athletics", 10);
            Athlete firstAthlete = new Athlete("First Athlete");
            Athlete secondAthlete = new Athlete("Second Athlete");


            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);
            gym.RemoveAthlete("First Athlete");
            var expectedCount = 1;
            var actualCount = gym.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Gym_TestRemoveAthlete_ShouldThrowExceptionAtMissingAthlete()
        {
            Gym gym = new Gym("Athletics", 1);
            Athlete firstAthlete = new Athlete("First Athlete");
            Athlete secondAthlete = new Athlete("Second Athlete");

            gym.AddAthlete(firstAthlete);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Second Athlete"), 
                "The athlete Second Athlete doesn't exist.");
        }

        [Test]
        public void Gym_TestInjureAthleteAthlete_InjureAthleteSuccess()
        {
            Gym gym = new Gym("Athletics", 10);
            Athlete firstAthlete = new Athlete("First Athlete");
            Athlete secondAthlete = new Athlete("Second Athlete");


            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);
            gym.InjureAthlete("First Athlete");
            var expectedAthlete = firstAthlete;
            var actualAthlete = gym.InjureAthlete("First Athlete");

            Assert.IsTrue(firstAthlete.IsInjured);
            Assert.IsFalse(secondAthlete.IsInjured);
            Assert.AreSame(expectedAthlete, actualAthlete);
        }

        [Test]
        public void Gym_TestInjureAthlete_ShouldThrowExceptionAtMissingAthlete()
        {
            Gym gym = new Gym("Athletics", 1);
            Athlete firstAthlete = new Athlete("First Athlete");
            Athlete secondAthlete = new Athlete("Second Athlete");

            gym.AddAthlete(firstAthlete);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Second Athlete"), 
                "The athlete Second Athlete doesn't exist.");
        }

        [Test]
        public void Gym_TestReport()
        {
            Gym gym = new Gym("Athletics", 10);
            Athlete firstAthlete = new Athlete("First Athlete");
            Athlete secondAthlete = new Athlete("Second Athlete");


            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);
            gym.InjureAthlete("Second Athlete");
            var expectedMessage = $"Active athletes at Athletics: First Athlete";
            var actualMessage = gym.Report();

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}