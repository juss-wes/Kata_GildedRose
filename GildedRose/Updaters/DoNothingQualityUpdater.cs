using GildedRose.Interfaces;

namespace GildedRose.Updaters
{
    /// <summary>
    /// Class to handle no quality update over time
    /// </summary>
    public class DoNothingQualityUpdater : IQualityUpdater
    {
        private bool _conjured { get; }

        public DoNothingQualityUpdater(bool conjured = false)
        {
            _conjured = conjured;
        }

        public void UpdateQuality(Item item)
        {
            return;
        }
    }
}
