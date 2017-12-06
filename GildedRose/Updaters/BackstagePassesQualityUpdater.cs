using GildedRose.Interfaces;

namespace GildedRose.Updaters
{
    /// <summary>
    /// Class to handle the quality of a "backstage pass"
    /// </summary>
    public class BackstagePassesQualityUpdater : IQualityUpdater
    {
        public void UpdateQuality(Item item)
        {
            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
            else if (item.SellIn <= 5)
            {
                if (item.Quality + 3 >= 50)
                    item.Quality = 50;
                else
                    item.Quality += 3;
            }
            else if (item.SellIn <= 10)
            {
                if (item.Quality + 2 >= 50)
                    item.Quality = 50;
                else
                    item.Quality += 2;
            }
            else
            {
                if (item.Quality + 1 >= 50)
                    item.Quality = 50;
                else
                    item.Quality += 1;
            }
        }
    }
}
