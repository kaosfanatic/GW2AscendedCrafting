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
        static bool bStopAtIngotsAndPlanks = true;
        public static string strApi = "https://api.guildwars2.com/v2/";
        static HttpClient client = new HttpClient();
        public static Item itemTest;
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

            try
            {
                itemTest = new Item();
                itemTest = await GetItemAsync(ID).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed: " + e.ToString());
            }
        }

        public static async Task<Recipe> GetRecipe(int ID)
        {
            //MessageBox.Show("TEST2");
            ID = 46697;
            Recipe apiRecipe = null;
            string strApiPath = Program.strApi;
            strApiPath = "recipes/search?input=" + ID.ToString();

            //MessageBox.Show(strApiPath);
            HttpResponseMessage response = await client.GetAsync(strApiPath);

            if (response.IsSuccessStatusCode)
                apiRecipe = await response.Content.ReadAsAsync<Recipe>();


            return apiRecipe;
        }

        public static async Task<Item> GetItemAsync(int ID)
        {

            Item apiItem = null;
            string strApiPath;
            strApiPath = "items";
            if(ID != -1)
                strApiPath = strApiPath + "?ids=" + ID.ToString();

            HttpResponseMessage response = await client.GetAsync(strApiPath).ConfigureAwait(false);

            if (response.IsSuccessStatusCode) {
                string test = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                
                var item = JsonConvert.DeserializeObject<List<Item>>(test);

                foreach (Item i in item) {
                    apiItem = i;

                }
            }
            

            return apiItem;
        }
    }
}
