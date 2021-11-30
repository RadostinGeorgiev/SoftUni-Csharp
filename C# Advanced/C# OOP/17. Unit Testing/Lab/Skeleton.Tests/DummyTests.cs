using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int DummyHealth = 10;
    private const int DummyHealthAfterAttack = 5;
    private const int DummyHealthDead = 0;
    private const int DummyExperience = 10;
    private const int DummyAttackPoints = 5;

    private Dummy dummyAlive;
    private Dummy dummyDead;

    [SetUp]
    public void BaseSetup()
    {
        this.dummyAlive = new Dummy(DummyHealth, DummyExperience);
        dummyDead = new Dummy(DummyHealthDead, DummyExperience);
    }

    [Test]
    public void DummyHealth_TestHealth_ShouldLoseHealthAtAttack()
    {
        dummyAlive.TakeAttack(DummyAttackPoints);

        Assert.That(dummyAlive.Health, Is.EqualTo(DummyHealthAfterAttack), "Dummy doesn't change his health at attack.");
    }
    [Test]
    public void DummyIsDead_TestTakeAttack_ShouldThrowException()
    {
        Assert.That(() => dummyDead.TakeAttack(DummyAttackPoints), 
            Throws.InvalidOperationException
                .With.Message.EqualTo("Dummy is dead."));
    }
    [Test]
    public void DummyExperience_TestGiveExperience_DeadDummyShouldGiveXp()
    {
        dummyDead.GiveExperience();

        Assert.That(dummyDead.GiveExperience(), Is.EqualTo(DummyExperience), "Dead Dummy doesn't give experience.");
    }

    [Test]
    public void DummyIsDead_TestGiveExperience_AliveDummyShouldThrowException()
    {
        Assert.That(() => dummyAlive.GiveExperience(),
            Throws.InvalidOperationException
                .With.Message.EqualTo("Target is not dead."));
    }

    [Test]
    public void DummyIsDead_ShoudReturnFalseWhenHealthIsPositive()
    {
        Assert.False(dummyAlive.Health <= 0);
    }
}
