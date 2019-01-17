using System.Collections;
using System.Collections.Generic;

namespace GW2CostAnalysis
{
    public class Details
    {
        //Will add if I find anything that needs it.  For now, it's just a 'model' to ensure API loads correctly.
    }

    public class ApiItem
    {
        //API Data
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string rarity { get; set; }
        public int level { get; set; }
        public int vendor_value { get; set; }
        public int default_skin { get; set; }
        public IList<string> flags { get; set; }
        public IList<string> game_types { get; set; }
        public IList<int> restrictions { get; set; }
        public Details details { get; set; }
        public string chat_link { get; set; }
    }

    public class Item
    {
        ApiItem itemData { get; set; }

        Prices itemPrice { get; set; }

        Recipe itemRecipe { get; set; }

        Item itemIngredient1;
        Item itemIngredient2;
        Item itemIngredient3;
        Item itemIngredient4;

        Item itemParent;
    }

    public class Recipe
    {
        public IList<int> itemIDs { get; set; }
        public IList<string> itemNames { get; set; }
        public IList<int> itemCounts { get; set; }
    }

    public class ApiIngredient
    {
        public int item_id { get; set; }
        public int count { get; set; }
    }

    public class ApiRecipe
    {
        //API Data
        public int ID { get; set; }
        public string Type { get; set; }
        public int Output_Item_ID { get; set; }
        public int Output_Item_Count { get; set; }
        public int Time_To_Craft_MS { get; set; }
        public IList<string> Disciplines { get; set; }
        public int Min_Rating { get; set; }
        public IList<string> Flags { get; set; }
        public IList<ApiIngredient> Ingredients { get; set; }
        public string strChatLink { get; set; }
    }

    public class BuySell
    {
        public int unit_price { get; set; }
        public int quantity { get; set; }

    }

    public class Prices
    {
        public int id { get; set; }
        public bool whitelisted { get; set; }
        public BuySell buys { get; set; }
        public BuySell sells { get; set; }
    }

}