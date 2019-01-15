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
    /*
     * Angchu Cavalier Inscription
Beigarth's Knight Inscription
Chorben's Soldier Inscription
Coalforge's Rampager Inscription
Ebonmane's Apothecary Inscription
Grizzlemouth's Rabid Inscription
Hronk's Magi Inscription
Keeper's Zealot Inscription
Leftpaw's Settler Inscription
Mathilde's Dire Inscription
Occam's Carrion Inscription
Soros' Assassin Inscription
Stonecleaver's Valkyrie Inscription
Theodosus' Cleric Inscription
Tonn's Sentinel Inscription
Ventari's Nomad Inscription
Wupwup Celestial Inscription
Zintl Shaman Inscription
Zojja's Berserker Inscription
     */
    public partial class frmCostAnalyzer : Form
    {
        private int[] iInscriptionIDs = new int[] { -1, 46702, 46698, 46705, 46697, 46693, 46703, 46704, 49863, 46706, 46707, 46691, 46694, 46696, 46692, 46700, 66639, 46699, 46701, 46695 };
        public frmCostAnalyzer()
        {
            InitializeComponent();
            //var itemTest = Program.GetItem(46697);
            cbInscriptionList.SelectedIndex = 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            int iID = iInscriptionIDs[cbInscriptionList.SelectedIndex];
            //MessageBox.Show(iID.ToString());
            if (iID != -1)
            {
                Program.RunAsync(iID).GetAwaiter().GetResult();

                lblIngredientName1.Text = Program.itemTest.name;

            }
        }
    }
}
