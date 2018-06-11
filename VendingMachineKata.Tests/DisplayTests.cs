﻿using System;
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
                Products = new[] { 0.50m },
                AmountInserted = 0.25m,
            };

            vm.PurchaseProduct(0);

            Assert.AreEqual(vm.GetDisplay(), @"PRICE $0.50");
        }
    }
}
