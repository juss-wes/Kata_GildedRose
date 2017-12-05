using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class GildedRoseTests
    {
        // NOTE: Sample test to test quality updates
        [TestMethod]
        public void foo()
        {
            // Arrange the item and app
            var Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new GildedRose(Items);

            // Act on the data
            app.UpdateQuality();

            // Assert the expected result
            Assert.AreEqual("fixme", Items[0].Name);
            Assert.AreEqual(Items[0].Quality, 0);
        }
    }
}
