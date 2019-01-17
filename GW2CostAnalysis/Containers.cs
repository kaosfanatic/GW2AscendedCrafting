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
        public ApiItem itemData { get; set; }

        public Prices itemPrice { get; set; }

        public Recipe itemRecipe { get; set; }

        public Item itemIngredient1;
        public Item itemIngredient2;
        public Item itemIngredient3;
        public Item itemIngredient4;

        public int iQuantity = 1;
    }

    public class Recipe
    {
        public IList<int> itemIDs = new List<int>();
        public IList<string> itemNames = new List<string>();
        public IList<int> itemCounts = new List<int>();
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
        public IList<ApiIngredient> Ingredients = new List<ApiIngredient>();
        public string strChatLink { get; set; }
    }

    public class BuySell
    {
        public int unit_price { get; set; }
        public int quantity { get; set; }

    }
    
    public class Listing
    {
        public int unit_price { get; set; }
        public int quantity { get; set; }
        public int listings { get; set; }
    }

    public class Prices
    {
        public int id { get; set; }
        public bool whitelisted { get; set; }
        public BuySell buys { get; set; }
        public BuySell sells { get; set; }
    }

    public class Listings
    {
        public int id { get; set; }
        public IList<Listing> buys { get; set; }
        public IList<Listing> sells { get; set; }

    }

}