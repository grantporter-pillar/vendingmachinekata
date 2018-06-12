using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata.Library;

namespace VendingMachineKata.Tests
{
    [TestClass]
    public class CoinChangerTests
    {
        // In the real vending machine implementation, these are stored in a configuration.  
        // For the unit test, they are static variables
        static readonly CoinSpecification UsaPenny =   new CoinSpecification(2.500, 19.05, 0.01m);
        static readonly CoinSpecification UsaNickel =  new CoinSpecification(5.000, 21.21, 0.05m);
        static readonly CoinSpecification UsaDime =    new CoinSpecification(2.268, 17.91, 0.10m);
        static readonly CoinSpecification UsaQuarter = new CoinSpecification(5.670, 24.26, 0.25m);

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
        public void WhenAnUnacceptableCoinIsInserted_CoinIsNotIdentified()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new Dictionary<CoinSpecification, int>
                {
                    { UsaNickel, 0 },
                },
            };

            Assert.IsNull(vm.IdentifyCoin(UsaPenny.MassGrams, UsaPenny.DiameterMillimeters));
        }

        [TestMethod]
        public void WhenAnAcceptableCoinIsInserted_CoinIsIdentified()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new Dictionary<CoinSpecification, int>
                {
                    { UsaNickel, 0 },
                },
            };

            Assert.IsNotNull(vm.IdentifyCoin(UsaNickel.MassGrams, UsaNickel.DiameterMillimeters));
        }

        [TestMethod]
        public void WhenAnAcceptableCoinIsInserted_CoinIsCorrectlyIdentified()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new Dictionary<CoinSpecification, int>
                {
                    { UsaNickel, 0 },
                    { UsaDime, 0 },
                    { UsaQuarter, 0 },
                },
            };

            Assert.AreEqual(vm.IdentifyCoin(UsaNickel.MassGrams, UsaNickel.DiameterMillimeters), UsaNickel);
            Assert.AreEqual(vm.IdentifyCoin(UsaDime.MassGrams, UsaDime.DiameterMillimeters), UsaDime);
            Assert.AreEqual(vm.IdentifyCoin(UsaQuarter.MassGrams, UsaQuarter.DiameterMillimeters), UsaQuarter);
        }

        [TestMethod]
        public void WhenAnAcceptableCoinIsInserted_AmountInsertedIncreases()
        {
            var vm = new VendingMachine()
            {
                AmountInserted = 0m,
                CoinTubes = new Dictionary<CoinSpecification, int>
                {
                    { UsaNickel, 0 },
                },
            };

            vm.AcceptCoin(UsaNickel.MassGrams, UsaNickel.DiameterMillimeters);

            Assert.IsTrue(vm.AmountInserted > 0m);
        }

        [TestMethod]
        public void WhenAnAcceptableCoinIsInserted_TheCoinInventoryIncreases()
        {
            var vm = new VendingMachine()
            {
                CoinTubes = new Dictionary<CoinSpecification, int>
                {
                    { UsaNickel, 0 },
                },
            };

            vm.AcceptCoin(UsaNickel.MassGrams, UsaNickel.DiameterMillimeters);

            Assert.IsTrue(vm.CoinTubes[UsaNickel] > 0);
        }
    }
}
