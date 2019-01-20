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

        public static List<int> iMasterListIDs;
        public static List<int> iMasterListCount;
        public static List<int> iMasterListPrice;
        public static List<string> strMasterListNames;


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

        public static async Task LoadItemAsync(int ID, Item curItem, int multiplier)
        {
            //MessageBox.Show("Test");

            try
            {
                curItem.itemData = new ApiItem();
                curItem.itemData = await GetItemAsync(ID).ConfigureAwait(false);

                curItem.itemRecipe = new Recipe();

                ApiRecipe curRecipe = new ApiRecipe();
                curRecipe = await GetRecipeAsync(ID).ConfigureAwait(false);
                
                ApiItem temp = new ApiItem();

                //string testString = string.Format("Current Recipe: {0}", curItem.itemData.name);
                if (curRecipe != null && (!RefinedIDs.Contains(curItem.itemData.id) || !bUseRefinedMaterials))
                {
                    //MessageBox.Show(string.Format("Current Item: {0}\n\rCalculating ingredients", curItem.itemData.name));
                    foreach (ApiIngredient i in curRecipe.Ingredients)
                    {
                        temp = await GetItemAsync(i.item_id).ConfigureAwait(false);

                        //MessageBox.Show(curItem.itemRecipe.itemIDs[0].ToString());
                        curItem.itemRecipe.itemIDs.Add(temp.id);
                        curItem.itemRecipe.itemCounts.Add(i.count);
                        curItem.itemRecipe.itemNames.Add(temp.name);
                    }

                    switch (curItem.itemRecipe.itemIDs.Count)
                    {
                        case 4:
                            curItem.itemIngredient4 = new Item
                            {
                                iQuantity = curItem.itemRecipe.itemCounts[3]
                            };
                            LoadItemAsync(curItem.itemRecipe.itemIDs[3], curItem.itemIngredient4, curItem.iQuantity * multiplier).GetAwaiter().GetResult();
                            goto case 3;
                        case 3:
                            curItem.itemIngredient3 = new Item
                            {
                                iQuantity = curItem.itemRecipe.itemCounts[2]
                            };
                            LoadItemAsync(curItem.itemRecipe.itemIDs[2], curItem.itemIngredient3, curItem.iQuantity * multiplier).GetAwaiter().GetResult();
                            goto case 2;
                        case 2:
                            curItem.itemIngredient2 = new Item
                            {
                                iQuantity = curItem.itemRecipe.itemCounts[1]
                            };
                            LoadItemAsync(curItem.itemRecipe.itemIDs[1], curItem.itemIngredient2, curItem.iQuantity * multiplier).GetAwaiter().GetResult();
                            goto case 1;
                        case 1:
                            curItem.itemIngredient1 = new Item
                            {
                                iQuantity = curItem.itemRecipe.itemCounts[0]
                            };
                            LoadItemAsync(curItem.itemRecipe.itemIDs[0], curItem.itemIngredient1, curItem.iQuantity * multiplier).GetAwaiter().GetResult();
                            goto default;
                        default:
                            break;
                    }
                }
                else
                {
                    
                    if (!curItem.itemData.flags.Contains("AccountBound"))
                    {
                        //MessageBox.Show(string.Format("Ingredient '{0}' does not have sub-recipe.", curItem.itemData.name));
                        if (iMasterListIDs.Contains(curItem.itemData.id))
                        {
                            iMasterListCount[iMasterListIDs.IndexOf(curItem.itemData.id)] += (curItem.iQuantity * multiplier);
                            //MessageBox.Show(string.Format("Item Exists.  Added {0} to {1}.", (curItem.iQuantity * multiplier), curItem.itemData.name));
                        }
                        else
                        {
                            iMasterListCount.Add(curItem.iQuantity * multiplier);
                            iMasterListIDs.Add(curItem.itemData.id);
                            strMasterListNames.Add(curItem.itemData.name);
                           //MessageBox.Show(string.Format("Item Does not Exist.  Added {0} of {1}.", (curItem.iQuantity * multiplier), curItem.itemData.name));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed: " + e.ToString());
            }
            
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

        public static async Task CalculatePrices() { 

            List<Listings> listing = new List<Listings>();

            totalPrice = 0;

            int index = 0;

            listing = await RetrieveListingsAsync(iMasterListIDs).ConfigureAwait(false);

            foreach (int i in iMasterListIDs)
            {

                int buyCounter = iMasterListCount[index];
                int buyIndex = 0;
                int tempCost = 0;

                while (buyCounter > 0)
                {
                    if (iMasterListCount[index] <= listing[index].buys[buyIndex].quantity)
                    {
                        tempCost = tempCost + (buyCounter * listing[index].buys[buyIndex].unit_price);
                        buyCounter = 0;
                    }
                    else
                    {
                        tempCost = tempCost + (listing[index].buys[buyIndex].quantity * listing[index].buys[buyIndex].unit_price);
                        buyCounter -= listing[index].buys[buyIndex].quantity;
                    }
                }

                totalPrice += tempCost;

                iMasterListPrice.Add(tempCost);
                
                index++;
            }

        }

        public static async Task<List<Listings>> RetrieveListingsAsync(List<int> ID)
        {
            List<Listings> listing = null;

            string strApiPath = "commerce/listings?ids=";
            if(ID.Count > 0)
            {
                foreach (int i in ID)
                    strApiPath += ID.IndexOf(i) == 0 ? i.ToString() : string.Format(",{0}",i.ToString());
            }


            HttpResponseMessage response = await client.GetAsync(strApiPath).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                //MessageBox.Show(jsonString);

                var lListing = JsonConvert.DeserializeObject<List<Listings>>(jsonString);

                listing = lListing;
            }
            else
                MessageBox.Show("Failed to retrieve data from:\n\r" + strApiPath);


            return listing;

        }
    }
}
