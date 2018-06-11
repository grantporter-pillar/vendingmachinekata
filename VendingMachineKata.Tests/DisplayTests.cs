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
            Equals(new VendingMachine().GetDisplay(), @"INSERT COIN");
        }
    }
}
