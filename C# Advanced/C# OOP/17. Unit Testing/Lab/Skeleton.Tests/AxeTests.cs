using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AxeAttackPoints = 10;
    private const int AxeDurabilityPoints = 10;
    private const int AxeDurabilityPointsAfterAttack = 9;
    private const int AxeDurabilityPointsBrokenAxe = 0;
    private const int DummyHealth = 10;
    private const int DummyExperience = 10;

    private Axe axe;
    private Axe axeBroken;
    private Dummy dummy;

    [SetUp]
    public void BaseSetup()
    {
        axe = new Axe(AxeAttackPoints, AxeDurabilityPoints);
        axeBroken = new Axe(AxeAttackPoints, AxeDurabilityPointsBrokenAxe);
        dummy = new Dummy(DummyHealth, DummyExperience);
    }

    [Test]
    public void AxeAttack_TestLosingDurability()
    {
        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(AxeDurabilityPointsAfterAttack), "Axe durability doesn't change after attack.");
    }

    [Test]
    public void AxeAttack_TestWithBrokenWeapon_ShouldThrowException()
    {
        Assert.That(() => axeBroken.Attack(dummy), 
            Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
    }
}