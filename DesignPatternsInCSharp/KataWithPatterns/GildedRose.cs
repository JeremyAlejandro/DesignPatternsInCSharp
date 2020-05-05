﻿using System.Collections.Generic;

namespace DesignPatternsInCSharp.KataWithPatterns
{
    /// <summary>
    /// Source: https://github.com/emilybache/GildedRose-Refactoring-Kata/tree/master/csharpcore
    /// Instructions: https://github.com/ardalis/kata-catalog/blob/master/katas/Gilded%20Rose.md
    /// Cannot change the Items collection
    /// </summary>
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateSulfuras(ItemProxy item)
        {
            // do nothing
        }

        public void UpdateAgedBrie(ItemProxy item)
        {
            item.IncrementQuality();
            item.DecrementSellIn();
            if (item.SellIn < 0)
            {
                item.IncrementQuality();
            }
        }

        public void UpdateBackstagePasses(ItemProxy item)
        {
            item.IncrementQuality();
            if (item.SellIn < 11)
            {
                item.IncrementQuality();
            }

            if (item.SellIn < 6)
            {
                item.IncrementQuality();
            }
            item.DecrementSellIn();
            if (item.SellIn < 0)
            {
                item.ResetQuality();
            }
        }
        public void UpdateQuality(ItemProxy item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                UpdateSulfuras(item);
                return;
            }
            if (item.Name == "Aged Brie")
            {
                UpdateAgedBrie(item);
                return;
            }
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                UpdateBackstagePasses(item);
                return;
            }
            item.DecrementQuality();

            item.DecrementSellIn();

            if (item.SellIn < 0)
            {
                item.DecrementQuality();
            }
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateQuality(new ItemProxy(Items[i]));
            }
        }
    }
}
