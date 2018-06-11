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
            var vm = new VendingMachine();

            vm.AmountInserted = 1.00m;

            Assert.IsTrue(Decimal.TryParse(vm.GetDisplay(), out var amountInserted));
        }
    }
}
