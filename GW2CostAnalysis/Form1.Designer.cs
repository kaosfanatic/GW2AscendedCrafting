namespace GW2CostAnalysis
{
    partial class frmCostAnalyzer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblInstantSell = new System.Windows.Forms.Label();
            this.cbInscriptionList = new System.Windows.Forms.ComboBox();
            this.lblIngredientName1 = new System.Windows.Forms.Label();
            this.lblIngredientName2 = new System.Windows.Forms.Label();
            this.lblIngredientName3 = new System.Windows.Forms.Label();
            this.lblIngredientCount4 = new System.Windows.Forms.Label();
            this.lblIngredientCount3 = new System.Windows.Forms.Label();
            this.lblIngredientCount2 = new System.Windows.Forms.Label();
            this.lblIngredientCount1 = new System.Windows.Forms.Label();
            this.lblIngredientName4 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblRecipeName1 = new System.Windows.Forms.Label();
            this.chkUseRefinedMaterials = new System.Windows.Forms.CheckBox();
            this.ttToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.lblShoppingList = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.listShoppingList = new System.Windows.Forms.ListView();
            this.listShoppingMaterial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listShoppingCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listShoppingPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnHide = new System.Windows.Forms.Button();
            this.panelShopping = new System.Windows.Forms.Panel();
            this.chkShowShopping = new System.Windows.Forms.CheckBox();
            this.panelRecipes = new System.Windows.Forms.Panel();
            this.panelShopping.SuspendLayout();
            this.panelRecipes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInstantSell
            // 
            this.lblInstantSell.AutoSize = true;
            this.lblInstantSell.Location = new System.Drawing.Point(207, 18);
            this.lblInstantSell.Name = "lblInstantSell";
            this.lblInstantSell.Size = new System.Drawing.Size(0, 13);
            this.lblInstantSell.TabIndex = 1;
            // 
            // cbInscriptionList
            // 
            this.cbInscriptionList.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbInscriptionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInscriptionList.FormattingEnabled = true;
            this.cbInscriptionList.Items.AddRange(new object[] {
            "Please select inscription...",
            "Angchu Cavalier Inscription",
            "Beigarth\'s Knight Inscription",
            "Chorben\'s Soldier Inscription",
            "Coalforge\'s Rampager Inscription",
            "Ebonmane\'s Apothecary Inscription",
            "Grizzlemouth\'s Rabid Inscription",
            "Hronk\'s Magi Inscription",
            "Keeper\'s Zealot Inscription",
            "Leftpaw\'s Settler Inscription",
            "Mathilde\'s Dire Inscription",
            "Occam\'s Carrion Inscription",
            "Soros\' Assassin Inscription",
            "Stonecleaver\'s Valkyrie Inscription",
            "Theodosus\' Cleric Inscription",
            "Tonn\'s Sentinel Inscription",
            "Ventari\'s Nomad Inscription",
            "Wupwup Celestial Inscription",
            "Zintl Shaman Inscription",
            "Zojja\'s Berserker Inscription"});
            this.cbInscriptionList.Location = new System.Drawing.Point(12, 12);
            this.cbInscriptionList.Name = "cbInscriptionList";
            this.cbInscriptionList.Size = new System.Drawing.Size(179, 21);
            this.cbInscriptionList.TabIndex = 2;
            // 
            // lblIngredientName1
            // 
            this.lblIngredientName1.AutoSize = true;
            this.lblIngredientName1.Location = new System.Drawing.Point(12, 71);
            this.lblIngredientName1.Name = "lblIngredientName1";
            this.lblIngredientName1.Size = new System.Drawing.Size(35, 13);
            this.lblIngredientName1.TabIndex = 3;
            this.lblIngredientName1.Text = "label1";
            // 
            // lblIngredientName2
            // 
            this.lblIngredientName2.AutoSize = true;
            this.lblIngredientName2.Location = new System.Drawing.Point(12, 133);
            this.lblIngredientName2.Name = "lblIngredientName2";
            this.lblIngredientName2.Size = new System.Drawing.Size(35, 13);
            this.lblIngredientName2.TabIndex = 4;
            this.lblIngredientName2.Text = "label2";
            // 
            // lblIngredientName3
            // 
            this.lblIngredientName3.AutoSize = true;
            this.lblIngredientName3.Location = new System.Drawing.Point(12, 195);
            this.lblIngredientName3.Name = "lblIngredientName3";
            this.lblIngredientName3.Size = new System.Drawing.Size(35, 13);
            this.lblIngredientName3.TabIndex = 5;
            this.lblIngredientName3.Text = "label3";
            // 
            // lblIngredientCount4
            // 
            this.lblIngredientCount4.AutoSize = true;
            this.lblIngredientCount4.Location = new System.Drawing.Point(238, 257);
            this.lblIngredientCount4.Name = "lblIngredientCount4";
            this.lblIngredientCount4.Size = new System.Drawing.Size(35, 13);
            this.lblIngredientCount4.TabIndex = 7;
            this.lblIngredientCount4.Text = "label5";
            // 
            // lblIngredientCount3
            // 
            this.lblIngredientCount3.AutoSize = true;
            this.lblIngredientCount3.Location = new System.Drawing.Point(238, 195);
            this.lblIngredientCount3.Name = "lblIngredientCount3";
            this.lblIngredientCount3.Size = new System.Drawing.Size(35, 13);
            this.lblIngredientCount3.TabIndex = 8;
            this.lblIngredientCount3.Text = "label6";
            // 
            // lblIngredientCount2
            // 
            this.lblIngredientCount2.AutoSize = true;
            this.lblIngredientCount2.Location = new System.Drawing.Point(238, 133);
            this.lblIngredientCount2.Name = "lblIngredientCount2";
            this.lblIngredientCount2.Size = new System.Drawing.Size(35, 13);
            this.lblIngredientCount2.TabIndex = 9;
            this.lblIngredientCount2.Text = "label7";
            // 
            // lblIngredientCount1
            // 
            this.lblIngredientCount1.AutoSize = true;
            this.lblIngredientCount1.Location = new System.Drawing.Point(238, 71);
            this.lblIngredientCount1.Name = "lblIngredientCount1";
            this.lblIngredientCount1.Size = new System.Drawing.Size(35, 13);
            this.lblIngredientCount1.TabIndex = 10;
            this.lblIngredientCount1.Text = "label8";
            // 
            // lblIngredientName4
            // 
            this.lblIngredientName4.AutoSize = true;
            this.lblIngredientName4.Location = new System.Drawing.Point(12, 257);
            this.lblIngredientName4.Name = "lblIngredientName4";
            this.lblIngredientName4.Size = new System.Drawing.Size(35, 13);
            this.lblIngredientName4.TabIndex = 11;
            this.lblIngredientName4.Text = "label1";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(282, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(99, 25);
            this.btnLoad.TabIndex = 12;
            this.btnLoad.Text = "Load Recipe";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblRecipeName1
            // 
            this.lblRecipeName1.AutoSize = true;
            this.lblRecipeName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipeName1.Location = new System.Drawing.Point(30, 26);
            this.lblRecipeName1.Name = "lblRecipeName1";
            this.lblRecipeName1.Size = new System.Drawing.Size(155, 24);
            this.lblRecipeName1.TabIndex = 13;
            this.lblRecipeName1.Text = "<RecipeName>";
            this.lblRecipeName1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkUseRefinedMaterials
            // 
            this.chkUseRefinedMaterials.AutoSize = true;
            this.chkUseRefinedMaterials.Location = new System.Drawing.Point(251, 39);
            this.chkUseRefinedMaterials.Name = "chkUseRefinedMaterials";
            this.chkUseRefinedMaterials.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkUseRefinedMaterials.Size = new System.Drawing.Size(130, 17);
            this.chkUseRefinedMaterials.TabIndex = 19;
            this.chkUseRefinedMaterials.Text = "Use Refined Materials";
            this.chkUseRefinedMaterials.UseVisualStyleBackColor = true;
            this.chkUseRefinedMaterials.CheckedChanged += new System.EventHandler(this.chkUseRefinedMaterials_CheckedChanged);
            // 
            // lblShoppingList
            // 
            this.lblShoppingList.AutoSize = true;
            this.lblShoppingList.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShoppingList.Location = new System.Drawing.Point(105, 18);
            this.lblShoppingList.Name = "lblShoppingList";
            this.lblShoppingList.Size = new System.Drawing.Size(144, 25);
            this.lblShoppingList.TabIndex = 21;
            this.lblShoppingList.Text = "Shopping List";
            this.lblShoppingList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 420);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Total Price";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(269, 420);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(0, 13);
            this.lblTotalCost.TabIndex = 30;
            // 
            // listShoppingList
            // 
            this.listShoppingList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listShoppingList.CheckBoxes = true;
            this.listShoppingList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listShoppingMaterial,
            this.listShoppingCount,
            this.listShoppingPrice});
            this.listShoppingList.GridLines = true;
            this.listShoppingList.Location = new System.Drawing.Point(9, 62);
            this.listShoppingList.Name = "listShoppingList";
            this.listShoppingList.Size = new System.Drawing.Size(340, 331);
            this.listShoppingList.TabIndex = 31;
            this.listShoppingList.UseCompatibleStateImageBehavior = false;
            this.listShoppingList.View = System.Windows.Forms.View.Details;
            // 
            // listShoppingMaterial
            // 
            this.listShoppingMaterial.Tag = "shopMaterial";
            this.listShoppingMaterial.Text = "Material";
            this.listShoppingMaterial.Width = 203;
            // 
            // listShoppingCount
            // 
            this.listShoppingCount.Tag = "shopCount";
            this.listShoppingCount.Text = "Quantity";
            this.listShoppingCount.Width = 55;
            // 
            // listShoppingPrice
            // 
            this.listShoppingPrice.Tag = "shopPrice";
            this.listShoppingPrice.Text = "Price";
            this.listShoppingPrice.Width = 52;
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(31, 414);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(104, 25);
            this.btnHide.TabIndex = 25;
            this.btnHide.Text = "Hide Completed";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // panelShopping
            // 
            this.panelShopping.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelShopping.Controls.Add(this.btnHide);
            this.panelShopping.Controls.Add(this.listShoppingList);
            this.panelShopping.Controls.Add(this.lblTotalCost);
            this.panelShopping.Controls.Add(this.label5);
            this.panelShopping.Controls.Add(this.lblShoppingList);
            this.panelShopping.Location = new System.Drawing.Point(387, -1);
            this.panelShopping.Name = "panelShopping";
            this.panelShopping.Size = new System.Drawing.Size(362, 452);
            this.panelShopping.TabIndex = 24;
            this.panelShopping.Visible = false;
            this.panelShopping.VisibleChanged += new System.EventHandler(this.panelShopping_VisibleChanged);
            // 
            // chkShowShopping
            // 
            this.chkShowShopping.AutoSize = true;
            this.chkShowShopping.Location = new System.Drawing.Point(252, 364);
            this.chkShowShopping.Name = "chkShowShopping";
            this.chkShowShopping.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkShowShopping.Size = new System.Drawing.Size(120, 17);
            this.chkShowShopping.TabIndex = 25;
            this.chkShowShopping.Text = "Show Shopping List";
            this.chkShowShopping.UseVisualStyleBackColor = true;
            this.chkShowShopping.CheckedChanged += new System.EventHandler(this.chkShowShopping_CheckedChanged);
            // 
            // panelRecipes
            // 
            this.panelRecipes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRecipes.Controls.Add(this.chkShowShopping);
            this.panelRecipes.Controls.Add(this.lblRecipeName1);
            this.panelRecipes.Controls.Add(this.lblIngredientName4);
            this.panelRecipes.Controls.Add(this.lblIngredientCount1);
            this.panelRecipes.Controls.Add(this.lblIngredientCount2);
            this.panelRecipes.Controls.Add(this.lblIngredientCount3);
            this.panelRecipes.Controls.Add(this.lblIngredientCount4);
            this.panelRecipes.Controls.Add(this.lblIngredientName3);
            this.panelRecipes.Controls.Add(this.lblIngredientName2);
            this.panelRecipes.Controls.Add(this.lblIngredientName1);
            this.panelRecipes.Location = new System.Drawing.Point(-1, 62);
            this.panelRecipes.Name = "panelRecipes";
            this.panelRecipes.Size = new System.Drawing.Size(389, 389);
            this.panelRecipes.TabIndex = 26;
            this.panelRecipes.Visible = false;
            this.panelRecipes.VisibleChanged += new System.EventHandler(this.panelRecipes_VisibleChanged);
            // 
            // frmCostAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 450);
            this.Controls.Add(this.panelRecipes);
            this.Controls.Add(this.chkUseRefinedMaterials);
            this.Controls.Add(this.panelShopping);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cbInscriptionList);
            this.Controls.Add(this.lblInstantSell);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCostAnalyzer";
            this.Text = "GW2 Ascended Crafting Analyzer";
            this.panelShopping.ResumeLayout(false);
            this.panelShopping.PerformLayout();
            this.panelRecipes.ResumeLayout(false);
            this.panelRecipes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblInstantSell;
        private System.Windows.Forms.ComboBox cbInscriptionList;
        private System.Windows.Forms.Label lblIngredientName1;
        private System.Windows.Forms.Label lblIngredientName2;
        private System.Windows.Forms.Label lblIngredientName3;
        private System.Windows.Forms.Label lblIngredientCount4;
        private System.Windows.Forms.Label lblIngredientCount3;
        private System.Windows.Forms.Label lblIngredientCount2;
        private System.Windows.Forms.Label lblIngredientCount1;
        private System.Windows.Forms.Label lblIngredientName4;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblRecipeName1;
        private System.Windows.Forms.CheckBox chkUseRefinedMaterials;
        private System.Windows.Forms.ToolTip ttToolTips;
        private System.Windows.Forms.Label lblShoppingList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.ListView listShoppingList;
        private System.Windows.Forms.ColumnHeader listShoppingMaterial;
        private System.Windows.Forms.ColumnHeader listShoppingCount;
        private System.Windows.Forms.ColumnHeader listShoppingPrice;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Panel panelShopping;
        private System.Windows.Forms.CheckBox chkShowShopping;
        private System.Windows.Forms.Panel panelRecipes;
    }
}

