using GildedRose.Interfaces;

namespace GildedRose.Updaters
{
    /// <summary>
    /// Class to handle the quality of "aged brie"
    /// </summary>
    public class AgedBrieQualityUpdater : IQualityUpdater
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn--;

            if (item.Quality >= 50)
            {
                return;
            }
            else
            {
                item.Quality += 1;
            }
        }
    }
}
