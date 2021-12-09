// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using Entities;

    [TestFixture]
	public class StageTests
	{
		private Song song;
		private Performer performer;
		private Stage stage;

		[SetUp]
		public void SetUp()
		{
			this.stage = new Stage();
		}

		[Test]
	    public void Song_TestConstructor()
	    {
		    //Arrange
		    var name = "New Song";
		    var duration = new TimeSpan(2, 14, 18);

			this.song = new Song(name, duration);
		    
			//Act
		    var expectedName = name;
		    var actualName = song.Name;
		    var expectedDuration = duration;
		    var actualDuration = this.song.Duration;

			//Assert
			Assert.AreEqual(expectedName, actualName);
			Assert.AreEqual(expectedDuration, actualDuration);
		}
	    
		[Test]
		[TestCase("First", "Last", 22)]
	    public void Performer_TestConstructor(string firstName, string lastName, int age)
	    {
			//Arrange
		    this.performer = new Performer(firstName, lastName, age);
		    
			//Act
		    var expectedFullName = firstName + " " + lastName;
		    var actualFullName = this.performer.FullName;
		    var expectedAge = age;
		    var actualAge = this.performer.Age;

			//Assert
			Assert.AreEqual(expectedFullName, actualFullName);
			Assert.AreEqual(expectedAge, actualAge);
			Assert.IsNotNull(this.performer.SongList);
		}

	    [Test]
	    public void Stage_TestConstructor()
	    {
		    //Assert
		    Assert.IsNotNull(this.stage.Performers);
	    }
	    
	    [Test]
	    [TestCase("First", "Last", 10)]
	    public void Stage_TestAddPerformer_ShouldThrowExceptionAtYoungerPerformerThan18(string firstName, string lastName, int age)
	    {
			//Act
		    this.performer = new Performer(firstName, lastName, age);

			//Assert
			Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(performer), 
				"You can only add performers that are at least 18.");
			Assert.That(() => this.stage.AddPerformer(performer), 
				Throws.ArgumentException
					.With.Message.EqualTo("You can only add performers that are at least 18."));
	    }

	    [Test]
	    [TestCase("First", "Last", 22)]
	    public void Stage_TestAddPerformer_ShouldIncreasePerformersCount(string firstName, string lastName, int age)
	    {
			//Arrange
		    this.performer = new Performer(firstName, lastName, age);
			this.stage.AddPerformer(this.performer);

		    //Act
		    var expectedCount = 1;
		    var actualCount = this.stage.Performers.Count;

		    //Assert
			Assert.AreEqual(expectedCount, actualCount);
			Assert.That(stage.Performers.First().FullName, Is.EqualTo(this.performer.FullName));
	    }

	    [Test]
	    public void Stage_TestAddPerformer_ShouldThrowExceptionAtNullValue()
	    {
			//Assert
			Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(null),
				"Can not be null!");
	    }

		[Test]
	    public void Stage_TestAddSong_ShouldThrowsExceptionAtShortestSongThan1min()
	    {
		    //Arrange
		    var name = "New Song";
		    var duration = new TimeSpan(0, 0, 50);

		    this.song = new Song(name, duration);

			//Act

			//Assert
			Assert.Throws<ArgumentException>(() => this.stage.AddSong(this.song),
				"You can only add songs that are longer than 1 minute.");
			Assert.That(() => this.stage.AddSong(this.song),
				Throws.ArgumentException
					.With.Message.EqualTo("You can only add songs that are longer than 1 minute."));
	    }
	    [Test]
	    public void Stage_TestAddSong_ShouldThrowExceptionAtNullValue()
	    {
		    //Assert
		    Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(null),
			    "Can not be null!");
	    }

	    [Test]
	    public void Stage_TestAddSongToPerformer_ShouldThrowExceptionAtNullSongName()
	    {
		    //Assert
		    Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(null, "performerName"),
			    "Can not be null!");
	    }

	    [Test]
	    public void Stage_TestAddSongToPerformer_ShouldThrowExceptionAtNullPerformerName()
	    {
		    //Assert
		    Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer("songName", null),
			    "Can not be null!");
	    }

	    [Test]
	    public void Stage_TestGetPerformer_ShouldThrowExceptionAtMissingPerformerName()
	    {
			//Arrange
			var firstPerformer = new Performer("Dua", "Lipa", 25);
			var secondPerformer = new Performer("Ariana", "Grande", 22);
			this.stage.AddPerformer(firstPerformer);
			this.stage.AddPerformer(secondPerformer);
			var firstSong = new Song("Levitating", new TimeSpan(0, 3, 54));
			var secondSong = new Song("Positions", new TimeSpan(0, 2, 58));
			this.stage.AddSong(firstSong);
			this.stage.AddSong(secondSong);

			//Assert
			Assert.Throws<ArgumentException>(() => this.stage.AddSongToPerformer("Levitating", "Bruno Mars"),
				"There is no performer with this name.");
			Assert.That(() => this.stage.AddSongToPerformer("Levitating", "Bruno Mars"),
				Throws.ArgumentException
					.With.Message.EqualTo("There is no performer with this name."));
	    }

	    [Test]
	    public void Stage_TestGetSong_ShouldThrowExceptionAtMissingSongName()
	    {
			//Arrange
			var firstPerformer = new Performer("Dua", "Lipa", 25);
			var secondPerformer = new Performer("Ariana", "Grande", 22);
			this.stage.AddPerformer(firstPerformer);
			this.stage.AddPerformer(secondPerformer);
			var firstSong = new Song("Levitating", new TimeSpan(0, 3, 54));
			var secondSong = new Song("Positions", new TimeSpan(0, 2, 58));
			this.stage.AddSong(firstSong);
			this.stage.AddSong(secondSong);

			//Assert
			Assert.Throws<ArgumentException>(() => this.stage.AddSongToPerformer("Blinding Lights", "Dua Lipa"),
				"There is no song with this name.");
			Assert.That(() => this.stage.AddSongToPerformer("Blinding Lights", "Dua Lipa"),
				Throws.ArgumentException
					.With.Message.EqualTo("There is no song with this name."));
		}

		[Test]
	    public void Stage_TestAddSongToPerformer_()
	    {
			//Arrange
			var firstPerformer = new Performer("Dua", "Lipa", 25);
			var secondPerformer = new Performer("Ariana", "Grande", 22);
			this.stage.AddPerformer(firstPerformer);
			this.stage.AddPerformer(secondPerformer);
			var firstSong = new Song("Levitating", new TimeSpan(0, 3, 54));
			var secondSong = new Song("Positions", new TimeSpan(0, 2, 58));
			this.stage.AddSong(firstSong);
			this.stage.AddSong(secondSong);

			//Act
			this.stage.AddSongToPerformer("Levitating", "Dua Lipa");
			var actualSongsCount = this.stage.Performers.First(p => p.FullName == "Dua Lipa").SongList.Count;
			var expectedMessage = $"Levitating (03:54) will be performed by Dua Lipa";
			var actualMessage = this.stage.AddSongToPerformer("Levitating", "Dua Lipa");

			//Assert
			Assert.That(actualSongsCount == 1);
			Assert.That(firstPerformer.SongList.First().Name == "Levitating");
			Assert.That(this.stage.Performers.First(p => p.FullName == "Dua Lipa").FullName == firstPerformer.FullName);
			Assert.AreEqual(expectedMessage, actualMessage);
	    }

		[Test]
	    public void Stage_TestPlay_ShouldIncreasaeSongsCountAtPerformerSongList()
	    {
			//Arrange
			var firstPerformer = new Performer("Dua", "Lipa", 25);
			var secondPerformer = new Performer("Ariana", "Grande", 22);
			this.stage.AddPerformer(firstPerformer);
			this.stage.AddPerformer(secondPerformer);
			var firstSong = new Song("Levitating", new TimeSpan(0, 3, 54));
			var secondSong = new Song("Positions", new TimeSpan(0, 2, 58));
			this.stage.AddSong(firstSong);
			this.stage.AddSong(secondSong);
			
			//Act
			this.stage.AddSongToPerformer("Levitating", "Dua Lipa");
			
			var expectedMessage = "2 performers played 1 songs"; ;
			var actualMessage = this.stage.Play();

			//Assert
			Assert.AreEqual(expectedMessage, actualMessage);
	    }


	}
}