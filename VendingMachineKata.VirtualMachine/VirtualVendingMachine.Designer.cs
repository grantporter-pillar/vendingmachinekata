﻿namespace VendingMachineKata.VirtualMachine
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
            this.labelDisplay.Size = new System.Drawing.Size(388, 60);
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
            this.buttonInsertPenny.Image = ((System.Drawing.Image)(resources.GetObject("buttonInsertPenny.Image")));
            this.buttonInsertPenny.Location = new System.Drawing.Point(193, 72);
            this.buttonInsertPenny.Margin = new System.Windows.Forms.Padding(0);
            this.buttonInsertPenny.Name = "buttonInsertPenny";
            this.buttonInsertPenny.Size = new System.Drawing.Size(85, 85);
            this.buttonInsertPenny.TabIndex = 4;
            this.buttonInsertPenny.UseVisualStyleBackColor = true;
            this.buttonInsertPenny.Click += new System.EventHandler(this.buttonInsertPenny_Click);
            // 
            // buttonInsertNickel
            // 
            this.buttonInsertNickel.Image = ((System.Drawing.Image)(resources.GetObject("buttonInsertNickel.Image")));
            this.buttonInsertNickel.Location = new System.Drawing.Point(293, 72);
            this.buttonInsertNickel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonInsertNickel.Name = "buttonInsertNickel";
            this.buttonInsertNickel.Size = new System.Drawing.Size(85, 85);
            this.buttonInsertNickel.TabIndex = 5;
            this.buttonInsertNickel.UseVisualStyleBackColor = true;
            this.buttonInsertNickel.Click += new System.EventHandler(this.buttonInsertNickel_Click);
            // 
            // buttonInsertDime
            // 
            this.buttonInsertDime.Image = ((System.Drawing.Image)(resources.GetObject("buttonInsertDime.Image")));
            this.buttonInsertDime.Location = new System.Drawing.Point(193, 172);
            this.buttonInsertDime.Margin = new System.Windows.Forms.Padding(0);
            this.buttonInsertDime.Name = "buttonInsertDime";
            this.buttonInsertDime.Size = new System.Drawing.Size(85, 85);
            this.buttonInsertDime.TabIndex = 6;
            this.buttonInsertDime.UseVisualStyleBackColor = true;
            this.buttonInsertDime.Click += new System.EventHandler(this.buttonInsertDime_Click);
            // 
            // buttonInsertQuarter
            // 
            this.buttonInsertQuarter.Image = ((System.Drawing.Image)(resources.GetObject("buttonInsertQuarter.Image")));
            this.buttonInsertQuarter.Location = new System.Drawing.Point(293, 172);
            this.buttonInsertQuarter.Margin = new System.Windows.Forms.Padding(0);
            this.buttonInsertQuarter.Name = "buttonInsertQuarter";
            this.buttonInsertQuarter.Size = new System.Drawing.Size(85, 85);
            this.buttonInsertQuarter.TabIndex = 7;
            this.buttonInsertQuarter.UseVisualStyleBackColor = true;
            this.buttonInsertQuarter.Click += new System.EventHandler(this.buttonInsertQuarter_Click);
            // 
            // buttonCoinReturn
            // 
            this.buttonCoinReturn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCoinReturn.Location = new System.Drawing.Point(193, 270);
            this.buttonCoinReturn.Name = "buttonCoinReturn";
            this.buttonCoinReturn.Size = new System.Drawing.Size(185, 33);
            this.buttonCoinReturn.TabIndex = 8;
            this.buttonCoinReturn.Text = "RETURN COINS";
            this.buttonCoinReturn.UseVisualStyleBackColor = true;
            this.buttonCoinReturn.Click += new System.EventHandler(this.buttonCoinReturn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Coin Return";
            // 
            // textBoxCoinReturn
            // 
            this.textBoxCoinReturn.Location = new System.Drawing.Point(193, 342);
            this.textBoxCoinReturn.Multiline = true;
            this.textBoxCoinReturn.Name = "textBoxCoinReturn";
            this.textBoxCoinReturn.Size = new System.Drawing.Size(185, 53);
            this.textBoxCoinReturn.TabIndex = 10;
            // 
            // buttonEmptyCoinReturn
            // 
            this.buttonEmptyCoinReturn.Location = new System.Drawing.Point(193, 401);
            this.buttonEmptyCoinReturn.Name = "buttonEmptyCoinReturn";
            this.buttonEmptyCoinReturn.Size = new System.Drawing.Size(185, 23);
            this.buttonEmptyCoinReturn.TabIndex = 11;
            this.buttonEmptyCoinReturn.Text = "Empty Coin Return";
            this.buttonEmptyCoinReturn.UseVisualStyleBackColor = true;
            this.buttonEmptyCoinReturn.Click += new System.EventHandler(this.buttonEmptyCoinReturn_Click);
            // 
            // textBoxInventory
            // 
            this.textBoxInventory.Location = new System.Drawing.Point(10, 270);
            this.textBoxInventory.Multiline = true;
            this.textBoxInventory.Name = "textBoxInventory";
            this.textBoxInventory.Size = new System.Drawing.Size(165, 154);
            this.textBoxInventory.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Inventory";
            // 
            // VirtualVendingMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 431);
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
    }
}

