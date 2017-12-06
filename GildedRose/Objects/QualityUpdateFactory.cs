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
            if (name == "Sulfuras, Hand of Ragnaros")
            {
                return new DoNothingQualityUpdater();
            }
            else if (name == "Aged Brie")
            {
                return new AgedBrieQualityUpdater();
            }
            else if (name == "Backstage passes to a Pentatonix concert")
            {
                return new BackstagePassesQualityUpdater();
            }
            else if (name.Contains("Conjured"))
            {
                return new ConjuredQualityUpdater();
            }
            else
            {
                return new StandardQualityUpdater();
            }
        }
    }
}
