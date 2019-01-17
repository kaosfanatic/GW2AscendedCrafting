using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GW2CostAnalysis
{
    public partial class frmCostAnalyzer : Form
    {
        private int[] iInscriptionIDs = new int[] { -1, 46702, 46698, 46705, 46697, 46693, 46703, 46704, 49863, 46706, 46707, 46691, 46694, 46696, 46692, 46700, 66639, 46699, 46701, 46695 };
        private int gold, silver, copper;
        //private int page = 0;
        private bool bShowShoppingList = false;
        private IList<int> listRefined = new List<int>();
        private IList<int> listUnrefined = new List<int>();
        private static bool bReady = false;

        public static ListView.ListViewItemCollection listMaster;

        public frmCostAnalyzer()
        {
            InitializeComponent();
            //var itemTest = Program.GetItem(46697);
            cbInscriptionList.SelectedIndex = 0;
            ttToolTips.SetToolTip(chkUseRefinedMaterials, "When checked, program will use Ingots, Planks, and Bolts instead of Ore, Logs, and Scraps.");
            /*ttToolTips.SetToolTip(btnBack, "Return to the previous recipe");
            ttToolTips.SetToolTip(btnRefresh, "Force update of prices");*/
            chkUseRefinedMaterials.Checked = true;
            listMaster = new ListView.ListViewItemCollection(listShoppingList);

            this.Width = 402;
            this.Height = 94;

            lblRecipeName1.Text = "";
            lblIngredientName1.Text = "";
            lblIngredientName2.Text = "";
            lblIngredientName3.Text = "";
            lblIngredientName4.Text = "";
            lblIngredientCount1.Text = "";
            lblIngredientCount2.Text = "";
            lblIngredientCount3.Text = "";
            lblIngredientCount4.Text = "";
        }

        private void chkUseRefinedMaterials_CheckedChanged(object sender, EventArgs e)
        {
            Program.bUseRefinedMaterials = chkUseRefinedMaterials.Checked;
            
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem l in listShoppingList.Items)
            {
                if (l.Checked)
                    l.Remove();
            }
        }

        private void chkShowShopping_CheckedChanged(object sender, EventArgs e)
        {
            bShowShoppingList = chkShowShopping.Checked;
            panelShopping.Visible = chkShowShopping.Checked;
        }

        private void panelShopping_VisibleChanged(object sender, EventArgs e)
        {

            this.Width = panelShopping.Visible ? 764 : 402;
        }

        private void panelRecipes_VisibleChanged(object sender, EventArgs e)
        {
            this.Height = panelRecipes.Visible ? 489 : 100;
        }

        private void UpdatePage()
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            btnLoad.Text = "Loading...";
            btnLoad.Enabled = false;

            ResetList();
            Program.itemMain = new Item();
            //listShoppingList.Clear();
            int iID = iInscriptionIDs[cbInscriptionList.SelectedIndex];
            //MessageBox.Show(iID.ToString());
            if (iID != -1)
            {
                Program.LoadItemAsync(iID, Program.itemMain).GetAwaiter().GetResult();

                lblRecipeName1.Text = Program.itemMain.itemData.name;

                if(Program.itemMain.itemRecipe != null)
                {
                    if(Program.itemMain.itemIngredient1 != null)
                    {
                        lblIngredientName1.Text = Program.itemMain.itemIngredient1.itemData.name;
                        lblIngredientCount1.Text = Program.itemMain.itemIngredient1.iQuantity.ToString();

                    }
                    if (Program.itemMain.itemIngredient2 != null)
                    {
                        lblIngredientName2.Text = Program.itemMain.itemIngredient2.itemData.name;
                        lblIngredientCount2.Text = Program.itemMain.itemIngredient2.iQuantity.ToString();

                    }
                    if (Program.itemMain.itemIngredient3 != null)
                    {
                        lblIngredientName3.Text = Program.itemMain.itemIngredient3.itemData.name;
                        lblIngredientCount3.Text = Program.itemMain.itemIngredient3.iQuantity.ToString();

                    }
                    if (Program.itemMain.itemIngredient4 != null)
                    {
                        lblIngredientName4.Text = Program.itemMain.itemIngredient4.itemData.name;
                        lblIngredientCount4.Text = Program.itemMain.itemIngredient4.iQuantity.ToString();

                    }
                }

                Program.PopulateList(Program.itemMain, 1);

                if (iID != 46699)
                {
                    int temp = Program.itemMain.itemPrice.buys.unit_price;

                    gold = temp / 10000;
                    temp = temp % 10000;
                    silver = temp / 100;
                    temp = temp % 100;
                    copper = temp;

                    lblInstantSell.Text = string.Format("{0}g, {1}s, {2}c", gold, silver, copper);
                }
                else
                    lblInstantSell.Text = "Account bound";

                Program.CalculatePrices().GetAwaiter().GetResult();

                FillShoppingList();

                panelRecipes.Visible = true;
            }

            

            btnLoad.Text = "Load Recipe";
            btnLoad.Enabled = true;
            bReady = true;
        }
        
        private void FillShoppingList()
        {
            string[] strListEntry = new string[3];
            ListViewItem temp = new ListViewItem();

            for(int i = 0; i < Program.iMasterListIDs.Count; i++)
            {
                strListEntry[0] = Program.strMasterListNames[i];
                strListEntry[1] = Program.iMasterListCount[i].ToString();
                strListEntry[2] = Program.iMasterListPrice[i].ToString();
                temp = new ListViewItem(strListEntry);
                listMaster.Add(temp);
            }

            //listShoppingList.Items.AddRange( = items;
            

            int tC, tS, tG;
            int totalPrice = Program.totalPrice;
            tG = totalPrice / 10000;
            totalPrice = totalPrice % 10000;
            tS = totalPrice / 100;
            tC = totalPrice % 100;


            lblTotalCost.Text = string.Format("{0}g {1}s {2}c", tG, tS, tC);
        }

        private void ResetList()
        {

            Program.iMasterListIDs = new List<int>();
            Program.iMasterListCount = new List<int>();
            Program.iMasterListPrice = new List<int>();
            Program.strMasterListNames = new List<string>();

            if (listShoppingList.Items.Count > 0)
            {
                foreach (ListViewItem i in listShoppingList.Items)
                {
                    i.Remove();
                }
            }
        }
    }
}
