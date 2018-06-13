using System.Collections.Generic;
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
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaQuarter, 10),
                },
            };

            vm.AcceptCoin(TestDefinitions.UsaQuarter.MassGrams, TestDefinitions.UsaQuarter.DiameterMillimeters);
            vm.AcceptCoin(TestDefinitions.UsaQuarter.MassGrams, TestDefinitions.UsaQuarter.DiameterMillimeters);
            vm.AcceptCoin(TestDefinitions.UsaQuarter.MassGrams, TestDefinitions.UsaQuarter.DiameterMillimeters);
            vm.AcceptCoin(TestDefinitions.UsaQuarter.MassGrams, TestDefinitions.UsaQuarter.DiameterMillimeters);

            Assert.AreEqual(vm.AmountInserted, 1.00m);

            vm.DispenseCoins(1.00m);

            Assert.AreEqual(vm.AmountInserted, 0m);
        }

        [TestMethod]
        public void WhenAnUnacceptableCoinIsInserted_CoinIsNotIdentified()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaNickel, 10),
                },
            };

            Assert.IsNull(vm.IdentifyCoin(TestDefinitions.UsaPenny.MassGrams, TestDefinitions.UsaPenny.DiameterMillimeters));
        }

        [TestMethod]
        public void WhenAnAcceptableCoinIsInserted_CoinIsIdentified()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaNickel, 10),
                },
            };

            Assert.IsNotNull(vm.IdentifyCoin(TestDefinitions.UsaNickel.MassGrams, TestDefinitions.UsaNickel.DiameterMillimeters));
        }

        [TestMethod]
        public void WhenAnAcceptableCoinIsInserted_CoinIsCorrectlyIdentified()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaNickel, 10),
                    new CoinTube(TestDefinitions.UsaDime, 10),
                    new CoinTube(TestDefinitions.UsaQuarter, 10),
                },
            };

            Assert.AreEqual(vm.IdentifyCoin(TestDefinitions.UsaNickel.MassGrams, TestDefinitions.UsaNickel.DiameterMillimeters), TestDefinitions.UsaNickel);
            Assert.AreEqual(vm.IdentifyCoin(TestDefinitions.UsaDime.MassGrams, TestDefinitions.UsaDime.DiameterMillimeters), TestDefinitions.UsaDime);
            Assert.AreEqual(vm.IdentifyCoin(TestDefinitions.UsaQuarter.MassGrams, TestDefinitions.UsaQuarter.DiameterMillimeters), TestDefinitions.UsaQuarter);
        }

        [TestMethod]
        public void WhenAnAcceptableCoinIsInserted_AmountInsertedIncreases()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaNickel, 10),
                },
            };

            vm.AcceptCoin(TestDefinitions.UsaNickel.MassGrams, TestDefinitions.UsaNickel.DiameterMillimeters);

            Assert.IsTrue(vm.AmountInserted > 0m);
        }

        [TestMethod]
        public void WhenAnAcceptableCoinIsInserted_TheCoinInventoryIncreases()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaNickel, 10),
                },
            };

            vm.AcceptCoin(TestDefinitions.UsaNickel.MassGrams, TestDefinitions.UsaNickel.DiameterMillimeters);

            Assert.IsTrue(vm.GetCoinInventory(TestDefinitions.UsaNickel) > 0);
        }

        [TestMethod]
        public void WhenAnAcceptableCoinIsInsertedAndAllCoinTubesAreFull_TheCoinInventoryStaysTheSame()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaNickel, 10),
                    new CoinTube(TestDefinitions.UsaNickel, 10),
                },
            };

            for (int i = 0; i < 20; i++)
            {
                vm.AcceptCoin(TestDefinitions.UsaNickel.MassGrams, TestDefinitions.UsaNickel.DiameterMillimeters);
            }

            Assert.IsTrue(vm.GetCoinInventory(TestDefinitions.UsaNickel) == 20);

            vm.AcceptCoin(TestDefinitions.UsaNickel.MassGrams, TestDefinitions.UsaNickel.DiameterMillimeters);

            Assert.IsTrue(vm.GetCoinInventory(TestDefinitions.UsaNickel) == 20);
        }

        [TestMethod]
        public void WhenCoinsNeedDispensedAndCoinInventoryAllows_DetermineThatCoinsCanBeDispensed()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaNickel, 10),
                },
            };

            vm.AcceptCoin(TestDefinitions.UsaNickel.MassGrams, TestDefinitions.UsaNickel.DiameterMillimeters);
            vm.AcceptCoin(TestDefinitions.UsaNickel.MassGrams, TestDefinitions.UsaNickel.DiameterMillimeters);

            Assert.IsTrue(vm.CanDispenseCoins(0.10m));
        }

        [TestMethod]
        public void WhenCoinsNeedDispensedAndCoinInventoryDoesNotAllow_DetermineThatCoinsCanNotBeDispensed()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaNickel, 10),
                },
            };

            vm.AcceptCoin(TestDefinitions.UsaNickel.MassGrams, TestDefinitions.UsaNickel.DiameterMillimeters);

            Assert.IsFalse(vm.CanDispenseCoins(0.10m));
        }

        [TestMethod]
        public void WhenChangeIsMade_TheAmountInsertedReturnsToZero()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new List<CoinTube>
                {
                    new CoinTube(TestDefinitions.UsaNickel, 10),
                },
            };

            vm.AcceptCoin(TestDefinitions.UsaNickel.MassGrams, TestDefinitions.UsaNickel.DiameterMillimeters);
            vm.AcceptCoin(TestDefinitions.UsaNickel.MassGrams, TestDefinitions.UsaNickel.DiameterMillimeters);

            vm.DispenseCoins(vm.AmountInserted);

            Assert.AreEqual(vm.AmountInserted, 0m);
        }
    }
}
