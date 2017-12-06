using GildedRose.Interfaces;

namespace GildedRose.Updaters
{
    /// <summary>
    /// Class to handle the quality of a "backstage pass"
    /// </summary>
    public class BackstagePassesQualityUpdater : IQualityUpdater
    {
        private bool _conjured { get; }

        public BackstagePassesQualityUpdater(bool conjured = false)
        {
            _conjured = conjured;
        }

        public void UpdateQuality(Item item)
        {
            item.SellIn--;
            var qualityChange = 0;

            if (item.SellIn < 0)
                item.Quality = 0;
            else if (item.SellIn <= 5)
                qualityChange = 3;
            else if (item.SellIn <= 10)
                qualityChange = 2;
            else
                qualityChange = 1;

            // Double the change due to a "conjured" item
            if (_conjured)
                qualityChange *= 2;
            
            if (item.Quality + qualityChange >= 50)
                item.Quality = 50;
            else
                item.Quality += qualityChange;
        }
    }
}
