using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GW2CostAnalysis
{
    static class Program
    {
        public static bool bUseRefinedMaterials = true;
        public static string strApi = "https://api.guildwars2.com/v2/";
        static HttpClient client = new HttpClient();
        public static Item itemMain;
        public static ApiRecipe recipeMain = new ApiRecipe();
        //public static Prices pricesMain = new Prices();

        public static IList<int> iMasterListIDs;
        public static IList<int> iMasterListCount;
        public static IList<int> iMasterListPrice;
        public static IList<string> strMasterListNames;


        public static int totalPrice = 0;

        public static int[] RefinedIDs = new int[]
        {
            19680,
            19679,
            19683,
            19687,
            19682,
            19688,
            19686,
            19681,
            19684,
            19685,
            19720,
            19740,
            19742,
            19744,
            19747,
            19746,
            19710,
            19713,
            19714,
            19711,
            19709,
            19712
        };


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           

            client.BaseAddress = new Uri(strApi);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmCostAnalyzer());
        }

        public static async Task LoadItemAsync(int ID, Item curItem)
        {
            //MessageBox.Show("Test");

            iMasterListIDs = new List<int>();
            iMasterListCount = new List<int>();
            iMasterListPrice = new List<int>();
            strMasterListNames = new List<string>();

            try
            {
                curItem.itemData = new ApiItem();
                curItem.itemData = await GetItemAsync(ID).ConfigureAwait(false);

                curItem.itemRecipe = new Recipe();

                ApiRecipe curRecipe = new ApiRecipe();
                curRecipe = await GetRecipeAsync(ID).ConfigureAwait(false);
                
                ApiItem temp = new ApiItem();

                //string testString = string.Format("Current Recipe: {0}", curItem.itemData.name);
                if (curRecipe != null)
                {
                    foreach (ApiIngredient i in curRecipe.Ingredients)
                    {
                        temp = await GetItemAsync(i.item_id).ConfigureAwait(false);

                        //MessageBox.Show(curItem.itemRecipe.itemIDs[0].ToString());
                        curItem.itemRecipe.itemIDs.Add(temp.id);
                        curItem.itemRecipe.itemCounts.Add(i.count);
                        curItem.itemRecipe.itemNames.Add(temp.name);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed: " + e.ToString());
            }

            if (curItem.itemRecipe.itemIDs.Count > 0)
            {
                bool bDoNext = true;
                foreach(int i in RefinedIDs)
                {
                    if (curItem.itemData.id == i && bUseRefinedMaterials)
                        bDoNext = false;
                }
                if (bDoNext)
                {
                    curItem.itemIngredient1 = new Item();
                    curItem.itemIngredient1.iQuantity = curItem.itemRecipe.itemCounts[0];
                    LoadItemAsync(curItem.itemRecipe.itemIDs[0], curItem.itemIngredient1).GetAwaiter().GetResult();
                }
            }
            if (curItem.itemRecipe.itemIDs.Count > 1)
            {
                bool bDoNext = true;
                foreach (int i in RefinedIDs)
                {
                    if (curItem.itemData.id == i && bUseRefinedMaterials)
                        bDoNext = false;
                }
                if (bDoNext)
                {
                    curItem.itemIngredient2 = new Item();
                    curItem.itemIngredient2.iQuantity = curItem.itemRecipe.itemCounts[1];
                    LoadItemAsync(curItem.itemRecipe.itemIDs[1], curItem.itemIngredient2).GetAwaiter().GetResult();
                }
            }
            if (curItem.itemRecipe.itemIDs.Count > 2)
            {
                bool bDoNext = true;
                foreach (int i in RefinedIDs)
                {
                    if (curItem.itemData.id == i && bUseRefinedMaterials)
                        bDoNext = false;
                }
                if (bDoNext)
                {
                    curItem.itemIngredient3 = new Item();
                    curItem.itemIngredient3.iQuantity = curItem.itemRecipe.itemCounts[2];
                    LoadItemAsync(curItem.itemRecipe.itemIDs[2], curItem.itemIngredient3).GetAwaiter().GetResult();
                }
            }
            if (curItem.itemRecipe.itemIDs.Count > 3)
            {
                bool bDoNext = true;
                foreach (int i in RefinedIDs)
                {
                    if (curItem.itemData.id == i && bUseRefinedMaterials)
                        bDoNext = false;
                }
                if (bDoNext)
                {
                    curItem.itemIngredient4 = new Item();
                    curItem.itemIngredient4.iQuantity = curItem.itemRecipe.itemCounts[3];
                    LoadItemAsync(curItem.itemRecipe.itemIDs[3], curItem.itemIngredient4).GetAwaiter().GetResult();
                }
            }

            Program.itemMain.itemPrice = await Program.GetPricesAsync(Program.itemMain.itemData.id).ConfigureAwait(false);
        }

        public static async Task<ApiRecipe> GetRecipeAsync(int ID)
        {
            ApiRecipe apiRecipe = null;
            string strApiPath;
            strApiPath = "recipes/search?output=" + ID.ToString();
           
            HttpResponseMessage response = await client.GetAsync(strApiPath).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                int iRecipeID = -1;
                string jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                IList<int> temp = JsonConvert.DeserializeObject<IList<int>>(jsonString);

                foreach (int i in temp)
                {
                    iRecipeID = i;
                }
                if (iRecipeID == -1)
                    return apiRecipe;

                strApiPath = "recipes/" + iRecipeID.ToString();
            }

            else
            {
                MessageBox.Show("Failed to retrieve data from:\n\r" + strApiPath);
                return apiRecipe;
            }

            response = await client.GetAsync(strApiPath).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                apiRecipe = JsonConvert.DeserializeObject<ApiRecipe>(jsonString);

            }
            else
                MessageBox.Show("Failed to retrieve data from:\n\r" + strApiPath);

            return apiRecipe;
        }

        public static async Task<ApiItem> GetItemAsync(int ID)
        {

            ApiItem apiItem = null;
            string strApiPath;
            strApiPath = "items";
            if(ID != -1)
                strApiPath = strApiPath + "?ids=" + ID.ToString();

            HttpResponseMessage response = await client.GetAsync(strApiPath).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var item = JsonConvert.DeserializeObject<List<ApiItem>>(jsonString);

                foreach (ApiItem i in item)
                {
                    apiItem = i;

                }
            }
            else
                MessageBox.Show("Failed to retrieve data from:\n\r" + strApiPath);
            

            return apiItem;
        }

        public static async Task<Prices> GetPricesAsync(int ID)
        {
            Prices prices = null;

            ApiItem tempItem = await GetItemAsync(ID).ConfigureAwait(false);

            if(tempItem.flags.Contains("AccountBound"))
                return prices;

            string strApiPath;
            strApiPath = "commerce/prices/" + ID.ToString();

            HttpResponseMessage response = await client.GetAsync(strApiPath).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                //MessageBox.Show(jsonString);

                var price = JsonConvert.DeserializeObject<Prices>(jsonString);

                prices = price;
            }
            else
                MessageBox.Show("Failed to retrieve data from:\n\r" + strApiPath);


            return prices;
        }

        public static async Task PopulateList(Item curItem, int multiplier)
        {
            //MessageBox.Show(string.Format("{0} of {1}",curItem.iQuantity,curItem.itemData.name));
            if (curItem.itemIngredient1 == null && curItem.itemIngredient2 == null && curItem.itemIngredient3 == null && curItem.itemIngredient4 == null)
            {
                if (!curItem.itemData.flags.Contains("AccountBound"))
                {
                    if (iMasterListIDs.Contains(curItem.itemData.id))
                    {
                        iMasterListCount[iMasterListIDs.IndexOf(curItem.itemData.id)] += (curItem.iQuantity * multiplier);
                        //MessageBox.Show(string.Format("Added {0} to {1}.", (curItem.iQuantity * multiplier), curItem.itemData.name));
                    }
                    else
                    {
                        iMasterListCount.Add(curItem.iQuantity * multiplier);
                        iMasterListIDs.Add(curItem.itemData.id);
                        strMasterListNames.Add(curItem.itemData.name);
                        //MessageBox.Show(string.Format("Added {0} of {1}.", (curItem.iQuantity * multiplier), curItem.itemData.name));
                    }
                }
            }
            else
            {
                if (curItem.itemIngredient1 != null)
                {
                    //MessageBox.Show(string.Format("Getting list for {0}", curItem.itemIngredient1.itemData.name));
                    PopulateList(curItem.itemIngredient1, curItem.iQuantity * multiplier).GetAwaiter().GetResult();
                }

                if (curItem.itemIngredient2 != null)
                {
                    //MessageBox.Show(string.Format("Getting list for {0}", curItem.itemIngredient2.itemData.name));
                    PopulateList(curItem.itemIngredient2, curItem.iQuantity * multiplier).GetAwaiter().GetResult();
                }

                if (curItem.itemIngredient3 != null)
                {
                    //MessageBox.Show(string.Format("Getting list for {0}", curItem.itemIngredient3.itemData.name));
                    PopulateList(curItem.itemIngredient3, curItem.iQuantity * multiplier).GetAwaiter().GetResult();
                }

                if (curItem.itemIngredient4 != null)
                {
                    //MessageBox.Show(string.Format("Getting list for {0}", curItem.itemIngredient4.itemData.name));
                    PopulateList(curItem.itemIngredient4, curItem.iQuantity * multiplier).GetAwaiter().GetResult();
                }
            }
        }

        public static async Task CalculatePrices() { 

            Listings listing = new Listings();

            int index = 0;

            foreach (int i in iMasterListIDs)
            {
                listing = await RetrieveListingsAsync(i).ConfigureAwait(false);

                int buyCounter = iMasterListCount[index];
                int buyIndex = 0;
                int tempCost = 0;

                while (buyCounter > 0)
                {
                    if (iMasterListCount[index] <= listing.buys[buyIndex].quantity)
                    {
                        tempCost = tempCost + (buyCounter * listing.buys[buyIndex].unit_price);
                        buyCounter = 0;
                    }
                    else
                    {
                        tempCost = tempCost + (listing.buys[buyIndex].quantity * listing.buys[buyIndex].unit_price);
                        buyCounter -= listing.buys[buyIndex].quantity;
                    }
                }

                totalPrice += tempCost;

                iMasterListPrice.Add(tempCost);
                
                index++;
            }

        }

        public static async Task<Listings> RetrieveListingsAsync(int ID)
        {
            Listings listing = null;
            ApiItem item = await GetItemAsync(ID).ConfigureAwait(false);

            if (item.flags.Contains("AccountBound"))
                return listing;

            string strApiPath;
            strApiPath = "commerce/listings/" + ID.ToString();

            HttpResponseMessage response = await client.GetAsync(strApiPath).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                //MessageBox.Show(jsonString);

                var lListing = JsonConvert.DeserializeObject<Listings>(jsonString);

                listing = lListing;
            }
            else
                MessageBox.Show("Failed to retrieve data from:\n\r" + strApiPath);


            return listing;

        }
    }
}
