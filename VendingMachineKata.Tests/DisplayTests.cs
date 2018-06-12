using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata.Library;

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
            var vm = new VendingMachine
            {
                AmountInserted = 1.00m
            };

            Assert.IsTrue(Decimal.TryParse(vm.GetDisplay(), out var amountInserted));
        }

        [TestMethod]
        public void WhenTheMachineHasMoneyInserted_TheDisplayReadsAmountInserted()
        {
            var vm = new VendingMachine
            {
                AmountInserted = 1.00m
            };

            Assert.IsTrue(Decimal.TryParse(vm.GetDisplay(), out var amountInserted));
            Assert.AreEqual(vm.AmountInserted, amountInserted);
        }

        [TestMethod]
        public void WhenAProductIsChosenAndNotEnoughMoneyHasBeenInserted_TheDisplayReadsTheProductPrice()
        {
            var vm = new VendingMachine()
            {
                DispenserChannels = new []
                {
                    new DispenserChannel { Price = 0.50m, Inventory = 1 }
                },
                AmountInserted = 0.25m,
            };

            vm.PurchaseProduct(0);

            Assert.AreEqual(vm.GetDisplay(), @"PRICE $0.50");
        }

        [TestMethod]
        public void WhenAProductIsPurchased_TheDisplayReadsThankYou()
        {
            var vm = new VendingMachine()
            {
                DispenserChannels = new[]
                {
                    new DispenserChannel { Price = 0.50m, Inventory = 1 }
                },
                AmountInserted = 0.50m,
            };

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
