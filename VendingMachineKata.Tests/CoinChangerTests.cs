using System;
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
    }
}
