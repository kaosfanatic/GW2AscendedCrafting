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
        private int page = 0;

        IList<string> strItemName;
        IList<string> strIngredientName1;
        IList<string> strIngredientName2;
        IList<string> strIngredientName3;
        IList<string> strIngredientName4;
        IList<int> iIngredientCount1;
        IList<int> iIngredientCount2;
        IList<int> iIngredientCount3;
        IList<int> iIngredientCount4;

        public frmCostAnalyzer()
        {
            InitializeComponent();
            //var itemTest = Program.GetItem(46697);
            cbInscriptionList.SelectedIndex = 0;
            ttStopIngotsPlanks.SetToolTip(chkUseRefinedMaterials, "When checked, program will use Ingots, Planks, and Bolts instead of Ore, Logs, and Scraps.");

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

        private void UpdatePage()
        {
            lblRecipeName1.Text = strItemName[page];

            lblIngredientName1.Text = strIngredientName1[page];
            lblIngredientName2.Text = strIngredientName2[page];
            lblIngredientName3.Text = strIngredientName3[page];
            lblIngredientName4.Text = strIngredientName4[page];
            lblIngredientCount1.Text = iIngredientCount1[page].ToString();
            lblIngredientCount2.Text = iIngredientCount2[page].ToString();
            lblIngredientCount3.Text = iIngredientCount3[page].ToString();
            lblIngredientCount4.Text = iIngredientCount4[page].ToString();

            if (page == 0)
                btnBack.Enabled = false;
            else
                btnBack.Enabled = true;


        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            int iID = iInscriptionIDs[cbInscriptionList.SelectedIndex];
            //MessageBox.Show(iID.ToString());
            if (iID != -1)
            {
                Program.RunAsync(iID).GetAwaiter().GetResult();

                lblRecipeName1.Text = Program.itemMain.name;
                
                if (Program.iNumIngredients > 0)
                {
                    lblIngredientName1.Text = Program.itmIngredients[0].name;
                    lblIngredientCount1.Text = Program.recipeMain.Ingredients[0].count.ToString();
                    if (Program.iNumIngredients > 1)
                    {
                        lblIngredientName2.Text = Program.itmIngredients[1].name;
                        lblIngredientCount2.Text = Program.recipeMain.Ingredients[1].count.ToString();
                        if (Program.iNumIngredients > 2)
                        {
                            lblIngredientName3.Text = Program.itmIngredients[2].name;
                            lblIngredientCount3.Text = Program.recipeMain.Ingredients[2].count.ToString();
                            if (Program.iNumIngredients > 3)
                            {
                                lblIngredientName4.Text = Program.itmIngredients[3].name;
                                lblIngredientCount4.Text = Program.recipeMain.Ingredients[3].count.ToString();
                            }
                        }
                    }
                }

                if (iID != 46699)
                {
                    int temp = Program.pricesMain.buys.unit_price;

                    gold = temp / 10000;
                    temp = temp % 10000;
                    silver = temp / 100;
                    temp = temp % 100;
                    copper = temp;

                    lblInstantSell.Text = string.Format("{0}g, {1}s, {2}c", gold, silver, copper);
                }
                else
                    lblInstantSell.Text = "Account bound";
            }
        }
    }
}
