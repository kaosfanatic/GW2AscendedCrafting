using System.Collections;
using System.Collections.Generic;

namespace GW2CostAnalysis
{
    public class Details
    {

    }

    public class Item
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

    public class Recipe
    {
        //API Data
        public int iID { get; set; }
        public string strType { get; set; }
        public int iOutID { get; set; }
        public int iOutQuantity { get; set; }
        public long iTime { get; set; }
        public string[] strDiscipline { get; set; }
        public int iMinRating { get; set; }
        public string[] strFlags { get; set; }
        public int[,] iIngredients { get; set; }
        public string strChatLink { get; set; }



    }

}