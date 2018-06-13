using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata.Library;

namespace VendingMachineKata.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void WhenAProductIsChosen_APriceIsDetermined()
        {
            var vm = new VendingMachine()
            {
                DispenserChannels = new[]
                {
                    new DispenserChannel { Price = 1.00m, Inventory = 1 }
                },
            };

            Assert.IsTrue(vm.GetProductPrice(0) > 0m);
        }

        [TestMethod]
        public void WhenAProductIsChosenAndEnoughMoneyHasBeenInserted_TheProductIsDispensed()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaQuarter, 10),
                },
                DispenserChannels = new[]
                {
                    new DispenserChannel { Price = 1.00m, Inventory = 1 }
                },
            };

            vm.AcceptCoin(TestDefinitions.UsaQuarter.MassGrams, TestDefinitions.UsaQuarter.DiameterMillimeters);
            vm.AcceptCoin(TestDefinitions.UsaQuarter.MassGrams, TestDefinitions.UsaQuarter.DiameterMillimeters);
            vm.AcceptCoin(TestDefinitions.UsaQuarter.MassGrams, TestDefinitions.UsaQuarter.DiameterMillimeters);
            vm.AcceptCoin(TestDefinitions.UsaQuarter.MassGrams, TestDefinitions.UsaQuarter.DiameterMillimeters);

            Assert.IsTrue(vm.PurchaseProduct(0));
        }

        [TestMethod]
        public void WhenAProductIsChosenAndNotEnoughMoneyHasBeenInserted_TheProductIsNotDispensed()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaQuarter, 10),
                },
                DispenserChannels = new[]
                {
                    new DispenserChannel { Price = 1.00m, Inventory = 1 }
                },
            };

            vm.AcceptCoin(TestDefinitions.UsaQuarter.MassGrams, TestDefinitions.UsaQuarter.DiameterMillimeters);
            vm.AcceptCoin(TestDefinitions.UsaQuarter.MassGrams, TestDefinitions.UsaQuarter.DiameterMillimeters);

            Assert.IsFalse(vm.PurchaseProduct(0));
        }

        [TestMethod]
        public void WhenAProductIsDispensed_TheAmountInsertedDecreases()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaQuarter, 10),
                },
                DispenserChannels = new[]
                {
                    new DispenserChannel { Price = 1.00m, Inventory = 1 }
                },
            };

            for (int i = 0; i < 8; i++) // $2.00
            {
                vm.AcceptCoin(TestDefinitions.UsaQuarter.MassGrams, TestDefinitions.UsaQuarter.DiameterMillimeters);
            }

            var originalAmountInserted = vm.AmountInserted;

            vm.PurchaseProduct(0);

            Assert.IsTrue(vm.AmountInserted < originalAmountInserted);
        }
    }
}
