using NUnit.Framework;

namespace Tests
{
    using System;
    using FightingArena;

    public class WarriorTests
    {
        private Warrior warrior;
        [SetUp]
        public void Setup()
        {
            string name = "Master";
            int damage = 100;
            int hp = 100;

            warrior = new Warrior(name, damage, hp);
        }

        [Test]
        [TestCase(null, 100, 100)]
        [TestCase("", 100, 100)]
        [TestCase("Master", 0, 100)]
        [TestCase("Master", -10, 100)]
        [TestCase("Master", 100, -10)]
        public void Warrior_TestConstructor_ShouldExceptionAtInvalidProperty(string name, int damage, int hp)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Master", 100, 100)]
        public void Warrior_TestConstructor_ShouldSetPropertyAtValidData(string name, int damage, int hp)
        {
            //Act
            string expectedName = name;
            int expectedDamage = damage;
            int expectedHP = hp;

            //Assert
            Assert.AreEqual(expectedName, this.warrior.Name);
            Assert.AreEqual(expectedDamage, this.warrior.Damage);
            Assert.AreEqual(expectedHP, this.warrior.HP);
        }

        [Test]
        [TestCase("Master", 100, 10)]
        public void Warrior_TestAttack_ShouldExceptionWhenTryToAttackWithHPLowerThanMin(string name, int damage, int hp)
        {
            //Arrange
            Warrior attackedWarrior = new Warrior(name, damage, hp);

            //Assert
            Assert.That(() => attackedWarrior.Attack(this.warrior),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        [TestCase("Target", 100, 10)]
        public void Warrior_TestAttack_ShouldExceptionWhenTryToAttackTargetWithHPLowerThanMin(string name, int damage, int hp)
        {
            //Arrange
            const int MIN_HP = 30;
            Warrior targetWarrior = new Warrior(name, damage, hp);

            //Assert
            Assert.That(() => this.warrior.Attack(targetWarrior),
                Throws.InvalidOperationException
                    .With.Message.EqualTo($"Enemy HP must be greater than {MIN_HP} in order to attack him!"));
        }

        [Test]
        [TestCase("Master", 100, 50)]
        public void Warrior_TestAttack_ShouldExceptionWhenTryToAttackStrongerWarrior(string name, int damage, int hp)
        {
            //Arrange
            Warrior attackedWarrior = new Warrior(name, damage, hp);

            //Assert
            Assert.That(() => attackedWarrior.Attack(this.warrior),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        [TestCase("Target", 50, 50)]
        public void Warrior_TestAttack_ShouldDecreaseHPAtSuccessAttack(string name, int damage, int hp)
        {
            //Arrange
            Warrior targetWarrior = new Warrior(name, damage, hp);

            //Act
            int expectedHP = this.warrior.HP - damage;
            this.warrior.Attack(targetWarrior);

            //Assert
            Assert.AreEqual(expectedHP, this.warrior.HP);
        }

        [Test]
        [TestCase("Target", 50, 50)]
        [TestCase("Target", 50, 150)]
        public void Warrior_TestAttack_ShouldDecreaseTargetHPAtSuccessAttack(string name, int damage, int hp)
        {
            //Arrange
            Warrior targetWarrior = new Warrior(name, damage, hp);

            //Act
            int expectedHP = this.warrior.HP - damage;
            this.warrior.Attack(targetWarrior);

            //Assert
            Assert.AreEqual(expectedHP, this.warrior.HP);
        }
    }
}