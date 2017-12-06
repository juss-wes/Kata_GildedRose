using GildedRose.Interfaces;

namespace GildedRose.Updaters
{
    /// <summary>
    /// Class to handle standard quality degredation
    /// </summary>
    public class StandardQualityUpdater : IQualityUpdater
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
                if (item.Quality - (item.SellIn < 0 ? 2 : 1) <= 0)
                    item.Quality = 0;
                else
                    item.Quality -= item.SellIn < 0 ? 2 : 1;
            }
        }
    }
}
