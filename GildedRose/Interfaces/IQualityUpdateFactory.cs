namespace GildedRose.Interfaces
{
    /// <summary>
    /// Factory interface to determine the proper quality updater for an item
    /// </summary>
    public interface IQualityUpdateFactory
    {
        IQualityUpdater Create(string name);
    }
}
