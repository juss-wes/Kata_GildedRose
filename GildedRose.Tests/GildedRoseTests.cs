using GildedRose.Objects;
using GildedRose.Updaters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class GildedRoseTests
    {
        [TestMethod]
        public void QualityFactorySelector_DoNothingUpdater()
        {
            // Arrange
            var factory = new QualityUpdateFactory();

            // Act
            var updater = factory.Create("Sulfuras, Hand of Ragnaros");

            // Assert
            Assert.AreEqual(updater.GetType(),typeof(DoNothingQualityUpdater));
        }

        [TestMethod]
        public void QualityFactorySelector_AgedBrieUpdater()
        {
            // Arrange
            var factory = new QualityUpdateFactory();

            // Act
            var updater = factory.Create("Aged Brie");

            // Assert
            Assert.AreEqual(updater.GetType(), typeof(AgedBrieQualityUpdater));
        }

        [TestMethod]
        public void QualityFactorySelector_BackstagePassUpdater()
        {
            // Arrange
            var factory = new QualityUpdateFactory();

            // Act
            var updater = factory.Create("Backstage passes to a Pentatonix concert");

            // Assert
            Assert.AreEqual(updater.GetType(), typeof(BackstagePassesQualityUpdater));
        }

        [TestMethod]
        public void QualityFactorySelector_ConjuredItemUpdater()
        {
            // Arrange
            var factory = new QualityUpdateFactory();

            // Act
            var updater = factory.Create("Conjured item");

            // Assert
            Assert.AreEqual(updater.GetType(), typeof(ConjuredQualityUpdater));
        }

        [TestMethod]
        public void QualityFactorySelector_StandardUpdater()
        {
            // Arrange
            var factory = new QualityUpdateFactory();

            // Act
            var updater = factory.Create("Some item");

            // Assert
            Assert.AreEqual(updater.GetType(), typeof(StandardQualityUpdater));
        }

        [TestMethod]
        public void StandardQualityUpdater_UpdateQuality()
        {
            // Arrange
            var updater = new StandardQualityUpdater();
            var item = new Item { Name = "Some item", SellIn = 10, Quality = 42 };

            // Act
            updater.UpdateQuality(item);

            // Assert
            Assert.AreEqual(item.Name, "Some item");
            Assert.AreEqual(item.SellIn, 9);
            Assert.AreEqual(item.Quality, 41);
        }

        [TestMethod]
        public void StandardQualityUpdater_UpdateQuality_Expired()
        {
            // Arrange
            var updater = new StandardQualityUpdater();
            var item = new Item { Name = "Some item", SellIn = -5, Quality = 8 };

            // Act
            updater.UpdateQuality(item);

            // Assert
            Assert.AreEqual(item.Name, "Some item");
            Assert.AreEqual(item.SellIn, -6);
            Assert.AreEqual(item.Quality, 6);
        }

        [TestMethod]
        public void StandardQualityUpdater_UpdateQuality_MinQuality()
        {
            // Arrange
            var updater = new StandardQualityUpdater();
            var item = new Item { Name = "Some item", SellIn = -5, Quality = 0 };

            // Act
            updater.UpdateQuality(item);

            // Assert
            Assert.AreEqual(item.Name, "Some item");
            Assert.AreEqual(item.SellIn, -6);
            Assert.AreEqual(item.Quality, 0);
        }

        [TestMethod]
        public void DoNothingQualityUpdater_UpdateQuality()
        {
            // Arrange
            var updater = new DoNothingQualityUpdater();
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };

            // Act
            updater.UpdateQuality(item);

            // Assert
            Assert.AreEqual(item.Name, "Sulfuras, Hand of Ragnaros");
            Assert.AreEqual(item.SellIn, 10);
            Assert.AreEqual(item.Quality, 80);
        }

        [TestMethod]
        public void AgedBrieUpdater_UpdateQuality()
        {
            // Arrange
            var updater = new AgedBrieQualityUpdater();
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 42 };

            // Act
            updater.UpdateQuality(item);

            // Assert
            Assert.AreEqual(item.Name, "Aged Brie");
            Assert.AreEqual(item.SellIn, 9);
            Assert.AreEqual(item.Quality, 43);
        }

        [TestMethod]
        public void AgedBrieUpdater_UpdateQuality_MaxQuality()
        {
            // Arrange
            var updater = new AgedBrieQualityUpdater();
            var item = new Item { Name = "Aged Brie", SellIn = -5, Quality = 50 };

            // Act
            updater.UpdateQuality(item);

            // Assert
            Assert.AreEqual(item.Name, "Aged Brie");
            Assert.AreEqual(item.SellIn, -6);
            Assert.AreEqual(item.Quality, 50);
        }

        [TestMethod]
        public void BackstagePassUpdater_UpdateQuality()
        {
            // Arrange
            var updater = new BackstagePassesQualityUpdater();
            var item = new Item { Name = "Backstage passes to a Pentatonix concert", SellIn = 25, Quality = 20 };

            // Act
            updater.UpdateQuality(item);

            // Assert
            Assert.AreEqual(item.Name, "Backstage passes to a Pentatonix concert");
            Assert.AreEqual(item.SellIn, 24);
            Assert.AreEqual(item.Quality, 21);
        }

        [TestMethod]
        public void BackstagePassUpdater_UpdateQuality_Below10()
        {
            // Arrange
            var updater = new BackstagePassesQualityUpdater();
            var item = new Item { Name = "Backstage passes to a Pentatonix concert", SellIn = 9, Quality = 30 };

            // Act
            updater.UpdateQuality(item);

            // Assert
            Assert.AreEqual(item.Name, "Backstage passes to a Pentatonix concert");
            Assert.AreEqual(item.SellIn, 8);
            Assert.AreEqual(item.Quality, 32);
        }

        [TestMethod]
        public void BackstagePassUpdater_UpdateQuality_Below5()
        {
            // Arrange
            var updater = new BackstagePassesQualityUpdater();
            var item = new Item { Name = "Backstage passes to a Pentatonix concert", SellIn = 3, Quality = 42 };

            // Act
            updater.UpdateQuality(item);

            // Assert
            Assert.AreEqual(item.Name, "Backstage passes to a Pentatonix concert");
            Assert.AreEqual(item.SellIn, 2);
            Assert.AreEqual(item.Quality, 45);
        }

        [TestMethod]
        public void BackstagePassUpdater_UpdateQuality_PastDate()
        {
            // Arrange
            var updater = new BackstagePassesQualityUpdater();
            var item = new Item { Name = "Backstage passes to a Pentatonix concert", SellIn = -1, Quality = 45 };

            // Act
            updater.UpdateQuality(item);

            // Assert
            Assert.AreEqual(item.Name, "Backstage passes to a Pentatonix concert");
            Assert.AreEqual(item.SellIn, -2);
            Assert.AreEqual(item.Quality, 0);
        }

        [TestMethod]
        public void BackstagePassUpdater_UpdateQuality_MaxQuality()
        {
            // Arrange
            var updater = new BackstagePassesQualityUpdater();
            var item = new Item { Name = "Backstage passes to a Pentatonix concert", SellIn = 5, Quality = 50 };

            // Act
            updater.UpdateQuality(item);

            // Assert
            Assert.AreEqual(item.Name, "Backstage passes to a Pentatonix concert");
            Assert.AreEqual(item.SellIn, 4);
            Assert.AreEqual(item.Quality, 50);
        }

        [TestMethod]
        public void ConjuredUpdater_UpdateQuality()
        {
            // Arrange
            var updater = new ConjuredQualityUpdater();
            var item = new Item { Name = "Conjured item", SellIn = 25, Quality = 40 };

            // Act
            updater.UpdateQuality(item);

            // Assert
            Assert.AreEqual(item.Name, "Conjured item");
            Assert.AreEqual(item.SellIn, 24);
            Assert.AreEqual(item.Quality, 38);
        }

        [TestMethod]
        public void ConjuredUpdater_UpdateQuality_Expired()
        {
            // Arrange
            var updater = new ConjuredQualityUpdater();
            var item = new Item { Name = "Conjured item", SellIn = -4, Quality = 15 };

            // Act
            updater.UpdateQuality(item);

            // Assert
            Assert.AreEqual(item.Name, "Conjured item");
            Assert.AreEqual(item.SellIn, -5);
            Assert.AreEqual(item.Quality, 11);
        }
    }
}
