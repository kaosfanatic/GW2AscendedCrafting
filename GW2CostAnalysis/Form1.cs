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
        public frmCostAnalyzer()
        {
            InitializeComponent();
            //var itemTest = Program.GetItem(46697);
            cbInscriptionList.SelectedIndex = 0;
            lblIngredientName1.Text = "";
            lblIngredientName2.Text = "";
            lblIngredientName3.Text = "";
            lblIngredientName4.Text = "";
            lblIngredientCount1.Text = "";
            lblIngredientCount2.Text = "";
            lblIngredientCount3.Text = "";
            lblIngredientCount4.Text = "";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            int iID = iInscriptionIDs[cbInscriptionList.SelectedIndex];
            //MessageBox.Show(iID.ToString());
            if (iID != -1)
            {
                Program.RunAsync(iID).GetAwaiter().GetResult();

                lblRecipeName1.Text = Program.itemTest.name;
                
                if (Program.iNumIngredients > 0)
                {
                    lblIngredientName1.Text = Program.itmIngredients[0].name;
                    lblIngredientCount1.Text = Program.recTest.Ingredients[0].count.ToString();
                    if (Program.iNumIngredients > 1)
                    {
                        lblIngredientName2.Text = Program.itmIngredients[1].name;
                        lblIngredientCount2.Text = Program.recTest.Ingredients[1].count.ToString();
                        if (Program.iNumIngredients > 2)
                        {
                            lblIngredientName3.Text = Program.itmIngredients[2].name;
                            lblIngredientCount3.Text = Program.recTest.Ingredients[2].count.ToString();
                            if (Program.iNumIngredients > 3)
                            {
                                lblIngredientName4.Text = Program.itmIngredients[3].name;
                                lblIngredientCount4.Text = Program.recTest.Ingredients[3].count.ToString();
                            }
                        }
                    }
                }

                if (iID != 46699)
                {
                    int temp = Program.priTest.buys.unit_price;

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
