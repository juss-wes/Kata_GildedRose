using GildedRose.Interfaces;

namespace GildedRose.Updaters
{
    /// <summary>
    /// Class to handle standard quality degredation
    /// </summary>
    public class StandardQualityUpdater : IQualityUpdater
    {
        private bool _conjured { get; }

        public StandardQualityUpdater(bool conjured = false)
        {
            _conjured = conjured;
        }

        public void UpdateQuality(Item item)
        {
            item.SellIn--;
            var qualityChange = 0;

            if (item.SellIn < 0)
                qualityChange = -2;
            else
                qualityChange = -1;

            // Double the change due to a "conjured" item
            if (_conjured)
                qualityChange *= 2;

            if (item.Quality + qualityChange <= 0)
                item.Quality = 0;
            else
                item.Quality += qualityChange;
        }
    }
}
