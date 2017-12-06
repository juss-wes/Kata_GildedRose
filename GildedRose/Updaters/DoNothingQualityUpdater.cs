using GildedRose.Interfaces;

namespace GildedRose.Updaters
{
    /// <summary>
    /// Class to handle no quality update over time
    /// </summary>
    public class DoNothingQualityUpdater : IQualityUpdater
    {
        public void UpdateQuality(Item item)
        {
            return;
        }
    }
}
