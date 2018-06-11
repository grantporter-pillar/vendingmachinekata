﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata.Library;

namespace VendingMachineKata.Tests
{
    [TestClass]
    public class CoinChangerTests
    {
        [TestMethod]
        public void WhenCustomerWantsMoneyInsertedReturned_AmountInsertedRevertsToZero()
        {
            var vm = new VendingMachine();

            vm.AmountInserted = 1.00m;

            vm.ReturnInsertedCoins();

            Assert.AreEqual(vm.AmountInserted, 0m);
        }

        [TestMethod]
        public void WhenACoinIsInserted_AmountInsertedIncreases()
        {
            var vm = new VendingMachine();

            vm.AmountInserted = 0m;

            vm.AcceptCoin(2.500, 19.05); // USA Penny

            Assert.IsTrue(vm.AmountInserted > 0m);
        }
    }
}
