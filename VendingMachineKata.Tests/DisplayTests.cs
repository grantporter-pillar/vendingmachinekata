using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata.Library;
using VendingMachineKata.Tests;

namespace VendingMachineKata.Tests
{
    [TestClass]
    public class DisplayTests
    {
        [TestMethod]
        public void WhenTheMachineIsReadyToAcceptMoney_TheDisplayReadsInsertCoin()
        {
            var vm = new VendingMachine();

            Assert.AreEqual(vm.GetDisplay(), @"INSERT COIN");
        }

        [TestMethod]
        public void WhenTheMachineHasMoneyInserted_TheDisplayReadsAnAmount()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaNickel, 10),
                },
            };

            vm.AcceptCoin(TestDefinitions.UsaNickel.MassGrams, TestDefinitions.UsaNickel.DiameterMillimeters);

            Assert.IsTrue(Decimal.TryParse(vm.GetDisplay(), out var amountInserted));
        }

        [TestMethod]
        public void WhenTheMachineHasMoneyInserted_TheDisplayReadsAmountInserted()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaNickel, 10),
                },
            };

            vm.AcceptCoin(TestDefinitions.UsaNickel.MassGrams, TestDefinitions.UsaNickel.DiameterMillimeters);

            Assert.AreEqual(vm.GetDisplay(), 0.05m.ToString());
        }

        [TestMethod]
        public void WhenAProductIsChosenAndNotEnoughMoneyHasBeenInserted_TheDisplayReadsTheProductPrice()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaNickel, 10),
                },
                DispenserChannels = new []
                {
                    new DispenserChannel { Price = 0.50m, Inventory = 1 }
                },
            };

            vm.AcceptCoin(TestDefinitions.UsaNickel.MassGrams, TestDefinitions.UsaNickel.DiameterMillimeters);

            vm.PurchaseProduct(0);

            Assert.AreEqual(vm.GetDisplay(), @"PRICE $0.50");
        }

        [TestMethod]
        public void WhenAProductIsPurchased_TheDisplayReadsThankYou()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaQuarter, 10),
                },
                DispenserChannels = new[]
                {
                    new DispenserChannel { Price = 0.50m, Inventory = 1 }
                },
            };

            vm.AcceptCoin(TestDefinitions.UsaQuarter.MassGrams, TestDefinitions.UsaQuarter.DiameterMillimeters);
            vm.AcceptCoin(TestDefinitions.UsaQuarter.MassGrams, TestDefinitions.UsaQuarter.DiameterMillimeters);

            vm.PurchaseProduct(0);

            Assert.AreEqual(vm.GetDisplay(), @"THANK YOU");
        }

        [TestMethod]
        public void WhenAProductChosenIsSoldOut_TheDisplayReadsSoldOut()
        {
            var vm = new VendingMachine()
            {
                DispenserChannels = new[]
                {
                    new DispenserChannel { Price = 1.00m, Inventory = 0 }
                },
            };

            vm.PurchaseProduct(0);

            Assert.AreEqual(vm.GetDisplay(), @"SOLD OUT");
        }
    }
}
