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
    }
}
