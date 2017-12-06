using System.Collections.Generic;
using GildedRose.Interfaces;
using GildedRose.Objects;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> _items;
        IQualityUpdateFactory _qualityFactory;

        public GildedRose(IList<Item> Items)
        {
            _items = Items;
            _qualityFactory = new QualityUpdateFactory();
        }

        // Update the inventory item qualities
        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                var updater = _qualityFactory.Create(item.Name);
                updater.UpdateQuality(item);
            }
        }
    }
}