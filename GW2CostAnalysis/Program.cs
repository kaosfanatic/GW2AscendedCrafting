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
    public enum IngotIDs
    {
        Copper = 19680,
        Bronze = 19679,
        Iron = 19683,
        Silver = 19687,
        Gold = 19682,
        Steel = 19688,
        Platinum = 19686,
        Darksteel = 19681,
        Mithril = 19684,
        Orichalcum = 19685
    }

    public enum BoltIDs
    {
        Jute = 19720,
        Wool = 19740,
        Cotton = 19742,
        Linen = 19744,
        Silk = 19747,
        Gossamer = 19746
    }

    public enum PlankIDs
    {
        Green = 19710,
        Soft = 19713,
        Seasoned = 19714,
        Hard = 19711,
        Elder = 19709,
        Ancient = 19712
    }

    static class Program
    {
        public static bool bUseRefinedMaterials = true;
        public static string strApi = "https://api.guildwars2.com/v2/";
        static HttpClient client = new HttpClient();
        public static ApiItem itemMain;
        public static ApiRecipe recipeMain;
        public static Prices pricesMain;

        public static int[] iIngredientIDs;
        public static ApiItem[] itmIngredients;
        public static int iNumIngredients;

        public static IList<int> iMasterList;
        

        

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

        public static async Task RunAsync(int ID)
        {
            //MessageBox.Show("Test");
            iIngredientIDs = new int[4];
            itmIngredients = new ApiItem[4];
            iNumIngredients = 0;

            try
            {
                itemMain = new ApiItem();
                itemMain = await GetItemAsync(ID).ConfigureAwait(false);

                recipeMain = new ApiRecipe();
                recipeMain = await GetRecipeAsync(ID).ConfigureAwait(false);
                
                foreach(ApiIngredient i in recipeMain.Ingredients)
                {
                    iIngredientIDs[iNumIngredients] = i.item_id;

                    itmIngredients[iNumIngredients] = await GetItemAsync(iIngredientIDs[iNumIngredients]).ConfigureAwait(false);

                    iNumIngredients++;
                }

                pricesMain = new Prices();
                pricesMain = await GetPricesAsync(ID).ConfigureAwait(false);
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
            if (ID == 46699) //Wupwup not tradeable
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
    }
}
