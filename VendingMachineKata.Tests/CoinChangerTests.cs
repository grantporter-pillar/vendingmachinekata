using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata.Library;

namespace VendingMachineKata.Tests
{
    [TestClass]
    public class CoinChangerTests
    {
        static List<CoinSpecification> AcceptedCoins { get; set; }

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            AcceptedCoins = new List<CoinSpecification>()
            {
                new CoinSpecification(5.000, 21.21,  0.05m), // USA Nickel
                new CoinSpecification(2.268, 17.91,  0.10m), // USA Dime
                new CoinSpecification(5.670, 24.26,  0.25m), // USA Quarter
            };
        }

        [TestMethod]
        public void WhenCustomerWantsMoneyInsertedReturned_AmountInsertedRevertsToZero()
        {
            var vm = new VendingMachine()
            {
                AmountInserted = 1.00m,
            };

            vm.ReturnInsertedCoins();

            Assert.AreEqual(vm.AmountInserted, 0m);
        }

        [TestMethod]
        public void WhenAnAcceptableCoinIsInserted_AmountInsertedIncreases()
        {
            var vm = new VendingMachine()
            {
                AmountInserted = 0m,
                AcceptedCoins = AcceptedCoins,
            };

            vm.AcceptCoin(5.000, 21.21); // USA Nickel

            Assert.IsTrue(vm.AmountInserted > 0m);
        }

        [TestMethod]
        public void WhenACoinIsInserted_AValueIsDetermined()
        {
            var vm = new VendingMachine()
            {
                AcceptedCoins = AcceptedCoins,
            };

            Assert.IsInstanceOfType(vm.GetCoinValue(2.500, 19.05), typeof(decimal)); // USA Penny
        }

        [TestMethod]
        public void WhenAnUnacceptableCoinIsInserted_ValueIsZero()
        {
            var vm = new VendingMachine()
            {
                AcceptedCoins = AcceptedCoins,
            };

            Assert.AreEqual(vm.GetCoinValue(2.500, 19.05), 0m); // USA Penny
        }

        [TestMethod]
        public void WhenAnAcceptableCoinIsInserted_PositiveValueIsDetermined()
        {
            var vm = new VendingMachine()
            {
                AcceptedCoins = AcceptedCoins,
            };

            Assert.IsTrue(vm.GetCoinValue(5.000, 21.21) > 0m); // USA Nickel
        }

        [TestMethod]
        public void WhenAnAcceptableCoinIsInserted_CorrectValueIsDetermined()
        {
            var vm = new VendingMachine()
            {
                AcceptedCoins = AcceptedCoins,
            };

            Assert.AreEqual(vm.GetCoinValue(5.000, 21.21), 0.05m); // USA Nickel
            Assert.AreEqual(vm.GetCoinValue(2.268, 17.91), 0.10m); // USA Dime
            Assert.AreEqual(vm.GetCoinValue(5.670, 24.26), 0.25m); // USA Quarter
        }
    }
}
