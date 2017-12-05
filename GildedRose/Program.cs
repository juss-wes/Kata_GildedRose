using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Items in the inventory
            var Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a Pentatonix concert",
                    SellIn = 15,
                    Quality = 20
                },
				// TODO: This conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);

            // Loop through the days
            for (var i = 0; i < 31; i++)
            {
                PrintDailyQuality(Items, i);

                // Quality updated at the end of each day
                app.UpdateQuality();
            }

            Console.WriteLine("press any key to close...");
            Console.ReadKey();
        }

        internal static void PrintDailyQuality(List<Item> items, int day)
        {
            Console.WriteLine($"-------- day {day} --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine($"{items[j].Name}, {items[j].SellIn}, {items[j].Quality}");
            }
            Console.WriteLine("");
        }
    }
}
