using GildedRose.Interfaces;
using GildedRose.Updaters;

namespace GildedRose.Objects
{
    /// <summary>
    /// Factory to provide the correct updater for item quality
    /// </summary>
    public class QualityUpdateFactory : IQualityUpdateFactory
    {
        public IQualityUpdater Create(string name)
        {
            var conjured = name.StartsWith("Conjured");

            if (name.ToLower().Contains("sulfuras"))
            {
                return new DoNothingQualityUpdater(conjured);
            }
            else if (name.ToLower().Contains("aged brie"))
            {
                return new AgedBrieQualityUpdater(conjured);
            }
            else if (name.ToLower().Contains("backstage passes"))
            {
                return new BackstagePassesQualityUpdater(conjured);
            }
            else
            {
                return new StandardQualityUpdater(conjured);
            }
        }
    }
}
