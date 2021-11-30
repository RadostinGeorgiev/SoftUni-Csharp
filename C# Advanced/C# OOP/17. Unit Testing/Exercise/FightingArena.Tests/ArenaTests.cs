using NUnit.Framework;

namespace Tests
{
    using System;
    using FightingArena;

    public class ArenaTests
    {
        private Arena arena;
        private Warrior attackerWarrior;
        private Warrior defenderWarrior;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();

            string name = "Fighter";
            int damage = 100;
            int hp = 50;
            attackerWarrior = new Warrior(name, damage, hp);

            name = "Defender";
            damage = 50;
            hp = 100;
            defenderWarrior = new Warrior(name, damage, hp);
        }

        [Test]
        public void Arena_TestEnroll_ShouldThrowExceptionWhenTryEnrollWarriorWithSameName()
        {
            //Arrange
            arena = new Arena();

            string name = "Fighter";
            int damage = 100;
            int hp = 50;
            Warrior attackerWarrior = new Warrior(name, damage, hp);

            name = "Fighter";
            damage = 50;
            hp = 100;
            Warrior defenderWarrior = new Warrior(name, damage, hp);

            //Act
            this.arena.Enroll(attackerWarrior);


            //Assert
            Assert.That(() => this.arena.Enroll(defenderWarrior),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void Arena_TestCount()
        {
            //Arrange

            //Act
            this.arena.Enroll(attackerWarrior);
            this.arena.Enroll(defenderWarrior);

            var expectedCount = 2;
            var actualCount = this.arena.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Arena_TestWarriors()
        {
            //Arrange
            Warrior[] warriors = new[] { attackerWarrior, defenderWarrior };

            //Act
            this.arena.Enroll(attackerWarrior);
            this.arena.Enroll(defenderWarrior);

            var expectedCount = warriors.Length;
            var actualCount = this.arena.Warriors.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase("SomeFighter", "Defender")]
        [TestCase("Fighter", "SomeDefender")]
        public void Arena_TestFight_ShouldThrowExceptionWhenTryFightWithMissingWarrior(string attackerName, string targetName)
        {
            //Arrange
            this.arena.Enroll(attackerWarrior);
            this.arena.Enroll(defenderWarrior);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attackerName, targetName));
        }

        [Test]
        [TestCase("Fighter", "Defender")]
        public void Arena_TestFight_ShouldDecreaseHPBothWarriors(string attackerName, string targetName)
        {
            //Arrange
            this.arena.Enroll(attackerWarrior);
            this.arena.Enroll(defenderWarrior);

            //Act
            int expectedAttackerHP = this.attackerWarrior.HP - this.defenderWarrior.Damage;
            int expectedDefenderHP = this.defenderWarrior.HP - this.attackerWarrior.Damage;
            this.arena.Fight(attackerName, targetName);
            
            //Assert
            Assert.AreEqual(expectedAttackerHP, this.attackerWarrior.HP);
            Assert.AreEqual(expectedDefenderHP, this.defenderWarrior.HP);
        }
    }
}