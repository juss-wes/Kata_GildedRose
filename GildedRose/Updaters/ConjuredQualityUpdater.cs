using GildedRose.Interfaces;

namespace GildedRose.Updaters
{
    /// <summary>
    /// Class to handle the quality of "conjured" items
    /// </summary>
    public class ConjuredQualityUpdater : IQualityUpdater
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn--;

            if (item.Quality <= 0)
            {
                return;
            }
            else
            {
                if (item.Quality - (item.SellIn < 0 ? 4 : 2) <= 0)
                    item.Quality = 0;
                else
                    item.Quality -= item.SellIn < 0 ? 4 : 2;
            }
        }
    }
}
