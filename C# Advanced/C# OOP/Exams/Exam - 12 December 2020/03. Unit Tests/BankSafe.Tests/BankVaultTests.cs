using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    using System.Linq;

    public class BankVaultTests
    {
        private BankVault vault;
        private Item itemOne;
        private Item itemTwo;

        [SetUp]
        public void Setup()
        {
            this.vault = new BankVault();
            this.itemOne = new Item("Owner", "123456");
            this.itemTwo = new Item("Different Owner", "234567");
        }

        [Test]
        [TestCase("Owner", "123456")]
        public void Item_TestConstructor(string owner, string itemId)
        {
            itemOne = new Item(owner, itemId);

            var expectedOwner = owner;
            var actualOwner = this.itemOne.Owner;
            var expectedId = itemId;
            var actualId = this.itemOne.ItemId;

            Assert.AreEqual(expectedOwner, actualOwner);
            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void BankVault_TestConstructor()
        {
            var expectedCount = 12;
            var actualCount = this.vault.VaultCells.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void BankVault_TestAddItem_SuccessfullyAdd()
        {
            this.vault.AddItem("A1", this.itemOne);

            var expectedValueId = this.itemOne.ItemId;
            var actualValueId = this.vault.VaultCells["A1"].ItemId;
            var expectedMessage = $"Item:123456 saved successfully!";
            var actualMessage = $"Item:{itemOne.ItemId} saved successfully!";

            Assert.AreEqual(expectedValueId, actualValueId);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void BankVault_TestAddItem_ShouldThrowExceptionAtMissingCell()
        {
            Assert.Throws<ArgumentException>(() => this.vault.AddItem("D1", this.itemOne), "Cell doesn't exists!");
            Assert.That(() => this.vault.AddItem("D1", this.itemOne),
                Throws.ArgumentException
                    .With.Message.EqualTo("Cell doesn't exists!"));
        }

        [Test]
        public void BankVault_TestAddItem_ShouldThrowExceptionAtTakenCell()
        {
            this.vault.AddItem("A1", this.itemOne);
            
            Assert.Throws<ArgumentException>(() => this.vault.AddItem("A1", this.itemTwo), "Cell is already taken!");
            Assert.That(() => this.vault.AddItem("A1", this.itemTwo),
                Throws.ArgumentException
                    .With.Message.EqualTo("Cell is already taken!"));
        }

        [Test]
        public void BankVault_TestAddItem_ShouldThrowExceptionAtExistingItem()
        {
            this.vault.AddItem("A1", this.itemOne);
            
            Assert.Throws<InvalidOperationException>(() => this.vault.AddItem("A2", this.itemOne), "Item is already in cell!");
            Assert.That(() => this.vault.AddItem("A2", this.itemOne),
                Throws.InvalidOperationException
                    .With.Message.EqualTo("Item is already in cell!"));
        }

        [Test]
        public void BankVault_TestRemoveItem_SuccessfullyRemove()
        {
            this.vault.AddItem("A1", this.itemOne);
            this.vault.AddItem("A2", this.itemTwo);

            this.vault.RemoveItem("A1", this.itemOne);
            var expectedCount = 1;
            var actualCount = this.vault.VaultCells.Count(c => c.Value != null);
            var expectedMessage = $"Remove item:123456 successfully!";
            var actualMessage = $"Remove item:{itemOne.ItemId} successfully!";

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [Test]
        public void BankVault_TestRemoveItem_ShouldThrowExceptionAtMissingCell()
        {
            Assert.Throws<ArgumentException>(() => this.vault.RemoveItem("D1", this.itemOne), "Cell doesn't exists!");
            Assert.That(() => this.vault.RemoveItem("D1", this.itemOne),
                Throws.ArgumentException
                    .With.Message.EqualTo("Cell doesn't exists!"));
        }

        [Test]
        public void BankVault_TestRemoveItem_ShouldThrowExceptionAtMissingItem()
        {
            this.vault.AddItem("A1", this.itemOne);
            
            Assert.Throws<ArgumentException>(() => this.vault.RemoveItem("A2", this.itemOne), "Item in that cell doesn't exists!");
            Assert.That(() => this.vault.RemoveItem("A2", this.itemOne),
                Throws.ArgumentException
                    .With.Message.EqualTo("Item in that cell doesn't exists!"));
        }

    }
}