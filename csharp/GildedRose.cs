using System.Collections.Generic;


namespace csharp
{
   public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

      public void UpdateQuality()
      {
         for (var i = 0; i < Items.Count; i++)
         {
            /*We do nothing for Sulfaras, so better get out from the beggining to imrpove performance */
            if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
            {
               continue;
            }

            /* idem for any item that has Quality of 0 and not aged brie*/
            if ((Items[i].Quality == 0 && Items[i].Name != "Aged Brie"))
            {
               Items[i].SellIn--;
               continue;
            }

            /*Always valid if we reached this place */
            Items[i].SellIn--;

            /* For Aged Brie increase the Quality */
            if (Items[i].Name == "Aged Brie")
            {
               Items[i].Quality += (Items[i].SellIn < 0 ? 2 : 1);

               Items[i].Quality = FixQuality(Items[i].Quality);
               continue;
            }

            /* This is for regular products and the "Conjured Mana Cake" */
            if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            {
               Items[i].Quality -= ((Items[i].Name == "Conjured Mana Cake")?2:1) * (Items[i].SellIn < 0 ? 2:1);

               Items[i].Quality = FixQuality(Items[i].Quality);
               continue;
            }

            /* Now handle the "Backstage passes to a TAFKAL80ETC concert"*/
            if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
            {
               /* For clarity purpose, let's make it in this way */
               if (Items[i].SellIn >= 0)
                  Items[i].Quality += ((Items[i].SellIn < 5) ? 3 : (Items[i].SellIn < 10 ? 2 : 1));
               else
                  Items[i].Quality = 0;

               /*Quality never exceed the 50 here */
               Items[i].Quality = FixQuality(Items[i].Quality);
            }
         }
      }

      private int FixQuality(int InQuality)
      {
         int LocalQuality = InQuality;

         /* Quality is never negative and never exceed the 50, 
          * therefore even if the calculation before was wrong, let's fix it here 
          */
         LocalQuality = (InQuality < 0 ? 0 : (InQuality >= 50 ? 50 : InQuality));

         return LocalQuality;
      }
   }
}
