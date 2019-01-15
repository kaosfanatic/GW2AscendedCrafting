﻿using System;
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
        static bool bStopAtIngotsAndPlanks = true;
        public static string strApi = "https://api.guildwars2.com/v2/";
        static HttpClient client = new HttpClient();
        public static ApiItem itemTest;
        public static ApiRecipe recTest;
        public static Prices priTest;

        public static int[] iIngredientIDs;
        public static ApiItem[] itmIngredients;
        public static int iNumIngredients;
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
                itemTest = new ApiItem();
                itemTest = await GetItemAsync(ID).ConfigureAwait(false);

                recTest = new ApiRecipe();
                recTest = await GetRecipeAsync(ID).ConfigureAwait(false);
                
                foreach(ApiIngredient i in recTest.Ingredients)
                {
                    iIngredientIDs[iNumIngredients] = i.item_id;

                    itmIngredients[iNumIngredients] = await GetItemAsync(iIngredientIDs[iNumIngredients]).ConfigureAwait(false);

                    iNumIngredients++;
                }

                priTest = new Prices();
                priTest = await GetPricesAsync(ID).ConfigureAwait(false);
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
