﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using VendingMachineKata.Library;

namespace VendingMachineKata.VirtualMachine
{
    public partial class VirtualVendingMachine : Form
    {
        protected VendingMachine VM { get; set; }

        public VirtualVendingMachine()
        {
            InitializeComponent();
        }

        private void VirtualVendingMachine_Load(object sender, System.EventArgs e)
        {
            VM = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaNickel, 102) { CountInTube = 0 },
                    new CoinTube(TestDefinitions.UsaDime, 148) { CountInTube = 10 },
                    new CoinTube(TestDefinitions.UsaQuarter, 114) { CountInTube = 10 },
                },
                DispenserChannels = new[]
                {
                    new DispenserChannel { Price = 1.00m, Inventory = 15 },
                    new DispenserChannel { Price = 0.50m, Inventory = 15 },
                    new DispenserChannel { Price = 0.65m, Inventory = 15 },
                },
            };

            VM.CoinDispensed += VM_CoinDispensed;

            UpdateDisplay();
            UpdateInventory();
        }

        private void VM_CoinDispensed(object sender, EventArgs e)
        {
            if (e == null)
            {
                textBoxCoinReturn.Text = @"[Invalid Coin]"
                    + Environment.NewLine + textBoxCoinReturn.Text;
                return;
            }
            if (e.GetType() == typeof(CoinDispensedEventArgs))
            {
                textBoxCoinReturn.Text = $"${((CoinDispensedEventArgs)e).CoinSpec.Value}"
                    + Environment.NewLine + textBoxCoinReturn.Text;
            }
        }

        private void UpdateDisplay()
        {
            timerUpdateDisplay.Stop();
            labelDisplay.Text = VM.GetDisplay();
            timerUpdateDisplay.Start();
        }

        private void UpdateInventory()
        {
            var inventoryDisplayLines = new List<string>();

            inventoryDisplayLines
                .AddRange(VM.CoinTubes.OrderBy(i => i.Spec.Value)
                .Select(i => $"{i.Spec.Value}: {i.CountInTube}/{i.Capacity}"));

            inventoryDisplayLines.Add(string.Empty);

            inventoryDisplayLines.Add($"Cola: {VM.DispenserChannels[0].Inventory}");
            inventoryDisplayLines.Add($"Chips: {VM.DispenserChannels[1].Inventory}");
            inventoryDisplayLines.Add($"Candy: {VM.DispenserChannels[2].Inventory}");

            textBoxInventory.Text = string.Join(Environment.NewLine, inventoryDisplayLines);
        }

        private void timerUpdateDisplay_Tick(object sender, System.EventArgs e)
        {
            UpdateDisplay();
        }

        #region Button Click Event Handlers
        private void buttonBuyCola_Click(object sender, EventArgs e)
        {
            if (VM.PurchaseProduct(0))
            {
                textBoxProductOutput.Text = @"Cola" + Environment.NewLine + textBoxProductOutput.Text;
            }

            UpdateDisplay();
            UpdateInventory();
        }

        private void buttonBuyChips_Click(object sender, EventArgs e)
        {
            if (VM.PurchaseProduct(1))
            {
                textBoxProductOutput.Text = @"Chips" + Environment.NewLine + textBoxProductOutput.Text;
            }

            UpdateDisplay();
            UpdateInventory();
        }

        private void buttonBuyCandy_Click(object sender, EventArgs e)
        {
            if (VM.PurchaseProduct(2))
            {
                textBoxProductOutput.Text = @"Candy" + Environment.NewLine + textBoxProductOutput.Text;
            }

            UpdateDisplay();
            UpdateInventory();
        }

        private void buttonInsertPenny_Click(object sender, System.EventArgs e)
        {
            VM.AcceptCoin(TestDefinitions.UsaPenny.MassGrams, TestDefinitions.UsaPenny.DiameterMillimeters);
            UpdateDisplay();
            UpdateInventory();
        }

        private void buttonInsertNickel_Click(object sender, System.EventArgs e)
        {
            VM.AcceptCoin(TestDefinitions.UsaNickel.MassGrams, TestDefinitions.UsaNickel.DiameterMillimeters);
            UpdateDisplay();
            UpdateInventory();
        }

        private void buttonInsertDime_Click(object sender, System.EventArgs e)
        {
            VM.AcceptCoin(TestDefinitions.UsaDime.MassGrams, TestDefinitions.UsaDime.DiameterMillimeters);
            UpdateDisplay();
            UpdateInventory();
        }

        private void buttonInsertQuarter_Click(object sender, System.EventArgs e)
        {
            VM.AcceptCoin(TestDefinitions.UsaQuarter.MassGrams, TestDefinitions.UsaQuarter.DiameterMillimeters);
            UpdateDisplay();
            UpdateInventory();
        }
        
        private void buttonCoinReturn_Click(object sender, System.EventArgs e)
        {
            var amountToReturn = VM.AmountInserted;
            VM.DispenseCoins(amountToReturn);
            UpdateDisplay();
            UpdateInventory();
        }
        
        private void buttonEmptyCoinReturn_Click(object sender, EventArgs e)
        {
            textBoxCoinReturn.Text = string.Empty;
        }
        
        private void buttonEmptyProductOutput_Click(object sender, EventArgs e)
        {
            textBoxProductOutput.Text = string.Empty;
        }
        #endregion
    }
}
