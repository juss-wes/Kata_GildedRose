using GildedRose.Interfaces;

namespace GildedRose.Updaters
{
    /// <summary>
    /// Class to handle the quality of "aged brie"
    /// </summary>
    public class AgedBrieQualityUpdater : IQualityUpdater
    {
        private bool _conjured { get; }

        public AgedBrieQualityUpdater(bool conjured = false)
        {
            _conjured = conjured;
        }

        public void UpdateQuality(Item item)
        {
            item.SellIn--;
            var qualityChange = 1;

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
