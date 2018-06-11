using System;
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
                Products = new [] { 1.00m }
            };

            Assert.IsTrue(vm.GetProductPrice(0) > 0m);
        }

        [TestMethod]
        public void WhenAProductIsChosenAndEnoughMoneyHasBeenInserted_TheProductIsDispensed()
        {
            var vm = new VendingMachine()
            {
                Products = new[] { 1.00m },
                AmountInserted = 1.00m,
            };

            Assert.IsTrue(vm.PurchaseProduct(0));
        }

        [TestMethod]
        public void WhenAProductIsChosenAndNotEnoughMoneyHasBeenInserted_TheProductIsNotDispensed()
        {
            var vm = new VendingMachine()
            {
                Products = new[] { 1.00m },
                AmountInserted = 0.50m,
            };

            Assert.IsFalse(vm.PurchaseProduct(0));
        }

        [TestMethod]
        public void WhenAProductIsDispensed_TheAmountInsertedDecreases()
        {
            var vm = new VendingMachine()
            {
                Products = new[] { 1.00m },
                AmountInserted = 2.00m,
            };

            var originalAmountInserted = vm.AmountInserted;

            vm.PurchaseProduct(0);

            Assert.IsTrue(vm.AmountInserted < originalAmountInserted);
        }
    }
}
