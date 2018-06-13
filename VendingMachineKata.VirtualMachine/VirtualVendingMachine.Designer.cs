namespace VendingMachineKata.VirtualMachine
{
    partial class VirtualVendingMachine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VirtualVendingMachine));
            this.labelDisplay = new System.Windows.Forms.Label();
            this.timerUpdateDisplay = new System.Windows.Forms.Timer(this.components);
            this.buttonInsertPenny = new System.Windows.Forms.Button();
            this.buttonInsertNickel = new System.Windows.Forms.Button();
            this.buttonInsertDime = new System.Windows.Forms.Button();
            this.buttonInsertQuarter = new System.Windows.Forms.Button();
            this.buttonCoinReturn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCoinReturn = new System.Windows.Forms.TextBox();
            this.buttonEmptyCoinReturn = new System.Windows.Forms.Button();
            this.textBoxInventory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBuyCola = new System.Windows.Forms.Button();
            this.buttonBuyCandy = new System.Windows.Forms.Button();
            this.buttonBuyChips = new System.Windows.Forms.Button();
            this.textBoxProductOutput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonEmptyProductOutput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelDisplay
            // 
            this.labelDisplay.BackColor = System.Drawing.Color.Black;
            this.labelDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDisplay.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisplay.ForeColor = System.Drawing.Color.Red;
            this.labelDisplay.Location = new System.Drawing.Point(0, 0);
            this.labelDisplay.Name = "labelDisplay";
            this.labelDisplay.Size = new System.Drawing.Size(420, 60);
            this.labelDisplay.TabIndex = 3;
            this.labelDisplay.Text = "DISPLAY";
            // 
            // timerUpdateDisplay
            // 
            this.timerUpdateDisplay.Interval = 3000;
            this.timerUpdateDisplay.Tick += new System.EventHandler(this.timerUpdateDisplay_Tick);
            // 
            // buttonInsertPenny
            // 
            this.buttonInsertPenny.BackColor = System.Drawing.Color.White;
            this.buttonInsertPenny.Image = ((System.Drawing.Image)(resources.GetObject("buttonInsertPenny.Image")));
            this.buttonInsertPenny.Location = new System.Drawing.Point(223, 72);
            this.buttonInsertPenny.Margin = new System.Windows.Forms.Padding(0);
            this.buttonInsertPenny.Name = "buttonInsertPenny";
            this.buttonInsertPenny.Size = new System.Drawing.Size(85, 85);
            this.buttonInsertPenny.TabIndex = 4;
            this.buttonInsertPenny.UseVisualStyleBackColor = false;
            this.buttonInsertPenny.Click += new System.EventHandler(this.buttonInsertPenny_Click);
            // 
            // buttonInsertNickel
            // 
            this.buttonInsertNickel.BackColor = System.Drawing.Color.White;
            this.buttonInsertNickel.Image = ((System.Drawing.Image)(resources.GetObject("buttonInsertNickel.Image")));
            this.buttonInsertNickel.Location = new System.Drawing.Point(323, 72);
            this.buttonInsertNickel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonInsertNickel.Name = "buttonInsertNickel";
            this.buttonInsertNickel.Size = new System.Drawing.Size(85, 85);
            this.buttonInsertNickel.TabIndex = 5;
            this.buttonInsertNickel.UseVisualStyleBackColor = false;
            this.buttonInsertNickel.Click += new System.EventHandler(this.buttonInsertNickel_Click);
            // 
            // buttonInsertDime
            // 
            this.buttonInsertDime.BackColor = System.Drawing.Color.White;
            this.buttonInsertDime.Image = ((System.Drawing.Image)(resources.GetObject("buttonInsertDime.Image")));
            this.buttonInsertDime.Location = new System.Drawing.Point(223, 172);
            this.buttonInsertDime.Margin = new System.Windows.Forms.Padding(0);
            this.buttonInsertDime.Name = "buttonInsertDime";
            this.buttonInsertDime.Size = new System.Drawing.Size(85, 85);
            this.buttonInsertDime.TabIndex = 6;
            this.buttonInsertDime.UseVisualStyleBackColor = false;
            this.buttonInsertDime.Click += new System.EventHandler(this.buttonInsertDime_Click);
            // 
            // buttonInsertQuarter
            // 
            this.buttonInsertQuarter.BackColor = System.Drawing.Color.White;
            this.buttonInsertQuarter.Image = ((System.Drawing.Image)(resources.GetObject("buttonInsertQuarter.Image")));
            this.buttonInsertQuarter.Location = new System.Drawing.Point(323, 172);
            this.buttonInsertQuarter.Margin = new System.Windows.Forms.Padding(0);
            this.buttonInsertQuarter.Name = "buttonInsertQuarter";
            this.buttonInsertQuarter.Size = new System.Drawing.Size(85, 85);
            this.buttonInsertQuarter.TabIndex = 7;
            this.buttonInsertQuarter.UseVisualStyleBackColor = false;
            this.buttonInsertQuarter.Click += new System.EventHandler(this.buttonInsertQuarter_Click);
            // 
            // buttonCoinReturn
            // 
            this.buttonCoinReturn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCoinReturn.Location = new System.Drawing.Point(223, 270);
            this.buttonCoinReturn.Name = "buttonCoinReturn";
            this.buttonCoinReturn.Size = new System.Drawing.Size(185, 85);
            this.buttonCoinReturn.TabIndex = 8;
            this.buttonCoinReturn.Text = "RETURN COINS";
            this.buttonCoinReturn.UseVisualStyleBackColor = true;
            this.buttonCoinReturn.Click += new System.EventHandler(this.buttonCoinReturn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Coin Return";
            // 
            // textBoxCoinReturn
            // 
            this.textBoxCoinReturn.Location = new System.Drawing.Point(223, 383);
            this.textBoxCoinReturn.Multiline = true;
            this.textBoxCoinReturn.Name = "textBoxCoinReturn";
            this.textBoxCoinReturn.Size = new System.Drawing.Size(185, 96);
            this.textBoxCoinReturn.TabIndex = 10;
            // 
            // buttonEmptyCoinReturn
            // 
            this.buttonEmptyCoinReturn.Location = new System.Drawing.Point(223, 487);
            this.buttonEmptyCoinReturn.Name = "buttonEmptyCoinReturn";
            this.buttonEmptyCoinReturn.Size = new System.Drawing.Size(185, 23);
            this.buttonEmptyCoinReturn.TabIndex = 11;
            this.buttonEmptyCoinReturn.Text = "Empty Coin Return";
            this.buttonEmptyCoinReturn.UseVisualStyleBackColor = true;
            this.buttonEmptyCoinReturn.Click += new System.EventHandler(this.buttonEmptyCoinReturn_Click);
            // 
            // textBoxInventory
            // 
            this.textBoxInventory.Enabled = false;
            this.textBoxInventory.Location = new System.Drawing.Point(10, 88);
            this.textBoxInventory.Multiline = true;
            this.textBoxInventory.Name = "textBoxInventory";
            this.textBoxInventory.Size = new System.Drawing.Size(76, 267);
            this.textBoxInventory.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(7, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Inventory";
            // 
            // buttonBuyCola
            // 
            this.buttonBuyCola.BackColor = System.Drawing.Color.White;
            this.buttonBuyCola.Image = ((System.Drawing.Image)(resources.GetObject("buttonBuyCola.Image")));
            this.buttonBuyCola.Location = new System.Drawing.Point(108, 172);
            this.buttonBuyCola.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBuyCola.Name = "buttonBuyCola";
            this.buttonBuyCola.Size = new System.Drawing.Size(85, 85);
            this.buttonBuyCola.TabIndex = 14;
            this.buttonBuyCola.UseVisualStyleBackColor = false;
            this.buttonBuyCola.Click += new System.EventHandler(this.buttonBuyCola_Click);
            // 
            // buttonBuyCandy
            // 
            this.buttonBuyCandy.BackColor = System.Drawing.Color.White;
            this.buttonBuyCandy.Image = ((System.Drawing.Image)(resources.GetObject("buttonBuyCandy.Image")));
            this.buttonBuyCandy.Location = new System.Drawing.Point(108, 270);
            this.buttonBuyCandy.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBuyCandy.Name = "buttonBuyCandy";
            this.buttonBuyCandy.Size = new System.Drawing.Size(85, 85);
            this.buttonBuyCandy.TabIndex = 15;
            this.buttonBuyCandy.UseVisualStyleBackColor = false;
            this.buttonBuyCandy.Click += new System.EventHandler(this.buttonBuyCandy_Click);
            // 
            // buttonBuyChips
            // 
            this.buttonBuyChips.BackColor = System.Drawing.Color.White;
            this.buttonBuyChips.Image = ((System.Drawing.Image)(resources.GetObject("buttonBuyChips.Image")));
            this.buttonBuyChips.Location = new System.Drawing.Point(108, 72);
            this.buttonBuyChips.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBuyChips.Name = "buttonBuyChips";
            this.buttonBuyChips.Size = new System.Drawing.Size(85, 85);
            this.buttonBuyChips.TabIndex = 16;
            this.buttonBuyChips.UseVisualStyleBackColor = false;
            this.buttonBuyChips.Click += new System.EventHandler(this.buttonBuyChips_Click);
            // 
            // textBoxProductOutput
            // 
            this.textBoxProductOutput.Enabled = false;
            this.textBoxProductOutput.Location = new System.Drawing.Point(10, 383);
            this.textBoxProductOutput.Multiline = true;
            this.textBoxProductOutput.Name = "textBoxProductOutput";
            this.textBoxProductOutput.Size = new System.Drawing.Size(183, 96);
            this.textBoxProductOutput.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(7, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Product Output";
            // 
            // buttonEmptyProductOutput
            // 
            this.buttonEmptyProductOutput.Location = new System.Drawing.Point(10, 487);
            this.buttonEmptyProductOutput.Name = "buttonEmptyProductOutput";
            this.buttonEmptyProductOutput.Size = new System.Drawing.Size(183, 23);
            this.buttonEmptyProductOutput.TabIndex = 19;
            this.buttonEmptyProductOutput.Text = "Empty Product Output";
            this.buttonEmptyProductOutput.UseVisualStyleBackColor = true;
            this.buttonEmptyProductOutput.Click += new System.EventHandler(this.buttonEmptyProductOutput_Click);
            // 
            // VirtualVendingMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 521);
            this.Controls.Add(this.buttonEmptyProductOutput);
            this.Controls.Add(this.textBoxProductOutput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonBuyChips);
            this.Controls.Add(this.buttonBuyCandy);
            this.Controls.Add(this.buttonBuyCola);
            this.Controls.Add(this.textBoxInventory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonEmptyCoinReturn);
            this.Controls.Add(this.textBoxCoinReturn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCoinReturn);
            this.Controls.Add(this.buttonInsertQuarter);
            this.Controls.Add(this.buttonInsertDime);
            this.Controls.Add(this.buttonInsertNickel);
            this.Controls.Add(this.buttonInsertPenny);
            this.Controls.Add(this.labelDisplay);
            this.Name = "VirtualVendingMachine";
            this.Text = "Vending Machine";
            this.Load += new System.EventHandler(this.VirtualVendingMachine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelDisplay;
        private System.Windows.Forms.Timer timerUpdateDisplay;
        private System.Windows.Forms.Button buttonInsertPenny;
        private System.Windows.Forms.Button buttonInsertNickel;
        private System.Windows.Forms.Button buttonInsertDime;
        private System.Windows.Forms.Button buttonInsertQuarter;
        private System.Windows.Forms.Button buttonCoinReturn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCoinReturn;
        private System.Windows.Forms.Button buttonEmptyCoinReturn;
        private System.Windows.Forms.TextBox textBoxInventory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBuyCola;
        private System.Windows.Forms.Button buttonBuyCandy;
        private System.Windows.Forms.Button buttonBuyChips;
        private System.Windows.Forms.TextBox textBoxProductOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonEmptyProductOutput;
    }
}

