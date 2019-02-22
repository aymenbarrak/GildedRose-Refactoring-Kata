using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
      {
         Console.WriteLine("OMGHAI!");

         IList<Item> Items = new List<Item>{

            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}, //Once the sell by date has passed, Quality degrades twice as fast (sellIn<Quality)
            new Item {Name = "+5 Dexterity Vest", SellIn = 31, Quality = 20}, //Once the sell by date has passed, Quality degrades twice as fast (sellIn>Quality)
            new Item {Name = "+5 Dexterity Vest", SellIn = 15, Quality = 15}, //Once the sell by date has passed, Quality degrades twice as fast (sellIn=Quality)
            new Item {Name = "+5 Dexterity Vest", SellIn = 15, Quality = 50}, //starts with uality 50,should be decreased
            
            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0}, //"Aged Brie" actually increases in Quality the older it gets (0 Quality)
            new Item {Name = "Aged Brie", SellIn = -1, Quality = 30}, //"Aged Brie" actually increases in Quality the older it gets (30 Quality)
            new Item {Name = "Aged Brie", SellIn = 0, Quality = 50}, //"Aged Brie" actually increases in Quality the older it gets (50 Quality)
            new Item {Name = "Aged Brie", SellIn = 31, Quality = 50}, //"Aged Brie" actually increases in Quality the older it gets (50 Quality unchanged)
            new Item {Name = "Aged Brie", SellIn = 10, Quality = 40}, //"Aged Brie" actually increases in Quality the older it gets (10 Quality stops at 50)
            
            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},// Quality never 0
                        
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80}, //unchanged
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 52}, //unchanged
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 31, Quality = 0}, //unchanged
            
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15,Quality = 20}, //reach the 50
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 25,Quality = 20}, //doesn't reach the 50 (=35)
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert",SellIn = -1,Quality = 49}, //shoud be 0
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert",SellIn = 10,Quality = 49}, //shoud be 0
            new Item {Name = "Backstage passes to a TAFKAL80ETC concert",SellIn = 5,Quality = 49},  //shoud be 0            
            
            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}, //shoud reach 0 in 3 days
            new Item {Name = "Conjured Mana Cake", SellIn = -1, Quality = 6}, //shoud reach 0 in 2 days
            new Item {Name = "Conjured Mana Cake", SellIn = 30, Quality = 50} //shoud reach 0 in 25 days

            };

         var app = new GildedRose(Items);

         for (var i = 0; i < 31; i++)
         {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < Items.Count; j++)
            {
               System.Console.WriteLine(Items[j]);
            }
            Console.WriteLine("");
            app.UpdateQuality();
         }
      }
   }
}
