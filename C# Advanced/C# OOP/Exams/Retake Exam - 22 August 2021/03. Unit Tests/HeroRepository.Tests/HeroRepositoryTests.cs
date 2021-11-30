using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    [TestCase("Hero", 10)]
    [TestCase("", 10)]
    [TestCase(null, 10)]
    [TestCase("Hero", 0)]
    [TestCase("Hero", -10)]
    public void Hero_TestConstructor(string name, int level)
    {
        //Arrange
        Hero hero = new Hero(name, level);

        //Act
        var expectedName = name;
        var expectedLevel = level;
        var actualName = hero.Name;
        var actualLevel = hero.Level;

        //Assert
        Assert.AreEqual(expectedName, actualName);
        Assert.AreEqual(expectedLevel, actualLevel);
    }

    [Test]
    public void HeroRepository_TestConstructor()
    {
        //Arrange
        var heroes = new HeroRepository();

        //Assert
        Assert.IsNotNull(heroes);
    }

    [Test]
    public void HeroRepository_TestCreate_ShouldThrowArgumentExceptionAtNullHero()
    {
        //Arrange
        var data = new HeroRepository();

        //Act
        Hero hero = null;

        //Assert
        Assert.Throws<ArgumentNullException>(() => data.Create(hero));
    }

    [Test]
    public void HeroRepository_TestCreate_ShouldThrowExceptionWhenTryAddExistingHero()
    {
        //Arrange
        var data = new HeroRepository();

        var name = "Droid";
        var level = 10;
        var heroDroid = new Hero(name, level);

        name = "Droid";
        level = 20;
        var heroMasterDroid = new Hero(name, level);

        //Act
        data.Create(heroDroid);

        //Assert
        Assert.That(() => data.Create(heroMasterDroid),
            Throws.InvalidOperationException
                .With.Message.EqualTo($"Hero with name {heroMasterDroid.Name} already exists"));
    }

    [Test]
    [TestCase("")]
    [TestCase(null)]
    public void HeroRepository_TestRemove_ShouldThrowExceptionWhenTryRemoveMissingHero(string name)
    {
        //Arrange
        var data = new HeroRepository();

        var heroName = "Droid";
        var level = 10;
        var heroDroid = new Hero(heroName, level);

        heroName = "Master Droid";
        level = 20;
        var heroMasterDroid = new Hero(heroName, level);

        data.Create(heroDroid);
        data.Create(heroMasterDroid);

        //Act

        //Assert
        Assert.Throws<ArgumentNullException>(() => data.Remove(name));
    }

    [Test]
    [TestCase("Droid")]
    public void HeroRepository_TestRemove_ShouldDecreaseCount(string name)
    {
        //Arrange
        var data = new HeroRepository();

        var heroName = "Droid";
        var level = 10;
        var heroDroid = new Hero(heroName, level);

        heroName = "Master Droid";
        level = 20;
        var heroMasterDroid = new Hero(heroName, level);

        data.Create(heroDroid);
        data.Create(heroMasterDroid);

        //Act
        data.Remove(name);
        var expectedCount = 1;
        var actualCount = data.Heroes.Count;

        //Assert
        Assert.AreEqual(expectedCount, actualCount);
    }

    [Test]
    public void HeroRepository_TestGetHeroWithHighestLevel()
    {
        //Arrange
        var data = new HeroRepository();

        var heroName = "Droid";
        var level = 10;
        var heroDroid = new Hero(heroName, level);

        heroName = "Master Droid";
        level = 20;
        var heroMasterDroid = new Hero(heroName, level);

        data.Create(heroDroid);
        data.Create(heroMasterDroid);

        //Act
        var expectedHeroName = "Master Droid";
        var actualHeroName = data.GetHeroWithHighestLevel().Name;

        //Assert
        Assert.AreEqual(expectedHeroName, actualHeroName);
    }

    [Test]
    [TestCase("Droid")]
    public void HeroRepository_TestGetHero(string name)
    {
        //Arrange
        var data = new HeroRepository();

        var heroName = "Droid";
        var level = 10;
        var heroDroid = new Hero(heroName, level);

        heroName = "Master Droid";
        level = 20;
        var heroMasterDroid = new Hero(heroName, level);

        data.Create(heroDroid);
        data.Create(heroMasterDroid);

        //Act
        var expectedHero = heroDroid;
        var actualHero = data.GetHero(name);
        
        //Assert
        Assert.AreEqual(expectedHero, actualHero);
    }

}